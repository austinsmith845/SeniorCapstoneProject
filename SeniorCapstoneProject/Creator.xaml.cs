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

namespace SeniorCapstoneProject
{
    /// <summary>
    /// Interaction logic for Creator.xaml
    /// </summary>
    public partial class Creator : Window
    {
        IRoom room;
        public Creator()
        {
            InitializeComponent();
            
           
        }

        #region Methods
        public void CreateRoom()
        {
           
            room = new Room("Room1", (int)this.Width, (int)this.Height); //Will add name setter in now.
        }

        private void MenuClick(object sender, RoutedEventArgs args)
        {
            MenuItem menu = (MenuItem)sender;
           if((string)menu.Tag == "Recliner")
            {

            }
        }
        #endregion 
    }
}
