// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UrlShortenerModule.cs" company="Patrick Magee">
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
//   The url shortener module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrlShortener
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Text.RegularExpressions;

    using Nircbot.Common.Extensions;
    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;
    using Nircbot.Modules.UrlShortener.Services;

    /// <summary>
    /// The url shortener module.
    /// </summary>
    public class UrlShortenerModule : BaseModule
    {
        /// <summary>
        /// The cache.
        /// </summary>
        private readonly ObjectCache cache = MemoryCache.Default;

        /// <summary>
        /// The providers.
        /// </summary>
        private readonly IEnumerable<IUrlShortenerProvider> providers;

        /// <summary>
        /// The URL pattern
        /// </summary>
        private const string UrlPattern = @"(?<url>(?<protocol>(ht|f)tp(s?))\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*))";

        /// <summary>
        /// The URL regex
        /// </summary>
        private static readonly Regex UrlRegex = new Regex(UrlPattern, RegexOptions.Compiled);

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlShortenerModule" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="providers">The providers.</param>
        public UrlShortenerModule(IIrcClient ircClient, IEnumerable<IUrlShortenerProvider> providers) : base(ircClient)
        {
            this.providers = providers;
        }

        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>
        /// The providers.
        /// </value>
        public IEnumerable<IUrlShortenerProvider> Providers
        {
            get
            {
                return this.providers;
            }
        }

        /// <summary>
        /// Registers the commands.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Command}" />.
        /// </returns>
        public override IEnumerable<Command> RegisterCommands()
        {
            yield return new Command("!shorten", this.ShortenUrl)
            {
                Accepts = MessageType.Both,
                LevelRequired = AccessLevel.None,
                Examples = this.providers.Select(p => "!shorten http://example.com --{0}".FormatWith(p.Trigger)),
                Description = "Shortens a given url with a url shortening service provider",
            };
        }

        /// <summary>
        /// Shortens the URL.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void ShortenUrl(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> arguments)
        {
            foreach (IUrlShortenerProvider provider in this.providers)
            {
                if(arguments.ContainsKey(provider.Trigger))
                {
                    try
                    {
                        var url = UrlRegex.Match(message).Groups["url"].Value;
                        string shortUrl;
                        shortUrl = this.GetShortUrl(url, provider);
                        var response = new Response(shortUrl, new[] { channel ?? user.Nick }, messageFormat, messageType);
                        this.SendResponse(response);
                    }
                    catch (Exception e)
                    {
                        Trace.TraceError(e.Source);
                        Trace.TraceError(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// The get short url.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        private string GetShortUrl(string url, IUrlShortenerProvider provider)
        {
            string shortUrl;

            if (this.cache.Contains(url))
            {
                shortUrl = this.cache[url] as string;
            }
            else
            {
                shortUrl = provider.Shorten(url);
                var item = new CacheItem(url, shortUrl);
                var policy = new CacheItemPolicy() { SlidingExpiration = TimeSpan.FromDays(1d) };
                this.cache.Add(item, policy);
            }

            return shortUrl;
        }
    }
}