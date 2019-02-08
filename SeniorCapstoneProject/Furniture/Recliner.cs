using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject.Furniture
{
    public class Recliner : IFurniture
    {
        private float _height = 50.8f; //this is the average height of a recliner in cm.
        public float Height
        {
            get { return _height; }

        }

        private float _width = 91.44f; //this is the average width in cm.
        public  float Width
        {
            get { return _width; }
        }



        #region Support Methods

        public void Select()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns wether or not the robot can pass under.
        /// </summary>
        /// <returns></returns>
        public bool CanPassUnder()
        {
            RobotVacuum vacuum = RobotVacuum.Vacuum;
            if(this.Height > vacuum.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
