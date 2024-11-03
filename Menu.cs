using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project
{
    internal class Menu
    {
        private int option;
        private bool isSelected;
        private string selectedTextColor;
        private string resetColor;
        private string backgroundColor;

        private int lastOption;
        private int firstOption;

        public Menu()
        {
            option = firstOption;
            isSelected = false;
            selectedTextColor = "\u001b[32m>>>     ";
            resetColor = "\u001b[37m";
        }

        public int IntroMenu(int cursorX = 0, int cursorY = 0)
        {
            Artwork art = new Artwork();
            List<string> optionList = new List<string>(); //Want to use the 'small' ASCII Font eventually
            optionList.Add("Start Game");
            optionList.Add("See Game Controls");
            optionList.Add("See Credits");
            optionList.Add("Exit Game");

            firstOption = 0;
            lastOption = optionList.Count;
            isSelected = false;

            //Draw Art
            art.DrawArt(art.worldArt["TitleArt"]);

            ConsoleKey key;

            while (isSelected == false)
            {
                for (int i = 0; i < lastOption; i++)
                {
                    SetCursorPosition(cursorX, cursorY + i);
                    WriteLine($"");
                }

                for (int i = 0; i < lastOption; i++)
                {
                    SetCursorPosition(cursorX, cursorY + i);
                    WriteLine($"{(option == i ? selectedTextColor : "        ")}{optionList[i]}{resetColor}");
                }

                ConsoleKeyInfo keyInfo = ReadKey();
                key = keyInfo.Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (option == firstOption)
                            option = lastOption;
                        else
                            option--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (option == lastOption)
                            option = firstOption;
                        else
                            option++;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            Thread.Sleep(500);
            art.Erase(art.worldArt["TitleArt"]);
            return option;
        }

        public int TownSquareMenu(int cursorX = 0, int cursorY = 0)
        {
            List<string> optionList = new List<string>(); //Want to use the 'small' ASCII Font eventually
            optionList.Add("Go to the graveyard");
            optionList.Add("Go to the the church");
            optionList.Add("Go to the corn maze");
            optionList.Add("Go to the barn");

            firstOption = 0;
            lastOption = optionList.Count;
            isSelected = false;

            ConsoleKey key;

            while (isSelected == false)
            {
                for (int i = 0; i < lastOption; i++)
                {
                    SetCursorPosition(cursorX, cursorY + i);
                    WriteLine($"");
                }

                for (int i = 0; i < lastOption; i++)
                {
                    SetCursorPosition(cursorX, cursorY + i);
                    WriteLine($"{(option == i ? selectedTextColor : "        ")}{optionList[i]}{resetColor}");
                }

                ConsoleKeyInfo keyInfo = ReadKey();
                key = keyInfo.Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (option == firstOption)
                            option = lastOption;
                        else
                            option--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (option == lastOption)
                            option = firstOption;
                        else
                            option++;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            return option;


        }

        public int BattleMenu(int cursorX = 0, int cursorY = 0)
        {
            List<string> optionList = new List<string>(); //Want to use the 'small' ASCII Font eventually
            optionList.Add("(70%) Basic Attack (0 stamina)");
            optionList.Add("(90%) Special Attack (3 stamina)");
            optionList.Add("Skip turn (gain +1 stamina");
            optionList.Add("Heal (heal 40 HP)");

            firstOption = 0;
            lastOption = optionList.Count;
            isSelected = false;

            ConsoleKey key;

            while (isSelected == false)
            {
                
                for (int i = 0; i < lastOption; i++)
                {
                    SetCursorPosition(cursorX, cursorY + i);
                    WriteLine($"");
                }

                for (int i = 0; i < lastOption; i++)
                {
                    SetCursorPosition(cursorX, cursorY + i);
                    WriteLine($"{(option == i ? selectedTextColor : "        ")}{optionList[i]}{resetColor}");
                }

                ConsoleKeyInfo keyInfo = ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (option == firstOption)
                            option = lastOption;
                        else
                            option--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (option == lastOption)
                            option = firstOption;
                        else
                            option++;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            return option;
        }
    }
}
