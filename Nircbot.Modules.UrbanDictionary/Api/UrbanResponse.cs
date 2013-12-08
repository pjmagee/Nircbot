// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class2.cs" company="Patrick Magee">
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
//   Defines the UrbanResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrbanDictionary.Api
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The response.
    /// </summary>
    [DataContract]
    public class UrbanResponse : IUrbanResponse
    {
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
        [DataMember(Name = "result_type")]
        public string ResultType { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        [DataMember(Name = "list")]
        public List<Result> Results { get; set; }
        
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        [IgnoreDataMember]
        IEnumerable<IResult> IUrbanResponse.Results
        {
            get
            {
                return this.Results;
            }
        }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        [IgnoreDataMember]
        IEnumerable<string> IUrbanResponse.Tags
        {
            get
            {
                return this.Tags; 
            }
        }

        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
        [IgnoreDataMember]
        string IUrbanResponse.ResultType
        {
            get
            {
                return this.ResultType;
            }
        }
    }
}
