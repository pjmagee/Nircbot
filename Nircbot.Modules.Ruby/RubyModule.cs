﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RubyModule.cs" company="Patrick Magee">
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
//   The ruby module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Modules.Ruby
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Threading.Tasks;

    using IronRuby;

    using Microsoft.Scripting.Hosting;

    using Nircbot.Core;
    using Nircbot.Core.Entities;
    using Nircbot.Core.Irc;
    using Nircbot.Core.Irc.Messages;
    using Nircbot.Core.Module;
    using Nircbot.Modules.Ruby.Services;

    #endregion

    /// <summary>
    /// The ruby module.
    /// </summary>
    public sealed class RubyModule : BaseModule
    {
        /// <summary>
        /// The interactive service.
        /// </summary>
        private readonly IIrbService irbService;

        #region Constants

        /// <summary>
        /// The base ruby class module file
        /// </summary>
        private const string ModuleFileName = "botmodule.rb";

        /// <summary>
        /// The base ruby class module name
        /// </summary>
        private const string ModuleName = "BotModule";

        #endregion

        #region Static Fields

        /// <summary>
        /// The iron ruby path.
        /// </summary>
        internal static readonly string IronRubyPath = ConfigurationManager.AppSettings.Get("Iron.Ruby.Path");

        #endregion

        #region Fields

        /// <summary>
        /// Iron Ruby.
        /// </summary>
        private readonly ScriptEngine engine;

        /// <summary>
        /// The ruby script modules.
        /// </summary>
        private readonly List<dynamic> instancedModules = new List<dynamic>();

        /// <summary>
        /// The interactive sessions.
        /// </summary>
        private readonly ObjectCache interactiveSessions = MemoryCache.Default;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RubyModule"/> class.
        /// </summary>
        /// <param name="ircClient">The irc client.</param>
        /// <param name="irbServiceFactory">The irb service factory.</param>
        /// <exception cref="System.ArgumentNullException">irbServiceFactory</exception>
        public RubyModule(IIrcClient ircClient, IIrbServiceFactory irbServiceFactory) : base(ircClient)
        {
            if (irbServiceFactory == null)
            {
                throw new ArgumentNullException("irbServiceFactory");
            }
            
            this.engine = Ruby.CreateEngine();
            
            try
            {
                this.InitializeScripts();
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }

            this.irbService = irbServiceFactory.Create(ircClient);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the scripts directory.
        /// </summary>
        /// <value>
        /// The scripts directory.
        /// </value>
        private static string ScriptsDirectory
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when [notice].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="notice">The notice.</param>
        public override void OnNotice(User user, string notice)
        {
            foreach (var module in this.instancedModules)
            {
                try
                {
                    module.on_notice(user, notice);
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.Message);
                }
            }
        }

        /// <summary>
        /// Called when [private message].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="message">The message.</param>
        public override void OnPrivateMessage(User user, string message)
        {
            foreach (var module in this.instancedModules)
            {
                try
                {
                    module.on_private_message(user, message);
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.Message);
                }
            }
        }

        /// <summary>
        /// Called when [public message].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="message">The message.</param>
        public override void OnPublicMessage(User user, string channel, string message)
        {
            foreach (var module in this.instancedModules)
            {
                try
                {
                    module.on_public_message(user, channel, message);
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.Message);
                }
            }
        }

        /// <summary>
        /// Called when [user joined].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        public override void OnUserJoined(User user, string channel)
        {
            foreach (var module in this.instancedModules)
            {
                try
                {
                    module.on_user_joined(user, channel);
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.Message);
                }
            }
        }

        /// <summary>
        /// Called when [user kicked].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="message">The message.</param>
        public override void OnUserKicked(User user, string channel, string message)
        {
            foreach (var module in this.instancedModules)
            {
                try
                {
                    module.on_user_kicked(user, channel, message);
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.Message);
                }
            }
        }

        /// <summary>
        /// Called when [user left].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        public override void OnUserLeft(User user, string channel)
        {
            foreach (var module in this.instancedModules)
            {
                try
                {
                    module.on_user_left(user, channel);
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.Message);
                }
            }
        }

        /// <summary>
        /// Registers the commands.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Command}" />.
        /// </returns>
        public override IEnumerable<Command> RegisterCommands()
        {
            yield return new Command("!irb", this.InteractiveRuby)
            {
                Description = "Provides a piped interactive ruby session for a user.",
                Examples = new [] { "!irb --start", "!irb --stop" },
                Accepts = MessageType.Both, 
                LevelRequired = AccessLevel.None
            };

            yield return new Command("!reload", this.ReloadScripts)
            {
                Description = "Reloads all the currently loaded scripts.",
                Examples = new [] {"!reload" },
                Accepts = MessageType.Both, 
                LevelRequired = AccessLevel.None
            };

            yield return new Command("!refresh", this.RefreshScripts)
            {
                Description = "Loads any new scripts that are not currently loaded",
                Examples = new [] { "!refresh"},
                Accepts = MessageType.Both, 
                LevelRequired = AccessLevel.None
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reloads the scripts.
        /// </summary>
        private void ReloadScripts()
        {
            this.ClearInstancedModules();
            this.InitializeScripts();
        }

        /// <summary>
        /// Initializes the scripts.
        /// </summary>
        private void InitializeScripts()
        {
            this.LoadAndExecuteScripts();
            this.SetGlobalVariables();
            this.InstanceModules();
        }

        /// <summary>
        /// Checks if an already loaded instance has the same name as an item
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="item">The item.</param>
        /// <returns>
        /// Returns true if the instance with a class name is the same as the name of the item to be instanced otherwise false.
        /// </returns>
        /// <exception cref="System.Exception">Instance provided is not known.</exception>
        private bool InstanceLoaded(dynamic instance, dynamic item)
        {
            if (!this.instancedModules.Contains(instance))
            {
                throw new Exception("Instance provided is not a known instance.");
            }

            try
            {
                return (this.engine.Operations.InvokeMember(instance, "class").Name == item.Name) == true;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
                Trace.TraceError(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Clears the instanced modules.
        /// </summary>
        private void ClearInstancedModules()
        {
            this.instancedModules.Clear();
        }

        /// <summary>
        /// Creates instances of the  Modules.
        /// </summary>
        private void InstanceModules()
        {
            try
            {
                dynamic botModule = this.engine.Runtime.Globals.GetVariable(ModuleName);
                
                foreach (var item in this.engine.Runtime.Globals.GetItems())
                {
                    dynamic variable = item.Value;
                    this.CreateInstance(variable, botModule);
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
                Trace.TraceError(e.StackTrace);
            }
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <param name="botModule">The bot module.</param>
        private void CreateInstance(dynamic variable, dynamic botModule)
        {
            if (this.IsAlreadyInstanced(variable))
            {
                Trace.TraceInformation("Item {0} was already found instanced", (object)variable.ToString());
            }
            else
            {
                dynamic instance;

                if (this.TryInstanceModule(variable, botModule, out instance))
                {
                    this.instancedModules.Add(instance);
                    Trace.TraceInformation("Loaded Ruby Module: {0}", (object)instance.ToString());
                }
            }
        }

        /// <summary>
        /// Tries to create an instance of the dynamic item from the given dynamic module.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="botModule">The bot Module.</param>
        /// <param name="instance">The instance.</param>
        /// <returns>
        /// True if an instance was created, otherwise false.
        /// </returns>
        private bool TryInstanceModule(dynamic module, dynamic botModule, out dynamic instance)
        {
            instance = null;

            try
            {
                bool isChild = (module < botModule) == true;

                if (isChild)
                {
                    instance = module.@new(this.IrcClient);
                    return true;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }

            return false;
        }

        /// <summary>
        /// Determines whether a module [is already instanced] from [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>True if instanced otherwise false.</returns>
        private bool IsAlreadyInstanced(dynamic item)
        {
            return this.instancedModules.Any(instance => this.InstanceLoaded(instance, item));
        }

        /// <summary>
        /// Interactive ruby.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        private void InteractiveRuby(User user, string channel, MessageType messageType, MessageFormat messageFormat, string message, Dictionary<string, string> args)
        {
            message = message.Remove(0, "!irb".Length);

            if (args.ContainsKey("start"))
            {
                this.irbService.CreateSession(user, channel);
            }
            else if (args.ContainsKey("stop"))
            {
                this.irbService.RemoveSession(user);
            }
            else if (!string.IsNullOrEmpty(message) && this.interactiveSessions.Contains(user.Nick))
            {
                this.irbService.WriteToSession(user, message);
            }
        }

        /// <summary>
        /// Loads the and executes the scripts.
        /// </summary>
        private void LoadAndExecuteScripts()
        {
            var files = Directory.GetFiles(ScriptsDirectory).Select(f => new FileInfo(f)).ToList();

            var baseModuleFile = files.First(f => f.Name.Equals(ModuleFileName, StringComparison.OrdinalIgnoreCase));

            this.engine.Runtime.LoadAssembly(typeof(Bot).Assembly);
            this.engine.Runtime.LoadAssembly(typeof(Trace).Assembly);

            this.engine.ExecuteFile(baseModuleFile.FullName);

            foreach (var script in files.Except(new[] { baseModuleFile }))
            {
                this.engine.ExecuteFile(script.FullName);
            }
        }

        /// <summary>
        /// Refreshes the scripts.
        /// <remarks>
        /// This executes any script files that have not already been executed and loaded.
        /// </remarks>
        /// </summary>
        private void RefreshScripts()
        {
            try
            {
                var files = Directory.GetFiles(ScriptsDirectory).Select(f => new FileInfo(f)).ToList();

                var baseModuleFile = files.First(f => f.Name.Equals(ModuleFileName, StringComparison.OrdinalIgnoreCase));

                foreach (var script in files.Except(files.Concat(new[] { baseModuleFile })))
                {
                    this.engine.ExecuteFile(script.FullName);
                }

                this.InstanceModules();
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }
        }

        /// <summary>
        /// Sets the global variables.
        /// </summary>
        private void SetGlobalVariables()
        {
            // We must set global varibales and execute prior to instantiating our classes 
            // this.engine.Runtime.Globals.SetVariable("client", this.IrcClient);
            // this.engine.Execute("$client = ircClient");
        }

        #endregion
    }
}
