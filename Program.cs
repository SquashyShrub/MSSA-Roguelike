﻿using System.Security.Cryptography.X509Certificates;
using System.Text;
using MSSA_Roguelike___Mini_Project.Characters;
using MSSA_Roguelike___Mini_Project.Places;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Game Objects

            string[,] screenGrid = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\NormalScreen.txt");
            World world = new World(screenGrid);
            Player Jimmy = new Player(0, 0, null, 0, 0, 0);

            Artwork gameArt = new Artwork();
            Menu menus = new Menu();
            Items graveKey = new Items("Graveyard Key", 1);
            Items sword = new Items("Sword", 1);

            IntroOutro introOutro = new IntroOutro();
            TownSquare townSquare = new TownSquare();
            AbandonedChurch church = new AbandonedChurch();
            CornMaze maze = new CornMaze();
            Graveyard grave = new Graveyard();
            Barn barn = new Barn();

            #endregion Game Objects

            //Set Game Resolution
            DefaultResolution();
            

            //Game Intro
            WriteLine("Press any key to start...");
            ReadAndClear();

            introOutro.DisplayIntro();
            world.Loading(2);

            //Conditionals
            bool exit = false;
            bool barnUnlocked = false;
            bool hasKey = false;
            bool churchVisit = false;

            do
            {
                world.DrawGrid(0, 45);
                if (hasKey)
                {
                    gameArt.DrawArt(gameArt.worldArt["GraveyardKey"], 39, 126);
                }
                switch(townSquare.DisplayTownSquare())
                {
                    case 0:
                        //Graveyard
                        if (hasKey)
                        {
                            grave.Start();
                            barnUnlocked = true;
                        }
                        else
                        {
                            Dialog("It's locked...Is there a key somewhere?", 58, 44);
                            ReadKey(true);
                        }
                        break;

                    case 1:
                        //Church
                        church.Start();
                        churchVisit = true;
                        break;

                    case 2:
                        //Corn Maze
                        maze.Start();
                        hasKey = true;
                        break;

                    case 3:
                        //Barn - BOSS
                        if (barnUnlocked)
                            barn.Start();
                        else
                        {
                            Dialog("I feel like I should explore more...", 58, 44);
                            ReadKey(true);
                        }
                        break;
                }

            } while(exit != true);

            ReadAndClear();

            //Ease-Of-Use Functions
            void DefaultResolution()
            {
                WindowHeight = 30;
                WindowWidth = 120;
            }
            void LargeResolution()
            {
                WindowHeight = 60;
                WindowWidth = 180;
            }

            void ReadAndClear()
            {
                ReadKey();
                Clear();
            }
            void Dialog(string input, int cursorX, int cursorY)
            {
                SetCursorPosition(cursorX, cursorY);
                ForegroundColor = ConsoleColor.Blue;
                WriteLine(input);
                ResetColor();
            }

        }
    }
}
