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

        public override void Battle(Character opponent, int menuX, int menuY)
        {
            switch (menu.BattleMenu(menuX, menuY))
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
                    if (stamina < 6)
                        stamina++;
                    break;

                case 1: //special attack
                    chance = RandGenerator.Next(1, 101);
                    if (chance <= 90)
                    {
                        Write($"{name} attempts 'Absolute Demolisher'! ");
                        int hit = RandGenerator.Next(1, 101);
                        Thread.Sleep(1000);
                        if (stamina >= 3)
                        {
                            if (hit <= 90)
                            {
                                stamina -= 3;
                                opponent.TakeDamage(SpecialAttack());
                            }
                            else
                            {
                                health -= 15;
                                stamina -= 3;
                                WriteLine($"{name}... How did you miss that? {name} loses 15 HP!");
                            } 
                        }
                        else
                        {
                            WriteLine("You do not have enough stamina for that! You took too long and forfeit the turn!");
                        }
                    }
                    if (stamina < 6)
                        stamina++;
                    break;

                case 2: //skip turn
                    if (stamina < 5)
                        stamina += 2;
                    else if (stamina < 6)
                        stamina++;
                    WriteLine($"{name} skips a turn and gains +1 stamina!");
                    break;

                case 3: //heal
                    health += 40;
                    if (health >= maxHealth)
                        health = maxHealth;
                    WriteLine($"{name} has healed 40 HP and forfeits the turn!");
                    break;
            }

            int BasicAttack()
            {
                int damage = RandGenerator.Next(9, 16);
                BackgroundColor = ConsoleColor.DarkGray;
                WriteLine($" {name} swings viciously for {damage} damage!");
                ResetColor();
                return damage;
            }
            int SpecialAttack()
            {
                int damage = RandGenerator.Next(20, 34);
                BackgroundColor = ConsoleColor.DarkRed;
                WriteLine($" {name} takes a mighty swing for {damage} damage!");
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
