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
        private Battlegrounds battle = new Battlegrounds();
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
            bool enemyDefeated = false;

            while (exit == false)
            {
                //Draw Everything
                DrawFrame();

                //Player movement
                PlayerInput();

                //Activate events
                string currentLocation = GameHandler_Church.GetElementAt(Player_Church.X, Player_Church.Y);
                
                switch (currentLocation)
                {
                    case "X":
                        //Add dialog and animation here
                        if (enemyDefeated == false)
                        {
                            enemyDefeated = true;
                            battle.churchBattle();
                        }
                        else
                        {
                            WriteLine("~~Plasma lays on the ground...~~         ");
                            ReadKey();
                        }
                        break;

                    case "O": 
                        //Pool of blood
                        if (Player_Church.X == 30 && Player_Church.Y == 6)
                        {
                            WriteLine("> A pool of blood...disgusting           ");
                            ReadKey(true);
                        }

                        //Dead Priest
                        if (Player_Church.X == 32 && Player_Church.Y == 5)
                        {
                            WriteLine("> A dead priest...                       ");
                            ReadKey(true);
                        }

                        //Partial note
                        if (Player_Church.X == 28 && Player_Church.Y == 4)
                        {
                            WriteLine("> A torn note... 'I dropped the key i...'");
                            ReadKey(true);
                        }

                        //Other partial note
                        if (Player_Church.X == 33 && Player_Church.Y == 22)
                        {
                            WriteLine("> An torn note... 'n the maze'...'       ");
                            ReadKey(true);
                        }
                        break;

                    case "<":
                        if (enemyDefeated == true)
                        {
                            Clear();
                            exit = true;
                        }
                        else
                        {
                            WriteLine("There are still enemies nearby...        ");
                            ReadKey(true);
                        }
                        break;

                    case ">":
                        if (enemyDefeated == true)
                        {
                            Clear();
                            exit = true;
                        }
                        else
                        {
                            WriteLine("There are still enemies nearby...        ");
                            ReadKey(true);
                        }
                        break;
                }

                //Render
                Thread.Sleep(10);
            }
        }
    }
}
