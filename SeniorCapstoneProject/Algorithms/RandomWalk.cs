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

            if (!vacuum.PointsVisited.Contains(new System.Drawing.Point(vacuum.X, vacuum.Y)))
            {
                vacuum.PointsVisited.Add(new System.Drawing.Point(vacuum.X, vacuum.Y));
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

            else if (vacuum.GetRotation() == 22)
            {
                vacuum.X += 5;
                vacuum.Y -= 8;
            }

            else if (vacuum.GetRotation() == 45)
            {
                vacuum.X += 5;
                vacuum.Y -= 5;
            }

            else if (vacuum.GetRotation() == 67)
            {
                vacuum.X += 8;
                vacuum.Y -= 5;
            }

            else if(vacuum.GetRotation()==90)
            {
                vacuum.X += 5;
            }

            else if (vacuum.GetRotation() == 112)
            {
                vacuum.X -= 5;
                vacuum.Y -= 8;
            }

            else if (vacuum.GetRotation() == 135)
            {
                vacuum.X -= 5;
                vacuum.Y -= 5;
            }

            else if (vacuum.GetRotation() == 157)
            {
                vacuum.X -= 5;
                vacuum.Y -= 8;
            }

            else if (vacuum.GetRotation() == 180)
            {
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 202)
            {
                vacuum.X -= 5;
                vacuum.Y += 8;
            }

            else if (vacuum.GetRotation() == 225)
            {
                vacuum.X -= 5;
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 247)
            {
                vacuum.X -= 8;
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 270)
            {
                vacuum.X -= 5;
            }

            else if (vacuum.GetRotation() == 292)
            {
                vacuum.X += 8;
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 315)
            {
                vacuum.X += 5;
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 315)
            {
                vacuum.X += 5;
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 337)
            {
                vacuum.X += 8;
                vacuum.Y += 5;
            }



        }

        private void Reverse(RobotVacuum vacuum)
        {
           
            if (vacuum.GetRotation() == 0)
            {
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 22)
            {
                vacuum.X -= 5;
                vacuum.Y += 8;
            }


            else if (vacuum.GetRotation() == 45)
            {
                vacuum.X -= 5;
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 67)
            {
                vacuum.X -= 8;
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 90)
            {
                vacuum.X -= 5;
            }

            else if (vacuum.GetRotation() == 112)
            {
                vacuum.X += 5;
                vacuum.Y += 8;
            }

            else if (vacuum.GetRotation() == 135)
            {
                vacuum.X += 5;
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == 157)
            {
                vacuum.X += 5;
                vacuum.Y += 8;
            }

            else if (vacuum.GetRotation() == 180)
            {
                vacuum.Y -= 5;
            }


            else if (vacuum.GetRotation() == 202)
            {
                vacuum.X += 5;
                vacuum.Y -= 8;
            }

            else if (vacuum.GetRotation() == 225)
            {
                vacuum.X += 5;
                vacuum.Y -= 5;
            }

            else if (vacuum.GetRotation() == 247)
            {
                vacuum.X += 8;
                vacuum.Y -= 5;
            }

            else if (vacuum.GetRotation() == 270)
            {
                vacuum.X += 5;
            }


            else if (vacuum.GetRotation() == 292)
            {
                vacuum.X -= 8;
                vacuum.Y -= 5;
            }

            else if (vacuum.GetRotation() == 315)
            {
                vacuum.X -= 5;
                vacuum.Y -= 5;
            }

            else if (vacuum.GetRotation() == 337)
            {
                vacuum.X -= 8;
                vacuum.Y -= 5;
            }
        }
        private void NextRotation(RobotVacuum vacuum)
        {
            Random _rnd = new Random();
            int[] rotations = { 0, 22, 45, 67, 90, 112, 135, 157, 180, 202, 225, 247, 270, 292, 315, 337  };
            int degree = _rnd.Next(0, rotations.Length);
            vacuum.RotateN(rotations[degree]);
        }

    }
}

