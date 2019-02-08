using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// This class will implement the singelton patter to ensure that there is always only one robot vacuum cleaner.
    /// </summary>
    public class RobotVacuum
    {
        #region Properties

        private static RobotVacuum _vacuum;
        public static RobotVacuum Vacuum
        {
            get
            {
               if(_vacuum == null )
                {
                    _vacuum = new RobotVacuum();
                }
                return _vacuum;
            }

        }

        private float _height = 6.9f; //This is in cm
        public float Height
        {
            get { return _height; } //no set here to ensure the user can not change the robot's height
        }

        private float _width = 13.9f; //This is in cm
        public float Width
        {
            get { return _width; } //no set here to ensure the user can not change the robot's height
        }

        //Will need a battery object eventually.
        #endregion

        #region Constructor

        /// <summary>
        /// This constructor is set to private to enure the singelton pattern is followed
        /// </summary>
        private RobotVacuum()
        {
            
        }

        #endregion

        #region Support Methods

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void GetNextAction()
        {
            throw new NotImplementedException();
        }
        #endregion 


    }
}
