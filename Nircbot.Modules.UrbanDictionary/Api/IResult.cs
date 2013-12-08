// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IResult.cs" company="Patrick Magee">
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
//   Defines the IResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrbanDictionary.Api
{
    /// <summary>
    /// The Result interface.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Gets the definition identifier.
        /// </summary>
        /// <value>
        /// The definition identifier.
        /// </value>
        int DefinitionId { get; }

        /// <summary>
        /// Gets the word.
        /// </summary>
        /// <value>
        /// The word.
        /// </value>
        string Word { get; }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        string Author { get; }

        /// <summary>
        /// Gets the perma link.
        /// </summary>
        /// <value>
        /// The perma link.
        /// </value>
        string PermaLink { get; }

        /// <summary>
        /// Gets the definition.
        /// </summary>
        /// <value>
        /// The definition.
        /// </value>
        string Definition { get; }

        /// <summary>
        /// Gets the example.
        /// </summary>
        /// <value>
        /// The example.
        /// </value>
        string Example { get; }

        /// <summary>
        /// Gets the thumbs up.
        /// </summary>
        /// <value>
        /// The thumbs up.
        /// </value>
        int? ThumbsUp { get; }

        /// <summary>
        /// Gets the thumbs down.
        /// </summary>
        /// <value>
        /// The thumbs down.
        /// </value>
        int? ThumbsDown { get; }

        /// <summary>
        /// Gets the current vote.
        /// </summary>
        /// <value>
        /// The current vote.
        /// </value>
        string CurrentVote { get;  }
    }
}