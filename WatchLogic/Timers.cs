using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WatchLogic
{
    /// <summary>
    /// Emulated a timers
    /// </summary>
    public sealed class Timers
    {
        /// <summary>
        /// Occurs when [time out].
        /// </summary>
        public event EventHandler<TimeOutEventArgs> TimeOut = delegate { };

        /// <summary>
        /// Starts the specified second.
        /// </summary>
        /// <param name="second">The second.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException">second</exception>
        public async void Start(int second, string message)
        {
            if (second <= 0 || second > int.MaxValue / 1000)
            {
                throw new ArgumentException($"{nameof(second)} can't be non-positive");
            }


            await Task.Delay(second * 1000).ContinueWith(x => OnTimerOut(new TimeOutEventArgs(message)));
            
            
        }

        /// <summary>
        /// Raises the <see cref="E:TimerOut" /> event.
        /// </summary>
        /// <param name="e">The <see cref="TimeOutEventArgs"/> instance containing the event data.</param>
        private void OnTimerOut(TimeOutEventArgs e)
        {
            TimeOut?.Invoke(this,e);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TimeOutEventArgs : EventArgs
    {
        /// <summary>
        /// The message
        /// </summary>
        private readonly string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeOutEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public TimeOutEventArgs(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get => message;
        }
    }

}
