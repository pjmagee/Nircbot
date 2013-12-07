// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandHandler.cs" company="Patrick Magee">
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
//   A command handling delegate. Called when a command is received.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Module
{
    using System.Collections.Generic;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc.Messages;

    /// <summary>
    /// A command handling delegate. Called when a command is received.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="channel">The channel.</param>
    /// <param name="messageType">Type of the message.</param>
    /// <param name="messageFormat">The message format.</param>
    /// <param name="message">The message.</param>
    /// <param name="arguments">The arguments.</param>
    public delegate void CommandHandler(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments);
   
}