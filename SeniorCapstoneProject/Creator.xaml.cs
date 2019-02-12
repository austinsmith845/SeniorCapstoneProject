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

namespace SeniorCapstoneProject
{
    /// <summary>
    /// Interaction logic for Creator.xaml
    /// </summary>
    public partial class Creator : Window
    {
        IRoom room;
        List<IFurniture> objects;
        public Creator()
        {
            InitializeComponent();
            CreateRoom();
            objects = new List<IFurniture>();
           
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


            objects.Add(furniture);

            switch (furnitureType)
            {
                case FurnitureTypes.recliner:
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\Recliner.jpg"));
                    break;
            }
            this.Grid.Children.Add(furniture.Img);

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

            else if ((string)menu.Tag == "Controls")
            {
                MessageBox.Show("How to use the editor\n1) Use the menu to add items.\n2)Click an item to select it.\n3)Use the arrow keys to reposition.\n4)Use a and d keys to rotate.");
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
