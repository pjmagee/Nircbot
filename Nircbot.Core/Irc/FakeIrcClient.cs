// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeIrcClient.cs" company="Patrick Magee">
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
//   The fake ircClient.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Irc
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Nircbot.Core.Connections;
    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;

    #endregion

    /// <summary>
    /// The fake ircClient.
    /// </summary>
    public sealed class FakeIrcClient : AbstractIrcClient
    {
        #region Static Fields

        /// <summary>
        /// The random
        /// </summary>
        private static readonly Random random;

        #endregion

        #region Fields

        /// <summary>
        /// The cancellation token source
        /// </summary>
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// The network
        /// </summary>
        private INetwork network;

        /// <summary>
        /// The runnable task
        /// </summary>
        private Task runnableTask;

        /// <summary>
        /// The server
        /// </summary>
        private IServer server;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="FakeIrcClient"/> class. 
        /// </summary>
        static FakeIrcClient()
        {
            random = new Random();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeIrcClient"/> class.
        /// </summary>
        /// <param name="moduleFactory">
        /// The module factory.
        /// </param>
        public FakeIrcClient(IModuleFactory moduleFactory) : base(moduleFactory)
        {
            Console.WriteLine("{0} : {1}", this.GetType().Name, this.GetHashCode());
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Bans the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="reason">
        /// The reason.
        /// </param>
        public override void Ban(string channel, string user, string reason = null)
        {
            Console.WriteLine("Kicked {0} from {1} ({2})", user, channel, reason);
        }

        /// <summary>
        /// Connects the specified network.
        /// </summary>
        /// <param name="network">
        /// The network.
        /// </param>
        public override void Connect(INetwork network)
        {
            this.network = network;
            this.server = network.Servers.FirstOrDefault();
            this.FakeConnect();
        }

        /// <summary>
        /// Connects the specified server.
        /// </summary>
        /// <param name="server">
        /// The server.
        /// </param>
        public override void Connect(IServer server)
        {
            this.server = server;
            this.FakeConnect();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public override void Dispose()
        {
            Console.WriteLine("Disposed underlying ircClient and all resources.");
            
        }

        /// <summary>
        /// Gets the users in channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public override IEnumerable<User> GetUsersInChannel(string channel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Joins the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        public override void Join(string channel, string key = null)
        {
            Console.WriteLine("Joined channel {0} with key ({1})", channel, key);
        }

        /// <summary>
        /// Kicks the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="reason">
        /// The reason.
        /// </param>
        public override void Kick(string channel, string user, string reason = null)
        {
            Console.WriteLine("Kicked {0} from {1} ({2})", user, channel, reason);
        }

        /// <summary>
        /// Called when [public message received].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public void OnPublicMessageReceived(User user, string channel, string message)
        {
            foreach (var module in this.Modules)
            {
                module.OnPublicMessage(user, channel, message);
            }
        }

        /// <summary>
        /// Parts the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void Part(string channel, string message = null)
        {
            Console.WriteLine("Parted from channel {0} with message {1}", channel, message);
        }

        /// <summary>
        /// Quits the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void Quit(string message = null)
        {
            Console.WriteLine("Quit {0} with message {0}", this.network.Name, message);
        }

        /// <summary>
        /// The run.
        /// </summary>
        public void Run()
        {
            var moduleTasks = new List<Task>();

            foreach (var module in this.Modules)
            {
                moduleTasks.Add(Task.Factory.StartNew(() => module.Start(), TaskCreationOptions.DenyChildAttach));
            }

            Task.WaitAll(moduleTasks.ToArray());

            var user = this.CreateGuestUser();

            while (true)
            {
                bool start = Convert.ToBoolean(Convert.ToInt16(random.Next(0, 2)));
                
                Console.WriteLine("ircClient {0} listening on thread {1}", this.GetHashCode(), Thread.CurrentThread.ManagedThreadId);

                this.OnPublicMessageReceived(user, "channel", start ? "start" : "stop");
                this.OnPublicMessageReceived(user, "channel", "http://www.youtube.com/watch?v=PFtdi9n4PxM");
                this.OnPublicMessageReceived(user, "channel", "!help");
                this.OnPrivateMessageReceived(user, "!help");

                this.OnUserJoined(user, "channel");
                this.OnUserLeft(user, "channel");
                this.OnNoticeReceived(user, "notice");

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        /// <summary>
        /// Sends the response.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        public override void SendResponse(IResponse response)
        {
            Console.WriteLine("Sent message to {0}", string.Join(", ", response.Targets));
        }

        /// <summary>
        /// Sets the topic.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="topic">
        /// The topic.
        /// </param>
        public override void SetTopic(string channel, string topic)
        {
            Console.WriteLine("Set topic in {0} to {1}", channel, topic);
        }

        /// <summary>
        /// Unbans the specified channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        public override void Unban(string channel, string user)
        {
            Console.WriteLine("Unbanned {0} from {1}", user, channel);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the guest user.
        /// </summary>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        private User CreateGuestUser()
        {
            return new User { AccessLevel = AccessLevel.Guest, Host = "hostname", Nick = "nickname" };
        }

        /// <summary>
        /// Fakes the connect.
        /// </summary>
        private void FakeConnect()
        {
            if (this.cancellationTokenSource == null) this.cancellationTokenSource = new CancellationTokenSource();

            if (this.runnableTask == null) this.runnableTask = new Task(this.Run, this.cancellationTokenSource.Token, TaskCreationOptions.LongRunning);

            if (this.runnableTask.Status == TaskStatus.Canceled || this.runnableTask.Status == TaskStatus.Created)
            {
                this.runnableTask.Start();
                this.IsConnected = true;
            }

            if (this.network != null)
            {
                Console.Write("Connect to network {0}", this.network.Name);

                if (this.server != null)
                {
                    Console.Write(" on server {0}", this.server.Address);
                }
            }
            else if (this.server != null)
            {
                Console.WriteLine("Connected to server {0}", this.server.Address);
            }
        }

        /// <summary>
        /// Called when [notice received].
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="notice">
        /// The notice.
        /// </param>
        private void OnNoticeReceived(User source, string notice)
        {
            foreach (var module in this.Modules)
            {
                module.OnNotice(source, notice);
            }
        }

        /// <summary>
        /// Called when [private message received].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        private void OnPrivateMessageReceived(User user, string message)
        {
            foreach (var module in this.Modules)
            {
                module.OnPrivateMessage(user, message);
            }
                
        }

        /// <summary>
        /// Called when [user joined].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        private void OnUserJoined(User user, string channel)
        {
            foreach (var module in this.Modules)
            {
                module.OnUserJoined(user, channel);
            }
        }

        /// <summary>
        /// Called when [user left].
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        private void OnUserLeft(User user, string channel)
        {
            foreach (var module in this.Modules)
            {
                module.OnUserLeft(user, channel);
            }
        }

        #endregion
    }
}