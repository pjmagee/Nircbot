// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Forecast.cs" company="Patrick Magee">
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
//   The forecast.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Weather.Wunderground.Api
{
    #region

    using System.Runtime.Serialization;

    using Nircbot.Modules.Weather.Wunderground.Api.Interfaces;

    #endregion

    /// <summary>
    /// The forecast.
    /// </summary>
    [DataContract(Name = "forecast")]
    public class Forecast : IForecast
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the textual forecast.
        /// </summary>
        [DataMember(Name = "txt_forecast")]
        public TextualForecast TextualForecast { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the textual forecast.
        /// </summary>
        [IgnoreDataMember]
        ITextualForecast IForecast.TextualForecast
        {
            get
            {
                return this.TextualForecast;
            }
        }

        #endregion
    }
}