// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleInfoModule.cs" company="Patrick Magee">
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
//   Defines the ModuleInfoModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Nircbot.Common.Extensions;
    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;

    /// <summary>
    /// The module info module.
    /// </summary>
    public class ModuleInfoModule : BaseModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleInfoModule" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        public ModuleInfoModule(IIrcClient ircClient) : base(ircClient)
        {

        }

        /// <summary>
        /// Registers the commands.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Command}" />.
        /// </returns>
        public override IEnumerable<Command> RegisterCommands()
        {
            var listModules = new Command("!modules", this.ListModules)
                                      {
                                          Description = "Provides information about the modules of the bot.",
                                          Examples = new [] { "!modules --list", "!modules --root", "!modules --examples" },
                                          LevelRequired = AccessLevel.None
                                      };

            IEnumerable<AccessLevel> accessLevels = Enum.GetValues(typeof(AccessLevel)).Cast<AccessLevel>();
            accessLevels.Do((level, i) => listModules.CreateArgument(level.ToString(), null));

            listModules.CreateArgument("examples");

            var listCommands = new Command("!module", this.ListCommands)
                                       {
                                           Description = "Lists the commands of a given module.",
                                           LevelRequired = AccessLevel.None,
                                           Accepts = MessageType.Both
                                       };


            listModules.CreateArgument("name");

            return new[] { listModules, listCommands };
        }

        /// <summary>
        /// Lists the commands of a given module.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void ListCommands(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments)
        {
            var targets = new[] { user.Nick };

            string name = null;

            if (arguments.TryGetValue("name", out name))
            {
                var module = this.IrcClient.Modules.FirstOrDefault(m => UserHasAccess(user, m) && m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (module != null)
                {
                    this.SendModuleCommands(user, messageType, module, targets);
                }
            }
        }

        /// <summary>
        /// Lists the modules.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void ListModules(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments)
        {
            var targets = new[] { user.Nick };

            if (arguments.None())
            {
                this.SendCommandUsageExamples(this, targets, messageType, messageFormat);
            }

            foreach (var key in arguments.Keys)
            {
                AccessLevel level;

                if (Enum.TryParse(key, ignoreCase: true, result: out level))
                {
                    foreach (var module in this.IrcClient.Modules.Where(m => m.Commands.Any(c => c.LevelRequired <= level && c.LevelRequired <= user.AccessLevel)))
                    {
                        var moduleInfoResponse = new Response("{0}: {1}".FormatWith(module.Name, module.Description), targets, MessageFormat.Notice, messageType);
                        this.SendResponse(moduleInfoResponse);
                    }
                }
            }

            if (arguments.ContainsKey("list"))
            {
                // For each module where the module has a command that is accessible by this user
                foreach (var module in this.IrcClient.Modules.Where(m => m.Commands.Any(c => c.LevelRequired <= user.AccessLevel)))
                {
                    var moduleInfoResponse = new Response("{0}: {1}".FormatWith(module.Name, module.Description), targets, MessageFormat.Notice, messageType);
                    this.SendResponse(moduleInfoResponse);
                }

                this.GetMoreInformation(messageType, targets);
            }

            if (arguments.ContainsKey("examples"))
            {
                // For each module where the module has a command that is accessible by this user
                foreach (var module in this.IrcClient.Modules.Where(m => m.Commands.Any(c => c.LevelRequired <= user.AccessLevel)))
                {
                    var response = new Response("{0}: {1}".FormatWith(module.Name, module.Description), targets, MessageFormat.Notice, messageType);
                    this.SendResponse(response);
                    this.SendCommandUsageExamples(module, targets, messageType, messageFormat);
                }
            }
        }

        /// <summary>
        /// Sends the usage example.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="targets">The targets.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        private void SendCommandUsageExamples(IModule module, IEnumerable<string> targets, MessageType messageType, MessageFormat messageFormat)
        {
            var response = new Response(string.Empty, targets, messageFormat, messageType);

            foreach (var command in module.Commands)
            {
                foreach (var example in command.Examples)
                {
                    response.Message = "{0}".FormatWith(example);
                    this.SendResponse(response);
                }
            }
        }

        /// <summary>
        /// Sends the module commands.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="module">The module.</param>
        /// <param name="targets">The targets.</param>
        private void SendModuleCommands(User user, MessageType messageType, IModule module, string[] targets)
        {
            // For each possible command where the command is accessible
            foreach (var command in module.Commands.Where(c => c.LevelRequired <= user.AccessLevel))
            {
                var response = new Response("{0}: {1}".FormatWith(command.Trigger, command.Description), targets, MessageFormat.Notice, messageType);
                this.SendResponse(response);

                response.Message = string.Empty;

                foreach (var argument in command.KnownArguments)
                {
                    response.Message += "{0}{1} {2}".FormatWith(command.ArgumentSplitter, argument.Key, argument.Value);
                }

                this.SendResponse(response);
            }
        }

        /// <summary>
        /// Sends a message about how to get more information on a module.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="targets">The targets.</param>
        private void GetMoreInformation(MessageType messageType, IEnumerable<string> targets)
        {
            var response = new Response("For more information: ", targets, MessageFormat.Notice, messageType);
            var command = this.Commands.FirstOrDefault(c => c.Trigger.Equals("!module", StringComparison.OrdinalIgnoreCase));
            response.Message += "Use command {0}".FormatWith(command.Trigger);

            foreach (var argument in command.KnownArguments)
            {
                response.Message += "{0}{1} {2}".FormatWith(command.ArgumentSplitter, argument.Key, argument.Value);
            }

            this.SendResponse(response);
        }

        /// <summary>
        /// Users the has access.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="module">The module.</param>
        /// <returns>
        /// True if the user has access to a command in the module, otherwise false.
        /// </returns>
        private static bool UserHasAccess(User user, IModule module)
        {
            return module.Commands.Any(c => c.LevelRequired <= user.AccessLevel);
        }
    }
}
