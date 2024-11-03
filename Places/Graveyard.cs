using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSA_Roguelike___Mini_Project.Characters;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Places
{
    internal class Graveyard
    {
        private World GameHandler_Graveyard;
        private Player Player_Graveyard;
        private Artwork Artwork_Graveyard = new Artwork();
        private Battlegrounds battle = new Battlegrounds();

        public void Start()
        {
            Clear();

            string[,] graveyardGrid = TextParser.ParseFileToArray("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\TextFiles\\Maps\\GraveYardMap.txt");

            GameHandler_Graveyard = new World(graveyardGrid);
            Player_Graveyard = new Player(3, 9, "Jimmy", 200, ConsoleColor.Cyan, 6);

            #region Display Graveyard Entrance

            Artwork_Graveyard.DrawArt(Artwork_Graveyard.worldArt["graveyardEntrance"]);
            ReadKey();
            Artwork_Graveyard.Erase(Artwork_Graveyard.worldArt["graveyardEntrance"], 2);

            #endregion Display Graveyard Entrance

            GameHandler_Graveyard.DrawGrid();
            Player_Graveyard.DrawPlayer();

            RunGraveyardLoop();
        }

        private void DrawFrame()
        {
            Clear();
            GameHandler_Graveyard.DrawGrid();
            Player_Graveyard.DrawPlayer();
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
                    if (!GameHandler_Graveyard.Colliding(Player_Graveyard.X, Player_Graveyard.Y - 1))
                        Player_Graveyard.Y -= 1;
                    break;

                case ConsoleKey.DownArrow:
                    if (!GameHandler_Graveyard.Colliding(Player_Graveyard.X, Player_Graveyard.Y + 1))
                        Player_Graveyard.Y += 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (!GameHandler_Graveyard.Colliding(Player_Graveyard.X - 1, Player_Graveyard.Y))
                        Player_Graveyard.X -= 1;
                    break;

                case ConsoleKey.RightArrow:
                    if (!GameHandler_Graveyard.Colliding(Player_Graveyard.X + 1, Player_Graveyard.Y))
                        Player_Graveyard.X += 1;
                    break;

            }
        }
        private void RunGraveyardLoop()
        {
            bool exit = false;
            bool enemyDefeated = false;

            while (exit == false)
            {
                //Draw Frame
                DrawFrame();

                //Player Input
                PlayerInput();

                //Event handler
                string currentElement = GameHandler_Graveyard.GetElementAt(Player_Graveyard.X, Player_Graveyard.Y);
                switch (currentElement)
                {
                    case "X":
                        if (enemyDefeated == false)
                        {
                            enemyDefeated = true;
                            battle.graveBattle();
                        }
                        else
                        {
                            WriteLine("~~A bunch of bones lay on the ground...~~");
                            ReadKey();
                        }
                        break;

                    case "O":
                        //Here something...should go to barn
                        if (enemyDefeated)
                        {
                            WriteLine("\n> What a strange altar...               ");
                            ReadKey(true);
                            WriteLine("> That's a lot of blood too...            ");
                            ReadKey(true);
                            WriteLine("~~A noise comes from the nearby barn~~    ");
                            ReadKey(true);
                            WriteLine("> What was that...                        ");
                            ReadKey(true);
                            WriteLine("> I should investigate...                 ");
                            ReadKey(true);
                            Clear();
                            exit = true;
                        }
                        else
                        {
                            WriteLine("> I should explore this after I defeat the chill skeleton...");
                            ReadKey(true);
                        }
                        break;
                }

                //Render Console
                Thread.Sleep(10);
            }
        }
    }
}
