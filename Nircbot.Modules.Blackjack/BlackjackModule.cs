// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlackjackModule.cs" company="Patrick Magee">
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
//   Defines the Class1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Blackjack
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Caching;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;
    using Nircbot.Modules.Blackjack.Services;

    /// <summary>
    /// The blackjack module.
    /// </summary>
    public class BlackjackModule : BaseModule
    {
        /// <summary>
        /// The blackjack service factory.
        /// <remarks>
        /// Used to create a new instance of a blackjack game per channel.
        /// </remarks>
        /// </summary>
        private readonly IBlackjackServiceFactory blackjackServiceFactory;

        /// <summary>
        /// The cache.
        /// </summary>
        private readonly ObjectCache cache = MemoryCache.Default;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlackjackModule" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="blackjackServiceFactory">The blackjack service factory.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public BlackjackModule(IIrcClient ircClient, IBlackjackServiceFactory blackjackServiceFactory) : base(ircClient)
        {
            if (blackjackServiceFactory == null)
            {
                throw new ArgumentNullException("blackjackService");
            }
        }

        /// <summary>
        /// Registers the commands.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Command}" />.
        /// </returns>
        public override IEnumerable<Command> RegisterCommands()
        {
            var start = new Command("!bj start", (user, channel, type, format, message, arguments) => this.StartCommand(user, channel))
            {
                Accepts = MessageType.Both,
                Examples = new[] { "To start the game, use !bj --start" },
                Description = "Starts a new blackjack game in the current channel.",
                LevelRequired = AccessLevel.User,
            };

            var stop = new Command("!bj stop", (user, channel, type, format, message, arguments) => this.StopCommand(user, channel))
            {
                Accepts = MessageType.Both,
                Description = "Stops the blackjack game.",
                Examples = new[] { "Stops the blackjack game in the current channel." },
                LevelRequired = AccessLevel.User,
            };

            var hit = new Command("!hit", (user, channel, type, format, message, arguments) => this.HitCommand(user, channel))
            {
                Accepts = MessageType.Both,
                Description = "Performs a hit, instructing the dealer to deal you another card.",
                LevelRequired = AccessLevel.None,
                Examples = new[] { "!hit" },
            };

            var stand = new Command("!stand", (user, channel, type, format, message, arguments) => this.StandCommand(user, channel))
            {
                Accepts = MessageType.Both,
                Description = "Performs a stand, instructing the dealer that you are standing on your current cards",
                Examples = new[] { "!stand" },
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
            BlackjackService service = this.GetOrCreateBlackjackService(channel);
            
        }

        /// <summary>
        /// Gets or creates the blackjack service for the provided channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns></returns>
        private BlackjackService GetOrCreateBlackjackService(string channel)
        {
            var key = this.CreateKey("blackjack", channel);

            if (!this.cache.Contains(key))
            {
                var blackjackService = this.blackjackServiceFactory.CreateBlackjackService(this.IrcClient, channel);
                CacheItem item = new CacheItem(key, blackjackService);

                CacheItemPolicy policy = new CacheItemPolicy()
                                             {
                                                 SlidingExpiration = TimeSpan.FromHours(1),
                                                 AbsoluteExpiration = DateTime.Now.AddHours(1)
                                             };

                this.cache.Add(item, policy);
            }

            return this.cache[key] as BlackjackService;
        }

        /// <summary>
        /// Creates the key.
        /// </summary>
        /// <param name="objects">The objects.</param>
        /// <returns></returns>
        private string CreateKey(params string[] objects)
        {
            return string.Join("-", objects);
        }
    }
}
