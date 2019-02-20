using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    public class RobotMovedObserver
    {
        public delegate void RobotMoved();
        RobotMoved Handler;

        public void RegisterCallBack(RobotMoved handler)
        {
            Handler += handler;
        }

        public void RobotHasMoved()
        {
            Handler();
        }
       
    }
}
