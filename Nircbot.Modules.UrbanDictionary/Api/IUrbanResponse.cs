// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUrbanResponse.cs" company="Patrick Magee">
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
//   The UrbanResponse interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrbanDictionary.Api
{
    using System.Collections.Generic;

    /// <summary>
    /// The UrbanResponse interface.
    /// </summary>
    public interface IUrbanResponse
    {
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        IEnumerable<string> Tags { get; }

        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
        string ResultType { get; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        IEnumerable<IResult> Results { get; }
    }
}