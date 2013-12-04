// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModule.cs" company="Patrick Magee">
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
//   The Module interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Module
{
    #region

    using System.Collections.Generic;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;

    #endregion

    /// <summary>
    /// The Module interface.
    /// </summary>
    public interface IModule
    {
        #region Public Properties

        /// <summary>
        /// Gets the commands.
        /// </summary>
        /// <value>
        /// The commands.
        /// </value>
        IEnumerable<Command> Commands { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; }

        /// <summary>
        /// Gets the irc client.
        /// </summary>
        IIrcClient IrcClient { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when [notice].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="notice">
        /// The notice.
        /// </param>
        void OnNotice(User user, string notice);

        /// <summary>
        /// Called when [private message].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        void OnPrivateMessage(User user, string message);

        /// <summary>
        /// Called when [public message].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        void OnPublicMessage(User user, string channel, string message);

        /// <summary>
        /// Called when [user joined].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        void OnUserJoined(User user, string channel);

        /// <summary>
        /// Called when [user kicked].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        void OnUserKicked(User user, string channel, string message);

        /// <summary>
        /// Called when [user left].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        void OnUserLeft(User user, string channel);

        /// <summary>
        /// Processes the specified request.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        void Process(Request request);

        /// <summary>
        /// Starts this instance.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops this instance.
        /// </summary>
        void Stop();

        #endregion
    }
}