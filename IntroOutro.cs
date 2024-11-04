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
                        void OutroDialog(int cursorX, int cursorY)
                        {
                            Clear();

                            List<string> list = new List<string>();
                            list.Add("               ");
                            list.Add("\"What...what is going on...where am I?\"");
                            list.Add("Jimmy notices a figure afar...It disappears...");
                            list.Add("\"Wait! Who are you?...\"");
                            list.Add("\"I have to figure out what's happening...\"");
                            list.Add("                  ");
                            list.Add("Jimmy follows a path that leads to an abandoned Townsquare...");

                            for (int i = 0; i < list.Count; i++)
                            {
                                SetCursorPosition(cursorX, cursorY);
                                foreach (char c in list[i])
                                {
                                    Write(c);
                                    Thread.Sleep(10);
                                }
                                Thread.Sleep(2000);
                                for (int j = list[i].Length - 1; j >= 0; j--)
                                {
                                    Write(" ");
                                }
                                Clear();
                            }
                        }
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

        public void DisplayOutroLived() //After fighting Death
        {
            //Woken up from a dream
            //Surrounded by doctors
            Clear();
            OutroDialog(75, 20);
            WriteLine("To be Continued...");

            void OutroDialog(int cursorX, int cursorY)
            {
                Clear();

                List<string> list = new List<string>();
                list.Add("Voice 1: Welcome back...");
                list.Add("Voice 2: We almost lost you there :)");
                list.Add("Behind their shoulder, you see a dark figure walking away");
                list.Add("Voice 1: We'll get your family in here right away okay?");
                list.Add("Voice 2: You just rest. They'll be here shortly");
                list.Add("                  ");
                list.Add("Voice 3: Baby! ");
                list.Add("     ...        ");

                for (int i = 0; i < list.Count; i++)
                {
                    SetCursorPosition(cursorX, cursorY);
                    foreach (char c in list[i])
                    {
                        Write(c);
                        Thread.Sleep(10);
                    }
                    Thread.Sleep(2000);
                    for (int j = list[i].Length - 1; j >= 0; j--)
                    {
                        Write(" ");
                    }
                    Clear();
                }
            }
        }
        public void DisplayOutroDead()
        {
            Clear();
            art.DrawArt(art.worldArt["YouDied"]);
            Thread.Sleep(3000);
            art.Erase(art.worldArt["YouDied"], 6);
            OutroDialog(75, 20);

            void OutroDialog(int cursorX, int cursorY)
            {
                Clear();

                List<string> list = new List<string>();
                list.Add("Voice 1: Give me the ... now!");
                list.Add("Voice 2: Ther 's... to...I ca.. stop i...");
                list.Add("Voice 1: Ther...we n..d suc..ion no.! ");
                list.Add("Voice 3: I...Ca...no! Ca..' be! ");
                list.Add("Voice 1: Call it.");
                list.Add("                  ");
                
                List<string> list2 = new List<string>();
                list2.Add("Voice 2: 17:09, dead");
                list2.Add("A blinding light fills Jimmy's head...");
                list2.Add("Slowly corrupted by the dark...");
                list2.Add("Death smiles sinisterly...");
                list2.Add("\"It's not over Death...\" ");

                for (int i = 0; i < list.Count; i++)
                {
                    SetCursorPosition(cursorX, cursorY);
                    foreach (char c in list[i])
                    {
                        Write(c);
                        Thread.Sleep(10);
                    }
                    Thread.Sleep(2000);
                    for (int j = list[i].Length - 1; j >= 0; j--)
                    {
                        Write(" ");
                    }
                    Clear();
                }
                for (int i = 0; i < list2.Count; i++)
                {
                    SetCursorPosition(cursorX, cursorY);
                    foreach (char c in list2[i])
                    {
                        Write(c);
                        Thread.Sleep(10);
                    }
                    Thread.Sleep(3000);
                    for (int j = list2[i].Length - 1; j >= 0; j--)
                    {
                        Write(" ");
                    }
                    Clear();
                }
            }
            
            SetCursorPosition(70, 25);
            Thread.Sleep(2000);
            WriteLine("To be Continued...");
        }

        private void Loading()
        {
            SetCursorPosition(WindowWidth / 2, WindowHeight / 2);
            WriteLine("Sorry to see you go");  
        }
    }
}
