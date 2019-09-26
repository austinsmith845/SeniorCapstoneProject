using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    public delegate void AddItemToUI(IFurniture furniture,FurnitureTypes type);
    public interface IRoom
    {
       float Length { get; set; } 
       float Width { get; set; }
       string Name { get; set; }
        bool HasVacuum { get; }
       
        RobotVacuum Vacuum { get; set; }

        void Insert(IFurniture furniture, int x, int y,AddItemToUI callBack);
        void Remove(IFurniture selected);
        List<IFurniture> GetFurniture();
        void Save();
        void SaveDialogReturnedHandler(string name);
        int PointsInRoom();


    }
}
