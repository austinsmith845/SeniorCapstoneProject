﻿using System;
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
    /// Represents the chair object.
    /// </summary>
    [Serializable]
    public class DeskChair : IFurniture
    {
        #region Attributes / Properties

        private float _height = 0; //this is the average height of a recliner in cm.
        public float Height
        {
            get { return _height; }

        }

        private float _width = 0; //this is the average width in cm.
        public float Width
        {
            get { return _width; }
        }


        
        public float Length
        {
            get { return this.Width; }
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
            set { _x = value; }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private int _rotation = 0;
        public int DegreeRotation
        {
            get { return _rotation; }
        }

        private FurnitureTypes _type;
        public FurnitureTypes Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [NonSerialized]
        private Image _img;
        public Image Img
        {
            get { return _img; }
            set { _img = value; Img.MouseDown += Select; Img.Width = this.Width; Img.Height = this.Width; }
        }

        [NonSerialized]
        private Grid _grid;


        [NonSerialized]
        RotateTransform rotation;




        #endregion

        #region Constructors
        public DeskChair(FurnitureTypes type, Grid grid)
        {
            this.Type = type;
            _grid = grid;
            FurnitureSetupWindow box = new FurnitureSetupWindow();

            box.txtLength.IsEnabled = false;
            while ((bool)box.ShowDialog(GetDialogResult)) ;


        }


        private void GetDialogResult(string height, string width, string length, int rotation)
        {
            if (this.Height == 0)
            {
                _height = float.Parse(height);

            }
            if (this.Width == 0)
            {
                _width = float.Parse(width);
            }

            
        }


    

        #endregion

        #region Support Methods

        public void SetRotation()
        {
            rotation = new RotateTransform(_rotation);
            Img.RenderTransform = rotation;
        }

        /// <summary>
        /// This method is called when the piece of furniture is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Select(Object sender, MouseButtonEventArgs args)
        {
            if (!Selected)
            {
                Selected = true;
            }
            else
            {
                Selected = false;
            }
        }

        public void MoveUp()
        {
            if (Selected)
            {
                this.Y -= 5;
                Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            }

        }

        public void MoveDown()
        {
            if (Selected)
            {
                this.Y += 5;
                Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            }

        }

        public void MoveLeft()
        {

            this.X -= 5;
            Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);

        }

        public void MoveRight()
        {
            if (Selected)
            {
                this.X += 5;
                Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            }

        }

        public void RotateRight()
        {
            if (Selected)
            {
                _rotation += 15; //this is in degrees
                rotation = new RotateTransform(_rotation);
                Img.RenderTransform = rotation;
            }
        }

        public void RotateLeft()
        {
            if (Selected)
            {
                _rotation -= 15; //this is in degrees
                rotation = new RotateTransform(_rotation);
                Img.RenderTransform = rotation;
            }
        }
        /// <summary>
        /// Returns whether or not the robot can pass under.
        /// </summary>
        /// <returns></returns>
        public bool CanPassUnder()
        {
            RobotVacuum vacuum = RobotVacuum.Vacuum;
            if (this.Height > vacuum.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetGrid(Grid grid)
        {
            _grid = grid;
        }
        #endregion
    }
}

