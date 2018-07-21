using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WatchLogic
{
    /// <summary>
    /// Class Phone
    /// </summary>
    public class Phone
    {
        /// <summary>
        /// Registers the specified timers.
        /// </summary>
        /// <param name="timers">The timers.</param>
        public void Register(Timers timers)
        {
            timers.TimeOut += OnDisplayShow;
        }

        /// <summary>
        /// Unregisters the specified timers.
        /// </summary>
        /// <param name="timers">The timers.</param>
        public void Unregister(Timers timers)
        {
            timers.TimeOut -= OnDisplayShow;
        }

        /// <summary>
        /// Called when [display show].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="TimeOutEventArgs"/> instance containing the event data.</param>
        private void OnDisplayShow(object sender,TimeOutEventArgs eventArgs)
        {
            Console.WriteLine("On" + this.GetType()+ eventArgs.Message);
        }
    }

}
