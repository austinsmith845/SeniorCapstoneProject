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
                NextRotation(vacuum); //Lets turn in a random direction when a collision detection.
            }
            else
            {
               
                MoveForward(vacuum);
            }
        }

        /// <summary>
        /// Needs to be updated to calculate what point is forward.
        /// </summary>
        /// <param name="vacuum"></param>
        private void MoveForward(RobotVacuum vacuum)
        {
            vacuum.Y -= 5;
        }

        private void NextRotation(RobotVacuum vacuum)
        {
            Random _rnd = new Random();
            int degree = _rnd.Next(1, 360);
            vacuum.RotateN(degree);
        }

    }
}

