// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStation.cs" company="Patrick Magee">
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
//   The Station interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    /// <summary>
    /// The Station interface.
    /// </summary>
    public interface IStation
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
        /// Gets the distance in kilometers.
        /// </summary>
        float DistanceInKilometers { get; }

        /// <summary>
        /// Gets the distance in miles.
        /// </summary>
        float DistanceInMiles { get; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the lat.
        /// </summary>
        float Lat { get; }

        /// <summary>
        /// Gets the lon.
        /// </summary>
        float Lon { get; }

        /// <summary>
        /// Gets the neighborhood.
        /// </summary>
        string Neighborhood { get; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        string State { get; }

        #endregion
    }
}