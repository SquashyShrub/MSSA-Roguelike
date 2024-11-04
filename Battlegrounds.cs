﻿using MSSA_Roguelike___Mini_Project.Characters;
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
        private MusicThemes battleTheme = new MusicThemes();
        IntroOutro outro = new IntroOutro();

        Player Jimmy = new Player(0, 0, "Jimmy", 200, ConsoleColor.Cyan, 6);

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
            battleTheme.Play(battleTheme.churchBattle);
            ChurchDialog(70, 20);

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
                    outro.DisplayOutroDead();
                    Environment.Exit(0);
                    break;
                }
            }
            battleTheme.Play(battleTheme.churchTheme);
        }

        public void graveBattle()
        { 
            battleTheme.Play(battleTheme.graveBattle);
            GraveDialog(50, 20);

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
                battleTheme.Play(battleTheme.graveTheme);
                Clear();
                WriteLine($"Jimmy has slain the skeleton of chill!");
                ReadKey(true);
            }
            else
            {
                Clear();
                WriteLine("Jimmy died. Those combos were vicious.");
                outro.DisplayOutroDead();
                ReadKey(true);
                Environment.Exit(0);
            }
        }

        public int barnBattle()
        {
            battleTheme.Play(battleTheme.barnBattle);
            BarnDialog(70, 20);
            Thread.Sleep(3500);
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
                battleTheme.Play(battleTheme.barnTheme);
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
            list.Add("\"Hey...\" ");
            list.Add("Before the words leave Jimmy's lips, 'Chill Skeleton' without hesitation swings sword with incredible speed");
            list.Add("Jimmy finds an opening and attacks...");

            for (int i = 0; i < list.Count; i++)
            {
                SetCursorPosition(cursorX, cursorY);
                foreach (char c in list[i])
                {
                    Write(c);
                    Thread.Sleep(10);
                }
                Thread.Sleep(1800);
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
