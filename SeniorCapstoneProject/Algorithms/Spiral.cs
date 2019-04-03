using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject.Algorithms
{
    public class Spiral : IAlgorithm
    {
        #region Properties / Attributes

        private CollisionChecker _checker;

        private int count = 1;


        public string Algorithm
        {
            get { return "Spiral"; }
        }

        #endregion

        private static int movesUntilTurn = 1;
        private static int movesMade = 0;
        private static int movesUntilResume;


        public Spiral()
        {
            _checker = RobotVacuum.Vacuum.Checker;
        }

        public void NextMove(RobotVacuum vacuum)
        {
            _checker = RobotVacuum.Vacuum.Checker;
            /*
            if (_checker.CollisionOccured(vacuum) && !_checker.NorthSouthWallCollision && !_checker.SideWallCollision)
            {
            }

            else if (_checker.CollisionOccured(vacuum) && _checker.NorthSouthWallCollision && _checker.SideWallCollision && vacuum.X >= 820)
            {
            }

            else if (_checker.CollisionOccured(vacuum) && _checker.NorthSouthWallCollision)
            {
            }

            else if (_checker.CollisionOccured(vacuum) && _checker.SideWallCollision)
            {
            }

            else
            {
            }
            */

            MoveForward(vacuum);


            AddPoints(vacuum);
        }

        private void MoveForward(RobotVacuum vacuum)
        {
            if (movesMade == movesUntilTurn)
            {
                vacuum.RotateN(vacuum.GetRotation() + 90);
                if (vacuum.GetRotation() == 360)
                {
                    vacuum.RotateN(0);
                }
                movesUntilTurn += 3;
                movesMade = 0;
            }

            if (_checker.CollisionOccured(vacuum))
            {
                movesMade = 0;
                movesUntilTurn = 1;
                movesUntilResume = 50;

                if (vacuum.GetRotation() == 0)
                {
                    vacuum.RotateN(180);
                }

                else if (vacuum.GetRotation() == 90)
                {
                    vacuum.RotateN(270);
                }

                else if (vacuum.GetRotation() == 180)
                {
                    vacuum.RotateN(0);
                }

                else if (vacuum.GetRotation() == 270)
                {
                    vacuum.RotateN(90);
                }

            }
            if (vacuum.GetRotation() == 0)
            {
                vacuum.Y -= 5;
            }

            else if (vacuum.GetRotation() == 90)
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

            if (movesUntilResume == 0)
            {
                movesMade += 1;
            }
            else
            {
                movesUntilResume--;
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

            else if (vacuum.GetRotation() == -90)
            {
                vacuum.X += 5;
            }

            else if (vacuum.GetRotation() == -180)
            {
                vacuum.Y += 5;
            }

            else if (vacuum.GetRotation() == -270)
            {
                vacuum.X -= 5;
            }
        }

        private void AddPoints(RobotVacuum vacuum)
        {
            object locker = new object();
            lock (locker)
            {
                int x = vacuum.X;
                int y = vacuum.Y;
                while (x < vacuum.X + vacuum.Width)
                {
                    y = vacuum.Y;
                    while (y < vacuum.Y + vacuum.Width)
                    {

                        if (!vacuum.PointsVisited.ContainsKey(new System.Drawing.Point(x, y)))
                        {
                            vacuum.PointsVisited.Add(new System.Drawing.Point(x, y), true);
                        }

                        y++;
                    }
                    x++;
                }
            }
        }
    }
}
