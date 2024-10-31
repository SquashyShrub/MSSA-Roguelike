using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSA_Roguelike___Mini_Project.Characters;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Places
{
    internal class AbandonedChurch
    {
        private World GameHandler_Church;
        private Player Player_Church;
        private Artwork Art_Church = new Artwork();
        public int Health = 200;
        public void Start()
        {
            Clear();

            string[,] churchGrid = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Maps\\ChurchInterior.txt");

            GameHandler_Church = new World(churchGrid);
            Player_Church = new Player(19, 13, "Jimmy", Health, ConsoleColor.Cyan, 6);

            #region Display Church Entrance

            Art_Church.DrawArt(Art_Church.worldArt["ChurchEntrance"], 2);
            ReadKey();
            Art_Church.Erase(Art_Church.worldArt["ChurchEntrance"], 2);

            #endregion Display Church Entrance

            GameHandler_Church.DrawGrid();
            Player_Church.DrawPlayer();

            ChurchGameLoop();
        }
        private void DrawFrame()
        {
            Clear();
            GameHandler_Church.DrawGrid();
            Player_Church.DrawPlayer();
        }
        private void PlayerInput()
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
            }
        }
        private void ChurchGameLoop()
        {
            //Variables
            bool exit = false;

            while (exit == false)
            {
                //Draw Everything
                DrawFrame();

                //Player movement
                PlayerInput();

                //Activate event
                ///Dependent on certain things - - Check notebook///

                //Render
                Thread.Sleep(150);
            }
        }
    }
}
