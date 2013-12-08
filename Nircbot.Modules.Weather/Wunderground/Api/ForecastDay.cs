// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForecastDay.cs" company="Patrick Magee">
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
//   The forecast day.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The forecast day.
    /// </summary>
    [DataContract]
    public class ForecastDay : IForecastDay
    {
        #region Public Properties

        /// <summary>
        /// Gets the forecast text.
        /// </summary>
        /// <value>
        /// The forecast text.
        /// </value>
        [DataMember(Name = "fcttext")]
        public string ForecastText { get; set; }

        /// <summary>
        /// Gets the forecast text metric.
        /// </summary>
        /// <value>
        /// The forecast text metric.
        /// </value>
        [DataMember(Name = "fcttext_metric")]
        public string ForecastTextMetric { get; set; }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the iron URL.
        /// </summary>
        /// <value>
        /// The iron URL.
        /// </value>
        [DataMember(Name = "icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        [DataMember(Name = "period")]
        public int Period { get; set; }

        /// <summary>
        /// Gets a value indicating whether [pop].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pop]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "pop")]
        public bool Pop { get; set; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the forecast text.
        /// </summary>
        /// <value>
        /// The forecast text.
        /// </value>
        [IgnoreDataMember]
        string IForecastDay.ForecastText
        {
            get
            {
                return this.ForecastText;
            }
        }

        /// <summary>
        /// Gets the forecast text metric.
        /// </summary>
        /// <value>
        /// The forecast text metric.
        /// </value>
        [IgnoreDataMember]
        string IForecastDay.ForecastTextMetric
        {
            get
            {
                return this.ForecastTextMetric;
            }
        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        [IgnoreDataMember]
        string IForecastDay.Icon
        {
            get
            {
                return this.Icon;
            }
        }

        /// <summary>
        /// Gets the icon URL.
        /// </summary>
        /// <value>
        /// The icon URL.
        /// </value>
        [IgnoreDataMember]
        string IForecastDay.IconUrl
        {
            get
            {
                return this.IconUrl;
            }
        }

        /// <summary>
        /// Gets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        [IgnoreDataMember]
        int IForecastDay.Period
        {
            get
            {
                return this.Period;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [pop].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pop]; otherwise, <c>false</c>.
        /// </value>
        [IgnoreDataMember]
        bool IForecastDay.Pop
        {
            get
            {
                return this.Pop;
            }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [IgnoreDataMember]
        string IForecastDay.Title
        {
            get
            {
                return this.Title;
            }
        }

        #endregion
    }
}