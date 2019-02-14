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
using System.Reflection;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using io = System.IO;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// Interaction logic for Creator.xaml
    /// </summary>
    public partial class Creator : Window
    {
        IRoom room;
        List<IFurniture> objects;
        public Creator(bool loading)
        {
            InitializeComponent();
            if (!loading)
            {
                CreateRoom();
                objects = new List<IFurniture>();
            }
            else
            {
                LoadRoom();
            }
           
        }


        #region Methods
        public void CreateRoom()
        {
           
            room = new Room("Room1", (int)this.Width, (int)this.Height); //Will add name setter in now.
        }

        public void UpdateUI(IFurniture furniture, FurnitureTypes furnitureType)
        {
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
            this.Grid.Children.Add(furniture.Img);

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

        /// <summary>
        /// Loads a room into the editor.
        /// </summary>
        private void LoadRoom()
        {
            OpenFileDialog opener = new OpenFileDialog();
            opener.DefaultExt = ".rvs";
            opener.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            bool? result = opener.ShowDialog();
            string fileName = opener.FileName;
            room = DeserializeRoom(fileName);
        

            foreach(IFurniture furn in room.GetFurniture())
            {
             
                LoadUI(furn, furn.Type);
                
            }
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

        /// <summary>
        /// handles a click on the menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MenuClick(object sender, RoutedEventArgs args)
        {
            MenuItem menu = (MenuItem)sender;
            FurnitureFactory factory = new FurnitureFactory();
            IFurniture furnToInsert;

           if((string)menu.Tag == "Recliner")
            {
                furnToInsert=factory.InsertFurniture("recliner",this.Grid);
                room.Insert(furnToInsert,0,0,UpdateUI);
            }

            else if ((string)menu.Tag == "CoffeeTable")
            {
                furnToInsert = factory.InsertFurniture("coffeetable", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }
            else if ((string)menu.Tag == "Couch")
            {
                furnToInsert = factory.InsertFurniture("couch", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }
            else if ((string)menu.Tag == "Chair")
            {
                furnToInsert = factory.InsertFurniture("chair", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Counter")
            {
                furnToInsert = factory.InsertFurniture("counter", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Bed")
            {
                furnToInsert = factory.InsertFurniture("bed", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Dresser")
            {
                furnToInsert = factory.InsertFurniture("dresser", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Controls")
            {
                MessageBox.Show("How to use the editor\n1) Use the menu to add items.\n2)Click an item to select it.\n3)Use the arrow keys to reposition.\n4)Use a and d keys to rotate.");
            }


            else if ((string)menu.Tag == "Save")
            {
                SaveDialog dialog = new SaveDialog();
                dialog.ShowDialog(room.SaveDialogReturnedHandler);
            
            }

            else if ((string)menu.Tag == "Load")
            {
                Creator creator = new Creator(true);
                creator.Show();

            }
        }


        #endregion

   
        /// <summary>
        /// Handles the key presses and executes the appropriate action on the selected objects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Right)
            {
                foreach (IFurniture furniture in objects)
                {
                    if (furniture.Selected)
                    {
                        furniture.MoveRight();
                    }
                }
            }

            else if(e.Key ==  Key.Left)
            {
                foreach (IFurniture furniture in objects)
                {
                    if (furniture.Selected)
                    {
                        furniture.MoveLeft();
                    }
                }
            }

            else if(e.Key == Key.Up)
            {
                foreach(IFurniture furniture in objects)
                {
                    furniture.MoveUp();
                }
            }

            else if (e.Key == Key.Down)
            {
                foreach (IFurniture furniture in objects)
                {
                    furniture.MoveDown();
                }
            }

            else if (e.Key == Key.A)
            {
                foreach (IFurniture furniture in objects)
                {
                    furniture.RotateRight();
                }
            }
            else if (e.Key == Key.D)
            {
                foreach (IFurniture furniture in objects)
                {
                    furniture.RotateLeft();
                }
            }




        }
    }
}
