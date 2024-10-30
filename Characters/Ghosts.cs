using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_Roguelike___Mini_Project.Characters
{
    internal class Ghosts : Enemy
    {
        private bool Evade;
        public Ghosts(string name, int health, string characterArt, ConsoleColor color) 
            : base(name, health, "Ghosts", color)
        {
            
        }
        //public bool evadeChance(Random x)
        //{
        //    if (x.Next(1,100) > 75) //25% chance
        //    {
        //        return true;
        //    }
        //    else { return false; }
        //}

        public void GhostPunch()
        {
            Random damage = new Random();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{name} threw 'Ghost Punch' and did {damage.Next(1, 10)} damage!");
            Console.ResetColor();
        }

        public void GhastlySuperPunch()
        {
            Random damage = new Random();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{name} threw 'Ghastly Super Punch!' and did {damage.Next(7, 18)} damage!");
            Console.ResetColor();
        }
    }
}
