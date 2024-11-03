using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project
{
    internal class World
    {
        //Items
        private Items Key;
        private Items Sword; 

        private string[,] Grid;
        private int rows;
        private int cols;

        public Dictionary<string, Artwork> artwork = new Dictionary<string, Artwork>();

        public World(string[,] grid)
        {
            Key = new Items("Graveyard Key", 1);

            CursorVisible = false;
            Grid = grid;
            rows = Grid.GetLength(0);
            cols = Grid.GetLength(1);
        }

        /// <summary>
        /// Draw a map grid at a certain position 
        /// </summary>
        /// <param name="cursorPositionX"></param>
        /// <param name="cursorPositionY"></param>
        public void DrawGrid(int cursorPositionX = 0, int cursorPositionY = 0)
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    string element = Grid[x, y];

                    //Change 'X', 'O', '<', '>' '#' colors
                    switch (element)
                    {
                        case "X":
                            ForegroundColor = ConsoleColor.Red;
                            break;
                        case "O":
                            ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        case "<":
                            ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case ">":
                            ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "#":
                            ForegroundColor = ConsoleColor.Green;
                            break;
                        default:
                            break;
                    }

                    //Check if user input is custom position
                    if (cursorPositionX == 0 && cursorPositionY == 0)
                        SetCursorPosition(y, x);
                    else
                        SetCursorPosition(cursorPositionY + y, cursorPositionX + x);

                    Write(element);
                    ForegroundColor = ConsoleColor.White;
                }
                WriteLine();
            }
        }

        /// <summary>
        /// Check if a collision is happening. Returns true if colliding 
        /// You can specify which string characters to avoid collision with 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Colliding(int x, int y)
        {
            //Check bounds
            if (x < 0 || y < 0 || y >= rows || x >= cols)
                return true;

            //Check if colliding
            if (Grid[y, x] == " " || Grid[y, x] == "O" || Grid[y, x] == "X" || Grid[y, x] == "<" || Grid[y, x] == ">" || Grid[y, x] == "#")
                return false;

            return true;
        }

        /// <summary>
        /// Get any element at a certain position 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        /// <summary>
        /// Enter a load time in seconds, and it will give a simple loading screen
        /// </summary>
        /// <param name="loadTime"></param>
        public void Loading(int loadTime)
        {
            string input = "Loading...";
            int load = loadTime * 1000;
            int indvLoad = load / 24;
            StringBuilder sb = new StringBuilder();
            for (int i = loadTime; i >= 0; i--)
            {
                Clear();
                SetCursorPosition(WindowWidth / 2, WindowHeight / 2);
                foreach (char c in input)
                {
                    Write(c);
                    Thread.Sleep(indvLoad);
                }
            }
        }
    }
}
