﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoviesModule.cs" company="Patrick Magee">
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
//   Defines the Class1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Movies
{
    using Nircbot.Core.Irc;
    using Nircbot.Core.Module;

    /// <summary>
    /// The movies module.
    /// </summary>
    public class MoviesModule : BaseModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesModule"/> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        public MoviesModule(IIrcClient ircClient) : base(ircClient)
        {
        }
    }
}
