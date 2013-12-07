// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Patrick Magee">
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
//   The user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Entities
{
    #region

    using System;

    using Nircbot.Core.Module;

    #endregion

    /// <summary>
    /// The user.
    /// </summary>
    public class User
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="accessLevel">The access level.</param>
        public User(AccessLevel accessLevel = AccessLevel.None)
        {
            this.AccessLevel = accessLevel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="nick">The nick.</param>
        /// <param name="host">The host.</param>
        public User(string nick, string host) : this()
        {
            this.Nick = nick;
            this.Host = host;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="nick">The nick.</param>
        /// <param name="host">The host.</param>
        /// <param name="email">The email.</param>
        public User(string nick, string host, string email) : this(nick, host)
        {
            this.Email = email;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="nick">The nick.</param>
        /// <param name="host">The host.</param>
        /// <param name="accessLevel">The access level.</param>
        public User(string nick, string host, AccessLevel accessLevel) : this(accessLevel)
        {
            this.Nick = nick;
            this.Host = host;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="nick">The nick.</param>
        /// <param name="host">The host.</param>
        /// <param name="email">The email.</param>
        /// <param name="accessLevel">The access level.</param>
         public User(string nick, string host, string email, AccessLevel accessLevel) : this(nick, host, email)
         {
             this.AccessLevel = accessLevel;
         }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the access level.
        /// </summary>
        /// <value>
        /// The access level.
        /// </value>
        public AccessLevel AccessLevel { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the nick.
        /// </summary>
        /// <value>
        /// The nick.
        /// </value>
        public string Nick { get; set; }

        #endregion
    }
}