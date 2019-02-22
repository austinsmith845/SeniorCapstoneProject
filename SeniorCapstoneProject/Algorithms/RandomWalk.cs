using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject.Algorithms
{
    public class RandomWalk : IAlgorithm
    {
        private CollisionChecker _checker;

        public RandomWalk()
        {
           
        }

        public string Algorithm
        {
            get { return "Random Walk"; }
        }

        public void NextMove(RobotVacuum vacuum)
        {
            _checker = RobotVacuum.Vacuum.Checker;

            if (_checker.CollisionOccured())
            {

            }
            else
            {
                MoveForward(vacuum);
            }
        }

        private void MoveForward(RobotVacuum vacuum)
        {
            int rotation = vacuum.GetRotation();
            if (rotation == 0)
            {
                vacuum.Y -= 5;
            }
        }
    }
}

