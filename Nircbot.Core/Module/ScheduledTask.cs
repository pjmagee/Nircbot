// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledTask.cs" company="Patrick Magee">
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
//   The scheduled task.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nircbot.Core.Module
{
    #region

    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// The scheduled task.
    /// </summary>
    public class ScheduledTask
    {
        #region Fields

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        private readonly Action action;

        /// <summary>
        /// Gets or sets the scheduled end time.
        /// </summary>
        /// <value>
        /// The scheduled end time.
        /// </value>
        private readonly DateTime? end;

        /// <summary>
        /// The name
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The schedule
        /// </summary>
        private readonly TimeSpan schedule;

        /// <summary>
        /// Gets or sets the scheduled start time.
        /// </summary>
        /// <value>
        /// The scheduled start time.
        /// </value>
        private readonly DateTime? start;

        /// <summary>
        /// The timeout
        /// </summary>
        private readonly TimeSpan? timeout;

        /// <summary>
        /// The is finished
        /// </summary>
        private bool isFinished;

        /// <summary>
        /// The token source
        /// </summary>
        private CancellationTokenSource tokenSource;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledTask"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="schedule">
        /// The schedule.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <param name="start">
        /// The start.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        public ScheduledTask(string name, Action action, TimeSpan schedule, TimeSpan? timeout = null, DateTime? start = null, DateTime? end = null)
        {
            this.name = name;
            this.schedule = schedule;
            this.timeout = timeout;
            this.action = action;
            this.start = start;
            this.end = end;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Cancels this instance.
        /// </summary>
        public void Cancel()
        {
            if (this.tokenSource != null)
            {
                this.tokenSource.Cancel();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Runs this action.
        /// <remarks>
        /// A task can be short or long running. We have no information about what this task will undertake.
        /// Execute the task in its own Task and continue.
        /// </remarks>
        /// </summary>
        internal void Run()
        {
            while (!this.isFinished)
            {
                if (this.end.HasValue && DateTime.Now >= this.end.Value)
                {
                    Trace.TraceInformation("Task ending: {0} on thead {1}", this.name, Thread.CurrentThread.ManagedThreadId);
                    this.isFinished = true;
                }
                else
                {
                    if (this.start.HasValue && DateTime.Now >= this.start.Value)
                    {
                        this.tokenSource = this.timeout == null ? new CancellationTokenSource() : new CancellationTokenSource(this.timeout.GetValueOrDefault());
                        Task.Factory.StartNew(() => this.action(), this.tokenSource.Token);
                    }

                    if (!this.start.HasValue)
                    {
                        this.tokenSource = this.timeout == null ? new CancellationTokenSource() : new CancellationTokenSource(this.timeout.GetValueOrDefault());
                        Task.Factory.StartNew(() => this.action(), this.tokenSource.Token);
                    }
                }

                Thread.Sleep(this.schedule);
            }
        }

        #endregion
    }
}