// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="Patrick Magee">
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
//   The location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The location.
    /// </summary>
    [DataContract(Name = "location")]
    public class Location : ILocation
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
        /// Gets or sets the country is o 3166.
        /// </summary>
        [DataMember(Name = "countryiso3166")]
        public string CountryISO3166 { get; set; }

        /// <summary>
        /// Gets or sets the country name.
        /// </summary>
        [DataMember(Name = "countryname")]
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        [DataMember(Name = "lat")]
        public float Lat { get; set; }

        /// <summary>
        /// Gets or sets the loc.
        /// </summary>
        /// <value>
        /// The loc.
        /// </value>
        [DataMember(Name = "location")]
        public string Loc { get; set; }

        /// <summary>
        /// Gets or sets the lon.
        /// </summary>
        [DataMember(Name = "lon")]
        public float Lon { get; set; }

        /// <summary>
        /// Gets or sets the magic.
        /// </summary>
        [DataMember(Name= "magic")]
        public string Magic { get; set; }

        /// <summary>
        /// Gets or sets the request url.
        /// </summary>
        [DataMember(Name = "requesturl")]
        public string RequestUrl { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the city.
        /// </summary>
        [IgnoreDataMember]
        string ILocation.City
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
        string ILocation.Country
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
        string ILocation.CountryISO3166
        {
            get
            {
                return this.CountryISO3166;
            }
        }

        /// <summary>
        /// Gets the country name.
        /// </summary>
        [IgnoreDataMember]
        string ILocation.CountryName
        {
            get
            {
                return this.CountryName;
            }
        }

        /// <summary>
        /// Gets the lat.
        /// </summary>
        [IgnoreDataMember]
        float ILocation.Lat
        {
            get
            {
                return this.Lat;
            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        [IgnoreDataMember]
        string ILocation.Location
        {
            get
            {
                return this.Loc;
            }
        }

        /// <summary>
        /// Gets the lon.
        /// </summary>
        [IgnoreDataMember]
        float ILocation.Lon
        {
            get
            {
                return this.Lon;
            }
        }

        /// <summary>
        /// Gets the magic.
        /// </summary>
        [IgnoreDataMember]
        string ILocation.Magic
        {
            get
            {
                return this.Magic;
            }
        }

        /// <summary>
        /// Gets the request url.
        /// </summary>
        string ILocation.RequestUrl
        {
            get
            {
                return this.RequestUrl;
            }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        string ILocation.State
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        string ILocation.Type
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the tz long.
        /// </summary>
        string ILocation.TzLong
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the tz short.
        /// </summary>
        [IgnoreDataMember]
        string ILocation.TzShort
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the wmo.
        /// </summary>
        [IgnoreDataMember]
        string ILocation.WMO
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the wui url.
        /// </summary>
        [IgnoreDataMember]
        string ILocation.WUIUrl
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the weather stations.
        /// </summary>
        [IgnoreDataMember]
        IEnumerable<IWeatherStation> ILocation.WeatherStations
        {
            get
            {
                return Enumerable.Empty<IWeatherStation>();
            }
        }

        /// <summary>
        /// Gets the zip.
        /// </summary>
        [IgnoreDataMember]
        string ILocation.Zip
        {
            get
            {
                return string.Empty;
            }
        }

        #endregion
    }
}