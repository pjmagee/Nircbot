// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetworkConfiguration.cs" company="Patrick Magee">
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
//   The network configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Infrastructure
{
    #region

    using System.Data.Entity.ModelConfiguration;

    using Nircbot.Core.Entities;

    #endregion

    /// <summary>
    /// The network configuration.
    /// </summary>
    public class NetworkConfiguration : EntityTypeConfiguration<Network>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkConfiguration"/> class.
        /// </summary>
        public NetworkConfiguration()
        {
            this.HasRequired(n => n.Identity).WithOptional(i => i.Network);
        }

        #endregion
    }
}