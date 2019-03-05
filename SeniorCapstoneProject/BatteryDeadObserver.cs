using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    public class BatteryDeadObserver
    {
        public delegate void BatteryIsDead();

        BatteryIsDead batteryDeadHandler;

        public BatteryDeadObserver()
        {

        }

        public BatteryDeadObserver(BatteryIsDead handler)
        {
            batteryDeadHandler += handler;
        }

        /// <summary>
        /// Add a method to call to the handler if the battery dies.
        /// </summary>
        /// <param name="handler"></param>
        public void RegisterHandler(BatteryIsDead handler)
        {
            batteryDeadHandler += handler;
        }

        /// <summary>
        /// Call all the methods attached to the handler when the battery dies.
        /// </summary>
        public void BatteryDead()
        {
            batteryDeadHandler();
        }

    }
}
