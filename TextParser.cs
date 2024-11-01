using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MSSA_Roguelike___Mini_Project
{
    internal class TextParser
    {
        public static string[,] ParseFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;

            string[,] grid = new string[rows, cols];


            for (int x = 0; x < rows; x++)
            {
                string line = lines[x];
                for (int y = 0; y < cols; y++)
                {
                    char currentChar = line[y];
                    grid[x, y] = currentChar.ToString();
                }
                
            }
            return grid;
            
        }
    }
}
