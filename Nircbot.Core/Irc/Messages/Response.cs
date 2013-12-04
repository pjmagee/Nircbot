// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="Patrick Magee">
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
//   The response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Irc.Messages
{
    #region

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The response.
    /// </summary>
    public class Response : IResponse
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        public Response()
        {
            this.MessageType = MessageType.Public;
            this.MessageFormat = MessageFormat.Message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class. 
        /// Initializes a new instance of the <see cref="Response"/> struct.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="targets">
        /// The targets.
        /// </param>
        /// <param name="messageFormat">
        /// The message format.
        /// </param>
        /// <param name="messageType">
        /// Type of the message.
        /// </param>
        public Response(string message, IEnumerable<string> targets, MessageFormat messageFormat, MessageType messageType)
        {
            this.Message = message;
            this.Targets = targets;

            this.MessageType = messageType;
            this.MessageFormat = messageFormat;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the message format.
        /// </summary>
        /// <value>
        /// The message format.
        /// </value>
        public MessageFormat MessageFormat { get; set; }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>
        /// The type of the message.
        /// </value>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets the targets.
        /// </summary>
        /// <value>
        /// The targets.
        /// </value>
        public IEnumerable<string> Targets { get; set; }

        #endregion
    }
}