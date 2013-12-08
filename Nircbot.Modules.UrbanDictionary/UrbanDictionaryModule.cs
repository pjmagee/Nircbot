// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UrbanDictionaryModule.cs" company="Patrick Magee">
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
//   The urban dictionary module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrbanDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;
    using Nircbot.Modules.UrbanDictionary.Api;
    using Nircbot.Modules.UrbanDictionary.Service;

    /// <summary>
    /// The urban dictionary module.
    /// </summary>
    public class UrbanDictionaryModule : BaseModule
    {
        /// <summary>
        /// The urban service.
        /// </summary>
        private readonly IUrbanService urbanService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrbanDictionaryModule" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="urbanService">The urban service.</param>
        /// <exception cref="System.ArgumentNullException">The urbanService is null.</exception>
        public UrbanDictionaryModule(IIrcClient ircClient, IUrbanService urbanService) : base(ircClient)
        {
            if (urbanService == null)
            {
                throw new ArgumentNullException("urbanService");
            }

            this.urbanService = urbanService;
        }

        /// <summary>
        /// Registers the commands.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Command}" />.
        /// </returns>
        public override IEnumerable<Command> RegisterCommands()
        {
            yield return new Command("!urban", this.UrbanCommand)
                             {
                                 Description = "Returns the first result of a term from UrbanDictionary",
                                 Accepts = MessageType.Both,
                                 Examples = new[]
                                                {
                                                    "!urban [search term]  i.e !urban Patrick Magee or !urban Superman",
                                                },
                                 LevelRequired = AccessLevel.None
                             };
        }

        /// <summary>
        /// Urban Dictionary command.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void UrbanCommand(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments)
        {
            message = message.TrimStart("!urban".ToCharArray()).Trim();
            this.urbanService.GetResultsAsync(message).ContinueWith(task => this.SendUrbanResponse(user, channel, messageType, messageFormat, task));
        }

        /// <summary>
        /// Creates the urban message.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="task">The task.</param>
        private void SendUrbanResponse(User user, string channel, MessageType messageType, MessageFormat messageFormat, Task<IUrbanResponse> task)
        {
            if (task.Result.Results.Any())
            {
                var targets = new[] { channel ?? user.Nick };
                IResult result = task.Result.Results.First();
                Response response = new Response(result.Definition, targets, messageFormat, messageType);
                this.SendResponse(response);
            }
        }
    }
}