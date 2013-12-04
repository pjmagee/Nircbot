// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Identity.cs" company="Patrick Magee">
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
//   The identity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Entities
{
    #region

    using System;

    using Nircbot.Core.Connections;

    #endregion

    /// <summary>
    /// The identity.
    /// </summary>
    public class Identity : IIdentity
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Identity" /> class.
        /// </summary>
        public Identity()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Identity"/> class.
        /// </summary>
        /// <param name="nickName">
        /// Name of the nick.
        /// </param>
        /// <param name="userName">
        /// Name of the user.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="realName">
        /// Name of the real.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public Identity(string nickName, string userName, string password, string realName, string description) : this()
        {
            this.NickName = nickName;
            this.UserName = userName;
            this.Password = password;
            this.RealName = realName;
            this.Description = description;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

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
        public Network Network { get; set; }

        /// <summary>
        /// Gets or sets the network identifier.
        /// </summary>
        /// <value>
        /// The network identifier.
        /// </value>
        public Guid? NetworkId { get; set; }

        /// <summary>
        /// Gets or sets the name of the nick.
        /// </summary>
        /// <value>
        /// The name of the nick.
        /// </value>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the name of the real.
        /// </summary>
        /// <value>
        /// The name of the real.
        /// </value>
        public string RealName { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string IIdentity.Description
        {
            get
            {
                return this.Description;
            }
        }

        /// <summary>
        /// Gets the network.
        /// </summary>
        /// <value>
        /// The network.
        /// </value>
        INetwork IIdentity.Network
        {
            get
            {
                return this.Network;
            }
        }

        /// <summary>
        /// Gets the name of the nick.
        /// </summary>
        /// <value>
        /// The name of the nick.
        /// </value>
        string IIdentity.NickName
        {
            get
            {
                return this.NickName;
            }
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string IIdentity.Password
        {
            get
            {
                return this.Password;
            }
        }

        /// <summary>
        /// Gets the name of the real.
        /// </summary>
        /// <value>
        /// The name of the real.
        /// </value>
        string IIdentity.RealName
        {
            get
            {
                return this.RealName;
            }
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string IIdentity.UserName
        {
            get
            {
                return this.UserName;
            }
        }

        #endregion
    }
}