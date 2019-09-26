using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SeniorCapstoneProject
{
    public interface IFurniture
    {
        float Height { get;  }
        float Width { get;  }
        float Length { get; }
        FurnitureTypes Type { get; set; }
        Image Img { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int DegreeRotation { get; }
        bool Selected { get; set; }
        bool CanPassUnder();
        void Select(Object sender, MouseButtonEventArgs args);
        void MoveUp();
        void MoveDown();
        void MoveRight();
        void MoveLeft();
        void RotateRight();
        void RotateLeft();
        void SetGrid(Grid grid);
        void SetRotation();

    }
}
