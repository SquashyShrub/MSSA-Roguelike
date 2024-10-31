using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_Roguelike___Mini_Project.Characters
{
    class Reaper : Enemy
    {
        public Reaper(string name, int health, string characterArt, ConsoleColor color) 
            : base(name, health, characterArt, color)
        {

        }

        public void SytheSlash()
        {
            Random damage = new Random();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{name} attacks! He does 'High Slash' and did {damage.Next(5, 13)} damage!");
            Console.ResetColor();
        }

        public void SuperSlash()
        {
            Random damage = new Random();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{name} attacks! He does 'High Slash' and did {damage.Next(5, 13)} damage!");
            Console.ResetColor();
        }

        public void Heal()
        {
            Random Heal = new Random();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{name} attacks! He does 'High Slash' and did {damage.Next(5, 13)} damage!");
            Console.ResetColor();
        }
    }
}
