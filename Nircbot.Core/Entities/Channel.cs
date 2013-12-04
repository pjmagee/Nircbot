// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Channel.cs" company="Patrick Magee">
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
//   The channel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Entities
{
    #region

    using System;

    using Nircbot.Core.Connections;

    #endregion

    /// <summary>
    /// The channel.
    /// </summary>
    public class Channel : IChannel
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Channel"/> class.
        /// </summary>
        public Channel()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Channel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public Channel(string name) : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Channel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        public Channel(string name, string key) : this(name)
        {
            this.Key = key;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

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

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the network.
        /// </summary>
        /// <value>
        /// The network.
        /// </value>
        INetwork IChannel.Network
        {
            get
            {
                return this.Network;
            }
        }

        #endregion
    }
}