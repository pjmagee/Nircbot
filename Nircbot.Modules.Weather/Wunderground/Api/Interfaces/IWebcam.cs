// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWebcam.cs" company="Patrick Magee">
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
//   The Webcam interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api.Interfaces
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The Webcam interface.
    /// </summary>
    public interface IWebcam
    {
        #region Public Properties

        /// <summary>
        /// Gets the associated station id.
        /// </summary>
        string AssociatedStationId { get; }

        /// <summary>
        /// Gets the cam id.
        /// </summary>
        string CamId { get; }

        /// <summary>
        /// Gets the cam index.
        /// </summary>
        int CamIndex { get; }

        /// <summary>
        /// Gets the cam url.
        /// </summary>
        string CamUrl { get; }

        /// <summary>
        /// Gets the camera type.
        /// </summary>
        string CameraType { get; }

        /// <summary>
        /// Gets the city.
        /// </summary>
        string City { get; }

        /// <summary>
        /// Gets the country.
        /// </summary>
        string Country { get; }

        /// <summary>
        /// Gets the current image url.
        /// </summary>
        string CurrentImageUrl { get; }

        /// <summary>
        /// Gets the downloaded.
        /// </summary>
        DateTime Downloaded { get; }

        /// <summary>
        /// Gets the handle.
        /// </summary>
        string Handle { get; }

        /// <summary>
        /// Gets a value indicating whether is recent.
        /// </summary>
        bool IsRecent { get; }

        /// <summary>
        /// Gets the lat.
        /// </summary>
        float Lat { get; }

        /// <summary>
        /// Gets the link.
        /// </summary>
        string Link { get; }

        /// <summary>
        /// Gets the link text.
        /// </summary>
        string LinkText { get; }

        /// <summary>
        /// Gets the lon.
        /// </summary>
        float Lon { get; }

        /// <summary>
        /// Gets the neighborhood.
        /// </summary>
        string Neighborhood { get; }

        /// <summary>
        /// Gets the organization.
        /// </summary>
        string Organization { get; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        string State { get; }

        /// <summary>
        /// Gets the time zone.
        /// </summary>
        string TimeZone { get; }

        /// <summary>
        /// Gets the updated.
        /// </summary>
        DateTime Updated { get; }

        /// <summary>
        /// Gets the widget current image url.
        /// </summary>
        string WidgetCurrentImageUrl { get; }

        /// <summary>
        /// Gets the zip.
        /// </summary>
        string Zip { get; }

        #endregion
    }
}