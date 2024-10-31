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

        Ghosts ghost1 = new Ghosts("Spooky Ghost", 50, "Ghosts", ConsoleColor.DarkGray);
        Ghosts ghost2 = new Ghosts("That one guy that died", 60, "Ghosts", ConsoleColor.Gray);
        Ghosts ghost3 = new Ghosts("Unusually buff ghost", 45, "Ghosts", ConsoleColor.DarkGray);
        Ghosts currentGhost;
        List<Ghosts> ghosts = new List<Ghosts>();
        
        Skeleton skeleton = new Skeleton("Chill Skeleton", 200, "Skeleton", ConsoleColor.Red);

        Reaper reaper = new Reaper("Only Part Death, Mom's side...", 250, "Reaper", ConsoleColor.DarkRed);

        
        public Battlegrounds()
        {
            randGenerator = new Random();

            //Add Ghosts
            ghosts.Add(ghost1);
            ghosts.Add(ghost2);
            ghosts.Add(ghost3);
        }

        public void churchBattle()
        {
            int i = 0;
            while ( i <= 3)
            {
                Ghosts currentGhost = ghosts[i];
                while (currentGhost.health > 0 && Jimmy.health > 0)
                {
                    currentGhost.DisplayInfo();

                    Jimmy.DisplayHealthBar();
                    Jimmy.DisplayStaminaBar();
                    WriteLine();
                    currentGhost.DisplayHealthBar();
                    WriteLine();
                    ReadKey();

                    Jimmy.Battle(currentGhost);
                    ReadKey();
                    currentGhost.Battle(Jimmy);
                    ReadKey();


                    Clear();
                }
                if (currentGhost.health <= 0)
                {
                    WriteLine($"Jimmy has slain the enemy!");
                    i++;
                }
                else
                {
                    WriteLine("Jimmy died even with all that health generously given to him by his creator");
                    break;
                }
            }
            
            

            //Loop this
            //show health bars, so player can make informed decisions
            //Player gets first attack and show the results
            //Reshow the health bars
            //Check if player or enemy is dead -> break loop if so
            //Let the enemy attack player and show results
        }

        /*
        public void graveBattle()
        {
            while (true)
            {
                skeleton.DisplayInfo(125, 97, 2, 90);
                ReadKey();

                skeleton.HighSlash();
                ReadKey();

                skeleton.QuickCombo();
                ReadKey();

                Clear();
            }
        } 

        public void barnBattle()
        {
            while (true)
            {
                reaper.DisplayInfo(125, 97, 2, 90);
                ReadKey();

                reaper.ScytheSlash();
                ReadKey();

                reaper.SuperSlash();
                ReadKey();

                reaper.Heal();
                ReadKey();

                Clear();
            }
        } */ //Other battles

    }
}
