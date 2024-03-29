﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// This class will implement the singelton patter to ensure that there is always only one robot vacuum cleaner.
    /// </summary>
    [Serializable]
    public class RobotVacuum
    {
        #region Properties

        private object lockobj = new object();

        private static object locker = new object();

        [NonSerialized]
        Thread thread;

        private static RobotVacuum _vacuum;
        public static RobotVacuum Vacuum
        {
            get
            {
                lock (locker)
                {
                    if (_vacuum == null)
                    {
                        _vacuum = new RobotVacuum();
                    }
                    return _vacuum;
                }
            
            }

        }

        [NonSerialized]
        private RobotMovedObserver _observer;
        public RobotMovedObserver MoveNotifier
        {
            get { return _observer; }
            set { _observer = value; }
        }

        [NonSerialized]
        private Dictionary<System.Drawing.Point,bool> _pointsVisited;
        public Dictionary<System.Drawing.Point,bool> PointsVisited
        {
            get {
                if (_pointsVisited == null)
                {
                    _pointsVisited = new Dictionary<System.Drawing.Point, bool>();
                }
                return _pointsVisited;
            }
        }

        private float _height = 9.144f; //This is in cm
        public float Height
        {
            get { return _height; } //no set here to ensure the user can not change the robot's height
        }

        private float _width = 35.30f; //This is in cm
        public float Width
        {
            get { return _width; } //no set here to ensure the user can not change the robot's height
        }

        private int _x;
        public int X
        {
            get {
                lock (this)
                {
                    return _x;
                }
            }

            set
            {
                lock (this)
                {
                    _x = value;
                }
                if (MoveNotifier != null)
                {
                    MoveNotifier.RobotHasMoved();
                }
            }
            
        }

        private int _y;
        public int Y
        {
            get
            {
                lock (this)
                {
                    return _y;
                }
            }
            set
            {
                lock (this)
                {
                    _y = value;
                }
                if (MoveNotifier != null)
                {
                    MoveNotifier.RobotHasMoved();
                }
            }
        }

        [NonSerialized]
        private IAlgorithm _algorithim;
        public IAlgorithm Algorithm
        {
            get { return _algorithim; }
            set { _algorithim = value; }
        }


        private bool _selected;

        [NonSerialized]
        private ITimer timer;

        [NonSerialized]
        private Battery battery = Battery.Instance;
        public Battery Battery
        {
            get { return Battery.Instance; }
        }

        

        [NonSerialized]
        private Image _img;
        public Image Img
        {
            get { return _img; }
            set { _img = value; Img.HorizontalAlignment = System.Windows.HorizontalAlignment.Center; Img.MouseDown += Select; Img.Width = this.Width; Img.Height = this.Width; Img.Margin = new System.Windows.Thickness(X, Y, 0, 0); }
        }

        private int _rotation = 0;
        public int DegreeRotation
        {
            get { return _rotation; }
        }


        [NonSerialized]
        private Grid _grid;

        [NonSerialized]
        RotateTransform rotation;
        internal RotateTransform Rotation
        {
            get { return rotation; }
        }

        private ITimeTickObserver observer;
        public ITimeTickObserver Observer
        {
            get { return observer; }
            set { observer = value; }
        }

        [NonSerialized]
        private CollisionChecker _checker;
        public CollisionChecker Checker
        {
            get { return _checker; }
            set { _checker = value; }
            
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

        /// <summary>
        /// This method is called when the piece of furniture is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Select(Object sender, MouseButtonEventArgs args)
        {
            if (!_selected)
            {
                _selected = true;
            }
            else
            {
                _selected = false;
            }
        }

        public void MoveUp()
        {
            if (_selected)
            {
                this.Y -= 5;
                Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            }

        }

        public void MoveDown()
        {
            if (_selected)
            {
                this.Y += 5;
                Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            }

        }

        public void MoveLeft()
        {
            if (_selected)
            {
                this.X -= 5;
                Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            }

        }

        public void MoveRight()
        {
            if (_selected)
            {
                this.X += 5;
                Img.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            }

        }

        public void RotateRight()
        {
            if (_selected)
            {
                _rotation += 90; //this is in degrees
                if(_rotation == 360 || _rotation == -360)
                {
                    _rotation = 0;
                }
                rotation = new RotateTransform(_rotation);
                Img.RenderTransform = rotation;
            }
        }

        public void RotateLeft()
        {
            if (_selected)
            {
                _rotation -= 90; //this is in degrees
                if (_rotation == 360 || _rotation == -360)
                {
                    _rotation = 0;
                }
                rotation = new RotateTransform(_rotation);
                Img.RenderTransform = rotation;
            }
        }

        public void RotateN(int degree) //needs renaming
        {
            if(degree == 360)
            {
                degree = 0;
            }
            _rotation = degree;
            rotation = new RotateTransform(_rotation);
            //MoveNotifier.RobotHasMoved();//Call the move notifier to tell the UI it needs to update its positions and transforms.
            //Img.RenderTransform = rotation;
        }

        public void SetRotation()
        {
            rotation = new RotateTransform(_rotation);
            Img.RenderTransform = rotation;
        }

        public void SetGrid(Grid grid)
        {
            _grid = grid;
        }

        public Grid GetGrid()
        {
            return _grid;
        }
       

        /// <summary>
        /// initiates the next move.
        /// </summary>
        public void Move(int secs)
        {
            Vacuum.Battery.Percent -= 0.0025f;
            while (GetNextAction())
            {
                Thread.Yield();
            }
           
        }

        /// <summary>
        /// Gets the next move based of the algorithm the vacuum is using.
        /// </summary>
        public bool GetNextAction()
        {
            Vacuum.Algorithm.NextMove(this);
            
            return false;
         
        }

        internal void SetRobotTimer()
        {
            Vacuum.Battery.Percent = 100f;
            timer = new Timer(Observer, 50);
            Vacuum.thread = new Thread(new ThreadStart(timer.Tick));
            Vacuum.thread.Start();
        }

        public void AbortThread()
        {
            if (Vacuum.thread != null)
            {
                Vacuum.thread.Abort();
                Vacuum.thread = null;
            }
        }

        public int GetRotation()
        {
            return _rotation;
        }
        #endregion 


    }
}
