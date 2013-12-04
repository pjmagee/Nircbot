// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccessLevel.cs" company="Patrick Magee">
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
//   The access level.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Module
{
    /// <summary>
    /// The access level.
    /// </summary>
    public enum AccessLevel
    {
        /// <summary>
        /// Access level 0.
        /// </summary>
        None = 0x0, 

        /// <summary>
        /// Access level 1
        /// </summary>
        Guest = 0x1, 

        /// <summary>
        /// Access level 2
        /// </summary>
        User = 0x2, 

        /// <summary>
        /// Access level 3
        /// </summary>
        Admin = 0x3, 

        /// <summary>
        /// Access level 4
        /// </summary>
        Root = 0x4, 
    }
}