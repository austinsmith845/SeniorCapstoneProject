using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// This class's sole job is to notify other objects that the timer has ticked so that they can update
    /// their state.
    /// </summary>
    public class TimeTickObserver : ITimeTickObserver
    {
        TimerTick handler;

        public TimeTickObserver(TimerTick tick)
        {
            handler += tick;
        }

        /// <summary>
        /// Adds a new handler (method) to the delegate to be called when the timer ticks.
        /// </summary>
        /// <param name="tick"></param>
        public void RegisterTimerListener(TimerTick tick)
        {
            handler += tick;
        }

        /// <summary>
        /// Called by the timer when the timer has ticked.
        /// </summary>
        public void TimerHasTicked(int secs)
        {
            handler(secs);
        }
    }
}
