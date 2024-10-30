using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Characters
{
    abstract class Enemy //base class
    {
        protected string name;
        protected int health;
        protected string worldArtName;
        protected ConsoleColor Color;

        Artwork art = new Artwork();

        public Enemy(string name, int health, string characterArt, ConsoleColor color)
        {
            this.name = name;
            this.worldArtName = characterArt;
            this.health = health;
            this.Color = color;
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
            WriteLine($"Health: {health}".PadLeft(healthPadding));
        }
    }
}
