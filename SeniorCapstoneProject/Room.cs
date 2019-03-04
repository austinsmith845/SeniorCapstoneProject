using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SeniorCapstoneProject
{
    [Serializable]
    internal class Room : IRoom
    {
        #region Properties


        private float _length;
        public float Length
        {
            get { return _length; }
            set { _length = value; ; }
        }

        private float _width;
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private RobotVacuum _vacuum;
        public RobotVacuum Vacuum
        {
            get { return _vacuum; }
            set { _vacuum = value; }
        }


        List<IFurniture> _furniture;

        private bool _hasVacuum;
        public bool HasVacuum
        {
            get { return _hasVacuum; }
            set { _hasVacuum = value; }
        }
        

   

        int[,] roomMatrix;


        #endregion

        #region Constructors

        public Room(string name, int width, int length)
        {
            this.Name = name;
            this.Width = width;
            this.Length = length;
            _furniture = new List<IFurniture>();

        }

        /// <summary>
        /// This function handles inserting furniture into the room
        /// </summary>
        /// <param name="furniture">The piece of furniture to insert</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="callBack">The function to call once the insert is complete.</param>
        public void Insert(IFurniture furniture, int x, int y, AddItemToUI callBack)
        {
            furniture.X = x;
            furniture.Y = y;
            this._furniture.Add(furniture);
            callBack(furniture, furniture.Type); //This will call back to the UI that it needs to update the view
        }

        public void Remove(IFurniture selected)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method will save the room out so that it can be loaded by the simulator or editor later.
        /// </summary>
        public void Save()
        {
            string fileName = Name + ".rvs";// System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + "\\"+ Name+".rvs";

            Stream room = File.Create(fileName);
            try
            {

                BinaryFormatter writer = new BinaryFormatter();
                writer.Serialize(room, this);
            }
            catch (ArgumentNullException i)
            {
                System.Windows.MessageBox.Show("An output error occuerd when saving the room.");
            }
            catch (SerializationException e)
            {
                System.Windows.MessageBox.Show("An error occuerd when saving the room.");
            }

            catch (System.Security.SecurityException s)
            {
                System.Windows.MessageBox.Show("Error\nYou do not have the appropriate permission to access the save directory.");
            }
            finally
            {
                room.Close();
            }


        }


        private void DeleteImagesForSave()
        {
            foreach (IFurniture furn in _furniture)
            {
                furn.Img = null;
            }
            Vacuum.Img = null;
        }
        public List<IFurniture> GetFurniture()
        {
            return _furniture;
        }

        public void SaveDialogReturnedHandler(string name)
        {
            this.Name = name;
            Save();
        }

        public int PointsInRoom()
        {
            return (int)(this.Width * this.Length);
        }
    

    }
}
           

            #endregion

            #region Support Methods

            #endregion
        
