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

namespace SeniorCapstoneProject
{
    /// <summary>
    /// Interaction logic for Simulator.xaml
    /// </summary>
    public partial class Simulator : Window
    {
        private IRoom room;
        private List<IFurniture> objects;
       
        public Simulator()
        {
            objects = new List<IFurniture>();
            InitializeComponent();
            LoadRoom();
            SimulationSetupScreen setup = new SimulationSetupScreen(StartSimulation);
            this.Width = room.Width;
            this.Height = room.Length;
            setup.ShowDialog();
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
                case FurnitureTypes.recliner:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Recliner.jpg"));
                    break;
                case FurnitureTypes.CoffeeTable:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\CoffeeTable.jpg"));
                    break;
                case FurnitureTypes.Couch:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Couch.jpg"));
                    break;
                case FurnitureTypes.chair:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Chair.png"));
                    break;

                case FurnitureTypes.Counter:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Counter.jpg"));
                    break;

                case FurnitureTypes.Bed:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Bed.jpg"));
                    break;

                case FurnitureTypes.Dresser:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Dresser.png"));
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

        public void StartSimulation(bool view)
        {
            ///throw new NotImplementedException();
        }
    }
}
