// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUrbanService.cs" company="Patrick Magee">
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
//   The UrbanService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrbanDictionary.Service
{
    using System.Threading.Tasks;

    using Nircbot.Modules.UrbanDictionary.Api;

    /// <summary>
    /// The UrbanService interface.
    /// </summary>
    public interface IUrbanService
    {
        /// <summary>
        /// The get results.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>
        /// The <see cref="IUrbanResponse" />.
        /// </returns>
        IUrbanResponse GetResults(string term);

        /// <summary>
        /// The get results async.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IUrbanResponse> GetResultsAsync(string term);
    }
}
