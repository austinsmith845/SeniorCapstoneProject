using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject.Algorithms
{
    public class RandomWalk : IAlgorithm
    {
       
        public string Algorithm
        {
            get { return "Random Walk"; }
        }

        public void NextMove(RobotVacuum vacuum)
        {
            MoveForward(vacuum);
        }

        private void MoveForward(RobotVacuum vacuum)
        {
            int rotation = vacuum.GetRotation();
            if (rotation == 0)
            {
                vacuum.Y += 5;
            }
        }
    }
}

