using MSSA_Roguelike___Mini_Project.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project
{
    internal class Battlegrounds
    {
        Ghosts ghost = new Ghosts("Spooky Ghost", 50, "Ghosts", ConsoleColor.DarkGray);
        Skeleton skeleton = new Skeleton("Chill Skeleton", 100, "Skeleton", ConsoleColor.Red);
        
        public void barnBattle()
        {
            while (true)
            {
                skeleton.DisplayInfo(125, 97, 2, 90);
                ReadKey();

                skeleton.HighSlash();
                ReadKey();

                skeleton.QuickCombo();
                ReadKey();

                Clear();
            }
            ghost.DisplayInfo(125, 100, 2, 102);
            ReadKey();

            ghost.GhostPunch();
            ReadKey();

            ghost.GhastlySuperPunch();
            ReadKey();

            Clear();



        } 
    }
}
