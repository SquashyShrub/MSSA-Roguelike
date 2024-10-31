using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Characters
{
    class Reaper : Character
    {
        public Reaper(string name, int health, string characterArt, ConsoleColor color) 
            : base(name, health, characterArt, color)
        {

        }
        public override void Battle(Character opponent)
        {
            ForegroundColor = Color;
            WriteLine($"{name} attacks {opponent.name}");
            ResetColor();
        }

        public void ScytheSlash()
        {
            int damage = RandGenerator.Next(1, 101);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{name} attacks! He does 'Scythe Slash' and did {damage} damage!");
            Console.ResetColor();
        }

        public void SuperSlash()
        {
            int damage = RandGenerator.Next(1, 101);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{name} attacks! He does 'Super Slash' and did {damage} damage!");
            Console.ResetColor();
        }

        public void Heal()
        {
            int heal = RandGenerator.Next(1, 20);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{name} heals! He heals {heal} HP!");
            Console.ResetColor();
        }
    }
}
