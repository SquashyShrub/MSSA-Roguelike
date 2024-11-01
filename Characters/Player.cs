using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Console;

namespace MSSA_Roguelike___Mini_Project.Characters
{
    internal class Player : Character
    {
        private ConsoleColor PlayerColor;
        private string PlayerMarker;
        private string PlayerReset;
        private Menu menu = new Menu();

        //Get player's X and Y position to draw
        public int X { get; set; }
        public int Y { get; set; }

        public Player(int startingX, int startingY, string name, int health, ConsoleColor color, int stamina)
            : base(name, health, "", color, stamina)
        {
            X = startingX;
            Y = startingY;

            PlayerColor = ConsoleColor.DarkCyan;
            PlayerMarker = "@";
        }

        public void DrawPlayer()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
            ResetColor();
        }

        public override void Battle(Character opponent)
        {
            switch (menu.BattleMenu(0, 22))
            { 
                case 0: //basic attack
                    int chance = RandGenerator.Next(1, 101);
                    if (chance <= 80)
                    {
                        Write($"{name} attempts 'Side Slash'! ");
                        int hit = RandGenerator.Next(1, 101);
                        Thread.Sleep(1000);
                        if (hit <= 70)
                        {
                            opponent.TakeDamage(BasicAttack());
                        }
                        else
                            WriteLine($"{name} wasn't even close with the swing!");
                    }
                    break;

                case 1: //special attack
                    WriteLine("Special Attack!");
                    break;

                case 2: //skip turn
                    WriteLine("Skip Turn!");
                    break;

                case 3: //heal
                    WriteLine("Healed 10 HP!");
                    break;
            }

            int BasicAttack()
            {
                int damage = RandGenerator.Next(10, 16);
                BackgroundColor = ConsoleColor.DarkGray;
                WriteLine($" {name} swings viciously for {damage} damage!");
                ResetColor();
                return damage;
            }
        }

        /* Handle player input for movement here? to avoid multiple times writing it like it is now - - > more readable aswell
        public void GetPlayerInput() 
        {
            //Gets the last input of the player to avoid trailing movement when no keys are being pressed
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;

            } while (KeyAvailable);

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (!GameHandler_Church.Colliding(Player_Church.X, Player_Church.Y - 1))
                    {
                        Player_Church.Y -= 1;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (!GameHandler_Church.Colliding(Player_Church.X, Player_Church.Y + 1))
                    {
                        Player_Church.Y += 1;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (!GameHandler_Church.Colliding(Player_Church.X - 1, Player_Church.Y))
                    {
                        Player_Church.X -= 1;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (!GameHandler_Church.Colliding(Player_Church.X + 1, Player_Church.Y))
                    {
                        Player_Church.X += 1;
                    }
                    break;
        } */



    }
}
