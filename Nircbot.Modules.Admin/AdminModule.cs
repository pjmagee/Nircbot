// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminModule.cs" company="Patrick Magee">
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
//   The admin module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Admin
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;
    using Nircbot.Core.Services;

    #endregion

    /// <summary>
    /// The admin module.
    /// </summary>
    public class AdminModule : BaseModule
    {
        #region Fields

        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService userService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminModule" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="userService">The user service.</param>
        /// <exception cref="System.ArgumentNullException">userService</exception>
        public AdminModule(IIrcClient ircClient, IUserService userService) : base(ircClient)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("userService");
            }

            this.userService = userService;
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
            var join = new Command("!join", this.JoinChannel)
                           {
                               Description = "Commands the bot to join a channel on the network.",
                               LevelRequired = AccessLevel.None,
                               Accepts = MessageType.Both
                           };

            join.CreateArgument("channel");
            join.CreateArgument("key");

            var admins = new Command("!admins", this.ListAdmins)
                             {
                                 LevelRequired = AccessLevel.None, 
                                 Accepts = MessageType.Both,
                                 Description = "Lists information about the admins of the bot",
                             };
            
            return new[] { join, admins };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Joins the channel.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void JoinChannel(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("channel"))
            {
                if (arguments.ContainsKey("key"))
                {
                    this.IrcClient.Join(arguments["channel"], arguments["key"]);
                }
                else
                {
                    this.IrcClient.Join(arguments["channel"]);
                }
            }
        }

        /// <summary>
        /// Lists the admins.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void ListAdmins(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments)
        {
            var admins = this.userService.ListAdmins().Select(a => string.Format("{0} : {1}", a.Nick, a.Email));

            foreach (var admin in admins)
            {
                var response = new Response(admin, new[] { channel ?? user.Nick }, MessageFormat.Message, MessageType.Both);
                this.IrcClient.SendResponse(response);
            }
        }

        #endregion
    }
}
