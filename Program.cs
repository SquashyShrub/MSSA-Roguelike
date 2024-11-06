using System.Media;
using System.Security.Cryptography.X509Certificates;
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

            //World
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string screen = Path.Combine(currentDir, "TextFiles", "NormalScreen.txt");
            string[,] screenGrid = TextParser.ParseFileToArray(screen);
            World world = new World(screenGrid);
            Player Jimmy = new Player(0, 0, null, 0, 0, 0);


            //Game
            Artwork gameArt = new Artwork();
            Menu menus = new Menu();
            IntroOutro introOutro = new IntroOutro();
            MusicThemes music = new MusicThemes();


            //Items
            Items graveKey = new Items("Graveyard Key", 1);
            Items sword = new Items("Sword", 1);


            //Places
            TownSquare townSquare = new TownSquare();
            AbandonedChurch church = new AbandonedChurch();
            CornMaze maze = new CornMaze();
            Graveyard grave = new Graveyard();
            Barn barn = new Barn();
            Battlegrounds battle = new Battlegrounds();

            #endregion Game Objects

            #region Initialize and Intro

            //Set Game Resolution
            DefaultResolution();

            //Ensure correct window size
            ForegroundColor = ConsoleColor.Green;
            SetCursorPosition(48, 12);
            WriteLine("Press any key to load the game...");
            ResetColor();
            ReadAndClear();

            ////Load Assets Animation
            //world.Loading(1, "Loading Assets");
            //world.Loading(1, "Loading Art");
            //world.Loading(2, "Loading Music");
            //Thread.Sleep(1000);
            //Clear();

            TryAgain:
            try
            {
                //Start Music
                music.Play(music.townSquareTheme);

                //Intro
                Thread.Sleep(500);
                introOutro.DisplayIntro();
                world.SceneLoad(2);
            }
            catch
            {
                Clear();
                music.Stop(music.townSquareTheme);
                ForegroundColor = ConsoleColor.Red;
                SetCursorPosition(20, 10);
                WriteLine("Please ensure your window is fullscreen otherwise the program cannot run correctly");
                SetCursorPosition(36, 12);
                WriteLine("Once screen is full size, press any key to continue");
                ForegroundColor = ConsoleColor.White;
                ReadKey();

                goto TryAgain;
            }

            #endregion Initialize and Intro

            #region Gameplay

            //Gameplay Conditionals
            bool exit = false;
            bool alive = true;
            bool barnUnlocked = false;
            bool hasKey = false;
            bool churchVisit = false;

            //Game Loop
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
                            music.Play(music.graveTheme);
                            Dialog("That place looks spooky...", 58, 45);
                            Thread.Sleep(2500);
                            grave.Start();
                            barnUnlocked = true;
                        }
                        else
                        {
                            Dialog("It's locked...Is there a key somewhere?", 58, 45);
                            ReadKey(true);
                        }
                        break; //Graveyard

                    case 1:
                        //Church
                        Dialog("I think that's a good place to start...", 58, 45);
                        Thread.Sleep(2500);
                        music.Play(music.churchTheme);
                        church.Start();
                        churchVisit = true;
                        break; //Church

                    case 2:
                        //Corn Maze
                        music.Play(music.mazeTheme);
                        Dialog("I hope I don't get lost...", 58, 45);
                        Thread.Sleep(2500);
                        maze.Start();
                        hasKey = true;
                        break; //Maze

                    case 3:
                        //Barn - BOSS
                        if (barnUnlocked)
                        {
                            music.Play(music.barnTheme);
                            Dialog("Something doesn't feel right", 58, 45);
                            Thread.Sleep(2500);
                            barn.Start();
                            alive = false;
                            exit = true;
                        }
                        else
                        {
                            Dialog("I feel like I should explore more...", 58, 45);
                            ReadKey(true);
                        }
                        break; //Barn
                }
                music.Play(music.townSquareTheme);

            } while(exit != true);


            //Outro
            music.Play(music.barnTheme);
            if (!alive)
                introOutro.DisplayOutroDead();
            ReadAndClear();

            #endregion Gameplay

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
