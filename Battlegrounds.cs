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

        Player Jimmy = new Player(0, 0, "Jimmy", 200, ConsoleColor.Cyan, 6);

        Ghosts ghost1 = new Ghosts("Spooky Ghost", 51, "Ghosts", ConsoleColor.DarkGray);
        Ghosts ghost2 = new Ghosts("That one guy that died", 45, "Ghosts", ConsoleColor.Gray);
        Ghosts ghost3 = new Ghosts("Unusually buff ghost", 63, "Ghosts", ConsoleColor.DarkGray);
        Ghosts currentGhost;
        List<Ghosts> ghosts = new List<Ghosts>();
        
        Skeleton skeleton = new Skeleton("Chill Skeleton", 124, "Skeleton", ConsoleColor.Red);

        Reaper reaper = new Reaper("Part Time Death", 250, "Reaper", ConsoleColor.DarkRed);

        public Battlegrounds()
        {
            //Add Ghosts
            ghosts.Add(ghost3);
            ghosts.Add(ghost2);
            ghosts.Add(ghost1);
        }

        public void churchBattle()
        {
            int ghostCount = 3;
            while ( ghostCount > 0)
            {
                Ghosts currentGhost = ghosts[ghostCount - 1];
                while (currentGhost.health > 0 && Jimmy.health > 0)
                {
                    Clear();
                    DisplayInfos();
                    Jimmy.Battle(currentGhost, 0, 22);
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
                        currentGhost.DisplayInfo();
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
                    WriteLine($"Jimmy has slain {currentGhost}!");
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
            while (true)
            {
                Clear();
                DisplayInfo();
                Jimmy.Battle(skeleton, 0, 40);
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
                    skeleton.DisplayInfo();
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

        public void barnBattle()
        {
            while (true)
            {
                while (true)
                {
                    Clear();
                    DisplayInfo();
                    Jimmy.Battle(reaper, 0, 44);
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
                        reaper.DisplayInfo();
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
                    WriteLine($"Jimmy has slain death!");
                    WriteLine("...\nYou were not supposed to defeat death...");
                    ReadKey(true);
                }
                else
                {
                    Clear();
                    WriteLine("You thought you could beat death? No one beats death.");
                    WriteLine("You will now exit the game");
                    ReadKey(true);
                    Environment.Exit(0);
                }
            }
        }

    }
}
