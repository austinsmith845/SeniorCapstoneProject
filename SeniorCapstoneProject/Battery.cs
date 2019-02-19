using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    public class Battery
    {
        private float _percent;
        public float Percent
        {
            get { return _percent; }
            set { _percent = value; }
        }

        public Battery()
        {
            Percent = 100f;
        }
    }
}
