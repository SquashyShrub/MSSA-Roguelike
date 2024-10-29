using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project
{
    internal class Player
    {
        private ConsoleColor PlayerColor;
        private string PlayerMarker;
        private string PlayerReset;

        //Get player's X and Y position to draw
        public int X {  get; set; }
        public int Y { get; set; }

        public Player(int startingX, int startingY)
        {
            X = startingX;
            Y = startingY;

            PlayerColor = ConsoleColor.DarkCyan;
            PlayerMarker = "@";
        }

        public void DrawPlayer()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
            ResetColor();
        }

    }
}
