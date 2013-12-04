// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bot.cs" company="Patrick Magee">
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
//   The nircbot.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core
{
    #region

    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Infrastructure;
    using Nircbot.Core.Irc;

    #endregion

    /// <summary>
    /// The nircbot.
    /// </summary>
    public class Bot
    {
        #region Fields

        /// <summary>
        /// The clients.
        /// </summary>
        private readonly List<IIrcClient> clients;

        /// <summary>
        /// The context.
        /// </summary>
        private readonly Context context;

        /// <summary>
        /// The ircClient factory.
        /// </summary>
        private readonly IIrcClientFactory ircClientFactory;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Bot"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="ircClientFactory">
        /// The ircClient factory.
        /// </param>
        public Bot(Context context, IIrcClientFactory ircClientFactory) : this()
        {
            this.context = context;
            this.ircClientFactory = ircClientFactory;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Bot"/> class from being created.
        /// </summary>
        private Bot()
        {
            this.clients = new List<IIrcClient>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The start.
        /// </summary>
        public void Start()
        {
            Trace.TraceInformation("Starting the bot.");

            List<Network> networks = this.context.Networks.ToList();
            
            foreach (var network in networks)
            {
                IIrcClient ircClient = this.ircClientFactory.Create();
                ircClient.Connect(network);
                this.clients.Add(ircClient);
            }
        }

        #endregion
    }
}
