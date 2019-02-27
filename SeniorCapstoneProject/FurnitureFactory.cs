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
            if(whatToInsert == "bed")
            {
                return new Bed(FurnitureTypes.Bed,grid);
            }

            else if (whatToInsert == "bed2")
            {
                return new Bed2(FurnitureTypes.Bed2, grid);
            }

            else if (whatToInsert == "bookshelf")
            {
                return new BookShelf(FurnitureTypes.BookShelf, grid);
            }

            else if (whatToInsert == "couch")
            {
                return new Couch(FurnitureTypes.Couch, grid);
            }

            else if (whatToInsert == "deskchair")
            {
                return new DeskChair(FurnitureTypes.DeskChair, grid);
            }

            else if (whatToInsert == "dresser")
            {
                return new Dresser(FurnitureTypes.Dresser, grid);
            }

            else if (whatToInsert == "recliner")
            {
                return new Recliner(FurnitureTypes.Recliner, grid);
            }

            else if (whatToInsert == "rug")
            {
                return new Rug(FurnitureTypes.Rug, grid);
            }

            else if (whatToInsert == "sofa")
            {
                return new Sofa(FurnitureTypes.Sofa, grid);
            }

            else if (whatToInsert == "stove")
            {
                return new Stove(FurnitureTypes.Stove, grid);
            }

            else if (whatToInsert == "table")
            {
                return new Table(FurnitureTypes.Table, grid);
            }

            else if (whatToInsert == "tvstand")
            {
                return new TVStand(FurnitureTypes.TVStand, grid);
            }

            return null;
        }


    }
}
