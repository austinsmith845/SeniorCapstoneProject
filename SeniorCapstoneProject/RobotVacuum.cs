using System;
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

        private RobotMovedObserver _observer;
        public RobotMovedObserver MoveNotifier
        {
            get { return _observer; }
            set { _observer = value; }
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
            get { return _x; }
            set { _x = value; MoveNotifier.RobotHasMoved(); }
            
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; MoveNotifier.RobotHasMoved(); }
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
            get { return battery; }
        }

        

        [NonSerialized]
        private Image _img;
        public Image Img
        {
            get { return _img; }
            set { _img = value; Img.MouseDown += Select; Img.Width = this.Width; Img.Height = this.Width; Img.Margin = new System.Windows.Thickness(X, Y, 0, 0); }
        }

        private int _rotation = 0;
        [NonSerialized]
        private Grid _grid;

        [NonSerialized]
        RotateTransform rotation;

        private ITimeTickObserver observer;
        public ITimeTickObserver Observer
        {
            get { return observer; }
            set { observer = value; }
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

        public void SetRotation()
        {
            rotation = new RotateTransform(_rotation);
            Img.RenderTransform = rotation;
        }

        public void SetGrid(Grid grid)
        {
            _grid = grid;
        }

        /// <summary>
        /// initiates the next move.
        /// </summary>
        public void Move(int secs)
        {
            GetNextAction();
        }

        /// <summary>
        /// Gets the next move based of the algorithm the vacuum is using.
        /// </summary>
        public void GetNextAction()
        {
            Vacuum.Algorithm.NextMove(this);
         
        }

        internal void SetRobotTimer()
        {
            timer = new Timer(Observer, 50);
            Thread thread = new Thread(new ThreadStart(timer.Tick));
            thread.Start();
        }

        public int GetRotation()
        {
            return _rotation;
        }
        #endregion 


    }
}
