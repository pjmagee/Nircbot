// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiceModule.cs" company="Patrick Magee">
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
//   The dice module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Dice
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Nircbot.Common.Extensions;
    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;

    #endregion

    /// <summary>
    /// The dice module.
    /// </summary>
    public class DiceModule : BaseModule
    {
        #region Constants

        /// <summary>
        /// The regex pattern
        /// </summary>
        private const string RegexPattern = @"^!((?<command>roll)(\s+(?<times>\d{1,2}))?)$";

        #endregion

        #region Static Fields

        /// <summary>
        /// The dice regex
        /// </summary>
        private static readonly Regex DiceRegex = new Regex(RegexPattern, RegexOptions.Compiled);

        #endregion

        #region Fields

        /// <summary>
        /// The random
        /// </summary>
        private readonly Random random = new Random();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceModule" /> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        public DiceModule(IIrcClient ircClient) : base(ircClient)
        {
            
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Registers the commands.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Command}" />.
        /// </returns>
        public override IEnumerable<Command> RegisterCommands()
        {
            yield return new Command(DiceRegex, this.OnRoll)
                             {
                                 LevelRequired = AccessLevel.None,
                                 Description = "Rolls a die",
                                 Examples = new[] {  "!roll", "To roll the die 10 times, !roll 10"},
                                 Accepts = MessageType.Both,
                             };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [roll].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="type">The type.</param>
        /// <param name="format">The format.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        private void OnRoll(User user, string channel, MessageType type, MessageFormat format, string message, Dictionary<string, string> arguments)
        {
            Match match = DiceRegex.Match(message);

            if (match.Success)
            {
                var group = match.Groups["times"];

                if (group.Success)
                {
                    int value = int.Parse(group.Value);
                    var results = new List<int>();
                    value.Times(() => results.Add(this.random.Next(1, 6)));

                    var response = new Response(string.Join(", ", results), new [] { channel ?? user.Nick }, MessageFormat.Message, MessageType.Both);
                    response.MessageType = MessageType.Both;
                    this.SendResponse(response);
                }
                else
                {
                    var response = new Response(string.Join(", ", this.random.Next(1, 6)), new[] { channel ?? user.Nick }, MessageFormat.Message, MessageType.Both);
                    response.MessageType = MessageType.Both;
                    this.SendResponse(response);
                }
            }
        }

        #endregion
    }
}
