// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Server.cs" company="Patrick Magee">
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
//   The server.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Entities
{
    #region

    using System;

    using Nircbot.Core.Connections;

    #endregion

    /// <summary>
    /// The server.
    /// </summary>
    public class Server : IServer
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        public Server()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        public Server(string address)
        {
            this.Address = address;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="port">
        /// The port.
        /// </param>
        /// <param name="ssl">
        /// if set to <c>true</c> [SSL].
        /// </param>
        public Server(string address, int port, bool ssl) : this(address)
        {
            this.Port = port;
            this.Ssl = ssl;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the network.
        /// </summary>
        /// <value>
        /// The network.
        /// </value>
        public virtual Network Network { get; set; }

        /// <summary>
        /// Gets or sets the network identifier.
        /// </summary>
        /// <value>
        /// The network identifier.
        /// </value>
        public Guid? NetworkId { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int? Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [SSL].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [SSL]; otherwise, <c>false</c>.
        /// </value>
        public bool Ssl { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        string IServer.Address
        {
            get
            {
                return this.Address;
            }
        }

        /// <summary>
        /// Gets the network.
        /// </summary>
        /// <value>
        /// The network.
        /// </value>
        INetwork IServer.Network
        {
            get
            {
                return this.Network;
            }
        }

        /// <summary>
        /// Gets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        int? IServer.Port
        {
            get
            {
                return this.Port;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [SSL].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [SSL]; otherwise, <c>false</c>.
        /// </value>
        bool IServer.Ssl
        {
            get
            {
                return this.Ssl;
            }
        }

        #endregion
    }
}