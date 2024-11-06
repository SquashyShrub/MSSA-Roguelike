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
                        IntroDialog(86, 20);
                        //go to town square (Handled in program)
                        void IntroDialog(int cursorX, int cursorY)
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
                        WriteLine("\n* Use the arrow keys to move and select different options");
                        WriteLine("\n* Press enter to select and option");
                        WriteLine("\n* 'X's are enemies");
                        WriteLine("\n* 'O's are things to explore");
                        WriteLine("\n* '>'s and '<'s are your exits");
                        WriteLine("\n* '#'s is an item\n\n");

                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("THINGS TO NOTE");

                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("\n* When in a cut scene, refrain from pressing any key too many times as it is known to cause issues with the game");
                        WriteLine("\n* To continue dialog, simply press any key on the keyboard");
                        WriteLine("\n* Each enemy has different skill sets, adjust your strategy accordingly");
                        WriteLine("\n* Once you complete the storyline, the game will exit. If you wish to play again, please re-open the application");
                        WriteLine("\n* Best of Luck!");
                        ResetColor();

                        WriteLine("\n\n>> Press any key to return to the menu <<");
                        ReadKey();
                        break; //Game controls

                    case 2:
                        //See credit screen
                        WriteLine("ARTWORK");
                        WriteLine(@"
    * GRAVEYARD INTERIOR        Myself                                   https://asciiflow.com/

    * MAZE INTERIOR             Myself                                   https://asciiflow.com/

    * CHURCH INTERIOR           Myself                                   https://asciiflow.com/

    * BARN INTERIOR             Myself                                   https://asciiflow.com/

    * GRAVEYARD EXTERIOR ART:   Myself                                   https://asciiflow.com/

    * CHURCH EXTERIOR ART:      Joan Stark                               https://www.asciiart.eu/buildings-and-places/church

    * BARN EXTERIOR ART:        No Artist Listed                         https://www.asciiart.eu/buildings-and-places/houses

    * TOWNSQUARE ART:           Myself (mashed together exterior arts)   https://asciiflow.com/

    * CORN MAZE START:          Spicer, Public Library Halls,            https://www.asciiart.eu/buildings-and-places/other

    * SKELETON ART IDLE:        Nabis                                    https://www.asciiart.eu/mythology/skeletons

    * SKELETON ART ATTACK:      No Artist Listed                         https://www.asciiart.eu/mythology/skeletons

    * GRIM REAPER ART:          jgs                                      https://www.asciiart.eu/mythology/grim-reapers

    * GHOST ART:                jgs                                      https://www.asciiart.eu/mythology/ghosts

    * KEY ART:                  Myself

    * TEXT ART:                 patorjk.com                              https://patorjk.com/software/taag/#p=display&h=2&v=0&f=BlurVision%20ASCII&t=Type%20Something%20


MUSIC - ALL MUSIC WAS WITH BEEPBOX

    * TOWN SQUARE THEME SONG:   Myself                                  ""Town Square Theme""

    * CHURCH THEME SONG:        Mystical Fire                           ""Groovy Spooky House""

    * CHURCH BATTLE SONG:       John Nesky                              ""Fay Witch Commune""

    * MAZE SONG:                Spooky Sandwich                           No song name

    * GRAVEYARD THEME SONG:     Mystical Fire                           ""Halloween Type Beat""

    * GRAVEYARD BATTLE SONG:    Myself                                  ""8-Bit Transposed Bloody Tears""

    * BARN THEME SONG:          Spooky Sandwich                         ""Strange Scale""

    * BARN BATTLE SONG:         Scarf Ghost                               No song name


WEBSITES USED

    * ASCII Flow                                                         https://asciiflow.com/
    
    * ASCII Art Archive         Injosoft                                 https://www.asciiart.eu/

    * Google Images             Google                                   https://images.google.com/

    * ASCII Image convertor     Injosoft                                 https://www.asciiart.eu/image-to-ascii

    * BeepBox                   John Nesky                               https://www.beepbox.co/

    * BeepBox Archive           Twitter Bot                              https://twitter-archive.beepbox.co/


GAME DESIGN

    * Story Writer              Myself                          

    * Development Guy           Myself
    
    * Implementation            Myself

    * Tester                    Myself


>> Press any key to return to the menu <<");

                        ReadKey();
                        Clear();
                        break; //Credits

                    case 3:
                        Loading();
                        Thread.Sleep(3000);
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
            OutroDialog(86, 20);
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
            art.Erase(art.worldArt["YouDied"], 8);
            OutroDialog(86, 20);

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
                list2.Add("Voice 2: 17:09, dead.");
                list2.Add("A blinding light fills your head...");
                list2.Add("Slowly corrupted by the dark...");
                list2.Add("Death smiles sinisterly...");
                list2.Add("\"It's not over Death...\"");
                list2.Add("\"I'm not dying yet.\"");

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
            
            SetCursorPosition(86, 20);
            Thread.Sleep(2000);
            WriteLine("To be Continued...");
            Thread.Sleep(2000);
            SetCursorPosition(86, 22);
            WriteLine("Thank you for playing!");
            SetCursorPosition(86, 24);
            WriteLine("Press any key to exit the application");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void Loading()
        {
            SetCursorPosition(WindowWidth / 2, WindowHeight / 2);
            WriteLine("Sorry to see you go.");  
        }
    }
}
