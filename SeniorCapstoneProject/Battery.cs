using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// This class represents a Battery for the vacuum. It implements the Singleton pattern to ensure that the vacuum
    /// only has one battery.
    /// </summary>
    public class Battery
    {
        private float _percent;
        public float Percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                if (_percent <= 0)
                {
                    observer.BatteryDead(); //call the battery dead handlers.
                    observer = null;
                }
            }

        }

        private static Battery _instance;
        public static Battery Instance
        {
            get
            {   
                if(_instance == null)
                {
                    _instance = new Battery();
                }
                return _instance;
            }
           
        }

        private BatteryDeadObserver observer;
        public BatteryDeadObserver BatteryDead
        {
            get
            {
                if(observer == null)
                {
                    observer = new BatteryDeadObserver();
                }
                return observer;
            }
        }


        private Battery()
        {
            Percent = 100f;
        }
    }
}
