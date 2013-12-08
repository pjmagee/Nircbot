// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFeatures.cs" company="Patrick Magee">
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
//   The Features interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    /// <summary>
    /// The Features interface.
    /// </summary>
    public interface IFeatures
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether [conditions].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [conditions]; otherwise, <c>false</c>.
        /// </value>
        bool Conditions { get; }

        /// <summary>
        /// Gets a value indicating whether [forecast].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [forecast]; otherwise, <c>false</c>.
        /// </value>
        bool Forecast { get; }

        /// <summary>
        /// Gets a value indicating whether [geo lookup].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [geo lookup]; otherwise, <c>false</c>.
        /// </value>
        bool GeoLookup { get; }

        /// <summary>
        /// Gets a value indicating whether [webcams].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [webcams]; otherwise, <c>false</c>.
        /// </value>
        bool Webcams { get; }

        /// <summary>
        /// Gets or sets the alerts.
        /// </summary>
        /// <value>
        /// The alerts.
        /// </value>
        bool Alerts { get; }

        /// <summary>
        /// Gets or sets the almanac.
        /// </summary>
        /// <value>
        /// The almanac.
        /// </value>
        bool Almanac { get; }

        /// <summary>
        /// Gets or sets the astronomy.
        /// </summary>
        /// <value>
        /// The astronomy.
        /// </value>
        bool Astronomy { get; }

        /// <summary>
        /// Gets or sets the current hurricane.
        /// </summary>
        /// <value>
        /// The current hurricane.
        /// </value>
        bool CurrentHurricane { get; }

        /// <summary>
        /// Gets or sets the forecast10 day.
        /// </summary>
        /// <value>
        /// The forecast10 day.
        /// </value>
        bool Forecast10Day { get; }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>
        /// The history.
        /// </value>
        bool History { get; }

        /// <summary>
        /// Gets or sets the hourly.
        /// </summary>
        /// <value>
        /// The hourly.
        /// </value>
        bool Hourly { get; }

        /// <summary>
        /// Gets or sets the hourly10 day.
        /// </summary>
        /// <value>
        /// The hourly10 day.
        /// </value>
        bool Hourly10Day { get; }

        /// <summary>
        /// Gets or sets the planner.
        /// </summary>
        /// <value>
        /// The planner.
        /// </value>
        bool Planner { get; }

        /// <summary>
        /// Gets or sets the raw tide.
        /// </summary>
        /// <value>
        /// The raw tide.
        /// </value>
        bool RawTide { get; }

        /// <summary>
        /// Gets or sets the tide.
        /// </summary>
        /// <value>
        /// The tide.
        /// </value>
        bool Tide { get; }

        /// <summary>
        /// Gets or sets the yesterday.
        /// </summary>
        /// <value>
        /// The yesterday.
        /// </value>
        bool Yesterday { get; }

        #endregion
    }
}