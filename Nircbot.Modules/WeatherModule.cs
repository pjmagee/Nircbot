﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherModule.cs" company="Patrick Magee">
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
//   The weather module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules
{
    #region

    using Nircbot.Core.Irc;
    using Nircbot.Core.Module;

    #endregion

    /// <summary>
    /// The weather module.
    /// </summary>
    public class WeatherModule : BaseModule
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherModule" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        public WeatherModule(IIrcClient ircClient) : base(ircClient)
        {
            
        }

        #endregion
    }
}
