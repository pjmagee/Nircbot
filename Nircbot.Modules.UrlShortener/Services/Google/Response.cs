// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="Patrick Magee">
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
//   Defines the Class1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrlShortener.Services.Google
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The root.
    /// <remarks>
    ///     See https://developers.google.com/url-shortener/v1/getting_started#shorten
    /// </remarks>
    /// </summary>
    [DataContract]
    public class Response
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        [DataMember(Name = "kind")]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the long URL.
        /// </summary>
        /// <value>
        /// The long URL.
        /// </value>
        [DataMember(Name = "longUrl")]
        public string LongUrl { get; set; }
    }
}
