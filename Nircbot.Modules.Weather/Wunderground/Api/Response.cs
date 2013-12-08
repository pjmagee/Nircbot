// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="Patrick Magee">
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
//   The response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The response.
    /// </summary>
    [DataContract(Name = "response")]
    public class Response : IResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        /// <value>
        /// The features.
        /// </value>
        [DataMember(Name = "features")]
        public Features Features { get; set; }

        /// <summary>
        /// Gets or sets the terms of service.
        /// </summary>
        /// <value>
        /// The terms of service.
        /// </value>
        [DataMember(Name = "termsofService")]
        public string TermsOfService { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [DataMember(Name = "version")]
        public string Version { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <value>
        /// The features.
        /// </value>
        [IgnoreDataMember]
        IFeatures IResponse.Features
        {
            get
            {
                return this.Features;
            }
        }

        /// <summary>
        /// Gets the terms of service.
        /// </summary>
        /// <value>
        /// The terms of service.
        /// </value>
        [IgnoreDataMember]
        string IResponse.TermsOfService
        {
            get
            {
                return this.TermsOfService;
            }
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [IgnoreDataMember]
        string IResponse.Version
        {
            get
            {
                return this.Version;
            }
        }

        #endregion
    }
}