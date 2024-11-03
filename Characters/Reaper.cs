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
        public override void Battle(Character opponent, int x = 0, int y = 0)
        {
            int chance = RandGenerator.Next(1, 101);

            ForegroundColor = Color;
            WriteLine($"{name} attacks {opponent.name}!");
            ResetColor();
            //40% chance scythe chance (10 - 50 Dmg) / 40% chance spin move (15 - 60 dmg acc) / 20% Heal chance (30 HP)
            //80% hit rate                        / 80% hit rate
            if (chance <= 40)
            {
                WriteLine($"{name} attempts 'Scythe Slash'! ");
                int hit = RandGenerator.Next(1, 101);
                Thread.Sleep(1000);
                if (hit <= 80)
                {
                    opponent.TakeDamage(ScytheSlash());
                }
                else
                    WriteLine($"{name} is part time for a reason! {name} misses catastrophically!");
            }
            else if (chance <= 80 && chance > 40)
            {
                WriteLine($"{name} attempts a 'Super Spinny Move'! ");
                int hit = RandGenerator.Next(1, 101);
                Thread.Sleep(1000);
                if (hit <= 80)
                {
                    opponent.TakeDamage(SuperSpinMove());
                }
                else
                    WriteLine($"{name} did ballerina moves for no reason! {name} misses!");
            }
            else
            {
                Heal();
            }
        }

        public int ScytheSlash()
        {
            int damage = RandGenerator.Next(10, 51);
            BackgroundColor = ConsoleColor.DarkGray;
            WriteLine($"{name} attacks! He does 'Scythe Slash' and did {damage} damage!");
            ResetColor();
            return damage;
        }

        public int SuperSpinMove()
        {
            int damage = RandGenerator.Next(15, 61);
            BackgroundColor = ConsoleColor.Red;
            WriteLine($"{name} attacks! He does 'Super Spinny Move' and does {damage} damage!");
            ResetColor();
            return damage;
        }

        public void Heal()
        {
            int heal = 30;
            health += heal;
            BackgroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{name} heals {heal} HP!");
            ResetColor();
        }
    }
}
