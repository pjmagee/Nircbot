﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherFixture.cs" company="Patrick Magee">
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
//   Defines the WeatherFixture type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Nircbot.Core.Irc.Messages;
    using Nircbot.Modules.Weather.Wunderground;

    /// <summary>
    /// The weather fixture.
    /// </summary>
    [TestClass]
    public class WeatherFixture
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void TestMethod()
        {
            var weatherProvider = new WundergroundWeatherProvider("ed8dd9f3c5f6df2a");

            var dictionary = new Dictionary<string, string>();
            dictionary.Add("postcode", "SM5 2HT");
            dictionary.Add("conditions", null);
            dictionary.Add("forecast", null);
            dictionary.Add("webcams", null);

            IEnumerable<IResponse> responses = weatherProvider.GetWeather(new[] { "Peej" }, MessageFormat.Message, MessageType.Both, string.Empty, dictionary);

        }
    }
}
