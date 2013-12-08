
namespace Nircbot.Modules.Weather.Service
{
    using System.Collections.Generic;

    using Nircbot.Core.Irc.Messages;

    /// <summary>
    /// The WeatherProvider interface.
    /// </summary>
    public interface IWeatherProvider
    {
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
        IEnumerable<IResponse> GetWeather(IEnumerable<string> targets, MessageFormat messageFormat, MessageType messageType, string message, Dictionary<string, string> arguments);
    }
}
