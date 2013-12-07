// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DropCreateDatabaseAlwaysStrategy.cs" company="Patrick Magee">
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
//   The drop create database always strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Infrastructure
{
    #region

    using System.Data.Entity;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Module;

    #endregion

    /// <summary>
    /// The drop create database always strategy.
    /// </summary>
    public class DropCreateDatabaseAlwaysStrategy : DropCreateDatabaseAlways<Context>
    {
        #region Methods

        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(Context context)
        {
            context.Users.Add(new User("Peej", "patrick.ma@cpc2-croy20-2-0-cust274.croy.cable.virginm.net", "patrick.magee@live.co.uk", AccessLevel.Root));

            Identity identity = context.Identities.Add(new Identity("NircBot", "Nircbot", "NircBot", "NircBot", "NircBot"));
            Server server = context.Servers.Add(new Server("irc.freenode.net"));
            Network network = context.Networks.Add(new Network("Freenode"));
            Channel bottersTestChannel = context.Channels.Add(new Channel("#botters-test"));

            network.Servers.Add(server);
            network.Channels.Add(bottersTestChannel);
            network.Identity = identity;
            identity.Network = network;

            context.SaveChanges();
        }

        #endregion
    }
}