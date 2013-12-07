// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserService.cs" company="Patrick Magee">
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
//   The user service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Services
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Module;

    #endregion

    /// <summary>
    /// The user service.
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields

        /// <summary>
        /// The users
        /// </summary>
        private readonly List<User> users = new List<User>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public UserService()
        {
            this.users.Add(new User { AccessLevel = AccessLevel.Root, Email = "patrick.magee@live.co.uk", Host = "patrick.mag@127.0.0.1", Nick = "Peej" });
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the user by host.
        /// </summary>
        /// <param name="host">
        /// The host.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User GetUserByHost(string host)
        {
            return this.users.FirstOrDefault(u => u.Host.Equals(host, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Lists the admins.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{User}"/>.
        /// </returns>
        public IEnumerable<User> ListAdmins()
        {
            return this.users.Where(u => u.AccessLevel >= AccessLevel.Admin);
        }

        #endregion
    }
}