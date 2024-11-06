﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project
{
    internal class Artwork
    {
        public Dictionary<string, string[,]> worldArt = new Dictionary<string, string[,]>();

        private int rows;
        private int cols;

        public Artwork()
        {
            string baseDir = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\";

            string titlePath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\Title.txt";
            string townPath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\TownSquare.txt";
            string churchPath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\ChurchEntrance.txt";
            string mazePath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\CornMazeEntrance.txt";
            string gravePath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\GraveYardEntrance.txt";
            string barnPath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\BarnEntrance.txt";
            string ghostPath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\GhostEnemy.txt";
            string skeletonPath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\SkeletonEnemy.txt";
            string reaperPath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\ReaperEnemy.txt";
            string keyPath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\Artwork\Key.txt";
            string diedPath = @"C:\MSSA\DS_Algo\MSSA Roguelike - Mini Project\TextFiles\MenuTexts\YouDied.txt";

            #region Add Artwork to Dictionary 

            //Beginning
            string[,] TitleArt = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, titlePath));
            worldArt.Add("TitleArt", TitleArt);

            string[,] TownSquare = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, townPath));
            worldArt.Add("TownSquare", TownSquare);


            //Entrances
            string[,] churchEntrance = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, churchPath));
            worldArt.Add("ChurchEntrance", churchEntrance);

            string[,] mazeEntrance = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, mazePath));
            worldArt.Add("MazeEntrance", mazeEntrance);

            string[,] graveyardEntrance = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, gravePath));
            worldArt.Add("graveyardEntrance", graveyardEntrance);

            string[,] barnEntrance = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, barnPath));
            worldArt.Add("barnEntrance", barnEntrance);


            //Enemies
            string[,] Ghosts = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, ghostPath));
            worldArt.Add("Ghosts", Ghosts);

            string[,] Skeleton = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, skeletonPath));
            worldArt.Add("Skeleton", Skeleton);

            string[,] Reaper = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, reaperPath));
            worldArt.Add("Reaper", Reaper);


            //Items
            string[,] GraveyardKey = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, keyPath));
            worldArt.Add("GraveyardKey", GraveyardKey);


            //MenuText
            string[,] YouDied = TextParser.ParseFileToArray(System.IO.Path.GetRelativePath(baseDir, diedPath));
            worldArt.Add("YouDied", YouDied);

            #endregion Add Artwork to Dictionary
        }

        /// <summary>
        /// Draw anything that is in a 2D Array grid. It was intended for the ArtWork Dictionary.
        /// </summary>
        /// <param name="artwork"></param>
        /// <param name="cursorPositionX"></param>
        /// <param name="cursorPositionY"></param>
        /// <param name="sleepTime"></param>
        public void DrawArt(string[,] artwork, int cursorPositionX = 0, int cursorPositionY = 0, int sleepTime = 0)
        {
            rows = artwork.GetLength(0);
            cols = artwork.GetLength(1);

            for(int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    string element = artwork[x, y];
                    if (cursorPositionX == 0 && cursorPositionY == 0)
                        SetCursorPosition(y, x);
                    else
                        SetCursorPosition(cursorPositionY + y, cursorPositionX + x); 
                    Write(element);
                }
                WriteLine();
                System.Threading.Thread.Sleep(sleepTime);
            }
        }

        /// <summary>
        /// Erase the draw art in a reverse fashion. You can specify the time in milliseconds it will take.
        /// </summary>
        /// <param name="artwork"></param>
        /// <param name="sleepTime"></param>
        public void Erase(string[,] artwork, int sleepTime = 0)
        {
            rows = artwork.GetLength(0);
            cols = artwork.GetLength(1);

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    SetCursorPosition(cols - y, rows - x);
                    Write(" ");
                    
                }
                System.Threading.Thread.Sleep(sleepTime);
            }
            Clear();
        }

        #region Credits
        /*
         * Church Exterior Art: Joan Stark https://www.asciiart.eu/buildings-and-places/church
         * Barn: No Artist Listed https://www.asciiart.eu/buildings-and-places/houses
         * CornMazeStart: Spicer, Public Library Halls, https://www.asciiart.eu/buildings-and-places/other
         * Skeleton Art Idle: Nabis https://www.asciiart.eu/mythology/skeletons
         * Skeleton Art Attack: No Artist Listed https://www.asciiart.eu/mythology/skeletons
         * Grim Reaper Art: jgs https://www.asciiart.eu/mythology/grim-reapers
         * Ghost Art: jgs https://www.asciiart.eu/mythology/ghosts
         * Key Art: Myself
         * Text Art: patorjk.com https://patorjk.com/software/taag/#p=display&h=2&v=0&f=BlurVision%20ASCII&t=Type%20Something%20
         * 
         */
        #endregion Credits
    }
}
