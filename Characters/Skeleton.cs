using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Characters
{
    internal class Skeleton : Character
    {
        public Skeleton(string name, int health, string characterArt, ConsoleColor color) 
            : base(name, health, characterArt, color)
        {

        }
        public override void Battle(Character opponent)
        {
            ForegroundColor = Color;
            WriteLine($"{name} attacks {opponent.name}");
            ResetColor();
        }
        public void HighSlash()
        {
            int damage = RandGenerator.Next(1, 101);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{name} attacks! He does 'High Slash' and did {damage} damage!");
            Console.ResetColor();
        }

        public void QuickCombo()
        {
            int damage = RandGenerator.Next(1, 101);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{name} does a 'Quick Combo'! ");
            Console.WriteLine($"Side slash does {damage} damage!");
            Thread.Sleep(1000);
            Console.WriteLine($"Jab does {damage} damage!");
            Thread.Sleep(1000);
            Console.WriteLine($"Power chop does {damage}");
            Console.ResetColor();
        }
    }
}
