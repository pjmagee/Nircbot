// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerExtensions.cs" company="Patrick Magee">
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
//   Integer Extensions
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Common.Extensions
{
    #region

    using System;

    #endregion

    /// <summary>
    /// Integer Extensions
    /// </summary>
    public static class IntegerExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Complete an action a number of times.
        /// Taken from StackOverflow
        /// http://stackoverflow.com/questions/177538/any-chances-to-imitate-times-ruby-method-in-c
        /// </summary>
        /// <param name="count">
        /// The number of times.
        /// </param>
        /// <param name="action">
        /// Action with exposed iterator.
        /// </param>
        public static void Times(this int count, Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(i);
            }
        }

        /// <summary>
        /// Complete an action a number of times.
        /// Taken from StackOverflow
        /// http://stackoverflow.com/questions/177538/any-chances-to-imitate-times-ruby-method-in-c
        /// </summary>
        /// <param name="count">
        /// The number of times.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        public static void Times(this int count, Action action)
        {
            for (int i = 0; i < count; i++)
            {
                action();
            }
        }

        #endregion
    }
}
