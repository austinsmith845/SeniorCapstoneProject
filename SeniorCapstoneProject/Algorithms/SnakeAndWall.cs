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
        private bool goRight = true; //Change this back to true
        private bool upAndDown = true;


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

            if (_checker.CollisionOccured(vacuum) && _checker.NorthSouthWallCollision && _checker.SideWallCollision && vacuum.X >= 820)
            {
                if (vacuum.Y < 0)
                {
                    vacuum.RotateN(90);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(0);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(180);
                    goRight = false;
                    upAndDown = true;
                }
                else
                {
                    vacuum.RotateN(90);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(180);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(0);
                    goRight = false;
                    upAndDown = true;
                }

            }

            if (_checker.CollisionOccured(vacuum) && _checker.NorthSouthWallCollision && _checker.SideWallCollision && vacuum.X <= -820)
            {
                if (vacuum.Y > 0)
                {
                    vacuum.RotateN(0);
                    Reverse(vacuum);
                    Reverse(vacuum);

                    vacuum.RotateN(270);
                    Reverse(vacuum);
                    Reverse(vacuum);

                    vacuum.RotateN(180);
                    goRight = false;
                    upAndDown = true;
                }
                else
                {
                    vacuum.RotateN(270);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(180);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(0);
                    goRight = false;
                    upAndDown = true;
                }

            }

            else if (_checker.CollisionOccured(vacuum) && _checker.NorthSouthWallCollision)
            {
                if ((vacuum.GetRotation() == 90 || vacuum.GetRotation() == 270) && vacuum.Y >= 400)
                {


                    vacuum.RotateN(180);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(0);
                    rotatedRightLast = true;
                    upAndDown = true;
                }

                else if ((vacuum.GetRotation() == 90 || vacuum.GetRotation() == 270) && vacuum.Y <= -400)
                {
                    vacuum.RotateN(0);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    Reverse(vacuum);
                    vacuum.RotateN(180);
                    rotatedRightLast = false;
                    upAndDown = true;
                }

                if (_checker.CollidedFurnitureObject != null)
                {
                    if (vacuum.X <= 0)
                    {
                        goRight = false;
                    }
                    else
                    {
                        goRight = true;
                    }

                    if (vacuum.X >= _checker.CollidedFurnitureObject.X)
                    {
                        //vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                        upAndDown = false;

                        rotatedRightLast = false;
                        vacuum.RotateN(270);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(90);
                    }
                    else
                    {
                        rotatedRightLast = true;
                        upAndDown = false;
                        vacuum.RotateN(90);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(270);
                    }
                    if (vacuum.Y <= -400)
                    {
                        vacuum.Y += 10;
                    }
                    else if (vacuum.Y >= 400)
                    {

                        vacuum.Y -= 10;
                    }
                    // upAndDown = false;
                }
              

                //else
                //{
                if (!rotatedRightLast)
                {
                    if (goRight && upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(90);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(180);
                        if (_checker.CollisionOccured(vacuum))
                        {
                            if (_checker.CollidedFurnitureObject != null)
                            {
                                if (vacuum.Y <= 0)
                                {
                                    goRight = false;
                                }
                                else
                                {
                                    goRight = true;
                                }

                                if (vacuum.X >= _checker.CollidedFurnitureObject.X)
                                {

                                    // vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                                    upAndDown = false;

                                    rotatedRightLast = false;
                                    vacuum.RotateN(270);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(90);
                                }
                                else
                                {
                                    rotatedRightLast = true;
                                    upAndDown = false;
                                    vacuum.RotateN(90);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(270);
                                }
                            }
                        }
                    }

                    else if (!goRight && upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(270);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(0);
                        if (_checker.CollisionOccured(vacuum))
                        {
                            if (_checker.CollidedFurnitureObject != null)
                            {
                                if (vacuum.Y <= 0)
                                {
                                    goRight = false;
                                }
                                else
                                {
                                    goRight = true;
                                }

                                if (vacuum.X >= _checker.CollidedFurnitureObject.X)
                                {

                                    // vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                                    upAndDown = false;
                                    rotatedRightLast = false;
                                    vacuum.RotateN(270);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(90);
                                }
                                else
                                {
                                    rotatedRightLast = true;
                                    upAndDown = false;
                                    vacuum.RotateN(90);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(270);
                                }
                            }
                        }
                    }

                    else if (goRight && !upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        //Reverse(vacuum);
                        //Reverse(vacuum);
                        vacuum.RotateN(270);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        //vacuum.RotateN(0);
                        if (_checker.CollisionOccured(vacuum))
                        {
                            if (_checker.CollidedFurnitureObject != null)
                            {
                                if (vacuum.Y <= 0)
                                {
                                    goRight = false;
                                }
                                else
                                {
                                    goRight = true;
                                }

                                if (vacuum.X >= _checker.CollidedFurnitureObject.X)
                                {

                                    // vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                                    upAndDown = false;
                                    rotatedRightLast = false;
                                    vacuum.RotateN(270);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(90);
                                }
                                else
                                {
                                    rotatedRightLast = true;
                                    upAndDown = false;
                                    vacuum.RotateN(90);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(270);
                                }
                            }
                        }
                    }
                }

                else
                {
                    if (goRight && upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(90);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(0);
                        if (_checker.CollisionOccured(vacuum))
                        {
                            if (_checker.CollidedFurnitureObject != null)
                            {
                                if (vacuum.Y <= 0)
                                {
                                    goRight = false;
                                }
                                else
                                {
                                    goRight = true;
                                }

                                if (vacuum.X >= _checker.CollidedFurnitureObject.X)
                                {
                                    //vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                                    upAndDown = false;
                                    rotatedRightLast = false;
                                    vacuum.RotateN(270);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(90);
                                }
                                else
                                {
                                    rotatedRightLast = true;
                                    upAndDown = false;
                                    vacuum.RotateN(90);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(270);
                                }
                            }
                        }
                    }

                    else if (!goRight && upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(270);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(180);
                        if (_checker.CollisionOccured(vacuum))
                        {
                            if (_checker.CollidedFurnitureObject != null)
                            {
                                if (vacuum.Y <= 0)
                                {
                                    goRight = false;
                                }
                                else
                                {
                                    goRight = true;
                                }

                                if (vacuum.X >= _checker.CollidedFurnitureObject.X)
                                {
                                    // vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                                    upAndDown = false;
                                    rotatedRightLast = false;
                                    vacuum.RotateN(270);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(90);
                                }
                                else
                                {
                                    rotatedRightLast = true;
                                    upAndDown = false;
                                    vacuum.RotateN(90);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    Reverse(vacuum);
                                    vacuum.RotateN(270);
                                }
                            }
                        }
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
                    upAndDown = false;
                }
                else
                {
                    if (_checker.CollisionOccured(vacuum))
                    {
                        if (_checker.CollidedFurnitureObject != null)
                        {
                            if (vacuum.X <= 0)
                            {
                                goRight = true;
                            }
                            else
                            {
                                goRight = false;
                            }

                            if (vacuum.Y <= _checker.CollidedFurnitureObject.Y)
                            {
                                upAndDown = true;
                                rotatedRightLast = false;
                                vacuum.RotateN(180);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                vacuum.RotateN(0);
                            }
                            else
                            {
                                rotatedRightLast = true;
                                upAndDown = true;
                                vacuum.RotateN(0);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                Reverse(vacuum);
                                vacuum.RotateN(180);
                            }
                        }
                    }

                    if (!rotatedRightLast)
                    {
                        if (goRight && !upAndDown)
                        {

                            rotatedRightLast = !rotatedRightLast;
                            Reverse(vacuum);
                            Reverse(vacuum);
                            vacuum.RotateN(0);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            vacuum.RotateN(270);
                            if (_checker.CollisionOccured(vacuum))
                            {
                                if (_checker.CollidedFurnitureObject != null)
                                {
                                    if (vacuum.X <= 0)
                                    {
                                        goRight = true;
                                    }
                                    else
                                    {
                                        goRight = false;
                                    }

                                    if (vacuum.Y <= _checker.CollidedFurnitureObject.Y)
                                    {
                                        // vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                                        upAndDown = true;
                                        rotatedRightLast = false;
                                        vacuum.RotateN(180);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        vacuum.RotateN(0);
                                    }
                                    else
                                    {
                                        rotatedRightLast = true;
                                        upAndDown = true;
                                        vacuum.RotateN(0);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        vacuum.RotateN(180);
                                    }
                                }
                            }
                        }

                        else if (!goRight && !upAndDown)
                        {

                            rotatedRightLast = !rotatedRightLast;
                            Reverse(vacuum);
                            Reverse(vacuum);
                            vacuum.RotateN(180);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            vacuum.RotateN(90);
                            if (_checker.CollisionOccured(vacuum))
                            {
                                if (_checker.CollidedFurnitureObject != null)
                                {
                                    if (vacuum.X <= 0)
                                    {
                                        goRight = true;
                                    }
                                    else
                                    {
                                        goRight = false;
                                    }

                                    if (vacuum.Y <= _checker.CollidedFurnitureObject.Y)
                                    {
                                        // vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                                        upAndDown = true;
                                        rotatedRightLast = false;
                                        vacuum.RotateN(180);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        vacuum.RotateN(0);
                                    }
                                    else
                                    {
                                        rotatedRightLast = true;
                                        upAndDown = true;
                                        vacuum.RotateN(0);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        vacuum.RotateN(180);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!goRight && !upAndDown)
                        {


                            rotatedRightLast = !rotatedRightLast;
                            Reverse(vacuum);
                            Reverse(vacuum);
                            vacuum.RotateN(180);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            vacuum.RotateN(270);
                            if (_checker.CollidedFurnitureObject != null)
                            {
                                if (vacuum.X <= 0)
                                {
                                    goRight = true;
                                }
                                else
                                {
                                    goRight = false;
                                }

                                if (_checker.CollisionOccured(vacuum))
                                {

                                    if (vacuum.Y <= _checker.CollidedFurnitureObject.Y)
                                    {
                                        // vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                                        upAndDown = true;
                                        rotatedRightLast = false;
                                        vacuum.RotateN(180);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum); vacuum.RotateN(0);
                                    }
                                    else
                                    {
                                        rotatedRightLast = true;
                                        upAndDown = true;
                                        vacuum.RotateN(0);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        vacuum.RotateN(180);
                                    }
                                }
                            }
                        }

                        else if (goRight && !upAndDown)
                        {

                            rotatedRightLast = !rotatedRightLast;
                            Reverse(vacuum);
                            Reverse(vacuum);
                            vacuum.RotateN(0);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            MoveForward(vacuum);
                            vacuum.RotateN(90);

                            if (_checker.CollisionOccured(vacuum))
                            {
                                if (_checker.CollidedFurnitureObject != null)
                                {
                                    if (vacuum.X <= 0)
                                    {
                                        goRight = true;
                                    }
                                    else
                                    {
                                        goRight = false;
                                    }

                                    if (vacuum.Y <= _checker.CollidedFurnitureObject.Y)
                                    {
                                        // vacuum.X += (int)_checker.CollidedFurnitureObject.Width;
                                        upAndDown = true;
                                        rotatedRightLast = false;
                                        vacuum.RotateN(180);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum); vacuum.RotateN(0);
                                    }
                                    else
                                    {
                                        rotatedRightLast = true;
                                        upAndDown = true;
                                        vacuum.RotateN(0);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        Reverse(vacuum);
                                        vacuum.RotateN(180);
                                    }
                                }
                            }
                        }
                    }
                    // }

                }
            }

            else if (_checker.CollisionOccured(vacuum) && !_checker.NorthSouthWallCollision && !_checker.SideWallCollision)
            {
                if (!rotatedRightLast)
                {
                    if (goRight && upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(90);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(180);

                    }
                    else if (goRight && !upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(0);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(90);
                    }

                    else if (!goRight && upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(270);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(0);
                    }

                    else if (!goRight && !upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(180);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(90);
                    }
                }
                else
                {
                    if (goRight && upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(90);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(0);
                    }
                    else if (goRight && !upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(0);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(270);
                    }

                    else if (!goRight && upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(270);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(180);
                    }

                    else if (!goRight && !upAndDown)
                    {
                        rotatedRightLast = !rotatedRightLast;
                        Reverse(vacuum);
                        Reverse(vacuum);
                        vacuum.RotateN(180);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        MoveForward(vacuum);
                        vacuum.RotateN(270);
                    }

                }
            }






            else
            {
                MoveForward(vacuum);
            }

            //if (!vacuum.PointsVisited.Contains(new System.Drawing.Point(vacuum.X, vacuum.Y)))
            //{
            //    vacuum.PointsVisited.Add(new System.Drawing.Point(vacuum.X, vacuum.Y));
            //}
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
            while (!AddPoints(vacuum))
            {
              
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
        private bool AddPoints(RobotVacuum vacuum)
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
                return true;
            }
        }
    }
}
