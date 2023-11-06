﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_Map
{
    internal class Program
    {
        
        static char[,] map = new char[,] // dimensions defined by following data:
    {
        {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
        {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
        {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
        {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','o','o','o','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','o','o','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','o','o','o','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','o','o','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
    };

        static void SetColorAndDrawConsole(char Character , ConsoleColor Color)
        {
            ConsoleColor colOriginal = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.Write(Character);
            Console.ForegroundColor = colOriginal;
        }

        static void SetColorAndDrawConsole(string szString, ConsoleColor Color)
        {
            ConsoleColor colOriginal = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.Write(szString);
            Console.ForegroundColor = colOriginal;
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("MiniGame");
            Console.WriteLine();

            Console.WriteLine("==================Scaled Map 1x1==================");
            Console.WriteLine();
            DisplayMap(1);
            Console.WriteLine();
            Console.WriteLine("==================================================");

            Console.WriteLine();

            Console.WriteLine("==================Scaled Map 2x2==================");
            Console.WriteLine();
            DisplayMap(2);
            Console.WriteLine();
            Console.WriteLine("==================================================");

            Console.WriteLine();

            Console.WriteLine("==================Scaled Map 3x3==================");
            Console.WriteLine();
            DisplayMap(3);
            Console.WriteLine();
            Console.WriteLine("==================================================");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }

        static void DisplayMap(int iScale = 1)
        {

            int iLegendPadding = 0;

            Console.Write("+"); // top left corner

            for (int iBorderChar = 0;iBorderChar < map.GetLength(1) * iScale; iBorderChar++)
                   Console.Write("-"); //top border

            Console.Write("+"); //top right corner

            Console.WriteLine(); // next line 

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int iCurrentScaleY = 0; iCurrentScaleY < iScale; iCurrentScaleY++)
                {
                    Console.Write("|");  // left border

                    for (int x = 0; x < map.GetLength(1); x++)
                    {
                        for (int iCurrentScaleX = 0; iCurrentScaleX < iScale; iCurrentScaleX++)
                        {
                            switch (map[y,x])
                            { 
                                case '^':  // mountains
                                    {
                                         SetColorAndDrawConsole(map[y, x], ConsoleColor.DarkGray);
                                    break;
                                }
                                case '~': // water
                                    {
                                        SetColorAndDrawConsole(map[y, x], ConsoleColor.Blue);
                                        break;
                                }
                                case '`':   // grass
                                    {
                                        SetColorAndDrawConsole(map[y, x], ConsoleColor.Green);
                                        break;
                                }
                                case '*':  // trees
                                    {
                                        SetColorAndDrawConsole(map[y, x], ConsoleColor.DarkGreen);
                                        break;
                                }
                                case 'o':   // lava
                                {
                                        SetColorAndDrawConsole(map[y, x], ConsoleColor.Red);
                                        break;
                                }
                                default:
                                {
                                    Console.Write(map[y, x]);
                                    break;
                                }

                            }

                        }

                    }

                    Console.Write("|");   //right border

                    if (iLegendPadding <= 6)
                    {
                        Console.Write("        ");

                        switch (iLegendPadding) 
                        {
                            case 0:
                            {
                                 Console.Write("=======LEGEND======");
                                 break;
                            }
                            case 1:
                            {
                                Console.Write("Mountains = ");
                                SetColorAndDrawConsole('^', ConsoleColor.DarkGray);
                                break;
                            }
                            case 2:
                            {
                                Console.Write("Water = ");
                                SetColorAndDrawConsole('~', ConsoleColor.Blue);
                                break;
                            }
                            case 3:
                            {
                                Console.Write("Grass = ");
                                SetColorAndDrawConsole('`', ConsoleColor.Green);
                                break;
                            }
                            case 4:
                            {
                                Console.Write("Trees = ");
                                SetColorAndDrawConsole('*', ConsoleColor.DarkGreen);
                                break;
                            }
                            case 5:
                            {
                                Console.Write("Lava = ");
                                SetColorAndDrawConsole('o', ConsoleColor.Red);
                                break;
                            }
                            case 6:
                            {
                                Console.Write("===================");
                                break;
                            }
                            default:
                            { 
                                break;
                            }


                       }

                        iLegendPadding += 1;
                    }

                    Console.WriteLine(); //\n for next line

                }
            }

            Console.Write("+"); // bottom left corner

            for (int iBorderChar = 0; iBorderChar < map.GetLength(1) * iScale; iBorderChar++)
                Console.Write("-"); //bottom border

            Console.Write("+"); // bottom right corner

            Console.WriteLine(); // finish map
        }
    }
}
