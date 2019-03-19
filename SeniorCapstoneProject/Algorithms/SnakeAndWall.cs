using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject.Algorithms
{
    public class SnakeAndWall : IAlgorithm
    {
        #region Properties / Attributes

        private CollisionChecker _checker;
        private bool rotatedRightLast = false;
        private bool goRight = true;
        private bool goLeft = false;
      

        public string Algorithm
        {
            get { return "SnakeAndWall"; }
        }

        #endregion
        public SnakeAndWall()
        {
            _checker = RobotVacuum.Vacuum.Checker;
        }

        public void NextMove(RobotVacuum vacuum)
        {
            _checker = RobotVacuum.Vacuum.Checker;
       
            if (_checker.CollisionOccured(vacuum) && !_checker.NorthSouthWallCollision && !_checker.SideWallCollision)
            {
                if (!rotatedRightLast)
                {
                    if (goRight)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(vacuum.GetRotation() + 90);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(vacuum.GetRotation() + 90);
                    }
                }
                else
                {
                    if (goRight)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(vacuum.GetRotation() - 90);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(vacuum.GetRotation() - 90);
                    }
                }


            }

            else if (_checker.CollisionOccured(vacuum) && _checker.NorthSouthWallCollision && _checker.SideWallCollision && vacuum.X>=820)
            {
                vacuum.RotateN(90);
                Reverse(vacuum);
                Reverse(vacuum);
                vacuum.RotateN(0);
                Reverse(vacuum);
                Reverse(vacuum);
                vacuum.RotateN(180);
                goRight = false;

            }

            else if(_checker.CollisionOccured(vacuum) && _checker.NorthSouthWallCollision)
            {
                if ((vacuum.GetRotation() == 90 || vacuum.GetRotation() == 270) && vacuum.Y >= 400)
                {
                    vacuum.RotateN(0);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(180);
                    rotatedRightLast = true;
                }

                else if ((vacuum.GetRotation() == 90 || vacuum.GetRotation() == 270) && vacuum.Y <= -400)
                {
                    vacuum.RotateN(180);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(0);
                    rotatedRightLast = false;
                }

                if (!rotatedRightLast)
                {
                    if (goRight)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(vacuum.GetRotation() + 90);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(vacuum.GetRotation() + 90);
                    }
                }
                else
                {
                    if (goRight)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(vacuum.GetRotation() - 90);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(vacuum.GetRotation() - 90);
                    }
                }
            }

            else if (_checker.CollisionOccured(vacuum) && _checker.SideWallCollision)
            {
                if ((vacuum.GetRotation() == 0 || vacuum.GetRotation() == 180) && vacuum.X >= 820)
                {
                    vacuum.RotateN(90);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(270);
                    rotatedRightLast = false;
                }
                else
                {
                    if (!rotatedRightLast)
                    {
                        if (goRight)
                        {
                            rotatedRightLast = !rotatedRightLast;
                            Reverse(vacuum);
                            Reverse(vacuum);
                            vacuum.RotateN(vacuum.GetRotation() + 90);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            vacuum.RotateN(vacuum.GetRotation() + 90);
                        }
                    }
                    else
                    {
                        if (goRight)
                        {
                            rotatedRightLast = !rotatedRightLast;
                            Reverse(vacuum);
                            Reverse(vacuum);
                            vacuum.RotateN(vacuum.GetRotation() - 90);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            vacuum.RotateN(vacuum.GetRotation() + 270);
                        }
                    }
                }
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

        private void MoveForward(RobotVacuum vacuum)
        {
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

            else if (vacuum.GetRotation() == -90)
            {
                vacuum.X -= 5;
            }



            else if (vacuum.GetRotation() == -180)
            {
                vacuum.Y -= 5;
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
    }
}
