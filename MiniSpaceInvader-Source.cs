using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MiniSpaceInvader
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomSeed = new Random();

            // Set the window properly
            int width = 35;
            int height = 30;
            byte points = 0;

            Console.CursorVisible = false;

            Console.SetWindowSize(width, height);

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            // Spaceship initial placement
            char spaceShip = '^';
            int rowOfSpaceShip = Console.WindowHeight - 1;
            int colOfSpaceShip = 0;
            int minRowOfEnemy = 0;
            int maxRowOfEnemy = width / 2;
            int minColOfEnemy = 0;
            int maxColOfEnemy = width;

            char spaceShipProjectile = '|';

            // Enemy initial placement
            char enemy = '*';
            int rowOfEnemy = randomSeed.Next(minRowOfEnemy, maxRowOfEnemy);
            int colOfEnemy = randomSeed.Next(minColOfEnemy, maxColOfEnemy);

            while (rowOfEnemy == 0 && colOfEnemy == 0)
            {
                rowOfEnemy = randomSeed.Next(minRowOfEnemy, maxRowOfEnemy);
                colOfEnemy = randomSeed.Next(minColOfEnemy, maxColOfEnemy);
            }

            // Game start
            Console.SetCursorPosition(colOfEnemy, rowOfEnemy);
            Console.Write(enemy);

            Console.SetCursorPosition(colOfSpaceShip, rowOfSpaceShip);
            Console.Write(spaceShip);

            Console.SetCursorPosition(0, 0);
            Console.Write(points);

            // Read user input & check for invalid input
            while (true)
            {
                ConsoleKeyInfo currentPressedKey = Console.ReadKey();

                if (currentPressedKey.Key == ConsoleKey.LeftArrow && colOfSpaceShip > 0)
                {
                    colOfSpaceShip--;
                }
                else if (currentPressedKey.Key == ConsoleKey.RightArrow && colOfSpaceShip <= Console.WindowWidth - 2)
                {
                    colOfSpaceShip++;
                }
                else if (currentPressedKey.Key == ConsoleKey.Spacebar)
                {
                    int rowOfProjectile = rowOfSpaceShip;
                    int colOfProjectile = colOfSpaceShip;
                    // Shoot the enemy
                    while (rowOfProjectile > 0)
                    {
                        Console.Clear();
                        rowOfProjectile--;

                        Console.SetCursorPosition(0, 0);
                        Console.Write(points);


                        Console.SetCursorPosition(colOfProjectile, rowOfProjectile);
                        Console.Write(spaceShipProjectile);

                        Console.SetCursorPosition(colOfSpaceShip, rowOfSpaceShip);
                        Console.Write(spaceShip);

                        Console.SetCursorPosition(colOfEnemy, rowOfEnemy);
                        Console.Write(enemy);

                        Thread.Sleep(50);

                        if (colOfProjectile == colOfEnemy && rowOfProjectile == rowOfEnemy)
                        {
                            rowOfEnemy = randomSeed.Next(minRowOfEnemy, maxRowOfEnemy);
                            colOfEnemy = randomSeed.Next(minColOfEnemy, maxColOfEnemy);
                            points++;
                            if (points == 10)
                            {
                                Console.Clear();
                                Console.WriteLine("YOU WON!");
                                Console.WriteLine("---Press any key to exit---");
                                Console.ReadKey();
                                return;
                            }
                            break;                            
                        }
                        if (rowOfProjectile == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("YOU LOST!");
                            Console.WriteLine("YOUR POINTS: {0}", points);
                            Console.WriteLine("---Press any key to exit---");
                            Console.ReadKey();
                            return;
                        }
                    }
                }

                // Refresh console and print the positions
                Console.Clear();
                Console.SetCursorPosition(colOfSpaceShip, rowOfSpaceShip);
                Console.Write(spaceShip);

                Console.SetCursorPosition(colOfEnemy, rowOfEnemy);
                Console.Write(enemy);

                Console.SetCursorPosition(0, 0);
                Console.Write(points);
            }
        }
    }
}

