// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseWeatherProvider.cs" company="Patrick Magee">
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
//   The weather provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Service
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using Nircbot.Core.Irc.Messages;

    /// <summary>
    /// The weather provider.
    /// </summary>
    public abstract class BaseWeatherProvider : IWeatherProvider
    {
        /// <summary>
        /// The post code coordinates
        /// </summary>
        protected static readonly Dictionary<string, Tuple<string, string>> PostCodeCoordinates;

        /// <summary>
        /// Initializes static members of the <see cref="BaseWeatherProvider"/> class. 
        /// </summary>
        static BaseWeatherProvider()
        {
            PostCodeCoordinates = File.ReadAllLines(@"postcodes.csv").Select(line => line.Split(',')).ToDictionary(line => line[0], line => Tuple.Create(line[1], line[2]));
            Trace.TraceInformation("Post Codes loaded.");
        }

        /// <summary>
        /// The API key
        /// </summary>
        protected readonly string ApiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseWeatherProvider"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        protected BaseWeatherProvider(string apiKey)
        {
            this.ApiKey = apiKey;
        }

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
        public abstract IEnumerable<IResponse> GetWeather(IEnumerable<string> targets, MessageFormat messageFormat, MessageType messageType, string message, Dictionary<string, string> arguments);
    }
}