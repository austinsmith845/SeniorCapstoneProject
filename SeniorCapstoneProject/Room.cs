using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeniorCapstoneProject
{
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
            get{ return _width;}
            set { _width = value ;}
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        List<IFurniture> _furniture;

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
            callBack(); //This will call back to the UI that it needs to update the view
        }

        public void Remove(IFurniture selected)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Support Methods

        #endregion
    }
}
