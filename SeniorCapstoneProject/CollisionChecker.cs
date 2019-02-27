using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using d= System.Drawing;
using System.Drawing.Drawing2D;

using System.Windows.Media;



namespace SeniorCapstoneProject
{
    public class CollisionChecker
    {
        List<IFurniture> furniture;
        private  IRoom _room;
        private d.Graphics _graphics;

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
            //int[,] bounds = _room.GetBoundsMatrix();
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
            foreach (IFurniture furn in furniture)
            {
              /*  
                furnBounds[0] = new Point(furn.X, furn.Y);
                furnBounds[1] = new Point(furn.X + furn.Width, furn.Y);
                furnBounds[1] = transform.Transform(furnBounds[1]);
                furnBounds[2] = transform.Transform(new Point(furn.X, furn.Y + furn.Length));
                furnBounds[2] = transform.Transform(furnBounds[2]);
                furnBounds[3] = transform.Transform(new Point(furn.X + furn.Width, furn.Y + furn.Length));
                furnBounds[3] = transform.Transform(furnBounds[3]);*/

                Application.Current.Dispatcher.Invoke((Action)delegate {

                    RotateTransform transform = new RotateTransform();
                    transform.Angle = furn.DegreeRotation;

                    Rect furnitureBounds = new Rect();
                    furnitureBounds = transform.TransformBounds(furn.Img.RenderTransform.TransformBounds(new Rect(furn.X, furn.Y, furn.Img.Width, furn.Img.Height)));

                    transform = new RotateTransform();
                    transform.Angle = vacuum.DegreeRotation;
                    Rect vacuumBounds = new Rect();
                    vacuumBounds = transform.TransformBounds(vacuum.Img.RenderTransform.TransformBounds(new Rect(vacuum.X, vacuum.Y, vacuum.Img.Width, vacuum.Img.Height)));

                    if(vacuumBounds.IntersectsWith(furnitureBounds) && !furn.CanPassUnder())
                    {
                        collision = true;
                    }

                });
                //return false;
                
            }
            
          

            return collision;
        }


       

    }
}
