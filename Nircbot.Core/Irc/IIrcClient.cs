// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIrcClient.cs" company="Patrick Magee">
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
//   The ircClient interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Irc
{
    #region

    using System;
    using System.Collections.Generic;

    using Nircbot.Core.Connections;
    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc.Messages;

    #endregion

    /// <summary>
    /// The ircClient interface.
    /// </summary>
    public interface IIrcClient : IDisposable
    {
        #region Public Properties

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; }

        /// <summary>
        /// Gets a value indicating whether [is connected].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is connected]; otherwise, <c>false</c>.
        /// </value>
        bool IsConnected { get; }

        /// <summary>
        /// Gets a value indicating whether [supports identification].
        /// </summary>
        /// <value>
        /// <c>true</c> if [supports identification]; otherwise, <c>false</c>.
        /// </value>
        bool SupportsIdentification { get; }

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
        void Ban(string channel, string user, string reason = null);

        /// <summary>
        /// Connects the specified network.
        /// </summary>
        /// <param name="network">
        /// The network.
        /// </param>
        void Connect(INetwork network);

        /// <summary>
        /// Connects the specified server.
        /// </summary>
        /// <param name="server">
        /// The server.
        /// </param>
        void Connect(IServer server);

        /// <summary>
        /// Gets the users in channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<User> GetUsersInChannel(string channel);

        /// <summary>
        /// Joins the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        void Join(string channel, string key = null);

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
        void Kick(string channel, string user, string reason = null);

        /// <summary>
        /// Parts the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        void Part(string channel, string message = null);

        /// <summary>
        /// Quits the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void Quit(string message = null);

        /// <summary>
        /// Sends the response.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        void SendResponse(IResponse response);

        /// <summary>
        /// Sets the topic.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="topic">
        /// The topic.
        /// </param>
        void SetTopic(string channel, string topic);

        /// <summary>
        /// Unbans the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        void Unban(string channel, string user);

        #endregion
    }
}