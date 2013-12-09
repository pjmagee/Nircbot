// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBlackjackServiceFactory.cs" company="Patrick Magee">
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
//   The BlackjackServiceFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Blackjack.Services
{
    using Nircbot.Core.Irc;

    /// <summary>
    /// The BlackjackServiceFactory interface.
    /// </summary>
    public interface IBlackjackServiceFactory
    {
        /// <summary>
        /// The create blackjack service.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="channel">The channel.</param>
        /// <returns>
        /// The <see cref="BlackjackService" />.
        /// </returns>
        BlackjackService CreateBlackjackService(IIrcClient ircClient, string channel);
    }
}