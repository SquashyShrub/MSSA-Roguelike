using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_Roguelike___Mini_Project.Places
{


    internal class TownSquare
    {
        public int DisplayTownSquare()
        {
            Menu menus = new Menu();
            Artwork art = new Artwork();
            

            art.DrawArt(art.worldArt["TownSquare"], 10, 65);


            Console.SetCursorPosition(50, 37);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Where should I go?");
            Console.ResetColor();

            return menus.TownSquareMenu(50, 40);
        }

    }


}
