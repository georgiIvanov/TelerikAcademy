using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] oPos = new int[4];//0to1 - position, 2-3 - other status
        string[,] screen = new string[25, 55];
        int[,] projectiles = new int[25, 55];
        int difficulty = 420;

        //fills screen with space
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 55; j++)
            {
                screen[i, j] = " ";

            }

        }

        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 55; j++)
            {

                projectiles[i, j] = 0;

            }
        }

        oPos[0] = 24;//i
        oPos[1] = 22;//j
        Stopwatch highScoreSw = new Stopwatch();
        Stopwatch diffSw = new Stopwatch();
        diffSw.Start();
        highScoreSw.Start();
        while (true)
        {
            if (diffSw.Elapsed.Seconds.CompareTo(5) == 1 && difficulty != 20
                && diffSw.Elapsed.Seconds < 35)
            {
                difficulty -= 50;
                diffSw.Restart();
            }
            Console.Clear();

            GetInput(oPos);
            ProjMovementAndCreation(projectiles, difficulty);
            DrawScreen(screen, projectiles, oPos, highScoreSw);
            CollisionDetection(projectiles, oPos, ref difficulty);

            Thread.Sleep(100);
        }


    }
    static void CollisionDetection(int[,] projectiles, int[] oPos, ref int difficulty)
    {
        for (int j = 0; j < 55; j++)
        {
            if (projectiles[24, j] == 1 && oPos[0] == 24 && oPos[1] == j)
            {
                oPos[2] = 1;
                difficulty = 400;
            }

        }
    }

    static void ProjMovementAndCreation(int[,] projectiles, int difficulty)
    {
        for (int i = 24; i >= 0; i--)
        {
            for (int j = 0; j < 55; j++)
            {
                if (i == 24) projectiles[i, j] = 0;

                if (projectiles[i, j] == 1)
                {
                    projectiles[i, j] = 0;
                    projectiles[i + 1, j] = 1;
                }

            }
        }

        Random rand = new Random();

        for (int j = 0; j < 55; j++)
        {
            if (rand.Next(0, difficulty) < 15)
            {
                projectiles[0, rand.Next(0, 55)] = 1;
            }
        }
    }

    static void GetInput(int[] oPos)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(false);

            if (key.Key == ConsoleKey.LeftArrow)
            {
                oPos[1] -= 1;
                if (oPos[1] <= 0)
                {
                    oPos[1] = 0;
                }
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                oPos[1] += 1;
                if (oPos[1] >= 54)
                {
                    oPos[1] = 54;
                }
            }
        }
    }

    static void DrawScreen(string[,] screen, int[,] projectiles, int[] oPos, Stopwatch sw)
    {

        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 55; j++)
            {
                if (oPos[0] == i && oPos[1] == j)
                {
                    if (oPos[2] == 1)
                    {
                        Console.WriteLine("X");
                        sw.Stop();
                        Console.Write("Your time: {0}", sw.Elapsed);
                        Thread.Sleep(5000);
                        Console.Clear();
                        sw.Restart();
                        oPos[2] = 0;
                        WipeProjectiles(projectiles);
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                else if (projectiles[i, j] == 1)
                {
                    Console.Write(RandomProjectile());
                }
                else
                    Console.Write(screen[i, j]);

            }
            if (oPos[0] == i)
            {

            }
            else
            {
                Console.WriteLine();
            }
        }
    }

    static void WipeProjectiles(int[,] projectiles)
    {
        for (int i = 24; i >= 0; i--)
        {
            for (int j = 0; j < 55; j++)
            {
                projectiles[i, j] = 0;
            }
        }
    }

    static string RandomProjectile()
    {
        char[] Projectiles = {'@', '!', '#', '$', '%', '^', '&', '*', '.', ';' };
        Random rd = new Random();
        return Projectiles[rd.Next(0, 10)].ToString();

    }
}