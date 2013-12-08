// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TinyUrlShortener.cs" company="Patrick Magee">
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
//   The tiny url shortner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrlShortener.Services.Tinyurl
{
    using System;
    using System.Diagnostics;
    using System.Net;

    /// <summary>
    /// The tiny url shortner.
    /// </summary>
    public sealed class TinyUrlShortener : IUrlShortenerProvider
    {
        /// <summary>
        /// Gets the service trigger.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public string Trigger { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TinyUrlShortener"/> class.
        /// </summary>
        /// <param name="trigger">The trigger.</param>
        public TinyUrlShortener(string trigger)
        {
            this.Trigger = trigger;
        }

        /// <summary>
        /// Shortens the given url.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// The shorter url or null if the service was down.
        /// </returns>
        public string Shorten(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadStringTaskAsync("http://tinyurl.com/api-create.php?url=" + url).Result;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }

            return null;
        }
    }
}