// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMoonPhase.cs" company="Patrick Magee">
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
//   The MoonPhase interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The MoonPhase interface.
    /// </summary>
    public interface IMoonPhase
    {
        #region Public Properties

        /// <summary>
        /// Gets the age of moon.
        /// </summary>
        int AgeOfMoon { get; }

        /// <summary>
        /// Gets the current time.
        /// </summary>
        DateTime CurrentTime { get; }

        /// <summary>
        /// Gets the hemisphere.
        /// </summary>
        string Hemisphere { get; }

        /// <summary>
        /// Gets the percent illuminated.
        /// </summary>
        int PercentIlluminated { get; }

        /// <summary>
        /// Gets the phase of moon.
        /// </summary>
        string PhaseOfMoon { get; }

        /// <summary>
        /// Gets the sunrise.
        /// </summary>
        DateTime Sunrise { get; }

        /// <summary>
        /// Gets the sunset.
        /// </summary>
        DateTime Sunset { get; }

        #endregion
    }
}