using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SeniorCapstoneProject
{
    public class Timer :ITimer
    {
        private int _secs;
        private TimeTickObserver _observer;
        private bool _enabled = false;
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }


        public Timer(TimeTickObserver observer)
        {
            _observer = observer;
            Enabled = true;

        }

        /// <summary>
        /// Ticks the timer, this method runs in its own thread.
        /// </summary>
        public void Tick()
        {
            if (Enabled)
            {
                Thread.Sleep(1000);
                _secs++;
                _observer.TimerHasTicked(_secs);
                Tick();
            }
        }
    }
}
