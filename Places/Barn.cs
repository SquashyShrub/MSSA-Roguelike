﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSA_Roguelike___Mini_Project.Characters;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Places
{
    internal class Barn
    {
        World GameHandler_Barn;
        Player Player_Barn;
        Artwork Artwork_Barn = new Artwork();
        Battlegrounds battle = new Battlegrounds();
        IntroOutro outro = new IntroOutro();

        public void Start()
        {
            Clear();

            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string barn = Path.Combine(currentDir, "TextFiles/Maps", "BarnInterior.txt");
            string[,] barnGrid = TextParser.ParseFileToArray(barn);

            GameHandler_Barn = new World(barnGrid);
            Player_Barn = new Player(12, 1, "Jimmy", 200, ConsoleColor.Cyan, 6);

            #region Display Barn Entrance

            Artwork_Barn.DrawArt(Artwork_Barn.worldArt["barnEntrance"]);
            ReadKey();
            Artwork_Barn.Erase(Artwork_Barn.worldArt["barnEntrance"], 20);

            #endregion Display Barn Entrance

            GameHandler_Barn.DrawGrid();
            Player_Barn.DrawPlayer();

            RunBarnLoop();
        }

        private void DrawFrame()
        {
            Clear();
            GameHandler_Barn.DrawGrid();
            Player_Barn.DrawPlayer();
        }
        private void PlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey();
                key = keyInfo.Key;

            } while (KeyAvailable);

            switch(key)
            {
                case ConsoleKey.UpArrow:
                    if (!GameHandler_Barn.Colliding(Player_Barn.X, Player_Barn.Y - 1))
                        Player_Barn.Y -= 1;
                    break;

                case ConsoleKey.DownArrow:
                    if (!GameHandler_Barn.Colliding(Player_Barn.X, Player_Barn.Y + 1))
                        Player_Barn.Y += 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (!GameHandler_Barn.Colliding(Player_Barn.X - 1, Player_Barn.Y))
                        Player_Barn.X -= 1;
                    break;

                case ConsoleKey.RightArrow:
                    if (!GameHandler_Barn.Colliding(Player_Barn.X + 1, Player_Barn.Y))
                        Player_Barn.X += 1;
                    break;
            }
        }
        private void RunBarnLoop()
        {
            bool exit = false;
            
            while (exit == false)
            {
                //Draw Frame
                DrawFrame();

                //Player Input
                PlayerInput();

                //Event
                string currentLocation = GameHandler_Barn.GetElementAt(Player_Barn.X, Player_Barn.Y);

                switch (currentLocation)
                {
                    case "X":
                        switch(battle.barnBattle())
                        {
                            case 1:
                                outro.DisplayOutroLived();
                                SetCursorPosition(70, 25);
                                Thread.Sleep(2000);
                                WriteLine("To be Continued...");
                                ReadKey();
                                Environment.Exit(0);
                                break;

                            case 2:
                                exit = true;
                                break;
                        }
                        break;
                }

                //Render console
                Thread.Sleep(10);
            }
        }


    }
}
