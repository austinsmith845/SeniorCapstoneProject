using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Reflection;
using io = System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


namespace SeniorCapstoneProject
{
    /// <summary>
    /// Interaction logic for Simulator.xaml
    /// </summary>
    public partial class Simulator : Window
    {
        private IRoom room;
        private List<IFurniture> objects;
        private ITimeTickObserver observer;
        Timer time;
        Thread timer;
        RobotMovedObserver movedObserver;
        

        public Simulator()
        {
            observer = new TimeTickObserver(UpdateTimerLabel);
            objects = new List<IFurniture>();
            InitializeComponent();
            LoadRoom();
            this.lblRoomName.Content = room.Name;
            SimulationSetupScreen setup = new SimulationSetupScreen(StartSimulation);
            this.Width = room.Width;
            this.Height = room.Length;
            setup.ShowDialog();
            this.lblAlgorithm.Content = RobotVacuum.Vacuum.Algorithm.Algorithm;
       

        }

        private void LoadRoom()
        {
            OpenFileDialog opener = new OpenFileDialog();
            opener.DefaultExt = ".rvs";
            opener.InitialDirectory = io.Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            bool? result = opener.ShowDialog();
            string fileName = opener.FileName;
            room = DeserializeRoom(fileName);

            foreach(IFurniture furn in room.GetFurniture())
            {
                LoadUI(furn, furn.Type);
            }
            
            InsertVacuumUi();
        }

        public void LoadUI(IFurniture furniture, FurnitureTypes furnitureType)
        {
            furniture.SetGrid(this.Grid);
            Image img = new Image();
            img.Width = furniture.Width;
            img.Height = furniture.Height;
            img.Visibility = Visibility.Visible;
            img.Margin = new Thickness(furniture.X, furniture.Y, 0, 0);

            furniture.Img = img;


            objects = room.GetFurniture();


            switch (furnitureType)
            {

                case FurnitureTypes.Bed:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Bed.png"));
                    break;
                case FurnitureTypes.Bed2:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Bed2.png"));
                    break;
                case FurnitureTypes.BookShelf:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\BookShelf.png"));
                    break;
                case FurnitureTypes.Couch:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Couch.png"));
                    break;
                case FurnitureTypes.DeskChair:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\DeskChair.png"));
                    break;
                case FurnitureTypes.Dresser:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Dresser.png"));
                    break;
                case FurnitureTypes.Recliner:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Recliner.png"));
                    break;
                case FurnitureTypes.Rug:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Rug.png"));
                    break;
                case FurnitureTypes.Sofa:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Sofa.png"));
                    break;
                case FurnitureTypes.Stove:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Stove.png"));
                    break;
                case FurnitureTypes.Table:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Table.png"));
                    break;
                case FurnitureTypes.TVStand:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\TVStand.png"));
                    break;
            }


            furniture.SetRotation();
            this.Grid.Children.Add(furniture.Img);

        }

        private IRoom DeserializeRoom(string path)
        {

            io.Stream inputStream = io.File.OpenRead(path);
            IRoom r = null;
            try
            {
                BinaryFormatter reader = new BinaryFormatter();
                r = (IRoom)reader.Deserialize(inputStream);
            }

            catch (ArgumentNullException n)
            {
                MessageBox.Show("The file passed is either empty, corrupted, or doesn't exist");


            }

            catch (System.Runtime.Serialization.SerializationException s)
            {
                MessageBox.Show("An error occurred while reading the file");


            }

            catch (System.Security.SecurityException s)
            {
                MessageBox.Show("You do not have the appropriate permission to access this file.");


            }
            finally
            {
                inputStream.Close();
            }
            return r;
        }

        private void InsertVacuumUi()
        {
            
            room.Vacuum.SetGrid(this.Grid);
            Image Img = new Image();
            Img.Source = Img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\RobotVacuum.png"));
            room.Vacuum.Img = Img;
            room.Vacuum.SetRotation();

            this.Grid.Children.Add(room.Vacuum.Img);
        }

        /// <summary>
        /// This method starts the simulation
        /// </summary>
        /// <param name="view"></param>
        public void StartSimulation(bool view)
        {
 
            movedObserver = new RobotMovedObserver();
            time = new Timer(observer, 1000);
            timer = new Thread(new ThreadStart(time.Tick));
            timer.Start();
            RobotVacuum.Vacuum.Checker = new CollisionChecker(room.GetFurniture(), room);
            room.Vacuum.MoveNotifier = movedObserver;
            room.Vacuum.MoveNotifier.RegisterCallBack(() => { this.Dispatcher.Invoke(() => { /*room.Vacuum.SetRotation();*/ room.Vacuum.Img.Margin = new Thickness(room.Vacuum.X, room.Vacuum.Y, 0, 0); }); }); //This forces the movement statement to execute on the UI thread to avoid a cross thread exception.
            room.Vacuum.Observer = new TimeTickObserver(room.Vacuum.Move);
            room.Vacuum.SetRobotTimer();
        }

        private void UpdateTimerLabel(int secs)
        {
            int mins = secs / 60;
            this.Dispatcher.Invoke(() => { this.lblTime.Content = String.Format("Elapsed time: {0}:{1:00}", mins, secs % 60); this.lblBattery.Content = String.Format("Battery: {0}%",(int)RobotVacuum.Vacuum.Battery.Percent); });
            
                
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            time.Enabled = false; //disables the timer.
            timer.Abort(); //Stops the timer thread.
        }
    }
}
