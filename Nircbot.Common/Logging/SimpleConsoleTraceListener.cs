// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleConsoleTraceListener.cs" company="Patrick Magee">
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
//   The simple console trace listener.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Common.Logging
{
    #region

    using System;
    using System.Diagnostics;

    #endregion

    /// <summary>
    /// The simple console trace listener.
    /// </summary>
    public class SimpleConsoleTraceListener : ConsoleTraceListener
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleConsoleTraceListener"/> class.
        /// </summary>
        public SimpleConsoleTraceListener()
        {
            this.TraceOutputOptions = TraceOptions.None;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The trace event.
        /// </summary>
        /// <param name="eventCache">
        /// The event cache.
        /// </param>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="eventType">
        /// The event type.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            Console.WriteLine("{0}: {1}", eventType, string.Format(format, args));
        }

        /// <summary>
        /// Writes trace information, a message, and event information to the listener specific output.
        /// </summary>
        /// <param name="eventCache">
        /// A <see cref="T:System.Diagnostics.TraceEventCache"/> object that contains the current process ID, thread ID, and stack trace information.
        /// </param>
        /// <param name="source">
        /// A name used to identify the output, typically the name of the application that generated the trace event.
        /// </param>
        /// <param name="eventType">
        /// One of the <see cref="T:System.Diagnostics.TraceEventType"/> values specifying the type of event that has caused the trace.
        /// </param>
        /// <param name="id">
        /// A numeric identifier for the event.
        /// </param>
        /// <param name="message">
        /// A message to write.
        /// </param>
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            Console.WriteLine("{0}: {1}", eventType, message);
        }

        #endregion
    }
}
