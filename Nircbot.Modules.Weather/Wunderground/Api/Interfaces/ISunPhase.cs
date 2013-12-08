// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISunPhase.cs" company="Patrick Magee">
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
//   The SunPhase interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The SunPhase interface.
    /// </summary>
    public interface ISunPhase
    {
        #region Public Properties

        /// <summary>
        /// Gets the sunrise.
        /// </summary>
        /// <value>
        /// The sunrise.
        /// </value>
        DateTime Sunrise { get; }

        /// <summary>
        /// Gets the sunset.
        /// </summary>
        /// <value>
        /// The sunset.
        /// </value>
        DateTime Sunset { get; }

        #endregion
    }
}