// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Context.cs" company="Patrick Magee">
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
//   The fake context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Infrastructure
{
    #region

    using System.Data.Entity;

    using Nircbot.Core.Entities;

    #endregion

    /// <summary>
    /// The context.
    /// </summary>
    public class Context : DbContext
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        public Context() : base("Default")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.UseDatabaseNullSemantics = true;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the channels.
        /// </summary>
        public DbSet<Channel> Channels { get; set; }

        /// <summary>
        /// Gets or sets the identities.
        /// </summary>
        public DbSet<Identity> Identities { get; set; }

        /// <summary>
        /// Gets or sets the networks.
        /// </summary>
        public DbSet<Network> Networks { get; set; }

        /// <summary>
        /// Gets or sets the servers.
        /// </summary>
        public DbSet<Server> Servers { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(Context).Assembly);
        }

        #endregion
    }
}
