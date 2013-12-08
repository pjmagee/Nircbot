// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Result.cs" company="Patrick Magee">
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
//   The result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrbanDictionary.Api
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The result.
    /// </summary>
    [DataContract]
    public class Result : IResult
    {
        /// <summary>
        /// Gets or sets the definition identifier.
        /// </summary>
        /// <value>
        /// The definition identifier.
        /// </value>
        [DataMember(Name = "defid")]
        public int DefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        /// <value>
        /// The word.
        /// </value>
        [DataMember(Name = "word")]
        public string Word { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        [DataMember(Name = "author")]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the perma link.
        /// </summary>
        /// <value>
        /// The perma link.
        /// </value>
        [DataMember(Name = "permalink")]
        public string PermaLink { get; set; }

        /// <summary>
        /// Gets or sets the definition.
        /// </summary>
        /// <value>
        /// The definition.
        /// </value>
        [DataMember(Name = "definition")]
        public string Definition { get; set; }

        /// <summary>
        /// Gets or sets the example.
        /// </summary>
        /// <value>
        /// The example.
        /// </value>
        [DataMember(Name = "example")]
        public string Example { get; set; }

        /// <summary>
        /// Gets or sets the thumbs up.
        /// </summary>
        /// <value>
        /// The thumbs up.
        /// </value>
        [DataMember(Name = "thumbs_up")]
        public int? ThumbsUp { get; set; }

        /// <summary>
        /// Gets or sets the thumbs down.
        /// </summary>
        /// <value>
        /// The thumbs down.
        /// </value>
        [DataMember(Name = "thumbs_down")]
        public int? ThumbsDown { get; set; }

        /// <summary>
        /// Gets or sets the current vote.
        /// </summary>
        /// <value>
        /// The current vote.
        /// </value>
        [DataMember(Name = "current_vote")]
        public string CurrentVote { get; set; }
    }
}