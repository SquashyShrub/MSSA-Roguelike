using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSA_Roguelike___Mini_Project.Characters;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Places
{
    internal class CornMaze
    {
        private World Maze_GameHandler;
        private Player Player_Maze;
        private Artwork Artwork_Maze = new Artwork();

        public void Start()
        {
            Clear();

            string[,] mazeGrid = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Maps\\CornMazeInterior.txt");

            Player_Maze = new Player(2, 9, "Jimmy", 200, ConsoleColor.Cyan, 6);
            Maze_GameHandler = new World(mazeGrid);

            #region Display Maze Entrance

            Artwork_Maze.DrawArt(Artwork_Maze.worldArt["MazeEntrance"], 2);
            ReadKey();
            Artwork_Maze.Erase(Artwork_Maze.worldArt["MazeEntrance"], 2);

            #endregion Display Maze Entrance

            Maze_GameHandler.DrawGrid();
            Player_Maze.DrawPlayer();

            MazeGameLoop();

        }

        private void DrawFrame()
        {
            Clear();
            Maze_GameHandler.DrawGrid();
            Player_Maze.DrawPlayer();
        }
        private void PlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey();
                key = keyInfo.Key;

            } while (KeyAvailable);

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (!Maze_GameHandler.Colliding(Player_Maze.X, Player_Maze.Y - 1))
                        Player_Maze.Y -= 1;
                    break;

                case ConsoleKey.DownArrow:
                    if (!Maze_GameHandler.Colliding(Player_Maze.X, Player_Maze.Y + 1))
                        Player_Maze.Y += 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (!Maze_GameHandler.Colliding(Player_Maze.X - 1, Player_Maze.Y))
                        Player_Maze.X -= 1;
                    break;

                case ConsoleKey.RightArrow:
                    if (!Maze_GameHandler.Colliding(Player_Maze.X + 1, Player_Maze.Y))
                        Player_Maze.X += 1;
                    break;
            }
        }
        private void MazeGameLoop()
        {
            //Variables
            bool exit = false;
            bool hasKey = false;

            while (exit == false)
            {
                //Draw frame
                DrawFrame();

                //Get player input
                PlayerInput();

                //Draw the chaser

                //Event Handler
                string currentLocation = Maze_GameHandler.GetElementAt(Player_Maze.X, Player_Maze.Y);

                switch (currentLocation)
                {
                    case "#":
                        WriteLine("> I got the Graveyard Key!");
                        hasKey = true;
                        ReadKey();
                        break;

                    case ">":
                        if (hasKey)
                        {
                            Clear();
                            exit = true;
                        }
                        else
                        {
                            WriteLine("> I think there is something I need to get here...");
                        }
                        break;
                }

                //Render console
                Thread.Sleep(10);
            }
        }

    }
}
