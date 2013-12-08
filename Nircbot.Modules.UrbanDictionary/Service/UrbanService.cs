// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UrbanService.cs" company="Patrick Magee">
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
//   The urban service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrbanDictionary.Service
{
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading.Tasks;

    using Nircbot.Common.Extensions;
    using Nircbot.Modules.UrbanDictionary.Api;

    /// <summary>
    /// The urban service.
    /// </summary>
    public class UrbanService : IUrbanService
    {
        /// <summary>
        /// The authorization header
        /// </summary>
        private const string AuthorizationHeader = "X-Mashape-Authorization";

        /// <summary>
        /// The url.
        /// </summary>
        private const string Url = "https://mashape-community-urban-dictionary.p.mashape.com/define?term={0}";

        /// <summary>
        /// The API key
        /// </summary>
        private readonly string apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrbanService" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <exception cref="System.ArgumentNullException">The apiKey is null.</exception>
        public UrbanService(string apiKey)
        {
            if (apiKey == null)
            {
                throw new ArgumentNullException("apiKey");
            }

            this.apiKey = apiKey;
        }

        /// <summary>
        /// The get results.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>
        /// The <see cref="IUrbanResponse" />.
        /// </returns>
        public IUrbanResponse GetResults(string term)
        {
            using (var webClient = this.CreateClient())
            {
                string json = webClient.DownloadString(Url.FormatWith(term));

                var serializer = new DataContractJsonSerializer(typeof(UrbanResponse));
                var response = serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(json))) as IUrbanResponse;

                return response;
            }
        }

        /// <summary>
        /// The get results async.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        public async Task<IUrbanResponse> GetResultsAsync(string term)
        {
            using (var webClient = this.CreateClient())
            {
                var json = await webClient.DownloadStringTaskAsync(Url.FormatWith(term));

                var serializer = new DataContractJsonSerializer(typeof(UrbanResponse));
                var response = serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(json))) as IUrbanResponse;

                return response;
            }
        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <returns>
        /// The WebClient with the Authorization header added.
        /// </returns>
        private WebClient CreateClient()
        {
            var client = new WebClient();
            client.Headers.Add(AuthorizationHeader, this.apiKey);
            return client;
        }
    }
}