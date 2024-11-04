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
                        //Display intro dialog and backstory
                        //go to town square (Handled in program)
                        break;

                    case 1:
                        //Game Controls screen
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("GAME CONTROLS");
                        ForegroundColor = ConsoleColor.DarkYellow;
                        WriteLine("\nUse the arrow keys to move and select different options");
                        WriteLine("\n'X' are enemies");
                        WriteLine("\n'O' are things to explore");
                        WriteLine("\n'>' and '<' are your exits");
                        WriteLine("\n'#' is an item");
                        ResetColor();
                        WriteLine("\n\n>>Press any key to continue<<");
                        ReadKey();
                        break; //Game controls

                    case 2:
                        //See credit screen
                        WriteLine("ARTWORK");
                        WriteLine(@"
    * CHURCH EXTERIOR ART:      Joan Stark                      https://www.asciiart.eu/buildings-and-places/church

    * BARN:                     No Artist Listed                https://www.asciiart.eu/buildings-and-places/houses

    * CORN MAZE START:          Spicer, Public Library Halls,   https://www.asciiart.eu/buildings-and-places/other

    * SKELETON ART IDLE:        Nabis                           https://www.asciiart.eu/mythology/skeletons

    * SKELETON ART ATTACK:      No Artist Listed                https://www.asciiart.eu/mythology/skeletons

    * GRIM REAPER ART:          jgs                             https://www.asciiart.eu/mythology/grim-reapers

    * GHOST ART:                jgs                             https://www.asciiart.eu/mythology/ghosts

    * KEY ART:                  Myself

    * TEXT ART:                 patorjk.com                     https://patorjk.com/software/taag/#p=display&h=2&v=0&f=BlurVision%20ASCII&t=Type%20Something%20

MUSIC

    * TOWN SQUARE THEME SONG:   Myself                          ""Town Square Theme""

    * CHURCH THEME SONG:        Mystical Fire                   ""Groovy Spooky House""

    * CHURCH BATTLE SONG:       John Nesky                      ""Fay Witch Commune""

    * MAZE SONG:                Spooky Sandwich                  No song name

    * GRAVEYARD THEME SONG:     Mystical Fire                   ""Halloween Type Beat""

    * GRAVEYARD BATTLE SONG:    Myself                          ""8-Bit Transposed Bloody Tears""

    * BARN THEME SONG:          Spooky Sandwich                 ""Strange Scale""

    * BARN BATTLE SONG:         Scarf Ghost                      No song name


WEBSITES USED

    * ASCII Flow                                                https://asciiflow.com/
    
    * ASCII Art Archive         Injosoft                        https://www.asciiart.eu/

    * Google Images             Google                          https://images.google.com/

    * ASCII Image convertor     Injosoft                        https://www.asciiart.eu/image-to-ascii

    * BeepBox                   John Nesky                      https://www.beepbox.co/");
                        ReadKey();
                        break; //Credits

                    case 3:
                        Loading();
                        ReadKey(true);
                        Environment.Exit(0);
                        break; //Exit Game
                }
            }



            Clear();
        }
        private void Loading()
        {
            SetCursorPosition(WindowWidth / 2, WindowHeight / 2);
            WriteLine("Sorry to see you go");
            
        }



    }
}
