// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IrbService.cs" company="Patrick Magee">
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
//   The irb service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Ruby.Services
{
    using System;
    using System.Diagnostics;
    using System.Runtime.Caching;
    using System.Threading.Tasks;

    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;

    /// <summary>
    /// The irb service.
    /// </summary>
    public class IrbService : IIrbService
    {
        /// <summary>
        /// The module
        /// </summary>
        private readonly IIrcClient ircClient;

        /// <summary>
        /// The interactive sessions.
        /// </summary>
        private readonly ObjectCache interactiveSessions = MemoryCache.Default;

        /// <summary>
        /// Initializes a new instance of the <see cref="IrbService" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <exception cref="System.ArgumentNullException">If the ircClient is null.</exception>
        public IrbService(IIrcClient ircClient)
        {
            if (ircClient == null)
            {
                throw new ArgumentNullException("ircClient");
            }

            this.ircClient = ircClient;
        }

        /// <summary>
        /// Writes to session.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="message">The message.</param>
        public void WriteToSession(User user, string message)
        {
            var process = this.interactiveSessions[user.Nick] as Process;

            if (process != null)
            {
                process.StandardInput.WriteLine(message);
            }
        }

        /// <summary>
        /// Creates the session.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        public void CreateSession(User user, string channel)
        {
            if (!this.interactiveSessions.Contains(user.Nick))
            {
                var ironRuby = CreateProcess();
                this.AddUserToSession(user, ironRuby);
                ironRuby.Start();
                this.ReadFromSession(ironRuby, user, channel);
            }
        }

        /// <summary>
        /// Removes the session.
        /// </summary>
        /// <param name="user">The user.</param>
        public void RemoveSession(User user)
        {
            if (this.interactiveSessions.Contains(user.Nick))
            {
                this.interactiveSessions.Remove(user.Nick);
            }
        }

        /// <summary>
        /// Adds the user to session.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="ironRuby">The iron ruby.</param>
        private void AddUserToSession(User user, Process ironRuby)
        {
            var item = new CacheItem(user.Nick, ironRuby);
            var policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(5), RemovedCallback = this.KillOnRemoval };
            this.interactiveSessions.Add(item, policy);
        }

        /// <summary>
        /// Reads from session.
        /// </summary>
        /// <param name="irb">The irb.</param>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        private void ReadFromSession(Process irb, User user, string channel)
        {
            // Read all standard output
            Task.Factory.StartNew(() =>
                {
                    while (!irb.StandardError.EndOfStream)
                    {
                        string line = irb.StandardError.ReadLine();
                        var response = new Response(line, new[] { channel ?? user.Nick }, MessageFormat.Message, MessageType.Both);
                        this.ircClient.SendResponse(response);
                    }
                });

            // Read all error output
            Task.Factory.StartNew(() =>
                {
                    while (!irb.StandardOutput.EndOfStream)
                    {
                        string line = irb.StandardOutput.ReadLine();
                        var response = new Response(line, new[] { channel ?? user.Nick }, MessageFormat.Message, MessageType.Both);
                        this.ircClient.SendResponse(response);
                    }
                });
        }

        /// <summary>
        /// Creates the process.
        /// </summary>
        /// <returns>
        /// The <see cref="Process" />.
        /// </returns>
        private static Process CreateProcess()
        {
            var ironRuby = new Process
            {
                StartInfo = new ProcessStartInfo(RubyModule.IronRubyPath)
                {
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    ErrorDialog = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };

            return ironRuby;
        }

        /// <summary>
        /// Kills the process on removal from cache.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        private void KillOnRemoval(CacheEntryRemovedArguments arguments)
        {
            // Lets kill the process before removing it from our in-memory cache
            var process = arguments.CacheItem.Value as Process;

            try
            {
                if (process != null)
                {
                    process.Kill();
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }
        }
    }
}