// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICurrentObservation.cs" company="Patrick Magee">
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
//   The CurrentObservation interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    /// <summary>
    /// The CurrentObservation interface.
    /// </summary>
    public interface ICurrentObservation
    {
        #region Public Properties

        /// <summary>
        /// Gets the dew point.
        /// </summary>
        /// <value>
        /// The dew point.
        /// </value>
        string DewPoint { get; }

        /// <summary>
        /// Gets the display location.
        /// </summary>
        /// <value>
        /// The display location.
        /// </value>
        IDisplayLocation DisplayLocation { get; }

        /// <summary>
        /// Gets the feels like.
        /// </summary>
        /// <value>
        /// The feels like.
        /// </value>
        string FeelsLike { get; }

        /// <summary>
        /// Gets the forecast URL.
        /// </summary>
        /// <value>
        /// The forecast URL.
        /// </value>
        string ForecastUrl { get; }

        /// <summary>
        /// Gets the history URL.
        /// </summary>
        /// <value>
        /// The history URL.
        /// </value>
        string HistoryUrl { get; }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        IImage Image { get; }

        /// <summary>
        /// Gets the local time rf C822.
        /// </summary>
        /// <value>
        /// The local time rf C822.
        /// </value>
        string LocalTimeRFC822 { get; }

        /// <summary>
        /// Gets the ob URL.
        /// </summary>
        /// <value>
        /// The ob URL.
        /// </value>
        string ObUrl { get; }

        /// <summary>
        /// Gets the observation location.
        /// </summary>
        /// <value>
        /// The observation location.
        /// </value>
        IObservationLocation ObservationLocation { get; }

        /// <summary>
        /// Gets the observation time.
        /// </summary>
        /// <value>
        /// The observation time.
        /// </value>
        string ObservationTime { get; }

        /// <summary>
        /// Gets the observation time rf C822.
        /// </summary>
        /// <value>
        /// The observation time rf C822.
        /// </value>
        string ObservationTimeRFC822 { get; }

        /// <summary>
        /// Gets the relative humidity.
        /// </summary>
        /// <value>
        /// The relative humidity.
        /// </value>
        string RelativeHumidity { get; }

        /// <summary>
        /// Gets the station identifier.
        /// </summary>
        /// <value>
        /// The station identifier.
        /// </value>
        string StationId { get; }

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        string Temperature { get; }

        /// <summary>
        /// Gets the weather.
        /// </summary>
        /// <value>
        /// The weather.
        /// </value>
        string Weather { get; }

        /// <summary>
        /// Gets or sets the wind.
        /// </summary>
        /// <value>
        /// The wind.
        /// </value>
        string Wind { get; }

        /// <summary>
        /// Gets the wind chill.
        /// </summary>
        /// <value>
        /// The wind chill.
        /// </value>
        string WindChill { get; }

        #endregion
    }
}