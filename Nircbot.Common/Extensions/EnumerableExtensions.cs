// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="Patrick Magee">
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
//   The enumerable extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Common.Extensions
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// The do.
        /// </summary>
        /// <typeparam name="T">
        /// The type
        /// </typeparam>
        /// <param name="enumerable">
        /// The enumerable.
        /// </param>
        /// <param name="action">
        /// The action. T being the item, int being the index
        /// </param>
        public static void Do<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            int i = 0;

            foreach (var item in enumerable)
            {
                action(item, i);
                i++;
            }
        }

        #endregion
    }
}