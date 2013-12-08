// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageData.cs" company="Patrick Magee">
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
//   The image data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The image data.
    /// </summary>
    [DataContract(Name = "image")]
    public class ImageData : IImage
    {
        #region Public Properties

        /// <summary>
        /// Gets the link.
        /// </summary>
        [DataMember(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets the url.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the link.
        /// </summary>
        [IgnoreDataMember]
        string IImage.Link
        {
            get
            {
                return this.Link;
            }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        [IgnoreDataMember]
        string IImage.Title
        {
            get
            {
                return this.Title;
            }
        }

        /// <summary>
        /// Gets the url.
        /// </summary>
        [IgnoreDataMember]
        string IImage.Url
        {
            get
            {
                return this.Url;
            }
        }

        #endregion
    }
}