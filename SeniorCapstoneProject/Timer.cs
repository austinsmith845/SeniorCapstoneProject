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
        private ITimeTickObserver _observer;
        private bool _enabled = false;
        private int _timeStep;
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        /// <summary>
        /// Creates a new timer.
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="timeStep">in millisecons</param>
        public Timer(ITimeTickObserver observer, int timeStep)
        {
            _observer = observer;
            _timeStep = timeStep;
            Enabled = true;

        }

        /// <summary>
        /// Ticks the timer, this method runs in its own thread.
        /// </summary>
        public void Tick()
        {
            if (Enabled)
            {
                Thread.Sleep(_timeStep);
                _secs++;
                _observer.TimerHasTicked(_secs);
                Tick();
            }
        }
    }
}
