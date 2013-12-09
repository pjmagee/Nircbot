// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Patrick Magee">
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
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Cli
{
    #region

    using System;
    using System.Configuration;
    using System.Diagnostics;

    using Ninject;
    using Ninject.Extensions.Factory;

    using Nircbot.Common.Logging;
    using Nircbot.Core;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Module;
    using Nircbot.Core.Services;
    using Nircbot.Modules;
    using Nircbot.Modules.Admin;
    using Nircbot.Modules.Blackjack.Services;
    using Nircbot.Modules.Dice;
    using Nircbot.Modules.Ruby;
    using Nircbot.Modules.Ruby.Services;
    using Nircbot.Modules.UrbanDictionary;
    using Nircbot.Modules.UrbanDictionary.Service;
    using Nircbot.Modules.UrlShortener;
    using Nircbot.Modules.UrlShortener.Services;
    using Nircbot.Modules.UrlShortener.Services.Google;
    using Nircbot.Modules.UrlShortener.Services.Tinyurl;
    using Nircbot.Modules.Weather;
    using Nircbot.Modules.Weather.Service;
    using Nircbot.Modules.Weather.Wunderground;

    #endregion

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        #region Public Methods and Operators

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            // This is our composition root.
            // The closest point to the entry of our application.
            // Configure our IoC here
            using (var kernel = new StandardKernel())
            {
                Trace.Listeners.Clear();
                Trace.Listeners.Add(new SimpleConsoleTraceListener());
                Trace.TraceInformation("Loading modules");

                kernel.Bind<IUserService>().To<UserService>().InSingletonScope();
                kernel.Bind<IIrcClient>().To<DefaultIrcClient>();

                kernel.Bind<IUrbanService>()
                    .To<UrbanService>()
                    .InSingletonScope()
                    .WithConstructorArgument("apiKey", ConfigurationManager.AppSettings.Get("Mashape.Api.Key"));

                kernel.Bind<IIrbService>().To<IrbService>();

                #region Bot Modules

                kernel.Bind<IModule>()
                    .To<UrbanDictionaryModule>()
                    .WithPropertyValue("Name", "Urban")
                    .WithPropertyValue("Description", "Provides results from UrbanDictionary with a given term.");

                kernel.Bind<IModule>()
                    .To<ModuleInfoModule>()
                    .WithPropertyValue("Name", "Information")
                    .WithPropertyValue("Description", "Module that provides information about modules.");

                kernel.Bind<IModule>()
                    .To<DiceModule>()
                    .WithPropertyValue("Name", "Dice")
                    .WithPropertyValue("Description", "Module for rolling a dice.");
                
                kernel.Bind<IModule>()
                    .To<RubyModule>()
                    .WithPropertyValue("Name", "Ruby")
                    .WithPropertyValue("Description", "Supports executing ruby scripts and an interactive ruby session.");

                kernel.Bind<IModule>()
                    .To<AdminModule>()
                    .WithPropertyValue("Name", "Admin")
                    .WithPropertyValue("Description", "Administers the bot.");

                kernel.Bind<IModule>()
                    .To<WeatherModule>()
                    .WithPropertyValue("Name", "Weather")
                    .WithPropertyValue("Description", "Provides all your detailed weather information.");

                kernel.Bind<IModule>()
                    .To<UrlShortenerModule>()
                    .WithPropertyValue("Name", "Shortener")
                    .WithPropertyValue("Description", "Shorten those long urls.");

                #endregion

                #region Url Providers 

                kernel.Bind<IUrlShortenerProvider>()
                    .To<GoogleUrlShortner>()
                    .InSingletonScope()
                    .WithConstructorArgument("trigger", "google")
                    .WithConstructorArgument("apiKey", ConfigurationManager.AppSettings.Get("Google.Api.Key"));

                kernel.Bind<IUrlShortenerProvider>()
                    .To<TinyUrlShortener>()
                    .InSingletonScope()
                    .WithConstructorArgument("trigger", "tinyurl");

                #endregion

                #region Weather Providers

                kernel.Bind<IWeatherProvider>()
                    .To<WundergroundWeatherProvider>()
                    .InSingletonScope()
                    .WithConstructorArgument("apiKey", ConfigurationManager.AppSettings.Get("Wunderground.Api.Key"));

                #endregion

                #region Factories

                kernel.Bind<IIrbServiceFactory>().ToFactory();
                kernel.Bind<IModuleFactory>().ToFactory();
                kernel.Bind<IIrcClientFactory>().ToFactory();
                kernel.Bind<IBlackjackServiceFactory>().ToFactory();

                #endregion

                kernel.Bind<Bot>().ToSelf().InSingletonScope();

                var nircbot = kernel.Get<Bot>();
                nircbot.Start();

                Console.Read();
            }
        }

        #endregion
    }
}
