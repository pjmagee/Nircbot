// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WundergroundWeatherProvider.cs" company="Patrick Magee">
//   Copyright © 2013 Patrick Magee
//   
//   This program is free software: you can redistribute it and/or modify it
//   under the +terms of the GNU General Public License as published by 
//   the Free Software Foundation, either version 3 of the License, 
//   or (at your option) any later version.
//   
//   This program is distributed in the hope that it will be useful, 
//   but WITHOUT ANY WARRANTY; without even the implied warranty of 
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
//   GNU General Public License for more details.
//   
//   You should have received a copy of the GNU General Public License
//   along with this program. If not, see http://www.gnu.org/licenses/.
// </copyright>
// <summary>
//   The wunderground weather provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Caching;
    using System.Runtime.Serialization.Json;
    using System.Text;

    using Nircbot.Common.Extensions;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Modules.Weather.Service;
    using Nircbot.Modules.Weather.Wunderground.Api;
    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    using IResponse = Nircbot.Core.Irc.Messages.IResponse;
    using Response = Nircbot.Core.Irc.Messages.Response;

    #endregion

    /// <summary>
    /// The wunderground weather provider.
    /// </summary>
    public class WundergroundWeatherProvider : BaseWeatherProvider
    {
        #region Constants

        /// <summary>
        /// The url.
        /// </summary>
        private const string Url = @"http://api.wunderground.com/api/{0}/{1}/{2}/q/{3}.json";

        #endregion

        #region Fields

        /// <summary>
        /// The cache of Responses.
        /// </summary>
        private static readonly ObjectCache Cache;

        /// <summary>
        /// The cache.
        /// </summary>
        private ObjectCache cache;

        /// <summary>
        /// The features
        /// </summary>
        private readonly List<string> features;

        /// <summary>
        /// The settings
        /// </summary>
        private readonly List<string> settings;

        /// <summary>
        /// The query
        /// </summary>
        private string query;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WundergroundWeatherProvider" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public WundergroundWeatherProvider(string apiKey)
            : base(apiKey)
        {
            this.features = new List<string>();
            this.settings = new List<string>();
            this.query = string.Empty;
            this.cache = Cache;
        }

        /// <summary>
        /// Initializes static members of the <see cref="WundergroundWeatherProvider" /> class.
        /// </summary>
        static WundergroundWeatherProvider()
        {
            Cache = MemoryCache.Default;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the weather.
        /// </summary>
        /// <param name="targets">The targets.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>
        /// Responses to send back.
        /// </returns>
        public override IEnumerable<IResponse> GetWeather(IEnumerable<string> targets, MessageFormat messageFormat, MessageType messageType, string message, Dictionary<string, string> arguments)
        {
            if (this.ParseArguments(arguments))
            {
                return this.BuildResponses(targets, messageFormat, messageType);
            }

            return Enumerable.Empty<IResponse>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sends the conditions.
        /// </summary>
        /// <param name="targets">The targets.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="currentObservation">The current observation.</param>
        /// <returns>
        /// The <see cref="IEnumerable" />.
        /// </returns>
        private static IEnumerable<IResponse> CreateConditionsResponse(IEnumerable<string> targets, MessageFormat messageFormat, MessageType messageType, ICurrentObservation currentObservation)
        {
            try
            {
                var conditions = "{0}. {1}. {2}, feels like {2}, wind chill {3}.".FormatWith(
                    currentObservation.DisplayLocation.Full,
                    currentObservation.ObservationTime,
                    currentObservation.Temperature,
                    currentObservation.FeelsLike,
                    currentObservation.Wind);

                var response = new Response(conditions, targets, messageFormat, messageType);

                return new[] { response };
            }
            catch (Exception e)
            {
                Trace.TraceError(e.TargetSite.Name);
                Trace.TraceError(e.Message);
            }

            return Enumerable.Empty<IResponse>();
        }

        /// <summary>
        /// Sends the forecast.
        /// </summary>
        /// <param name="targets">The targets.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="forecast">The forecast.</param>
        /// <returns>
        /// The forecasts.
        /// </returns>
        private static IEnumerable<IResponse> CreateForecastResponses(IEnumerable<string> targets, MessageFormat messageFormat, MessageType messageType, IForecast forecast)
        {
            try
            {
                var responses = new List<IResponse>();

                foreach (var day in forecast.TextualForecast.ForecastDays)
                {
                    responses.Add(new Response(day.ForecastTextMetric, targets, messageFormat, messageType));
                }

                return responses;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.TargetSite.Name);
                Trace.TraceError(e.Message);
            }

            return Enumerable.Empty<IResponse>();
        }

        /// <summary>
        /// Adds the feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        private void AddFeature(string feature)
        {
            if (!this.features.Contains(feature))
            {
                this.features.Add(feature);
            }
        }

        /// <summary>
        /// Adds the post code by latitude and longitude.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        private void AddPostCodeByLatitudeAndLongitude(Dictionary<string, string> arguments)
        {
            var postCode = arguments["postcode"].ToUpper();

            while (postCode.Contains(" "))
            {
                postCode = postCode.Split(' ')[0];
            }

            if (PostCodeCoordinates.ContainsKey(postCode))
            {
                Tuple<string, string> coordinates = PostCodeCoordinates[postCode];
                var latitudeLongitude = string.Format("{0},{1}", coordinates.Item1, coordinates.Item2).Trim();
                this.AddQuery(latitudeLongitude);
            }
        }

        /// <summary>
        /// Adds the query.
        /// </summary>
        /// <param name="query">The query.</param>
        private void AddQuery(string query)
        {
            this.query += "/{0}".FormatWith(query);
        }

        /// <summary>
        /// Adds the setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        private void AddSetting(string setting)
        {
            if (!setting.Contains(setting))
            {
                this.settings.Add(setting);
            }
        }

        /// <summary>
        /// Builds the responses to send.
        /// </summary>
        /// <param name="targets">The targets.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <returns>
        /// The <see cref="IEnumerable" />.
        /// </returns>
        private IEnumerable<IResponse> BuildResponses(IEnumerable<string> targets, MessageFormat messageFormat, MessageType messageType)
        {
            var receivers = targets.ToArray();
            var wundergroundResponse = this.ExecuteRequest();
            var responses = new List<IResponse>();

            try
            {
                if (wundergroundResponse.Response.Features.Conditions)
                {
                    responses.AddRange(CreateConditionsResponse(receivers, messageFormat, messageType, wundergroundResponse.CurrentObservation));
                }

                if (wundergroundResponse.Response.Features.Forecast)
                {
                    responses.AddRange(CreateForecastResponses(receivers, messageFormat, messageType, wundergroundResponse.Forecast));
                }

                return responses;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.TargetSite.Name);
                Trace.TraceError(e.Message);
            }

            return Enumerable.Empty<IResponse>();
        }

        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <returns>
        /// The response from Wunderground.
        /// </returns>
        private IWundergroundResponse ExecuteRequest()
        {
            try
            {
                var url = Url.FormatWith(this.ApiKey, string.Join("/", this.features), string.Join("/", this.settings), this.query);
                var response = this.GetOrCacheResponse(url);

                return response;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.TargetSite.Name);
                Trace.TraceError(e.Message);
            }

            return default(IWundergroundResponse);
        }

        /// <summary>
        /// Gets a cached response or retrieves new results from Wunderground.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private IWundergroundResponse GetOrCacheResponse(string url)
        {
            if (this.cache.Contains(url))
            {
                return this.cache[url] as IWundergroundResponse;
            }

            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);

                var serializer = new DataContractJsonSerializer(typeof(WundergroundResponse));

                var wundergroundResponse = serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(json))) as IWundergroundResponse;

                CacheItem item = new CacheItem(url, wundergroundResponse);
                CacheItemPolicy policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(30), RemovedCallback = this.RemovedCallback };
                this.cache.Add(item, policy);
            }

            this.ClearRequest();

            return cache[url] as IWundergroundResponse;
        }

        /// <summary>
        /// Clears the request.
        /// </summary>
        private void ClearRequest()
        {
            this.features.Clear();
            this.settings.Clear();
            this.query = string.Empty;
        }

        /// <summary>
        /// Parses the arguments.
        /// </summary>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        /// <returns>
        /// True if arguments were present, otherwise false.
        /// </returns>
        private bool ParseArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("forecast"))
            {
                this.AddFeature("forecast");
            }

            if (arguments.ContainsKey("conditions"))
            {
                this.AddFeature("conditions");
            }

            if (arguments.ContainsKey("webcams"))
            {
                this.AddFeature("webcams");
            }

            if (arguments.ContainsKey("lang"))
            {
                var language = "lang:{0}".FormatWith(arguments["lang"]);
                this.AddSetting(language);
            }

            if (arguments.ContainsKey("postcode"))
            {
                this.AddPostCodeByLatitudeAndLongitude(arguments);
            }
            else if (arguments.ContainsKey("zipcode"))
            {
                this.AddQuery(arguments["zipcode"]);
            }

            return arguments.Any();
        }

        /// <summary>
        /// Removes the feature.
        /// </summary>
        /// <param name="feature">
        /// The feature.
        /// </param>
        private void RemoveFeature(string feature)
        {
            this.features.Remove(feature);
        }

        /// <summary>
        /// Removes the setting.
        /// </summary>
        /// <param name="setting">
        /// The setting.
        /// </param>
        private void RemoveSetting(string setting)
        {
            this.settings.Remove(setting);
        }

        /// <summary>
        /// Information about a weather result removed from cache.
        /// </summary>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        private void RemovedCallback(CacheEntryRemovedArguments arguments)
        {
            Trace.TraceInformation("Removing weather request from cache: {0}", arguments.CacheItem.Key);
        }

        #endregion
    }
}