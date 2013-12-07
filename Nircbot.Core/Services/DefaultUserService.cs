// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultUserService.cs" company="Patrick Magee">
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
//   The default user service to use with our backing database.
//   Using Entity Framwork DbContext
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Services
{
    #region

    using System.Collections.Generic;
    using System.Linq;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Infrastructure;
    using Nircbot.Core.Module;

    #endregion

    /// <summary>
    /// The default user service to use with our backing database.
    /// Using Entity Framework DbContext
    /// </summary>
    public class DefaultUserService : IUserService
    {
        #region Fields

        /// <summary>
        /// The context
        /// </summary>
        private readonly Context context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultUserService"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public DefaultUserService(Context context)
        {
            this.context = context;
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
            return (from user in this.context.Users where user.Host.Equals(host) select user).FirstOrDefault();
        }

        /// <summary>
        /// Lists the admins.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{User}"/>.
        /// </returns>
        public IEnumerable<User> ListAdmins()
        {
            return this.context.Users.Where(u => u.AccessLevel >= AccessLevel.Admin).ToList();
        }

        #endregion
    }
}
