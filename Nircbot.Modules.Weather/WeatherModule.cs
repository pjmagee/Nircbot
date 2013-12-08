// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherModule.cs" company="Patrick Magee">
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
//   The weather module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather
{
    using System.Collections.Generic;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;
    using Nircbot.Modules.Weather.Service;

    /// <summary>
    /// The weather module.
    /// </summary>
    public class WeatherModule : BaseModule
    {
        /// <summary>
        /// The weather provider
        /// </summary>
        private readonly IWeatherProvider weatherProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherModule" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="weatherProvider">The weather provider.</param>
        public WeatherModule(IIrcClient ircClient, IWeatherProvider weatherProvider) : base(ircClient)
        {
            this.weatherProvider = weatherProvider;
        }

        /// <summary>
        /// Registers the commands.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Command}" />.
        /// </returns>
        public override IEnumerable<Command> RegisterCommands()
        {
            var weatherCommand = new Command("!weather", GetWeather)
            {
                LevelRequired = AccessLevel.None,
                Description = "Provides access to detailed up to date weather information",
                Accepts = MessageType.Both,
                Examples = new []
                {
                    "!weather --forecast --conditions --zipcode 310310 --country UK --City London",
                    "!weather --conditions --postcode sm5 2ht",
                    "!weather sm5 2ht",
                    "!weather --lang FR --postcode sm5 2ht",
                }
            };

            weatherCommand.CreateArgument("forecast");
            weatherCommand.CreateArgument("conditions");
            weatherCommand.CreateArgument("postcode");
            weatherCommand.CreateArgument("country");
            weatherCommand.CreateArgument("city");
            weatherCommand.CreateArgument("webcams");
            weatherCommand.CreateArgument("lang");

            return new[] { weatherCommand };
        }

        /// <summary>
        /// Gets the weather.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void GetWeather(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments)
        {
            var targets = new[] { channel ?? user.Nick };
            IEnumerable<IResponse> weatherResponses = this.weatherProvider.GetWeather(targets, messageFormat, messageType, message, arguments);

            foreach (var weatherResponse in weatherResponses)
            {
                this.SendResponse(weatherResponse);
            }
        }
    }
}
