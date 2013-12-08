// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIrbService.cs" company="Patrick Magee">
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
//   The IrbService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Ruby.Services
{
    using Nircbot.Core.Entities;

    /// <summary>
    /// The IrbService interface.
    /// </summary>
    public interface IIrbService
    {
        /// <summary>
        /// Writes to session.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="message">The message.</param>
        void WriteToSession(User user, string message);

        /// <summary>
        /// Creates the session.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        void CreateSession(User user, string channel);

        /// <summary>
        /// Removes the session.
        /// </summary>
        /// <param name="user">The user.</param>
        void RemoveSession(User user);
    }
}