// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWundergroundResponse.cs" company="Patrick Magee">
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
//   The WundergroundResponse interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    #region

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The WundergroundResponse interface.
    /// </summary>
    public interface IWundergroundResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets the current observation.
        /// </summary>
        /// <value>
        /// The current observation.
        /// </value>
        ICurrentObservation CurrentObservation { get; }

        /// <summary>
        /// Gets the forecast.
        /// </summary>
        /// <value>
        /// The forecast.
        /// </value>
        IForecast Forecast { get; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        ILocation Location { get; }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        IResponse Response { get; }

        /// <summary>
        /// Gets the webcams.
        /// </summary>
        /// <value>
        /// The webcams.
        /// </value>
        IEnumerable<IWebcam> Webcams { get; }

        #endregion
    }
}
