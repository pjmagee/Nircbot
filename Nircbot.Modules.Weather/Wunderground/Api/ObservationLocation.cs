// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObservationLocation.cs" company="Patrick Magee">
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
//   The observation location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The observation location.
    /// </summary>
    [DataContract(Name = "observation_location")]
    public class ObservationLocation : IObservationLocation
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [DataMember(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the country iso 3166.
        /// </summary>
        [DataMember(Name = "country_iso3166")]
        public string CountryISO3166 { get; set; }

        /// <summary>
        /// Gets or sets the elevation.
        /// </summary>
        [DataMember(Name = "elevation")]
        public string Elevation { get; set; }

        /// <summary>
        /// Gets or sets the full.
        /// </summary>
        [DataMember(Name = "full")]
        public string Full { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        [DataMember(Name = "latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// Gets or sets the lon.
        /// </summary>
        [DataMember(Name = "longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [DataMember(Name = "state")]
        public string State { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the city.
        /// </summary>
        [IgnoreDataMember]
        string IObservationLocation.City
        {
            get
            {
                return this.City;
            }
        }

        /// <summary>
        /// Gets the country.
        /// </summary>
        [IgnoreDataMember]
        string IObservationLocation.Country
        {
            get
            {
                return this.Country;
            }
        }

        /// <summary>
        /// Gets the country is o 3166.
        /// </summary>
        [IgnoreDataMember]
        string IObservationLocation.CountryISO3166
        {
            get
            {
                return this.CountryISO3166;
            }
        }

        /// <summary>
        /// Gets the elevation.
        /// </summary>
        [IgnoreDataMember]
        string IObservationLocation.Elevation
        {
            get
            {
                return this.Elevation;
            }
        }

        /// <summary>
        /// Gets the full.
        /// </summary>
        [IgnoreDataMember]
        string IObservationLocation.Full
        {
            get
            {
                return this.Full;
            }
        }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        [IgnoreDataMember]
        float IObservationLocation.Latitude
        {
            get
            {
                return this.Latitude;
            }
        }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        [IgnoreDataMember]
        float IObservationLocation.Longitude
        {
            get
            {
                return this.Longitude;
            }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        [IgnoreDataMember]
        string IObservationLocation.State
        {
            get
            {
                return this.State;
            }
        }

        #endregion
    }
}