using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_Roguelike___Mini_Project.Characters
{
    internal class Skeleton : Enemy
    {
        public Skeleton(string name, int health, string characterArt, ConsoleColor color) 
            : base(name, health, characterArt, color)
        {

        }

        public void HighSlash()
        {
            Random damage = new Random();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{name} attacks! He does 'High Slash' and did {damage.Next(5, 13)} damage!");
            Console.ResetColor();
        }

        public void QuickCombo()
        {
            Random damage = new Random();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{name} does a 'Quick Combo'! ");
            Console.WriteLine($"Side slash does {damage.Next(1, 4)} damage!");
            Thread.Sleep(1000);
            Console.WriteLine($"Jab does {damage.Next(1, 7)} damage!");
            Thread.Sleep(1000);
            Console.WriteLine($"Power chop does {damage.Next(4, 12)}");
            Console.ResetColor();
        }
    }
}
