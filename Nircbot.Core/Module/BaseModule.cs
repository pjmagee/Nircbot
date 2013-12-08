// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseModule.cs" company="Patrick Magee">
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
//   The base module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Module
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Ninject;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;

    #endregion

    /// <summary>
    /// The base module.
    /// </summary>
    public abstract class BaseModule : IModule, IStartable
    {
        #region Fields

        /// <summary>
        /// The ircClient
        /// </summary>
        private readonly IIrcClient ircClient;

        /// <summary>
        /// The commands
        /// </summary>
        private List<Command> commands;

        /// <summary>
        /// The name
        /// <remarks>
        /// A backing field to set the optional module name.
        /// </remarks>
        /// </summary>
        private string name;

        /// <summary>
        /// The scheduled tasks
        /// </summary>
        private List<ScheduledTask> scheduledTasks;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModule" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <exception cref="System.ArgumentNullException">ircClient</exception>
        protected BaseModule(IIrcClient ircClient)
        {
            if (ircClient == null)
            {
                throw new ArgumentNullException("ircClient");
            }

            this.ircClient = ircClient;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the commands.
        /// </summary>
        /// <value>
        /// The commands.
        /// </value>
        public IEnumerable<Command> Commands
        {
            get
            {
                return this.commands;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets the irc client.
        /// </summary>
        /// <value>
        /// The irc client.
        /// </value>
        public IIrcClient IrcClient
        {
            get
            {
                return this.ircClient;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name
        {
            get
            {
                return this.name ?? this.GetType().Name;
            }

            set
            {
                this.name = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when [notice].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="notice">The notice.</param>
        public virtual void OnNotice(User user, string notice)
        {
        }

        /// <summary>
        /// Called when [private message].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="message">The message.</param>
        public virtual void OnPrivateMessage(User user, string message)
        {
        }

        /// <summary>
        /// Called when [public message].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="message">The message.</param>
        public virtual void OnPublicMessage(User user, string channel, string message)
        {
        }

        /// <summary>
        /// Called when [user joined].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        public virtual void OnUserJoined(User user, string channel)
        {
        }

        /// <summary>
        /// Called when [user kicked].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="message">The message.</param>
        public virtual void OnUserKicked(User user, string channel, string message)
        {
        }

        /// <summary>
        /// Called when [user left].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        public virtual void OnUserLeft(User user, string channel)
        {
        }

        /// <summary>
        /// Processes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Process(Request request)
        {
            this.commands.ForEach(command => command.Process(request));
        }

        /// <summary>
        /// Registers the commands.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Command}" />.
        /// </returns>
        public virtual IEnumerable<Command> RegisterCommands()
        {
            yield break;
        }

        /// <summary>
        /// Registers the tasks.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{ScheduledTask}" />.
        /// </returns>
        public virtual IEnumerable<ScheduledTask> RegisterTasks()
        {
            yield break;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            this.InitializeCommands();
            this.InitializeTasks();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            foreach (var scheduledTask in this.scheduledTasks)
            {
                scheduledTask.Cancel();
            }
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// Starts this instance.
        /// </summary>
        void IStartable.Start()
        {
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        void IStartable.Stop()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the users in channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns>
        /// The <see cref="IEnumerable{User}" />.
        /// </returns>
        protected IEnumerable<User> GetUsersInChannel(string channel)
        {
            return this.ircClient.GetUsersInChannel(channel);
        }

        /// <summary>
        /// Sends the response.
        /// </summary>
        /// <param name="response">The response.</param>
        public void SendResponse(IResponse response)
        {
            this.ircClient.SendResponse(response);
        }

        /// <summary>
        /// Initializes the commands.
        /// </summary>
        private void InitializeCommands()
        {
            this.commands = new List<Command>(this.RegisterCommands());

            foreach (var command in this.commands)
            {
                var knownArguments = command.KnownArguments.Select(pair => pair.Key + " " + string.Join("|", pair.Value ?? new[] { string.Empty }));

                var arguments = string.Join(string.Empty, knownArguments.Select(arg => string.Format("--{0}", arg)));

                Trace.TraceInformation("Registered command {0}", string.Format("{0} {1}", command.Trigger, arguments).Trim());
            }
        }

        /// <summary>
        /// The initialize tasks.
        /// </summary>
        private void InitializeTasks()
        {
            this.scheduledTasks = new List<ScheduledTask>(this.RegisterTasks());

            foreach (var scheduledTask in this.scheduledTasks)
            {
                Trace.TraceInformation("Starting task {0} on module {1}", scheduledTask.Name, this.Name ?? this.GetType().Name);
                ScheduledTask task = scheduledTask;
                Task.Factory.StartNew(task.Run, TaskCreationOptions.LongRunning);
            }
        }

        #endregion
    }
}
