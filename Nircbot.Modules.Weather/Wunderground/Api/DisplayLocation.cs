// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayLocation.cs" company="Patrick Magee">
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
//   The display location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The display location.
    /// </summary>
    [DataContract(Name = "display")]
    public class DisplayLocation : IDisplayLocation
    {
        #region Public Properties

        /// <summary>
        /// Gets the city.
        /// </summary>
        [DataMember(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// Gets the country.
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets the country is o 3166.
        /// </summary>
        [DataMember(Name = "country_iso3166")]
        public string CountryISO3166 { get; set; }

        /// <summary>
        /// Gets the elevation.
        /// </summary>
        [DataMember(Name = "elevation")]
        public string Elevation { get; set; }

        /// <summary>
        /// Gets the full.
        /// </summary>
        [DataMember(Name = "full")]
        public string Full { get; set; }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        [DataMember(Name = "latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        [DataMember(Name = "longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// Gets the magic.
        /// </summary>
        [DataMember(Name = "magic")]
        public string Magic { get; set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        [DataMember(Name = "state")]
        public string State { get; set; }

        /// <summary>
        /// Gets the state name.
        /// </summary>
        [DataMember(Name = "state_name")]
        public string StateName { get; set; }

        /// <summary>
        /// Gets the wmo.
        /// </summary>
        [DataMember(Name = "wmo")]
        public string WMO { get; set; }

        /// <summary>
        /// Gets the zip.
        /// </summary>
        [DataMember(Name = "zip")]
        public string Zip { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the city.
        /// </summary>
        [IgnoreDataMember]
        string IDisplayLocation.City
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
        string IDisplayLocation.Country
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
        string IDisplayLocation.CountryISO3166
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
        string IDisplayLocation.Elevation
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
        string IDisplayLocation.Full
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
        float IDisplayLocation.Latitude
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
        float IDisplayLocation.Longitude
        {
            get
            {
                return this.Longitude;
            }
        }

        /// <summary>
        /// Gets the magic.
        /// </summary>
        [IgnoreDataMember]
        string IDisplayLocation.Magic
        {
            get
            {
                return this.Magic;
            }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        [IgnoreDataMember]
        string IDisplayLocation.State
        {
            get
            {
                return this.State;
            }
        }

        /// <summary>
        /// Gets the state name.
        /// </summary>
        [IgnoreDataMember]
        string IDisplayLocation.StateName
        {
            get
            {
                return this.StateName;
            }
        }

        /// <summary>
        /// Gets the wmo.
        /// </summary>
        [IgnoreDataMember]
        string IDisplayLocation.WMO
        {
            get
            {
                return this.WMO;
            }
        }

        /// <summary>
        /// Gets the zip.
        /// </summary>
        [IgnoreDataMember]
        string IDisplayLocation.Zip
        {
            get
            {
                return this.Zip;
            }
        }

        #endregion
    }
}