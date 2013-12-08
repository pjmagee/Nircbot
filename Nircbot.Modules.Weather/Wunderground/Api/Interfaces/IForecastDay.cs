// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IForecastDay.cs" company="Patrick Magee">
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
//   The ForecastDay interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    /// <summary>
    /// The ForecastDay interface.
    /// </summary>
    public interface IForecastDay
    {
        #region Public Properties

        /// <summary>
        /// Gets the forecast text.
        /// </summary>
        /// <value>
        /// The forecast text.
        /// </value>
        string ForecastText { get; }

        /// <summary>
        /// Gets the forecast text metric.
        /// </summary>
        /// <value>
        /// The forecast text metric.
        /// </value>
        string ForecastTextMetric { get; }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        string Icon { get; }

        /// <summary>
        /// Gets the icon URL.
        /// </summary>
        /// <value>
        /// The icon URL.
        /// </value>
        string IconUrl { get; }

        /// <summary>
        /// Gets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        int Period { get; }

        /// <summary>
        /// Gets a value indicating whether [pop].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pop]; otherwise, <c>false</c>.
        /// </value>
        bool Pop { get; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; }

        #endregion
    }
}