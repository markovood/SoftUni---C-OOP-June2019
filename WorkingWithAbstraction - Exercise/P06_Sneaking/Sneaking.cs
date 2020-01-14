﻿using System;

namespace P06_Sneaking
{
    public class Sneaking
    {
        private static char[][] room;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            InitializeRoom(n);

            var moves = Console.ReadLine().ToCharArray();
            int[] samPosition = GetSamPosition();
            

            for (int i = 0; i < moves.Length; i++)
            {
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        if (room[row][col] == 'b')
                        {
                            if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                            {
                                room[row][col] = '.';
                                room[row][col + 1] = 'b';
                                col++;
                            }
                            else
                            {
                                room[row][col] = 'd';
                            }
                        }
                        else if (room[row][col] == 'd')
                        {
                            if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                            {
                                room[row][col] = '.';
                                room[row][col - 1] = 'd';
                            }
                            else
                            {
                                room[row][col] = 'b';
                            }
                        }
                    }
                }

                int[] enemyPosition = GetEnemy(samPosition);                

                if (samPosition[1] < enemyPosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'd' && enemyPosition[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    PrintRoom();
                    Environment.Exit(0);
                }
                else if (enemyPosition[1] < samPosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'b' && enemyPosition[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    PrintRoom();
                    Environment.Exit(0);
                }

                room[samPosition[0]][samPosition[1]] = '.';
                switch (moves[i])
                {
                    case 'U':
                        samPosition[0]--;
                        break;
                    case 'D':
                        samPosition[0]++;
                        break;
                    case 'L':
                        samPosition[1]--;
                        break;
                    case 'R':
                        samPosition[1]++;
                        break;
                }

                room[samPosition[0]][samPosition[1]] = 'S';

                enemyPosition = GetEnemy(samPosition);

                if (room[enemyPosition[0]][enemyPosition[1]] == 'N' && samPosition[0] == enemyPosition[0])
                {
                    room[enemyPosition[0]][enemyPosition[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintRoom();
                    Environment.Exit(0);
                }
            }
        }

        private static int[] GetEnemy(int[] position)
        {
            for (int j = 0; j < room[position[0]].Length; j++)
            {
                if (room[position[0]][j] != '.' && room[position[0]][j] != 'S')
                {
                    return new int[] { position[0], j };
                }
            }

            return new int[2];
        }

        private static int[] GetSamPosition()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            throw new ApplicationException("Sam was not found in the room");
        }

        private static void InitializeRoom(int n)
        {
            room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }

        private static void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
