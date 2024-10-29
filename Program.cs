using System.Security.Cryptography.X509Certificates;
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

            Artwork gameArt = new Artwork();
            Menu menus = new Menu();

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
            //Loading Symbol

            //Gameplay
            bool exit = false;
            do
            { 
                world.DrawGrid(0, 45);
                switch(townSquare.DisplayTownSquare())
                {
                    case 0:
                        //Graveyard
                        grave.Start();
                        break;

                    case 1:
                        //Church
                        church.Start();
                        break;

                    case 2:
                        //Corn Maze
                        maze.Start();
                        break;

                    case 3:
                        //Barn - BOSS
                        barn.Start();
                        break;
                }

            } while(exit != true);

            //ReadAndClear();

            


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
            void Loading()
            {

            }
        }
    }
}
