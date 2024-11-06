using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Characters
{
    abstract class Character //base class
    {
        public string name { get; protected set; }
        public int health { get; set; }
        public int maxHealth { get; protected set; }
        public int stamina { get; protected set; }
        public int maxStamina { get; protected set; }
        public string worldArtName { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public Random RandGenerator { get; protected set; }

        Artwork art = new Artwork();

        public Character(string name, int health, string characterArt, ConsoleColor color, int stamina = 0)
        {
            this.name = name;
            this.worldArtName = characterArt;
            this.health = health;
            this.maxHealth = health;
            this.stamina = stamina;
            this.maxStamina = stamina;
            this.Color = color;
            this.RandGenerator = new Random();
        }
        public void DisplayInfo(int namePadding = 0, int healthPadding = 0, int cursorPositionX = 0, int cursorPositionY = 0)
        {
            //Name
            WriteLine($">>>>>>>>>>  {name.ToUpper()} <<<<<<<<<<".PadLeft(namePadding));

            //Art
            ForegroundColor = Color;
            art.DrawArt(art.worldArt[worldArtName], cursorPositionX, cursorPositionY);
            ResetColor();

            //Health - - at the bottom
            //WriteLine($"Health: {health}".PadLeft(healthPadding));
        }

        public virtual void Battle(Character opponent, int x = 0, int y = 0)
        {
            ForegroundColor = Color;
            WriteLine($"{name} is fighting!");
            ResetColor();
        }

        public void TakeDamage(int damageAmount)
        {
            health -= damageAmount;
            if (health < 0)
            {
                health = 0;
            }
        }

        public void DisplayHealthBar()
        {
            ForegroundColor = Color;
            WriteLine($"{name}'s Health: ");
            ResetColor();

            if (health >= maxHealth)
                health = maxHealth;

            Write("[");
            //Draw HP filled in
            BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < health/4; i++)
            {
                Write(" ");
            }
            //Draw HP not filled in
            BackgroundColor = ConsoleColor.White;
            for (int i = health/4; i < maxHealth/4; i++)
            {
                Write(" ");
            }
            ResetColor();

            WriteLine($"] {health}/{maxHealth}");
            
        }

        public void DisplayStaminaBar()
        {
            ForegroundColor = Color;
            WriteLine($"{name}'s Stamina: ");
            ResetColor();

            if (stamina >= maxStamina)
                stamina = maxStamina;

            Write("[");
            BackgroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < stamina; i++)
            {
                Write(" ");
            }
            BackgroundColor = ConsoleColor.Black;
            for (int i = stamina; i < maxStamina; i++)
            {
                Write(" ");
            }
            ResetColor();
            Write("]");
            WriteLine($" {stamina}/{maxStamina}");
        }
    }
}
