// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILocation.cs" company="Patrick Magee">
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
//   The Location interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    #region

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The Location interface.
    /// </summary>
    public interface ILocation
    {
        #region Public Properties

        /// <summary>
        /// Gets the city.
        /// </summary>
        string City { get; }

        /// <summary>
        /// Gets the country.
        /// </summary>
        string Country { get; }

        /// <summary>
        /// Gets the country is o 3166.
        /// </summary>
        string CountryISO3166 { get; }

        /// <summary>
        /// Gets the country name.
        /// </summary>
        string CountryName { get; }

        /// <summary>
        /// Gets the lat.
        /// </summary>
        float Lat { get; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets the lon.
        /// </summary>
        float Lon { get; }

        /// <summary>
        /// Gets the magic.
        /// </summary>
        string Magic { get; }

        /// <summary>
        /// Gets the request url.
        /// </summary>
        string RequestUrl { get; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        string State { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the tz long.
        /// </summary>
        string TzLong { get; }

        /// <summary>
        /// Gets the tz short.
        /// </summary>
        string TzShort { get; }

        /// <summary>
        /// Gets the wmo.
        /// </summary>
        string WMO { get; }

        /// <summary>
        /// Gets the wui url.
        /// </summary>
        string WUIUrl { get; }

        /// <summary>
        /// Gets the weather stations.
        /// </summary>
        IEnumerable<IWeatherStation> WeatherStations { get; }

        /// <summary>
        /// Gets the zip.
        /// </summary>
        string Zip { get; }

        #endregion
    }
}