// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextualForecast.cs" company="Patrick Magee">
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
//   The textual forecast.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The textual forecast.
    /// </summary>
    [DataContract(Name = "txt_forecast")]
    public class TextualForecast : ITextualForecast
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [DataMember(Name = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the forecast days.
        /// </summary>
        /// <value>
        /// The forecast days.
        /// </value>
        [DataMember(Name = "forecastday")]
        public List<ForecastDay> ForecastDays { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [IgnoreDataMember]
        string ITextualForecast.Date
        {
            get
            {
                return this.Date;
            }
        }

        /// <summary>
        /// Gets the forecast days.
        /// </summary>
        /// <value>
        /// The forecast days.
        /// </value>
        [IgnoreDataMember]
        IEnumerable<IForecastDay> ITextualForecast.ForecastDays
        {
            get
            {
                return this.ForecastDays;
            }
        }

        #endregion
    }
}