// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INetwork.cs" company="Patrick Magee">
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
//   The Network interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Connections
{
    #region

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The Network interface.
    /// </summary>
    public interface INetwork
    {
        #region Public Properties

        /// <summary>
        /// Gets the channels.
        /// </summary>
        /// <value>
        /// The channels.
        /// </value>
        IEnumerable<IChannel> Channels { get; }

        /// <summary>
        /// Gets the identity.
        /// </summary>
        /// <value>
        /// The identity.
        /// </value>
        IIdentity Identity { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the servers.
        /// </summary>
        /// <value>
        /// The servers.
        /// </value>
        IEnumerable<IServer> Servers { get; }

        #endregion
    }
}