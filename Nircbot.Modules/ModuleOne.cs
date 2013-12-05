// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleOne.cs" company="Patrick Magee">
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
//   The module one.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;

    #endregion

    /// <summary>
    /// The module one.
    /// </summary>
    public sealed class ModuleOne : BaseModule
    {
        #region Constants

        /// <summary>
        /// The pattern.
        /// </summary>
        private const string Pattern = @"(http://)?(www\.)?(youtube|yimg|youtu)\.([A-Za-z]{2,4}|[A-Za-z]{2}\.[A-Za-z]{2})/(watch\?v=)?[A-Za-z0-9\-_]{6,12}(&[A-Za-z0-9\-_]{1,}=[A-Za-z0-9\-_]{1,})*";

        #endregion

        #region Static Fields

        /// <summary>
        /// 
        /// </summary>
        private static readonly Regex youTubeRegex = new Regex(Pattern, RegexOptions.Compiled);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleOne"/> class.
        /// </summary>
        /// <param name="ircClient">
        /// The irc client.
        /// </param>
        public ModuleOne(IIrcClient ircClient) : base(ircClient)
        {
            
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Registers the commands.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Command}" />.
        /// </returns>
        public override IEnumerable<Command> RegisterCommands()
        {
            yield return new Command("!help", this.HandleHelp)
                             {
                                 Accepts = MessageType.Both, 
                                 LevelRequired = AccessLevel.Guest,
                                 Description = "Provides information about how to use the bot.",
                             };

            yield return new Command(youTubeRegex, this.HandleYoutubeLink)
                             {
                                 LevelRequired = AccessLevel.None,
                                 Description = "Identifies Youtube videos and outputs information about them."
                             };
        }

        /// <summary>
        /// Registers the tasks.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{ScheduledTask}" />.
        /// </returns>
        public override IEnumerable<ScheduledTask> RegisterTasks()
        {
            yield return new ScheduledTask("Info", this.Run, TimeSpan.FromSeconds(60));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the help.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void HandleHelp(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments)
        {
            var response = new Response();
            response.MessageFormat = messageFormat;
            response.MessageType = messageType;
            response.Targets = new[] { channel ?? user.Nick };
            response.Message = "This is a verbose message on the help command.";

            this.SendResponse(response);
        }

        /// <summary>
        /// Handles the youtube link.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void HandleYoutubeLink(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments)
        {
            var response = new Response();
            response.MessageFormat = messageFormat;
            response.MessageType = messageType;
            response.Targets = new[] { channel ?? user.Nick };
            response.Message = string.Format("{0}", arguments.Select(kv => kv.Key));

            this.SendResponse(response);
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        private void Run()
        {
            var message = string.Format("{0} {1} is running on thread {2}.", this.GetType().Name, this.GetHashCode(), Thread.CurrentThread.ManagedThreadId);
            var targets = new[] { "Peej" };

            var response = new Response(message, targets, MessageFormat.Message, MessageType.Private);
            this.SendResponse(response);
        }

        #endregion
    }
}