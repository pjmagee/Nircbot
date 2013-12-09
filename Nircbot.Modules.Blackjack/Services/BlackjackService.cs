// --------------------------------------------------------------------------------------------------------------------
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
    using System.Collections.Generic;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;

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
        protected abstract void OnAdd(string user);

        /// <summary>
        /// Removes a user from the table.
        /// </summary>
        /// <param name="user">The user.</param>
        protected abstract void OnRemove(string user);

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

    /// <summary>
    /// The basic blackjack service.
    /// </summary>
    public class BasicBlackjackService : BlackjackService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicBlackjackService" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="channel">The channel.</param>
        public BasicBlackjackService(IIrcClient ircClient, string channel) : base(ircClient, channel)
        {
        }

        /// <summary>
        /// Registers the commands for this blackjack service.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Command> RegisterCommands()
        {
            var start = new Command("!bj start", (user, channel, type, format, message, arguments) => this.StartCommand(user, channel))
                                {
                                    Accepts = MessageType.Both,
                                    Examples = new [] { "To start the game, use !bj --start"},
                                    Description = "Starts a new blackjack game in the current channel.",
                                    LevelRequired = AccessLevel.User,
                                };

            var stop = new Command("!bj stop", (user, channel, type, format, message, arguments) => this.StopCommand(user, channel))
                           {
                               Accepts = MessageType.Both,
                               Description = "Stops the blackjack game.",
                               Examples = new [] { "Stops the blackjack game in the current channel."},
                               LevelRequired = AccessLevel.User,
                           };

            var hit = new Command("!hit", (user, channel, type, format, message, arguments) => this.HitCommand(user, channel))
                          {
                              Accepts = MessageType.Both,
                              Description = "Performs a hit, instructing the dealer to deal you another card.",
                              LevelRequired = AccessLevel.None,
                              Examples = new []{ "!hit"},
                          };

            var stand = new Command("!stand", (user, channel, type, format, message, arguments) => this.StandCommand(user, channel))
                            {
                                Accepts = MessageType.Both,
                                Description = "Performs a stand, instructing the dealer that you are standing on your current cards",
                                Examples = new[]{ "!stand"},
                                LevelRequired = AccessLevel.None,
                            };

            var join = new Command("!join", (user, channel, type, format, message, arguments) => this.JoinCommand(user, channel))
                           {
                               Accepts = MessageType.Both,
                               LevelRequired = AccessLevel.Guest,
                               Description = "Instructs the dealer that you join the table.",
                               Examples = new[] { "!join" },
                           };

            return new[] { start, stop, hit, stand, join };
        }

        private void JoinCommand(User user, string channel)
        {
            
        }

        private void StandCommand(User user, string channel)
        {
            
        }

        private void HitCommand(User user, string channel)
        {
            
        }

        private void StopCommand(User user, string channel)
        {
           
        }

        private void StartCommand(User user, string channel)
        {
            
        }

        public override void StartGame()
        {
            throw new NotImplementedException();
        }

        public override void StopGame()
        {
            throw new NotImplementedException();
        }

        public override void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public override void Hit(User user)
        {
            throw new NotImplementedException();
        }

        public override void DoubleDown(User user)
        {
            throw new NotImplementedException();
        }

        public override void Split(User user)
        {
            throw new NotImplementedException();
        }

        public override void Surrender(User user)
        {
            throw new NotImplementedException();
        }
    }
}