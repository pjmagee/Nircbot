// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WundergroundResponse.cs" company="Patrick Magee">
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
//   The wunderground response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The wunderground response.
    /// </summary>
    [DataContract]
    public class WundergroundResponse : IWundergroundResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the current observation.
        /// </summary>
        /// <value>
        /// The current observation.
        /// </value>
        [DataMember(Name = "current_observation")]
        public CurrentObservation CurrentObservation { get; set; }

        /// <summary>
        /// Gets or sets the forecast.
        /// </summary>
        /// <value>
        /// The forecast.
        /// </value>
        [DataMember(Name = "forecast")]
        public Forecast Forecast { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [DataMember(Name = "location")]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        [DataMember(Name = "response")]
        public Response Response { get; set; }

        /// <summary>
        /// Gets or sets the webcams.
        /// </summary>
        /// <value>
        /// The webcams.
        /// </value>
        [DataMember(Name = "webcams")]
        public List<Webcam> Webcams { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the current observation.
        /// </summary>
        /// <value>
        /// The current observation.
        /// </value>
        [IgnoreDataMember]
        ICurrentObservation IWundergroundResponse.CurrentObservation
        {
            get
            {
                return this.CurrentObservation;
            }
        }

        /// <summary>
        /// Gets the forecast.
        /// </summary>
        /// <value>
        /// The forecast.
        /// </value>
        [IgnoreDataMember]
        IForecast IWundergroundResponse.Forecast
        {
            get
            {
                return this.Forecast;
            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [IgnoreDataMember]
        ILocation IWundergroundResponse.Location
        {
            get
            {
                return this.Location;
            }
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        [IgnoreDataMember]
        IResponse IWundergroundResponse.Response
        {
            get
            {
                return this.Response;
            }
        }

        /// <summary>
        /// Gets the webcams.
        /// </summary>
        /// <value>
        /// The webcams.
        /// </value>
        IEnumerable<IWebcam> IWundergroundResponse.Webcams
        {
            get
            {
                return this.Webcams;
            }
        }

        #endregion
    }
}