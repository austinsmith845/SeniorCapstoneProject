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

        #endregion

        #region Constructors

        public Room(string name, int width, int length)
        {
            this.Name = name;
            this.Width = width;
            this.Length = length;
           
        }

        public void Insert(IFurniture furniture, int x, int y)
        {
            throw new NotImplementedException();
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
