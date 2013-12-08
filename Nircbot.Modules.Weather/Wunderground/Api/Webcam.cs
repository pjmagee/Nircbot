// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Webcam.cs" company="Patrick Magee">
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
//   The webcam.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    #region

    using System;
    using System.Runtime.Serialization;

    #endregion

    /// <summary>
    /// The webcam.
    /// </summary>
    [DataContract(Name = "webcam")]
    public class Webcam : IWebcam
    {
        #region Public Properties

        /// <summary>
        /// Gets the associated station id.
        /// </summary>
        [DataMember(Name = "assoc_station_id")]
        public string AssociatedStationId { get; set; }

        /// <summary>
        /// Gets the cam id.
        /// </summary>
        [DataMember(Name = "camid")]
        public string CamId { get; set; }

        /// <summary>
        /// Gets the cam index.
        /// </summary>
        [DataMember(Name = "camindex")]
        public int CamIndex { get; set; }

        /// <summary>
        /// Gets the cam url.
        /// </summary>
        [DataMember(Name = "CAMURL")]
        public string CamUrl { get; set; }

        /// <summary>
        /// Gets the camera type.
        /// </summary>
        [DataMember(Name = "cameratype")]
        public string CameraType { get; set; }

        /// <summary>
        /// Gets the city.
        /// </summary>
        [DataMember(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// Gets the country.
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets the current image url.
        /// </summary>
        [DataMember(Name = "CURRENTIMAGEURL")]
        public string CurrentImageUrl { get; set; }

        /// <summary>
        /// Gets the downloaded.
        /// </summary>
        [DataMember(Name = "downloaded")]
        public string Downloaded { get; set; }

        /// <summary>
        /// Gets the handle.
        /// </summary>
        [DataMember(Name = "handle")]
        public string Handle { get; set; }

        /// <summary>
        /// Gets a value indicating whether is recent.
        /// </summary>
        [DataMember(Name = "isrecent")]
        public bool IsRecent { get; set; }

        /// <summary>
        /// Gets the lat.
        /// </summary>
        [DataMember(Name = "lat")]
        public float Lat { get; set; }

        /// <summary>
        /// Gets the link.
        /// </summary>
        [DataMember(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets the link text.
        /// </summary>
        [DataMember(Name = "linktext")]
        public string LinkText { get; set; }

        /// <summary>
        /// Gets the lon.
        /// </summary>
        [DataMember(Name = "lon")]
        public float Lon { get; set; }

        /// <summary>
        /// Gets the neighborhood.
        /// </summary>
        [DataMember(Name = "neighborhood")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Gets the organization.
        /// </summary>
        [DataMember(Name = "organization")]
        public string Organization { get; set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        [DataMember(Name = "state")]
        public string State { get; set; }

        /// <summary>
        /// Gets the time zone.
        /// </summary>
        [DataMember(Name = "tzname")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets the updated.
        /// </summary>
        [DataMember(Name = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// Gets the widget current image url.
        /// </summary>
        [DataMember(Name = "WIDGETCURRENTIMAGEURL")]
        public string WidgetCurrentImageUrl { get; set; }

        /// <summary>
        /// Gets the zip.
        /// </summary>
        [DataMember(Name = "zip")]
        public string Zip { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the downloaded.
        /// </summary>
        DateTime IWebcam.Downloaded
        {
            get
            {
                DateTime dateTime;

                if(DateTime.TryParse(this.Downloaded, out dateTime))
                {
                    return dateTime;
                }

                return default(DateTime);
            }
        }

        /// <summary>
        /// Gets the updated.
        /// </summary>
        DateTime IWebcam.Updated
        {
            get
            {
                DateTime dateTime;

                if (DateTime.TryParse(this.Updated, out dateTime))
                {
                    return dateTime;
                }

                return default(DateTime);
            }
        }

        #endregion
    }
}