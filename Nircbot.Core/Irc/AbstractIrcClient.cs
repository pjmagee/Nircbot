// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbstractIrcClient.cs" company="Patrick Magee">
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
//   The abstract client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Irc
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Nircbot.Core.Connections;
    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;

    #endregion

    /// <summary>
    /// The abstract client.
    /// </summary>
    public abstract class AbstractIrcClient : IIrcClient
    {
        #region Fields

        /// <summary>
        /// The modules
        /// </summary>
        private readonly IEnumerable<IModule> modules;
        

        /// <summary>
        /// The network
        /// </summary>
        private readonly INetwork network;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractIrcClient"/> class.
        /// </summary>
        /// <param name="moduleFactory">
        /// The module factory.
        /// </param>
        protected AbstractIrcClient(IModuleFactory moduleFactory)
        {
            this.modules = moduleFactory.Create(this);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is connected].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is connected]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsConnected { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether [supports identification].
        /// </summary>
        /// <value>
        /// <c>true</c> if [supports identification]; otherwise, <c>false</c>.
        /// </value>
        public bool SupportsIdentification { get; protected set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the modules.
        /// </summary>
        /// <value>
        /// The modules.
        /// </value>
        protected IEnumerable<IModule> Modules { get { return this.modules; } }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Bans the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="reason">
        /// The reason.
        /// </param>
        public abstract void Ban(string channel, string user, string reason = null);

        /// <summary>
        /// Connects the specified network.
        /// </summary>
        /// <param name="network">
        /// The network.
        /// </param>
        public abstract void Connect(INetwork network);

        /// <summary>
        /// Connects the specified server.
        /// </summary>
        /// <param name="server">
        /// The server.
        /// </param>
        public abstract void Connect(IServer server);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Gets the users in channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public abstract IEnumerable<User> GetUsersInChannel(string channel);

        /// <summary>
        /// Joins the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        public abstract void Join(string channel, string key = null);

        /// <summary>
        /// Kicks the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="reason">
        /// The reason.
        /// </param>
        public abstract void Kick(string channel, string user, string reason = null);

        /// <summary>
        /// Parts the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public abstract void Part(string channel, string message = null);

        /// <summary>
        /// Quits the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public abstract void Quit(string message = null);

        /// <summary>
        /// Sends the response.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        public abstract void SendResponse(IResponse response);

        /// <summary>
        /// Sets the topic.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="topic">
        /// The topic.
        /// </param>
        public abstract void SetTopic(string channel, string topic);

        /// <summary>
        /// Unbans the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        public abstract void Unban(string channel, string user);

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether [is nickserv notice] [the specified nickname].
        /// </summary>
        /// <param name="nickname">
        /// The nickname.
        /// </param>
        /// <param name="notice">
        /// The notice.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected virtual bool IsNickServNotice(string nickname, string notice)
        {
            if (nickname.Equals("nickserv", StringComparison.OrdinalIgnoreCase))
            {
                Trace.TraceInformation("Notice from nickserv: {0}", notice);

                var isIdentified = notice.StartsWith("You are now identified for", StringComparison.OrdinalIgnoreCase);
                var isNotRegistered = notice.StartsWith("The nickname", StringComparison.OrdinalIgnoreCase) && notice.EndsWith("is not registered", StringComparison.OrdinalIgnoreCase);
                return isIdentified || isNotRegistered;
            }

            return false;
        }

        #endregion
    }
}