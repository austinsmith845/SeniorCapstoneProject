using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using d = System.Drawing;
using System.Drawing.Drawing2D;

using System.Windows.Media;



namespace SeniorCapstoneProject
{
    public class CollisionChecker
    {
        List<IFurniture> furniture;
        private IRoom _room;
        private d.Graphics _graphics;
        
        public bool SideWallCollision
        {
            get;
            set;
        }

        public bool NorthSouthWallCollision
        {
            get;
            set;
        }

        public CollisionChecker(List<IFurniture> furn, IRoom room)
        {
            furniture = furn;
            _room = room;

        }

        /// <summary>
        /// This method will check for collsions.
        /// </summary>
        /// <returns></returns>
        public bool CollisionOccured(RobotVacuum vacuum)
        {
            bool collision = false;
            NorthSouthWallCollision = false;
            SideWallCollision = false;
           
            // int[,] bounds = new int[1640, 840];
            /*  Point[] furnBounds = new Point[4];
              Point[] vacBounds = new Point[4];


              vacBounds[0] = new Point(vacuum.X , vacuum.Y);
              vacBounds[1] = new Point(vacuum.X + vacuum.Width , vacuum.Y);
              vacBounds[2] = new Point(vacuum.X, vacuum.Y + vacuum.Y);
              vacBounds[3] = new Point(vacuum.X + vacuum.Width, vacuum.Y + vacuum.Width);

              d.PointF[] dpoint= new d.PointF[4];
              int i = 0;
              foreach(Point p in vacBounds)
              {
                  dpoint[i++] = new d.PointF((float)p.X, (float)p.Y);
              }

              GraphicsPath path = new GraphicsPath();
              path.AddPolygon(dpoint);
              d.Region region = new d.Region(path);

              */
            lock (this)
            {
                Point robotPoint = new Point(vacuum.X, vacuum.Y);
                foreach (IFurniture furn in furniture)
                {
                    Rect furnitureBounds = new Rect(furn.X, furn.Y, furn.Width, furn.Length);
                    Rect vacuumBounds = new Rect(vacuum.X, vacuum.Y, vacuum.Width, vacuum.Width);

                   

                    if ((furnitureBounds.IntersectsWith(vacuumBounds)) && !furn.CanPassUnder())// || (furnitureBounds.Contains(robotPoint) || furnitureBounds.Contains(new Point(robotPoint.X + vacuum.Width, robotPoint.Y)) || furnitureBounds.Contains(new Point(robotPoint.X, vacuum.Y + vacuum.Height)) || furnitureBounds.Contains(new Point(robotPoint.X + vacuum.Width, vacuum.Y + vacuum.Height))) && !furn.CanPassUnder())
                    {
                        collision = true;
                    }

                    if ((vacuum.X >= furn.X - furn.Width && vacuum.X <= furn.X + furn.Width) && (vacuum.Y >= furn.Y - furn.Length && vacuum.Y <= furn.Y + furn.Length) && !furn.CanPassUnder())
                    {
                        collision = true;
                    }

                    furnitureBounds.Intersect(vacuumBounds);

                    if (!furnitureBounds.IsEmpty && !furn.CanPassUnder())
                    {
                        return true;
                    }


                }
                /*
                        if(!intersect.IsEmpty)
                        {
                           collision = true;
                        }*/


                if (vacuum.X >= 820)
                {
                    collision = true;
                    SideWallCollision = true;
                }

                if (vacuum.X <= -820)
                {
                    collision = true;
                    SideWallCollision = true;
                }

                if (vacuum.Y >= 400)
                {
                    collision = true;
                    NorthSouthWallCollision = true;
                }

                if (vacuum.Y <= -400)
                {
                    NorthSouthWallCollision = true;
                    return true;
                }



                //return false;

            }
            return collision;

        }

    }




}

