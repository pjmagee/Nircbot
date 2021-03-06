﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UrbanDictionaryFixture.cs" company="Patrick Magee">
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
//   The urban dictionary tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrbanDictionary.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Nircbot.Modules.UrbanDictionary.Api;
    using Nircbot.Modules.UrbanDictionary.Service;

    /// <summary>
    /// The urban dictionary tests.
    /// </summary>
    [TestClass]
    public class UrbanDictionaryFixture
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void TestMethod()
        {
            IUrbanService service = new UrbanService("oPaojq8Ka8BqqeBNiQAUeHulUPgheemU");

            IUrbanResponse urbanResponse = service.GetResultsAsync("superman").Result;

            Console.Read();
        }
    }
}
