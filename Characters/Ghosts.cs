using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Characters
{
    internal class Ghosts : Character
    {
        private bool Evade;
        public Ghosts(string name, int health, string characterArt, ConsoleColor color) 
            : base(name, health, "Ghosts", color)
        {
            
        }
        

        public override void Battle(Character opponent, int x = 0, int y = 0)
        {
            int chance = RandGenerator.Next(1, 101);

            ForegroundColor = Color;
            WriteLine($"{name} attacks {opponent.name}!");
            ResetColor();
            //80% chance ghost punch (1 - 10 Dmg) / 20% chance Super (5 - 18 dmg)
            //75% hit rate                        / 90% hit rate
            if (chance <= 80)
            {
                Write($"{name} attempts 'Ghost Punch'! ");
                int hit = RandGenerator.Next(1, 101);
                Thread.Sleep(1000);
                if (hit <= 75)
                {
                    opponent.TakeDamage(GhostPunch());
                }
                else
                    WriteLine($"{name} misses with incredible inaccuracy!");
            }
            else
            {
                Write($"{name} attempts a 'Ghastly Super Punch'! ");
                int hit = RandGenerator.Next(1, 101);
                Thread.Sleep(1000);
                if (hit <= 90)
                {
                    opponent.TakeDamage(GhastlySuperPunch());
                }
                else
                    WriteLine($"{name} misses an attack with 90% accuracy. It explains the ghost situation.");
            }
        }
        public int GhostPunch()
        {
            int damage = RandGenerator.Next(1, 11);
            BackgroundColor = ConsoleColor.DarkGray;
            WriteLine($" {name} does {damage} damage!");
            ResetColor();
            return damage;
        }

        public int GhastlySuperPunch()
        {
            int damage = RandGenerator.Next(5, 19);
            BackgroundColor = ConsoleColor.DarkRed;
            WriteLine($"{name} does {damage} damage!");
            ResetColor();
            return damage;
        }
    }
}
