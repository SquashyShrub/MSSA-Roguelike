﻿using System;
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

        /* Handle player input for movement here? to avoid multiple times writing it like it is now - - > more readable aswell
        public void GetPlayerInput() 
        {
            //Gets the last input of the player to avoid trailing movement when no keys are being pressed
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;

            } while (KeyAvailable);

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (!GameHandler_Church.Colliding(Player_Church.X, Player_Church.Y - 1))
                    {
                        Player_Church.Y -= 1;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (!GameHandler_Church.Colliding(Player_Church.X, Player_Church.Y + 1))
                    {
                        Player_Church.Y += 1;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (!GameHandler_Church.Colliding(Player_Church.X - 1, Player_Church.Y))
                    {
                        Player_Church.X -= 1;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (!GameHandler_Church.Colliding(Player_Church.X + 1, Player_Church.Y))
                    {
                        Player_Church.X += 1;
                    }
                    break;
        } */
         
        

    }
}
