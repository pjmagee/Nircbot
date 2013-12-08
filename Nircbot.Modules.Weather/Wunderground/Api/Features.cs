// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Features.cs" company="Patrick Magee">
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
//   The features.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The features.
    /// </summary>
    [DataContract(Name = "features")]
    public class Features : IFeatures
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the alerts.
        /// </summary>
        /// <value>
        /// The alerts.
        /// </value>
        [DataMember(Name = "alerts", IsRequired = false)]
        public int? Alerts { get; set; }

        /// <summary>
        /// Gets or sets the almanac.
        /// </summary>
        /// <value>
        /// The almanac.
        /// </value>
        [DataMember(Name = "almanac", IsRequired = false)]
        public int? Almanac { get; set; }



        /// <summary>
        /// Gets or sets the astronomy.
        /// </summary>
        /// <value>
        /// The astronomy.
        /// </value>
        [DataMember(Name = "astronomy", IsRequired = false)]
        public int? Astronomy { get; set; }

        /// <summary>
        /// Gets a value indicating whether [conditions].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [conditions]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "conditions", IsRequired = false)]
        public int? Conditions { get; set; }

        /// <summary>
        /// Gets or sets the current hurricane.
        /// </summary>
        /// <value>
        /// The current hurricane.
        /// </value>
        [DataMember(Name = "currenthurricane", IsRequired = false)]
        public int? CurrentHurricane { get; set; }

        /// <summary>
        /// Gets a value indicating whether [forecast].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [forecast]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "forecast", IsRequired = false)]
        public int? Forecast { get; set; }

        /// <summary>
        /// Gets or sets the forecast10 day.
        /// </summary>
        /// <value>
        /// The forecast10 day.
        /// </value>
        [DataMember(Name = "forecast10day", IsRequired = false)]
        public int? Forecast10Day { get; set; }

        /// <summary>
        /// Gets a value indicating whether [geo lookup].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [geo lookup]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "geolookup", IsRequired = false)]
        public int? GeoLookup { get; set; }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>
        /// The history.
        /// </value>
        [DataMember(Name = "history", IsRequired = false)]
        public int? History { get; set; }

        /// <summary>
        /// Gets or sets the hourly.
        /// </summary>
        /// <value>
        /// The hourly.
        /// </value>
        [DataMember(Name = "hourly", IsRequired = false)]
        public int? Hourly { get; set; }

        /// <summary>
        /// Gets or sets the hourly10 day.
        /// </summary>
        /// <value>
        /// The hourly10 day.
        /// </value>
        [DataMember(Name = "hourly10day", IsRequired = false)]
        public int? Hourly10Day { get; set; }

        /// <summary>
        /// Gets or sets the planner.
        /// </summary>
        /// <value>
        /// The planner.
        /// </value>
        [DataMember(Name = "planner", IsRequired = false)]
        public int? Planner { get; set; }

        /// <summary>
        /// Gets or sets the raw tide.
        /// </summary>
        /// <value>
        /// The raw tide.
        /// </value>
        [DataMember(Name = "rawtide", IsRequired = false)]
        public int? RawTide { get; set; }

        /// <summary>
        /// Gets or sets the tide.
        /// </summary>
        /// <value>
        /// The tide.
        /// </value>
        [DataMember(Name = "tide", IsRequired = false)]
        public int? Tide { get; set; }

        /// <summary>
        /// Gets or sets the webcams.
        /// </summary>
        /// <value>
        /// The webcams.
        /// </value>
        [DataMember(Name = "webcams", IsRequired = false)]
        public int? Webcams { get; set; }

        /// <summary>
        /// Gets or sets the yesterday.
        /// </summary>
        /// <value>
        /// The yesterday.
        /// </value>
        [DataMember(Name = "yesterday", IsRequired = false)]
        public int? Yesterday { get; set; }

        #endregion

        #region Explicit Interface Properties


        /// <summary>
        /// Gets or sets the tide.
        /// </summary>
        /// <value>
        /// The tide.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.Astronomy
        {
            get
            {
                return this.Astronomy.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the planner.
        /// </summary>
        /// <value>
        /// The planner.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.Planner
        {
            get
            {
                return this.Planner.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the almanac.
        /// </summary>
        /// <value>
        /// The almanac.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.Almanac
        {
            get
            {
                return this.Almanac.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the forecast10 day.
        /// </summary>
        /// <value>
        /// The forecast10 day.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.Forecast10Day
        {
            get
            {
                return this.Forecast10Day.HasValue;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [conditions].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [conditions]; otherwise, <c>false</c>.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.Conditions
        {
            get
            {
                return this.Conditions.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the alerts.
        /// </summary>
        /// <value>
        /// The alerts.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.Alerts
        {
            get
            {
                return this.Alerts.HasValue;
            }
        }


        /// <summary>
        /// Gets or sets the hourly.
        /// </summary>
        /// <value>
        /// The hourly.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.Hourly
        {
            get
            {
                return this.Hourly.HasValue;
            }
        }



        /// <summary>
        /// Gets or sets the current hurricane.
        /// </summary>
        /// <value>
        /// The current hurricane.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.CurrentHurricane
        {
            get
            {
                return this.CurrentHurricane.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the raw tide.
        /// </summary>
        /// <value>
        /// The raw tide.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.RawTide
        {
            get
            {
                return this.RawTide.HasValue;
            }
        }


        /// <summary>
        /// Gets a value indicating whether [forecast].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [forecast]; otherwise, <c>false</c>.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.Forecast
        {
            get
            {
                return this.Forecast.HasValue;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [geo lookup].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [geo lookup]; otherwise, <c>false</c>.
        /// </value>
        [IgnoreDataMember]
        bool IFeatures.GeoLookup
        {
            get
            {
                return this.GeoLookup.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the yesterday.
        /// </summary>
        /// <value>
        /// The yesterday.
        /// </value>
        bool IFeatures.Yesterday
        {
            get
            {
                return this.Yesterday.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the tide.
        /// </summary>
        /// <value>
        /// The tide.
        /// </value>
        bool IFeatures.Hourly10Day
        {
            get
            {
                return this.Hourly10Day.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>
        /// The history.
        /// </value>
        bool IFeatures.History
        {
            get
            {
                return this.History.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the tide.
        /// </summary>
        /// <value>
        /// The tide.
        /// </value>
        bool IFeatures.Tide
        {
            get
            {
                return this.Tide.HasValue;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [webcams].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [webcams]; otherwise, <c>false</c>.
        /// </value>
        bool IFeatures.Webcams
        {
            get
            {
                return this.Webcams.HasValue;
            }
        }

        #endregion
    }
}