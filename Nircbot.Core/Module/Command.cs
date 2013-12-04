// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Command.cs" company="Patrick Magee">
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
//   The commandHandlerHandler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Module
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    using Nircbot.Core.Irc.Messages;

    #endregion

    /// <summary>
    /// The commandHandlerHandler.
    /// </summary>
    public class Command
    {
        #region Fields

        /// <summary>
        /// The knownArguments
        /// </summary>
        private readonly IDictionary<string, string[]> knownArguments;

        /// <summary>
        /// The regex
        /// </summary>
        private readonly Regex regex;
        private string p;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class.
        /// <remarks>
        /// Defaults to accepting public messages.
        /// </remarks>
        /// </summary>
        public Command()
        {
            this.Accepts = MessageType.Both;
            this.knownArguments = new Dictionary<string, string[]>();
            this.ArgumentSplitter = "--";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param name="trigger">The trigger.</param>
        /// <param name="commahdHandler">The commahd handler.</param>
        public Command(string trigger, CommandHandler commahdHandler) : this()
        {
            this.CommandHandler = commahdHandler;
            this.Trigger = trigger;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="trigger">The trigger.</param>
        /// <param name="perform">The perform.</param>
        public Command(string trigger, Action perform) : this()
        {
            this.Trigger = trigger;
            this.Perform = perform;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param name="trigger">The trigger.</param>
        /// <param name="knownArguments">The knownArguments.</param>
        /// <param name="commandHandler">The command handler.</param>
        public Command(string trigger, IDictionary<string, string[]> knownArguments, CommandHandler commandHandler)
        {
            this.Trigger = trigger;
            this.CommandHandler = commandHandler;
            this.knownArguments = knownArguments;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param name="trigger">The trigger.</param>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="argument">The argument.</param>
        /// <param name="options">The options.</param>
        public Command(string trigger, CommandHandler commandHandler, string argument, params string[] options) : this(trigger, new Dictionary<string, string[]> { { argument, options } }, commandHandler)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param name="regex">The regex.</param>
        /// <param name="commandHandler">The command handler.</param>
        public Command(Regex regex, CommandHandler commandHandler)
        {
            this.CommandHandler = commandHandler;
            this.Trigger = regex.ToString();
            this.regex = new Regex(this.Trigger, RegexOptions.Compiled);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param name="regex">The regex.</param>
        /// <param name="perform">The perform.</param>
        public Command(Regex regex, Action perform)
        {
            this.Trigger = regex.ToString();
            this.Perform = perform;
            this.regex = new Regex(Trigger, RegexOptions.Compiled);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the accepts.
        /// </summary>
        /// <value>
        /// The accepts.
        /// </value>
        /// <trigger>
        /// The accepts.
        /// </trigger>
        public MessageType Accepts { get; set; }

        /// <summary>
        /// Gets or sets the argument splitter.
        /// </summary>
        /// <value>
        /// The argument splitter.
        /// </value>
        /// <trigger>
        /// The argument splitter.
        /// </trigger>
        public string ArgumentSplitter { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the command handler handler.
        /// </summary>
        /// <value>
        /// The command handler handler.
        /// </value>
        public CommandHandler CommandHandler { get; set; }

        /// <summary>
        /// Gets or sets the perform.
        /// <remarks>
        /// Perform a given action when receiving this commandHandlerHandler.
        /// </remarks>
        /// </summary>
        /// <value>
        /// The perform.
        /// </value>
        public Action Perform { get; set; }

        /// <summary>
        /// Gets the known arguments.
        /// </summary>
        /// <value>
        /// The known arguments.
        /// </value>
        public IDictionary<string, string[]> KnownArguments
        {
            get
            {
                return this.knownArguments;
            }
        }

        /// <summary>
        /// Gets or sets the access level.
        /// </summary>
        /// <trigger>
        /// The access level.
        /// </trigger>
        public AccessLevel LevelRequired { get; set; }

        /// <summary>
        /// Gets or sets the trigger.
        /// </summary>
        /// <trigger>
        /// The trigger.
        /// </trigger>
        public string Trigger { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a trigger indicating whether [is regex].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is regex]; otherwise, <c>false</c>.
        /// </value>
        /// <trigger>
        ///   <c>true</c> if [is regex]; otherwise, <c>false</c>.
        /// </trigger>
        private bool IsRegex
        {
            get
            {
                return this.regex != null && !string.IsNullOrWhiteSpace(this.Trigger);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates the argument and adds it to the known arguments dictionary.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="options">The options.</param>
        public void CreateArgument(string argument, params string[] options)
        {
            this.KnownArguments.Add(argument, options);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        internal void Process(Request request)
        {
            if (this.IsCommand(request.Message) && request.User.AccessLevel < this.LevelRequired)
            {
                Trace.TraceWarning("{0} tried to access commandHandlerHandler {1} using {2}", request.User.Nick, this.Trigger, request.Message);
            }

            if (this.IsCommand(request.Message) && request.User.AccessLevel >= this.LevelRequired)
            {
                Trace.TraceInformation("{0} was called with message: {1}", this.Trigger, request.Message);

                var arguments = this.ParseArguments(request.Message);

                if (this.CommandHandler != null)
                {
                    try
                    {
                        this.CommandHandler(request.User, request.Channel, request.MessageType, request.MessageFormat, request.Message, arguments);
                    }
                    catch (Exception e)
                    {
                        Trace.TraceError("There was an error executing a commandHandler for {0}", request.Message);
                        Trace.TraceError(e.Message);
                    }
                }

                if (this.Perform != null)
                {
                    try
                    {
                        this.Perform();
                    }
                    catch (Exception e)
                    {
                        Trace.TraceError("There was an error executing a Perform action for {0}", request.Message);
                        Trace.TraceError(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Parses the messsage to produce any known arguments.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// The arguments if any or null.
        /// </returns>
        private Dictionary<string, string> ParseArguments(string message)
        {
            if (this.IsRegex)
            {
                Match match = this.regex.Match(message);
                Group commandGroup = match.Groups["commandHandlerHandler"];

                if (commandGroup.Success)
                {
                    message = this.StripCommand(commandGroup.Value, message);
                }
            }
            else
            {
                message = this.StripCommand(this.Trigger, message);
            }

            var dictionary = message
                        .Split(new[] { this.ArgumentSplitter }, StringSplitOptions.RemoveEmptyEntries)
                        .ToLookup(value => value.Split(' ')[0], value => value.TrimStart(value.Split(' ')[0].ToCharArray()).Trim())
                        .ToDictionary(lu => lu.Key, lu => string.Join(" ", lu).Trim());

            foreach (var pair in dictionary)
            {
                Trace.TraceInformation("Argument parsed: {0}:{1}", pair.Key, pair.Value);
            }

            return dictionary;
        }

        /// <summary>
        /// Determines whether the specified message is commandHandlerHandler.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// The <see cref="bool" />.
        /// </returns>
        private bool IsCommand(string message)
        {
            return (this.IsRegex && this.regex.IsMatch(message)) || message.StartsWith(this.Trigger ?? string.Empty);
        }

        /// <summary>
        /// Strips the commandHandlerHandler.
        /// </summary>
        /// <param name="command">The commandHandlerHandler.</param>
        /// <param name="message">The message.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        private string StripCommand(string command, string message)
        {
            if (message.StartsWith(command))
            {
                message = message.Remove(0, command.Length);
            }

            return message;
        }

        #endregion
    }
}