// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IResponse.cs" company="Patrick Magee">
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
//   The Response interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    /// <summary>
    /// The Response interface.
    /// </summary>
    public interface IResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <value>
        /// The features.
        /// </value>
        IFeatures Features { get; }

        /// <summary>
        /// Gets the terms of service.
        /// </summary>
        /// <value>
        /// The terms of service.
        /// </value>
        string TermsOfService { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        string Version { get; }

        #endregion
    }
}