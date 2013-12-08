// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleUrlShortner.cs" company="Patrick Magee">
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
//   The google url shortner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrlShortener.Services.Google
{
    using System;
    using System.Net.Http;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Web.Script.Serialization;

    using Nircbot.Common.Extensions;

    /// <summary>
    /// The google url shortner.
    /// </summary>
    public sealed class GoogleUrlShortner : IUrlShortenerProvider
    {
        /// <summary>
        /// The base url.
        /// </summary>
        private const string Url = "https://www.googleapis.com/urlshortener/v1/url?key={0}";

        /// <summary>
        /// The api key.
        /// </summary>
        private readonly string apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleUrlShortner" /> class.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="trigger">The trigger.</param>
        public GoogleUrlShortner(string apiKey, string trigger)
        {
            this.apiKey = apiKey;
            this.Trigger = trigger;
        }

        /// <summary>
        /// Gets or sets the trigger.
        /// </summary>
        /// <value>
        /// The trigger.
        /// </value>
        public string Trigger { get; set; }

        /// <summary>
        /// Shortens the given url.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// The shorter url.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string Shorten(string url)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri(Url.FormatWith(this.apiKey));
                var serializer = new JavaScriptSerializer();
                var content = new StringContent(serializer.Serialize(new { longUrl = url }), Encoding.UTF8, "application/json");

                var httpResponseMessage = client.PostAsync(uri, content).Result;
                var stream = httpResponseMessage.Content.ReadAsStreamAsync().Result;

                using (stream)
                {
                    var root = new DataContractJsonSerializer(typeof(Response)).ReadObject(stream) as Response;
                    return root.Id;
                }
            }
        }
    }
}