using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SeniorCapstoneProject.Furniture
{
    /// <summary>
    /// This class represents the Recliner object.
    /// </summary>
    public class Recliner : IFurniture
    {
        #region Attributes / Properties

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

        public bool Selected
        {
            get;
            set;
        }

        private int _x;
        public int X
        {
            get { return _x; }
            set { _x = value;  }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value;  }
        }

        private FurnitureTypes _type;
        public FurnitureTypes Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private Image _img;
        public Image Img
        {
            get { return _img; }
            set { _img = value; Img.MouseDown += Select; }
        }

        private Grid _grid;
        private int _rotation = 0;


        #endregion

        #region Constructors
        public Recliner(FurnitureTypes type, Grid grid)
        {
            this.Type = type;
            _grid = grid;
        }

        #endregion

        #region Support Methods

        /// <summary>
        /// This method is called when the piece of furniture is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Select(Object sender, MouseButtonEventArgs args)
        {

            Selected = !Selected;

        }

        public void MoveUp()
        {

            this.Y -= 5;
            Img.Margin = new System.Windows.Thickness(X , Y, 0, 0);
            
        }

        public void MoveDown()
        {

            this.Y += 5;
            Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);

        }

        public void MoveLeft()
        {

            this.X -= 5;
            Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);

        }

        public void MoveRight()
        {

            this.X += 5;
            Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);

        }

        public void RotateRight()
        {
            _rotation += 15; //this is in degrees
            RotateTransform rotation = new RotateTransform(_rotation);
            Img.RenderTransform = rotation;
        }

        public void RotateLeft()
        {
            _rotation -= 15; //this is in degrees
            RotateTransform rotation = new RotateTransform(_rotation);
            Img.RenderTransform = rotation;
        }
        /// <summary>
        /// Returns whether or not the robot can pass under.
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
