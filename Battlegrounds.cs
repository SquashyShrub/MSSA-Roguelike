using MSSA_Roguelike___Mini_Project.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project
{
    internal class Battlegrounds
    {
        private Random randGenerator;

        Player Jimmy = new Player(0, 0, "Jimmy", 10, ConsoleColor.Cyan, 6);

        Ghosts ghost1 = new Ghosts("Spooky Ghost", 51, "Ghosts", ConsoleColor.DarkGray);
        Ghosts ghost2 = new Ghosts("That one guy that died", 45, "Ghosts", ConsoleColor.Gray);
        Ghosts ghost3 = new Ghosts("Unusually buff ghost", 63, "Ghosts", ConsoleColor.DarkGray);
        Ghosts currentGhost;
        List<Ghosts> ghosts = new List<Ghosts>();
        
        Skeleton skeleton = new Skeleton("Chill Skeleton", 124, "Skeleton", ConsoleColor.Red);

        Reaper reaper = new Reaper("Part Time Death", 250, "Reaper", ConsoleColor.DarkRed);

        public bool alive = true;

        public Battlegrounds()
        {
            //Add Ghosts
            ghosts.Add(ghost3);
            ghosts.Add(ghost2);
            ghosts.Add(ghost1);
        }

        public void churchBattle()
        {

            ChurchDialog(75, 22);

            int ghostCount = 3;
            while ( ghostCount > 0)
            {
                Ghosts currentGhost = ghosts[ghostCount - 1];
                while (currentGhost.health > 0 && Jimmy.health > 0)
                {
                    Clear();
                    DisplayInfos();
                    Jimmy.Battle(currentGhost, 0, 23);
                    if (currentGhost.health <= 0)
                        break;

                    ReadKey(true);
                    Clear();

                    DisplayInfos();
                    currentGhost.Battle(Jimmy);
                    if (Jimmy.health <= 0)
                        break;

                    ReadKey(true);
                    Clear();

                    void DisplayInfos()
                    {
                        currentGhost.DisplayInfo(0, 0, 2, 0);
                        Jimmy.DisplayHealthBar();
                        Jimmy.DisplayStaminaBar();
                        WriteLine();
                        currentGhost.DisplayHealthBar();
                        WriteLine();
                    }
                }
                if (currentGhost.health <= 0)
                {
                    Clear();
                    WriteLine($"Jimmy has slain {currentGhost.name}!");
                    if (ghostCount > 0)
                    {
                        WriteLine("Another approaches!");
                        ghostCount -= 1;
                    }
                    ReadKey(true);
                }
                else
                {
                    Clear();
                    WriteLine("Jimmy died even with all that health generously given to him by his creator");
                    WriteLine("You will now exit the game");
                    ReadKey(true);
                    Environment.Exit(0);
                    break;
                }
            }
        }

        public void graveBattle()
        {
            //INTRO TO FIGHT HERE
            GraveDialog(WindowWidth/2 - 25, WindowHeight/2);

            while (true)
            {
                Clear();
                DisplayInfo();
                Jimmy.Battle(skeleton, 0, 42);
                if (skeleton.health <= 0)
                    break;

                ReadKey(true);
                Clear();

                DisplayInfo();
                skeleton.Battle(Jimmy);
                if (Jimmy.health <= 0)
                    break;

                ReadKey(true);
                Clear();

                void DisplayInfo()
                {
                    skeleton.DisplayInfo(0, 0, 2, 0);
                    Jimmy.DisplayHealthBar();
                    Jimmy.DisplayStaminaBar();
                    WriteLine();
                    skeleton.DisplayHealthBar();
                    WriteLine();
                }
            }
            if (skeleton.health <= 0)
            {
                Clear();
                WriteLine($"Jimmy has slain the skeleton of chill!");
                ReadKey(true);
            }
            else
            {
                Clear();
                WriteLine("Jimmy died. Those combos were vicious.");
                WriteLine("You will now exit the game");
                ReadKey(true);
                Environment.Exit(0);
            }
        }

        public int barnBattle()
        {
            //INTRO TO FIGHT HERE
            BarnDialog(70, 20);
            int returnInt = 0;

            bool exit = false;
            while (exit == false)
            {
                while (true)
                {
                    Clear();
                    DisplayInfo();
                    Jimmy.Battle(reaper, 0, 46);
                    if (reaper.health <= 0)
                        break;

                    ReadKey(true);
                    Clear();

                    DisplayInfo();
                    reaper.Battle(Jimmy);
                    if (Jimmy.health <= 0)
                        break;

                    ReadKey(true);
                    Clear();

                    void DisplayInfo()
                    {
                        reaper.DisplayInfo(0, 0, 1, 0);
                        Jimmy.DisplayHealthBar();
                        Jimmy.DisplayStaminaBar();
                        WriteLine();
                        reaper.DisplayHealthBar();
                        WriteLine();
                    }
                }
                if (reaper.health <= 0)
                {
                    Clear();
                    returnInt = 1;
                    alive = true;

                }
                else
                {
                    Clear();
                    returnInt = 2;
                    alive = false;
                }
                exit = true;
            }
            return returnInt;
        }

        public void ChurchDialog(int cursorX, int cursorY)
        {
            Clear();

            List<string> list = new List<string>();
            list.Add("Suddenly, the air gets cold...");
            list.Add("Shivering, the sword quivering in his hands");
            list.Add("Jimmy see's a faint outline moving towards him");
            list.Add("A plasmic entity shoots forward throwing a punch of vicious speed");
            list.Add("Barely dodging the attack, Jimmy counters...");

            for (int i = 0; i < list.Count; i++)
            {
                SetCursorPosition(cursorX, cursorY);
                foreach (char c in list[i])
                {
                    Write(c);
                    Thread.Sleep(10);
                }
                Thread.Sleep(3000);
                for (int j = list[i].Length - 1; j >= 0; j--)
                {
                    Write(" ");
                }
                Clear();
            }
        }
        public void GraveDialog(int cursorX, int cursorY)
        {
            Clear();

            List<string> list = new List<string>();
            list.Add("Walking into the graveyard, you see a skeleton boppin to some tunes...");
            list.Add("Jimmy approaches the skeleton cautiously. \"He look's chill\" Jimmy thinks to himself...");
            list.Add("\"Hey...\" ");
            list.Add("            ");
            list.Add("Before the words leave Jimmy's lips, the 'Chill Skeleton' without hesitation raises his sword and swings with incredible speed");
            list.Add("Evading the attacks, Jimmy is sliced in the arm...");
            list.Add("Blood boiling, Jimmy raises his sword to counter...");

            for (int i = 0; i < list.Count; i++)
            {
                SetCursorPosition(cursorX, cursorY);
                foreach (char c in list[i])
                {
                    Write(c);
                    Thread.Sleep(10);
                }
                Thread.Sleep(3000);
                for (int j = list[i].Length - 1; j >= 0; j--)
                {
                    Write(" ");
                }
                Clear();
            }
        }
        public void BarnDialog(int cursorX, int cursorY)
        {
            Clear();

            List<string> list = new List<string>();
            list.Add("Turning towards Jimmy, Nothing is behind the hood...");
            list.Add("\"I am Death\", says the creature");
            list.Add("\"Well, part time at least\" ");
            list.Add("            ");
            list.Add("\"You have met your end, Jimmy.\" Death raises his scythe, ready to smite");
            list.Add("\"Try me\", Jimmy says with false confidence...");
            list.Add("Jimmy charges with his attack...");

            for (int i = 0; i < list.Count; i++)
            {
                SetCursorPosition(cursorX, cursorY);
                foreach (char c in list[i])
                {
                    Write(c);
                    Thread.Sleep(10);
                }
                Thread.Sleep(3000);
                for (int j = list[i].Length - 1; j >= 0; j--)
                {
                    Write(" ");
                }
                Clear();
            }
        }

    }
}
