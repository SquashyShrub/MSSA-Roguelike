using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project
{
    internal class IntroOutro
    {
        private Artwork art = new Artwork();
        private Menu menus = new Menu();
        public void DisplayIntro()
        {
            int response = 1;

            while (response != 0)
            {
                response = menus.IntroMenu(113, 15);
                
                switch (response)
                {
                    case 0:
                        //Loading Symbol ->
                        //go to town square (Handled in program)
                        break;

                    case 1:
                        //Game Controls screen
                        WriteLine("Game Controls");
                        ReadKey();
                        break;

                    case 2:
                        //See credit screen
                        WriteLine("Credit Screen");
                        ReadKey();
                        break;

                    case 3:
                        //Loading Symbol
                        Environment.Exit(0);
                        break;
                }
            }

            //WriteLine("Use the arrow keys to move and select different options");
            //WriteLine("X are enemies");
            //WriteLine("O are things to explore");
            //WriteLine("> and < are your exits");
            //WriteLine("# is an item");
            //WriteLine("\n Press any key to continue:");

            Clear();
        }




    }
}
