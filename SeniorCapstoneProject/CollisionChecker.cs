using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using d= System.Drawing;

using System.Windows.Media;



namespace SeniorCapstoneProject
{
    public class CollisionChecker
    {
        List<IFurniture> furniture;
        public IRoom _room;

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
            Point[] furnBounds = new Point[4];
            Point[] vacBounds = new Point[4];
            RotateTransform transform = new RotateTransform();

            vacBounds[0] = new Point(vacuum.X , vacuum.Y);
            vacBounds[1] = new Point(vacuum.X + vacuum.Width , vacuum.Y);
            vacBounds[2] = new Point(vacuum.X, vacuum.Y + vacuum.Y);
            vacBounds[3] = new Point(vacuum.X + vacuum.Width, vacuum.Y + vacuum.Width);

           /* Polygon vacuumBounds = new Polygon();
            PointCollection points = new PointCollection(vacBounds);
            vacuumBounds.Points = points;*/


            foreach (IFurniture furn in furniture)
            {
                transform.Angle = furn.DegreeRotation;
                furnBounds[0] = new Point(furn.X, furn.Y);
                furnBounds[1] = new Point(furn.X + furn.Width, furn.Y);
                furnBounds[1] = transform.Transform(furnBounds[1]);
                furnBounds[2] = transform.Transform(new Point(furn.X, furn.Y + furn.Length));
                furnBounds[2] = transform.Transform(furnBounds[2]);
                furnBounds[3] = transform.Transform(new Point(furn.X + furn.Width, furn.Y + furn.Length));
                furnBounds[3] = transform.Transform(furnBounds[3]);

                //Application.Current.Dispatcher.Invoke((Action)delegate {
                //Polygon furnitureBounds = new Polygon();
                //PointCollection furnPoints = new PointCollection(furnBounds);


                //  });
                return false;
                
            }
            
          

            return collision;
        }


       

    }
}
