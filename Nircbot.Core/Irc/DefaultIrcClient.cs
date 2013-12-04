// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultIrcClient.cs" company="Patrick Magee">
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
//   The default ircClient.
//   <remarks>
//   This uses the third party <see cref="IrcDotNet" /> library.
//   </remarks>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Irc
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Threading;
    using System.Threading.Tasks;

    using IrcDotNet;
    using IrcDotNet.Ctcp;

    using Nircbot.Core.Connections;
    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;
    using Nircbot.Core.Services;

    #endregion

    /// <summary>
    /// The default ircClient.
    /// <remarks>
    /// This uses the third party <see cref="IrcDotNet" /> library.
    /// </remarks>
    /// </summary>
    public sealed class DefaultIrcClient : AbstractIrcClient
    {
        #region Fields

        /// <summary>
        /// The cache.
        /// </summary>
        private readonly ObjectCache cache = new MemoryCache("Users");

        /// <summary>
        /// The CTCP ircClient
        /// </summary>
        private readonly CtcpClient ctcpClient;

        /// <summary>
        /// The irc ircClient
        /// </summary>
        private readonly IrcClient ircClient;

        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// The channels
        /// </summary>
        private List<string> channels = new List<string>();

        /// <summary>
        /// The is user initiated disconnect
        /// </summary>
        private bool isUserInitiatedDisconnect;

        /// <summary>
        /// The network
        /// </summary>
        private INetwork network;

        /// <summary>
        /// The server
        /// </summary>
        private IServer server;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultIrcClient"/> class.
        /// </summary>
        /// <param name="userService">
        /// The user service.
        /// </param>
        /// <param name="moduleFactory">
        /// The module factory.
        /// </param>
        public DefaultIrcClient(IUserService userService, IModuleFactory moduleFactory) : base(moduleFactory)
        {
            this.userService = userService;
            this.ircClient = new IrcClient();
            this.ctcpClient = new CtcpClient(this.ircClient);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [is connected].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is connected]; otherwise, <c>false</c>.
        /// </value>
        public override bool IsConnected
        {
            get
            {
                return this.ircClient != null && this.ircClient.IsConnected;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Bans the specified user.
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
            IrcChannel ircChannel = this.GetChannelByName(channel);

            if (ircChannel != null)
            {
                // todo: ban user
            }
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
            this.Connect(network.Servers.FirstOrDefault());
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

            this.ircClient.Connected += this.OnIrcClientOnConnected;
            this.ircClient.ChannelListReceived += this.IrcClientOnChannelListReceived;
            this.ircClient.Registered += this.IrcClientOnRegistered;
            this.ircClient.RawMessageReceived += this.IrcClientOnRawMessageReceived;
            this.ircClient.RawMessageSent += this.IrcClientOnRawMessageSent;
            this.ircClient.Connect(server.Address, server.Port.GetValueOrDefault(6667), server.Ssl, this.GetRegistration(this.network));
            this.ircClient.Disconnected += this.IrcClientOnDisconnected;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            this.StopModules();
            this.UnwireEvents();
            this.ircClient.Dispose();
        }

        /// <summary>
        /// Gets the users in the channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{User}"/>.
        /// </returns>
        public override IEnumerable<User> GetUsersInChannel(string channel)
        {
            var ircChannel = this.ircClient.Channels.FirstOrDefault(c => c.Name.Equals(channel, StringComparison.OrdinalIgnoreCase));
            
            return from channelUser in ircChannel.Users 
                   select this.userService.GetUserByHost(channelUser.User.HostName);
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
            Trace.TraceInformation("Joining channel {0}", channel);

            if (string.IsNullOrWhiteSpace(key))
            {
                this.ircClient.Channels.Join(channel);
            }
            else
            {
                this.ircClient.Channels.Join(Tuple.Create(channel, key));
            }
        }

        /// <summary>
        /// Kicks the specified user.
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
            IrcChannel ircChannel = this.GetChannelByName(channel);

            if (ircChannel != null)
            {
                ircChannel.Kick(user, reason);
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
            Trace.TraceInformation("Parting channel {0} ({1})", channel, message);

            if (string.IsNullOrWhiteSpace(message))
            {
                this.ircClient.Channels.Leave(channel);
            }
            else
            {
                this.ircClient.Channels.Leave(new[] { channel }, message);
            }
        }

        /// <summary>
        /// Quits with the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void Quit(string message = null)
        {
            if (this.IsConnected)
            {
                Trace.TraceInformation("Quitting.{0}", message ?? string.Empty.PadLeft(1));

                this.isUserInitiatedDisconnect = true;
                this.ircClient.Quit(message);
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
            this.LogResponse(response);

            if (response.MessageType == MessageType.Both)
            {
                IEnumerable<string> channels = this.GetChannelsForResponse(response);
                IEnumerable<string> users = this.GetUsersForResponse(response).Select(t => t.Name);

                var targets = channels.Concat(users);

                this.SendResponse(response, targets);
            }

            if (response.MessageType == MessageType.Public)
            {
                var targets = this.GetChannelsForResponse(response);
                this.SendResponse(response, targets);
            }

            if (response.MessageType == MessageType.Private)
            {
                var targets = this.GetUsersForResponse(response);
                this.SendResponse(response, targets.Select(t => t.Name));
            }
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
            Trace.TraceInformation("Setting topic: {0} ({1})", topic, channel);

            IrcChannel ircChannel = this.GetChannelByName(channel);

            if (ircChannel != null)
            { 
                ircChannel.SetTopic(topic);
            }
        }

        /// <summary>
        /// Unbans the specified user.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        public override void Unban(string channel, string user)
        {
            IrcChannel ircChannel = this.GetChannelByName(channel);

            if (ircChannel != null)
            {
                // unban
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Channels the on message received.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="IrcMessageEventArgs"/> instance containing the event data.
        /// </param>
        private void ChannelOnMessageReceived(object sender, IrcMessageEventArgs e)
        {
            var ircChannel = (IrcChannel)sender;

            if (e.Source is IrcUser)
            {
                var sourceUser = (IrcUser)e.Source;
                var user = this.userService.GetUserByHost(sourceUser.HostName) ?? this.GetOrCreateGuestUser(sourceUser);
                var request = new Request { Channel = ircChannel.Name, MessageFormat = MessageFormat.Message, MessageType = MessageType.Public, User = user, Message = e.Text };

                this.LogRequest(request);

                Parallel.ForEach(this.Modules, module =>
                {
                    module.OnPublicMessage(user, ircChannel.Name, e.Text);
                    module.Process(request);           
                });
            }
        }

        /// <summary>
        /// Channels the on topic changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="EventArgs"/> instance containing the event data.
        /// </param>
        private void ChannelOnTopicChanged(object sender, EventArgs e)
        {
            var sourceChannel = (IrcChannel)sender;
        }

        /// <summary>
        /// Gets the action targets.
        /// </summary>
        /// <param name="targets">
        /// The targets.
        /// </param>
        /// <returns>
        /// The <see cref="IList{IIrcMessageTarget}"/>.
        /// </returns>
        private IList<IIrcMessageTarget> GetActionTargets(IEnumerable<string> targets)
        {
            IEnumerable<IIrcMessageTarget> ircUsers = this.ircClient.Users.AsEnumerable<IIrcMessageTarget>();
            IEnumerable<IIrcMessageTarget> ircChannels = this.ircClient.Channels.AsEnumerable<IIrcMessageTarget>();

            return (from target in targets
                    from messageTarget in ircUsers.Concat(ircChannels)
                    where messageTarget.Name.Equals(target, StringComparison.OrdinalIgnoreCase)
                    select messageTarget).ToList();
        }

        /// <summary>
        /// Gets the name of the channel by.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <returns>
        /// The <see cref="IrcChannel"/>.
        /// </returns>
        private IrcChannel GetChannelByName(string channel)
        {
            return this.ircClient.Channels.FirstOrDefault(c => c.Name.Equals(channel, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets the channels for response.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The channel names.
        /// </returns>
        private IEnumerable<string> GetChannelsForResponse(IResponse response)
        {
            // Task.Factory.StartNew(() => this.ircClient.ListChannels());
            var targets = from channel in this.ircClient.Channels.Select(c => c.Name).Concat(this.channels).Distinct()
                          from target in response.Targets
                          where channel.Equals(target, StringComparison.OrdinalIgnoreCase)
                          select channel;

            return targets;
        }

        /// <summary>
        /// Gets the or create guest user.
        /// </summary>
        /// <param name="ircUser">
        /// The irc user.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        private User GetOrCreateGuestUser(IrcUser ircUser)
        {
            if (this.cache.Contains(ircUser.NickName))
            {
                Trace.TraceInformation("Returning {0} from cache", ircUser.NickName);
                return this.cache[ircUser.NickName] as User;    
            }

            Trace.TraceInformation("Adding {0} to cache", ircUser.NickName);

            CacheItem item = new CacheItem(ircUser.NickName ?? ircUser.NickName, new User { AccessLevel = AccessLevel.Guest, Host = ircUser.HostName, Nick = ircUser.NickName, Email = string.Empty, Id = Guid.Empty });
            this.cache.Add(item, new CacheItemPolicy { Priority = CacheItemPriority.Default, SlidingExpiration = TimeSpan.FromMinutes(30), RemovedCallback = this.OnRemoved });
            return this.cache[ircUser.NickName] as User;

        }

        /// <summary>
        /// Gets the registration.
        /// </summary>
        /// <param name="network">
        /// The network.
        /// </param>
        /// <returns>
        /// The <see cref="IrcUserRegistrationInfo"/>.
        /// </returns>
        private IrcUserRegistrationInfo GetRegistration(INetwork network)
        {
            return new IrcUserRegistrationInfo
                       {
                           NickName = network.Identity.NickName, 
                           Password = network.Identity.Password, 
                           RealName = network.Identity.RealName, 
                           UserName = network.Identity.UserName, 
                           UserModes = new Collection<char>(), 
                       };
        }

        /// <summary>
        /// Gets the users for response.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{IIrcMessageTarget}"/>.
        /// </returns>
        private IEnumerable<IIrcMessageTarget> GetUsersForResponse(IResponse response)
        {
            var targets = from user in this.ircClient.Users
                          from target in response.Targets
                          where user.NickName.Equals(target, StringComparison.OrdinalIgnoreCase)
                          select user as IIrcMessageTarget;

            Trace.TraceInformation("Users for response: {0}", string.Join(", ", targets.Select(t => t.Name)));

            return targets;
        }

        /// <summary>
        /// Ircs the ircClient on channel list received.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="IrcChannelListReceivedEventArgs"/> instance containing the event data.
        /// </param>
        private void IrcClientOnChannelListReceived(object sender, IrcChannelListReceivedEventArgs e)
        {
            this.channels = new List<string>(from info in e.Channels select info.Name);
        }

        /// <summary>
        /// Ircs the ircClient on disconnected.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="EventArgs"/> instance containing the event data.
        /// </param>
        private void IrcClientOnDisconnected(object sender, EventArgs e)
        {
            var reconnectCount = 1;

            this.UnwireEvents();
            
            if (!this.isUserInitiatedDisconnect)
            {
                Trace.TraceWarning("ircClient disconnected from {0} unintentially.", this.server.Address);

                while (!this.IsConnected)
                {
                    Trace.TraceInformation("Attempting to reconnect to network {0}", this.network.Name);

                    this.Connect(this.network);

                    if (!this.IsConnected)
                    {
                        Trace.TraceWarning("Failed whilst attempting reconnection attempt #{0}", reconnectCount);

                        Thread.Sleep(TimeSpan.FromSeconds(30));
                        reconnectCount++;
                    }
                }
            }
        }

        /// <summary>
        /// Ircs the ircClient on raw message received.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="IrcRawMessageEventArgs"/> instance containing the event data.
        /// </param>
        private void IrcClientOnRawMessageReceived(object sender, IrcRawMessageEventArgs e)
        {
           // Trace.TraceInformation("{0}", e.RawContent);
        }

        /// <summary>
        /// Ircs the ircClient on raw message sent.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="IrcRawMessageEventArgs"/> instance containing the event data.
        /// </param>
        private void IrcClientOnRawMessageSent(object sender, IrcRawMessageEventArgs e)
        {
           // Trace.TraceInformation("{0}", e.RawContent);
        }

        /// <summary>
        /// Ircs the ircClient on registered.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The <see cref="EventArgs"/> instance containing the event data.
        /// </param>
        private void IrcClientOnRegistered(object sender, EventArgs eventArgs)
        {
            this.ircClient.LocalUser.JoinedChannel += this.LocalUserOnJoinedChannel;
            this.ircClient.LocalUser.LeftChannel += this.LocalUserOnLeftChannel;
            this.ircClient.LocalUser.NoticeReceived += this.LocalUserOnNoticeReceived;
            this.ircClient.LocalUser.MessageReceived += this.LocalUserOnMessageReceived;

            if (this.SupportsIdentification)
            {
                Trace.TraceInformation("Attempting to identify on network: {0}", this.network.Name);
                this.ircClient.LocalUser.SendMessage("nickserv", string.Format("identify {0}", this.network.Identity.Password));
            }
            else
            {
                this.JoinChannels();
            }
        }

        /// <summary>
        /// Joins the channels.
        /// </summary>
        private void JoinChannels()
        {
            foreach (var channel in this.network.Channels)
            {
                this.Join(channel.Name, channel.Key);
            }
        }

        /// <summary>
        /// Locals the user on joined channel.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="IrcChannelEventArgs"/> instance containing the event data.
        /// </param>
        private void LocalUserOnJoinedChannel(object sender, IrcChannelEventArgs e)
        {
            e.Channel.MessageReceived += this.ChannelOnMessageReceived;
            e.Channel.TopicChanged += this.ChannelOnTopicChanged;
        }

        /// <summary>
        /// Locals the user on left channel.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="IrcChannelEventArgs"/> instance containing the event data.
        /// </param>
        private void LocalUserOnLeftChannel(object sender, IrcChannelEventArgs e)
        {
            e.Channel.MessageReceived -= this.ChannelOnMessageReceived;
            e.Channel.TopicChanged -= this.ChannelOnTopicChanged;
        }

        /// <summary>
        /// Locals the user on message received.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="IrcMessageEventArgs"/> instance containing the event data.
        /// </param>
        private void LocalUserOnMessageReceived(object sender, IrcMessageEventArgs e)
        {
            Trace.TraceInformation("Private Message received: {0}");

            var ircUser = (IrcUser)e.Source;

            if (ircUser != null)
            {
                var user = this.userService.GetUserByHost(ircUser.HostName) ?? this.GetOrCreateGuestUser(ircUser);
                var request = new Request { Channel = null, MessageFormat = MessageFormat.Message, MessageType = MessageType.Private, User = user, Message = e.Text };

                this.LogRequest(request);

                Parallel.ForEach(this.Modules, module =>
                {
                    module.OnPrivateMessage(user, e.Text);
                    module.Process(request);
                });
            }
        }

        /// <summary>
        /// Locals the user on notice received.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="IrcMessageEventArgs"/> instance containing the event data.
        /// </param>
        private void LocalUserOnNoticeReceived(object sender, IrcMessageEventArgs e)
        {
            if (e.Source is IrcUser)
            {
                var sourceUser = e.Source as IrcUser;

                Trace.TraceInformation("{0} {1} sent a NOTICE: {2}", sourceUser.NickName, sourceUser.HostName, e.Text);

                if (this.SupportsIdentification && this.IsNickServNotice(sourceUser.NickName, e.Text))
                {
                    this.JoinChannels();
                }
                else
                {
                    var user = this.userService.GetUserByHost(sourceUser.HostName) ?? this.GetOrCreateGuestUser(sourceUser);
                    var request = new Request { Channel = null, MessageFormat = MessageFormat.Notice, MessageType = MessageType.Private, User = user, Message = e.Text };

                    this.LogRequest(request);

                    Parallel.ForEach(this.Modules, module =>
                    {
                        module.OnNotice(user, e.Text);
                        module.Process(request);
                    });
                }
            }
        }

        /// <summary>
        /// The log request.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        private void LogRequest(IRequest request)
        {
            if (request.MessageType == MessageType.Private)
            {
                Trace.TraceInformation("{0} : {1} : {2} : {3}", request.User.Nick, request.MessageFormat, request.MessageType, request.Message);
            }

            if (request.MessageType == (MessageType.Public | MessageType.Both))
            {
                Trace.TraceInformation("{0} : {1} : {2} : {3} : {4}", request.User.Nick, request.Channel ?? string.Empty, request.MessageFormat, request.MessageType, request.Message);
            }
        }

        /// <summary>
        /// Logs the response.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        private void LogResponse(IResponse response)
        {
            Trace.TraceInformation("Response: {0} : {1} : {2} : {3}", response.Message, response.MessageFormat, response.MessageType, string.Join(",", response.Targets));
        }

        /// <summary>
        /// Called when [irc ircClient on connected].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The <see cref="EventArgs"/> instance containing the event data.
        /// </param>
        private void OnIrcClientOnConnected(object sender, EventArgs args)
        {
            this.StartModules();
        }

        /// <summary>
        /// Called when [removed].
        /// </summary>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        private void OnRemoved(CacheEntryRemovedArguments arguments)
        {
            IrcUser ircUser = arguments.CacheItem.Value as IrcUser;

            Trace.TraceInformation("User {0} was removed from cache", ircUser.NickName);
        }

        /// <summary>
        /// Sends the response.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <param name="targets">
        /// The targets.
        /// </param>
        private void SendResponse(IResponse response, IEnumerable<string> targets)
        {
            if (!targets.Any())
            {
                Trace.TraceWarning("There were no targets for the following response: ");
                return;
            }
            
            if (response.MessageFormat == MessageFormat.Message)
            {
                this.ircClient.LocalUser.SendMessage(targets, response.Message);
            }
            else if (response.MessageFormat == MessageFormat.Notice)
            {
                this.ircClient.LocalUser.SendNotice(targets, response.Message);
            }
            else if (response.MessageFormat == MessageFormat.Action)
            {
                this.ctcpClient.SendAction(this.GetActionTargets(targets), response.Message);
            }
        }

        /// <summary>
        /// Starts the modules.
        /// </summary>
        private void StartModules()
        {
            foreach (var module in this.Modules)
            {
                Trace.TraceInformation("Starting module {0}", module.Name);

                module.Start();
            }
        }

        /// <summary>
        /// Stops the modules.
        /// </summary>
        private void StopModules()
        {
            Trace.TraceInformation("Stopping modules.");

            Parallel.ForEach(this.Modules, module => module.Stop()); 
        }

        /// <summary>
        /// Unwires the events.
        /// </summary>
        private void UnwireEvents()
        {
            Trace.TraceInformation("Unwireing events.");

            this.ircClient.ChannelListReceived -= this.IrcClientOnChannelListReceived;
            this.ircClient.LocalUser.JoinedChannel -= this.LocalUserOnJoinedChannel;
            this.ircClient.LocalUser.LeftChannel -= this.LocalUserOnLeftChannel;
            this.ircClient.LocalUser.MessageReceived -= this.LocalUserOnMessageReceived;
            this.ircClient.Registered -= this.IrcClientOnRegistered;
            this.ircClient.LocalUser.NoticeReceived -= this.LocalUserOnNoticeReceived;
            this.ircClient.RawMessageReceived -= this.IrcClientOnRawMessageReceived;
            this.ircClient.RawMessageSent -= this.IrcClientOnRawMessageSent;
            this.ircClient.Disconnected -= this.IrcClientOnDisconnected;
            this.ircClient.Connected -= this.OnIrcClientOnConnected;

            this.StopModules();
        }

        #endregion
    }
}