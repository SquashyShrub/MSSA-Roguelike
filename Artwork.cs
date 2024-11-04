using System;
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
            #region Add Artwork to Dictionary 

            //Beginning
            string[,] TitleArt = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\Title.txt");
            worldArt.Add("TitleArt", TitleArt);

            string[,] TownSquare = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\TownSquare.txt");
            worldArt.Add("TownSquare", TownSquare);


            //Entrances
            string[,] churchEntrance = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\ChurchEntrance.txt");
            worldArt.Add("ChurchEntrance", churchEntrance);

            string[,] mazeEntrance = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\CornMazeEntrance.txt");
            worldArt.Add("MazeEntrance", mazeEntrance);

            string[,] graveyardEntrance = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\GraveYardEntrance.txt");
            worldArt.Add("graveyardEntrance", graveyardEntrance);

            string[,] barnEntrance = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\BarnEntrance.txt");
            worldArt.Add("barnEntrance", barnEntrance);


            //Enemies
            string[,] Ghosts = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\GhostEnemy.txt");
            worldArt.Add("Ghosts", Ghosts);

            string[,] Skeleton = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\SkeletonEnemy.txt");
            worldArt.Add("Skeleton", Skeleton);

            string[,] Reaper = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\ReaperEnemy.txt");
            worldArt.Add("Reaper", Reaper);


            //Items
            string[,] GraveyardKey = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Artwork\\Key.txt");
            worldArt.Add("GraveyardKey", GraveyardKey);


            //MenuText
            string[,] GameControls = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\MenuTexts\\GameControls.txt");
            worldArt.Add("GameControls", GameControls);

            string[,] YouDied = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\MenuTexts\\YouDied.txt");
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
