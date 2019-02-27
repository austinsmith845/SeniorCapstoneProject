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

            if (_checker.CollisionOccured(vacuum))
            {
                Reverse(vacuum);
                Reverse(vacuum);
                Reverse(vacuum);
                Reverse(vacuum);
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
            if (vacuum.GetRotation() == 0)
            {
                vacuum.Y -= 5;
            }
      
            else if(vacuum.GetRotation()==90)
            {
                vacuum.X += 5;
            }

            else if (vacuum.GetRotation() == 180)
            {
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 270)
            {
                vacuum.X -= 5;
            }

            else if (vacuum.GetRotation() == -90)
            {
                vacuum.X -= 5;
            }

            else if (vacuum.GetRotation() == -180)
            {
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == -270)
            {
                vacuum.X += 5;
            }
        }

        private void Reverse(RobotVacuum vacuum)
        {
           
            if (vacuum.GetRotation() == 0)
            {
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 90)
            {
                vacuum.X -= 5;
            }

            else if (vacuum.GetRotation() == 180)
            {
                vacuum.Y -= 5;
            }

            else if (vacuum.GetRotation() == 270)
            {
                vacuum.X += 5;
            }
        }
        private void NextRotation(RobotVacuum vacuum)
        {
            Random _rnd = new Random();
            int[] rotations = { 0, 90, 180, 270 };
            int degree = _rnd.Next(0, 4);
            vacuum.RotateN(rotations[degree]);
        }

    }
}

