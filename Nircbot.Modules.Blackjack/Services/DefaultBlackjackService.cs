// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultBlackjackService.cs" company="Patrick Magee">
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
//   The basic blackjack service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Blackjack.Services
{
    using System;

    using Nircbot.Core.Irc;

    /// <summary>
    /// The basic blackjack service.
    /// </summary>
    public class DefaultBlackjackService : BlackjackService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultBlackjackService" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="channel">The channel.</param>
        public DefaultBlackjackService(IIrcClient ircClient, string channel) : base(ircClient, channel)
        {

        }

        /// <summary>
        /// Starts the blackjack game.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void OnStart()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the blackjack game.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void OnStop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a user to the table.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void OnJoin(string user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a user from the table.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void OnLeave(string user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs a Hit for the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void OnHit(string user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs a double down move for the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void OnDoubleDown(string user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs a split move for the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void OnSplit(string user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs a surrender move for the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void OnSurrender(string user)
        {
            throw new NotImplementedException();
        }
    }
}