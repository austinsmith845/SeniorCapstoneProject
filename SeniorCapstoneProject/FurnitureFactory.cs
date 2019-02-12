using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeniorCapstoneProject.Furniture;
using System.Windows.Controls;

namespace SeniorCapstoneProject
{
    public class FurnitureFactory
    {
        /// <summary>
        /// This method creates the furntiture objects and returns them.
        /// </summary>
        /// <param name="whatToInsert"></param>
        /// <param name="grid"></param>
        /// <returns></returns>
        public IFurniture InsertFurniture(string whatToInsert, Grid grid)
        {
            whatToInsert = whatToInsert.ToLower();
            if(whatToInsert == "recliner")
            {
                return new Recliner(FurnitureTypes.recliner,grid);
            }

            if (whatToInsert == "coffeetable")
            {
                return new CoffeeTable(FurnitureTypes.CoffeeTable, grid);
            }
            return null;
        }


    }
}
