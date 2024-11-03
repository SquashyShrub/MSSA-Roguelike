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
        public override void Battle(Character opponent, int x = 0, int y = 0)
        {
            int chance = RandGenerator.Next(1, 101);

            ForegroundColor = Color;
            WriteLine($"{name} attacks {opponent.name}!");
            ResetColor();
            //60% chance Slash (6 - 17 Dmg) / 40% chance combo (20 - 50 dmg acc)
            //70% hit rate                        / 50% hit rate
            if (chance <= 60)
            {
                WriteLine($"{name} attempts 'High Slash'! ");
                int hit = RandGenerator.Next(1, 101);
                Thread.Sleep(1000);
                if (hit <= 70)
                {
                    opponent.TakeDamage(HighSlash());
                }
                else
                    WriteLine($"{name} slashes too high!");
            }
            else
            {
                WriteLine($"{name} attempts a 'Lightning Combo'! ");
                int hit = RandGenerator.Next(1, 101);
                Thread.Sleep(1000);
                if (hit <= 90)
                {
                    opponent.TakeDamage(QuickCombo());
                }
                else
                    WriteLine($"{name} stumbles and loses his balance! {name} uses their turn to get back up!");
            }
        }
        public int HighSlash()
        {
            int damage = RandGenerator.Next(6, 18);
            BackgroundColor = ConsoleColor.DarkGray;
            WriteLine($"{name} attacks! He does 'High Slash' and did {damage} damage!");
            ResetColor();
            return damage;
        }

        public int QuickCombo()
        {
            int damageSlash = RandGenerator.Next(6, 19);
            int damageJab = RandGenerator.Next(4, 15);
            int damageChop = RandGenerator.Next(10, 19);

            BackgroundColor = ConsoleColor.Red;
            WriteLine($"{name} does a 'Quick Combo'! ");
            WriteLine($"Side slash does {damageSlash} damage!");
            Thread.Sleep(1000);
            WriteLine($"Jab does {damageJab} damage!");
            Thread.Sleep(1000);
            WriteLine($"Power chop does {damageChop} damage!");
            int damage = damageChop + damageJab + damageSlash;
            WriteLine($"Total damage: {damage} ");
            ResetColor();
            
            return damage;
        }
    }
}
