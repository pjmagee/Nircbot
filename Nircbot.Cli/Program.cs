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
    using System.Data.Entity;
    using System.Diagnostics;

    using Ninject;
    using Ninject.Extensions.Factory;

    using Nircbot.Common.Logging;
    using Nircbot.Core;
    using Nircbot.Core.Infrastructure;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Module;
    using Nircbot.Core.Services;
    using Nircbot.Modules;

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
                kernel.Bind<IIrcClientFactory>().ToFactory();

                kernel.Bind<IModule>()
                    .To<ModuleOne>()
                    .WithPropertyValue("Name", "ModuleOne")
                    .WithPropertyValue("Description", "The first module ever created");

                kernel.Bind<IModule>()
                    .To<DiceModule>()
                    .WithPropertyValue("Name", "Dice Module")
                    .WithPropertyValue("Description", "Module for rolling a dice");
                
                kernel.Bind<IModule>()
                    .To<RubyModule>()
                    .WithPropertyValue("Name", "Ruby Module")
                    .WithPropertyValue("Description", "Supports executing ruby scripts");

                kernel.Bind<IModule>()
                    .To<AdminModule>()
                    .WithPropertyValue("Name", "Admin Module")
                    .WithPropertyValue("Description", "Administers the bot");

                kernel.Bind<IModuleFactory>().ToFactory();

                kernel.Bind<Bot>().ToSelf();

                Database.SetInitializer(new DropCreateDatabaseAlwaysStrategy());

                Bot nircbot = kernel.Get<Bot>();

                Trace.TraceInformation("Starting bot");
                nircbot.Start();

                Console.Read();
            }
        }

        #endregion
    }
}
