// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Patrick Magee">
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
//   The message type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Irc.Messages
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The message type.
    /// </summary>
    [Flags]
    public enum MessageType
    {
        /// <summary>
        /// Public Messages
        /// </summary>
        Public = 1, 

        /// <summary>
        /// Private Messages
        /// </summary>
        Private = 2, 

        /// <summary>
        /// Public and Private Messages
        /// </summary>
        Both = Public & Private, 
    }
}