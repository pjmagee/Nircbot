// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Patrick Magee">
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
//   The weather fixture.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.UrlShortener.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Nircbot.Modules.UrlShortener.Services.Google;
    using Nircbot.Modules.UrlShortener.Services.Tinyurl;

    /// <summary>
    /// The url shortener fixture.
    /// </summary>
    [TestClass]
    public class UrlShortenerFixture
    {

        [TestMethod]
        public void GoogleShortner()
        {
            var shortner = new GoogleUrlShortner("AIzaSyC3diVUpQjg2niWpu84Be5hByOkg2-MsuU", "google");
            string shorten = shortner.Shorten("http://geeks.ltd.uk");
            Assert.AreEqual(expected: "http://goo.gl/1Q6wnh", actual: shorten);
        }

        [TestMethod]
        public void TinyUrlShortner()
        {
            var shortner = new TinyUrlShortener("tinyurl");
            string shorten = shortner.Shorten("http://geeks.ltd.uk");
        }
    }
}
