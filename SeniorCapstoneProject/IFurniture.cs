using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    public interface IFurniture
    {
        float Height { get;  }
        float Width { get;  }
        int X { get; set; }
        int Y { get; set; }
        bool Selected { get; set; }
        bool CanPassUnder();
        void Select();
    }
}
