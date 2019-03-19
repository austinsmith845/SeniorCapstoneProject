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
        RobotVacuum vacuum;

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
            //img.Stretch = Stretch.Fill;
            furniture.Img = img;


            objects = room.GetFurniture();

            switch (furnitureType)
            {
                case FurnitureTypes.Bed:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Bed2.png"));
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
            this.Grid.Children.Add(furniture.Img);

        }

        public void LoadUI(IFurniture furniture, FurnitureTypes furnitureType)
        {
            furniture.SetGrid(this.Grid);
            Image img = new Image();
            img.Width = furniture.Width;
            img.Height = furniture.Height;
            img.Visibility = Visibility.Visible;
            //img.Stretch = Stretch.Fill;

            img.Margin = new Thickness(furniture.X, furniture.Y, 0, 0);

            furniture.Img = img;
           

            objects = room.GetFurniture();
            

            switch (furnitureType)
            {
                case FurnitureTypes.Bed:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Bed2.png"));
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
        
            if(room.GetFurniture() != null)
            {
                foreach (IFurniture furn in room.GetFurniture())
                {

                    LoadUI(furn, furn.Type);

                }
            }
           
            InsertVacuumUi();
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

            if((string)menu.Tag == "Bed")
            {
                furnToInsert=factory.InsertFurniture("Bed",this.Grid);
                room.Insert(furnToInsert,0,0,UpdateUI);
            }

            else if ((string)menu.Tag == "Bed2")
            {
                furnToInsert = factory.InsertFurniture("Bed2", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "BookShelf")
            {
                furnToInsert = factory.InsertFurniture("BookShelf", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Couch")
            {
                furnToInsert = factory.InsertFurniture("Couch", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "DeskChair")
            {
                furnToInsert = factory.InsertFurniture("DeskChair", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Dresser")
            {
                furnToInsert = factory.InsertFurniture("Dresser", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Recliner")
            {
                furnToInsert = factory.InsertFurniture("Recliner", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Rug")
            {
                furnToInsert = factory.InsertFurniture("Rug", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Sofa")
            {
                furnToInsert = factory.InsertFurniture("Sofa", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Stove")
            {
                furnToInsert = factory.InsertFurniture("Stove", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Table")
            {
                furnToInsert = factory.InsertFurniture("Table", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "TVStand")
            {
                furnToInsert = factory.InsertFurniture("TVStand", this.Grid);
                room.Insert(furnToInsert, 0, 0, UpdateUI);
            }

            else if ((string)menu.Tag == "Vacuum")
            {
                if(room.Vacuum == null)
                {
                    room.Vacuum = RobotVacuum.Vacuum;
                    room.Vacuum.X = 0;
                    room.Vacuum.Y = 0;
                    InsertVacuumUi();
                }
                else
                {
                    MessageBox.Show("You can only have one vacuum per room.");
                }
                
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
                if (objects != null)
                {
                    foreach (IFurniture furniture in objects)
                    {
                        if (furniture.Selected)
                        {
                            furniture.MoveRight();
                        }
                    }
                }
                if (room.Vacuum != null)
                {
                    room.Vacuum.MoveRight();
                }
            }

            else if(e.Key ==  Key.Left)
            {
                if (objects != null)
                {
                    foreach (IFurniture furniture in objects)
                    {
                        if (furniture.Selected)
                        {
                            furniture.MoveLeft();
                        }
                    }
                }
                if (room.Vacuum != null)
                {
                    room.Vacuum.MoveLeft();
                }
            }

            else if(e.Key == Key.Up)
            {
                if (objects != null)
                {
                    foreach (IFurniture furniture in objects)
                    {
                        furniture.MoveUp();
                    }
                }
                if (room.Vacuum != null)
                {
                    room.Vacuum.MoveUp();
                }
            }

            else if (e.Key == Key.Down)
            {
                if (objects != null)
                {
                    foreach (IFurniture furniture in objects)
                    {
                        furniture.MoveDown();
                    }
                }
                if (room.Vacuum != null)
                {
                    room.Vacuum.MoveDown();
                }
            }

          




        }
    }
}
