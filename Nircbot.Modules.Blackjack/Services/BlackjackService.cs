﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlackjackService.cs" company="Patrick Magee">
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
//   The blackjack service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Blackjack.Services
{
    using System;

    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;

    /// <summary>
    /// The blackjack service.
    /// </summary>
    public abstract class BlackjackService
    {
        /// <summary>
        /// The irc client.
        /// </summary>
        private readonly IIrcClient ircClient;

        /// <summary>
        /// The channel.
        /// </summary>
        private readonly string channel;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlackjackService" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="channel">The channel.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        protected BlackjackService(IIrcClient ircClient, string channel)
        {
            if (channel == null)
            {
                throw new ArgumentNullException("channel");
            }

            if (ircClient == null)
            {
                throw new ArgumentNullException("ircClient");
            }

            this.ircClient = ircClient;
            this.channel = channel;
        }

        public void StartGame()
        {
            this.OnStart();

            Response reponse = new Response("Game started", new[] { this.channel }, MessageFormat.Notice, MessageType.Both);
            this.ircClient.SendResponse(reponse);
        }

        /// <summary>
        /// Starts the blackjack game.
        /// </summary>
        protected abstract void OnStart();

        /// <summary>
        /// Stops the blackjack game.
        /// </summary>
        protected abstract void OnStop();

        /// <summary>
        /// Adds a user to the table.
        /// </summary>
        /// <param name="user">The user.</param>
        protected abstract void OnJoin(string user);

        /// <summary>
        /// Removes a user from the table.
        /// </summary>
        /// <param name="user">The user.</param>
        protected abstract void OnLeave(string user);

        /// <summary>
        /// Performs a Hit for the user.
        /// </summary>
        /// <param name="user">The user.</param>
        protected abstract void OnHit(string user);

        /// <summary>
        /// Performs a double down move for the user.
        /// </summary>
        /// <param name="user">The user.</param>
        protected abstract void OnDoubleDown(string user);

        /// <summary>
        /// Performs a split move for the user.
        /// </summary>
        /// <param name="user">The user.</param>
        protected abstract void OnSplit(string user);

        /// <summary>
        /// Performs a surrender move for the user.
        /// </summary>
        /// <param name="user">The user.</param>
        protected abstract void OnSurrender(string user);
    }
}