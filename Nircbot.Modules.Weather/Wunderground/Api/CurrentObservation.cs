// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentObservation.cs" company="Patrick Magee">
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
//   The current observation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The current observation.
    /// </summary>
    [DataContract(Name = "current_observation")]
    public class CurrentObservation : ICurrentObservation
    {
        #region Public Properties

        /// <summary>
        /// Gets the dew point.
        /// </summary>
        /// <value>
        /// The dew point.
        /// </value>
        [DataMember(Name = "dewpoint_string")]
        public string DewPoint { get; set; }

        /// <summary>
        /// Gets or sets the display location.
        /// </summary>
        [DataMember(Name = "display_location")]
        public DisplayLocation DisplayLocation { get; set; }

        /// <summary>
        /// Gets the feels like.
        /// </summary>
        /// <value>
        /// The feels like.
        /// </value>
        [DataMember(Name = "feelslike_string")]
        public string FeelsLike { get; set; }

        /// <summary>
        /// Gets the forecast URL.
        /// </summary>
        /// <value>
        /// The forecast URL.
        /// </value>
        [DataMember(Name = "forecast_url")]
        public string ForecastUrl { get; set; }

        /// <summary>
        /// Gets the history URL.
        /// </summary>
        /// <value>
        /// The history URL.
        /// </value>
        [DataMember(Name = "history_url")]
        public string HistoryUrl { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        [DataMember(Name = "image")]
        public ImageData Image { get; set; }

        /// <summary>
        /// Gets or sets the local time rf C822.
        /// </summary>
        /// <value>
        /// The local time rf C822.
        /// </value>
        [DataMember(Name = "local_time_rfc822")]
        public string LocalTimeRFC822 { get; set; }

        /// <summary>
        /// Gets the ob URL.
        /// </summary>
        /// <value>
        /// The ob URL.
        /// </value>
        [DataMember(Name = "ob_url")]
        public string ObUrl { get; private set; }

        /// <summary>
        /// Gets or sets the observation location.
        /// </summary>
        /// <value>
        /// The observation location.
        /// </value>
        [DataMember(Name = "observation_location")]
        public ObservationLocation ObservationLocation { get; set; }

        /// <summary>
        /// Gets the observation time.
        /// </summary>
        /// <value>
        /// The observation time.
        /// </value>
        [DataMember(Name = "observation_time")]
        public string ObservationTime { get; set; }

        /// <summary>
        /// Gets the observation time.
        /// </summary>
        /// <value>
        /// The observation time.
        /// </value>
        [DataMember(Name = "observation_time_rfc822")]
        public string ObservationTimeRfc822 { get; set; }

        /// <summary>
        /// Gets the relative humidity.
        /// </summary>
        /// <value>
        /// The relative humidity.
        /// </value>
        [DataMember(Name = "relative_humidity")]
        public string RelativeHumidity { get; set; }

        /// <summary>
        /// Gets or sets the station identifier.
        /// </summary>
        /// <value>
        /// The station identifier.
        /// </value>
        [DataMember(Name = "station_id")]
        public string StationId { get; set; }

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        [DataMember(Name = "temperature_string")]
        public string Temperature { get; set; }

        /// <summary>
        /// Gets the weather.
        /// </summary>
        /// <value>
        /// The weather.
        /// </value>
        [DataMember(Name = "weather")]
        public string Weather { get; set; }

        /// <summary>
        /// Gets or sets the wind.
        /// </summary>
        /// <value>
        /// The wind.
        /// </value>
        [DataMember(Name = "wind_string")]
        public string Wind { get; set; }

        /// <summary>
        /// Gets the wind chill.
        /// </summary>
        /// <value>
        /// The wind chill.
        /// </value>
        [DataMember(Name = "windchill_string")]
        public string WindChill { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the display location.
        /// </summary>
        /// <value>
        /// The display location.
        /// </value>
        [IgnoreDataMember]
        IDisplayLocation ICurrentObservation.DisplayLocation
        {
            get
            {
                return this.DisplayLocation;
            }
        }

        /// <summary>
        /// Gets the feels like.
        /// </summary>
        /// <value>
        /// The feels like.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.FeelsLike
        {
            get
            {
                return this.FeelsLike;
            }
        }

        /// <summary>
        /// Gets the forecast URL.
        /// </summary>
        /// <value>
        /// The forecast URL.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.ForecastUrl
        {
            get
            {
                return this.ForecastUrl;
            }
        }

        /// <summary>
        /// Gets the history URL.
        /// </summary>
        /// <value>
        /// The history URL.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.HistoryUrl
        {
            get
            {
                return this.HistoryUrl;
            }
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        [IgnoreDataMember]
        IImage ICurrentObservation.Image
        {
            get
            {
                return this.Image;
            }
        }

        /// <summary>
        /// Gets the local time rf c 822.
        /// </summary>
        /// <value>
        /// The local time rf C822.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.LocalTimeRFC822
        {
            get
            {
                return this.LocalTimeRFC822;
            }
        }

        /// <summary>
        /// Gets the ob URL.
        /// </summary>
        /// <value>
        /// The ob URL.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.ObUrl
        {
            get
            {
                return this.ObUrl;
            }
        }

        /// <summary>
        /// Gets the observation location.
        /// </summary>
        /// <value>
        /// The observation location.
        /// </value>
        [IgnoreDataMember]
        IObservationLocation ICurrentObservation.ObservationLocation
        {
            get
            {
                return this.ObservationLocation;
            }
        }

        /// <summary>
        /// Gets the observation time.
        /// </summary>
        /// <value>
        /// The observation time.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.ObservationTime
        {
            get
            {
                return this.ObservationTime;
            }
        }

        /// <summary>
        /// Gets the observation time rfc822.
        /// </summary>
        /// <value>
        /// The observation time rfC 822.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.ObservationTimeRFC822
        {
            get
            {
                return this.ObservationTimeRfc822;
            }
        }

        /// <summary>
        /// Gets the station id.
        /// </summary>
        /// <value>
        /// The station identifier.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.StationId
        {
            get
            {
                return this.StationId;
            }
        }

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.Temperature
        {
            get
            {
                return this.Temperature;
            }
        }

        /// <summary>
        /// Gets or sets the wind.
        /// </summary>
        /// <value>
        /// The wind.
        /// </value>
        [IgnoreDataMember]
        string ICurrentObservation.Wind
        {
            get
            {
                return this.Wind;
            }
        }

        #endregion
    }
}