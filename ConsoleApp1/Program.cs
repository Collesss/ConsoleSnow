using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static private char[,] snow = new char[25, 80];
        static private Random random = new Random();

        static void Main(string[] args)
        {
            Console.WindowHeight = 25;
            Console.WindowWidth = 80;

            Console.Title = "SNOW";

            while (!Console.KeyAvailable || Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Move();
                GenerateFirstLineSnow();
                Show();
                Task.Delay(300).Wait();
                Console.Clear();
            }
        }


        static void GenerateFirstLineSnow()
        {
            for (int i = 0; i < snow.GetLength(1); i++)
                snow[0, i] = random.Next() % 12 <= 1 ? '*':' ';
        }

        static void Move()
        {
            void ClearLine(int line)
            {
                for (int i = 0; i < snow.GetLength(1); i++)
                    snow[line, i] = ' ';
            }


            ClearLine(snow.GetLength(0)-1);

            for (int i = snow.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < snow.GetLength(1); j++)
                {
                    if (snow[i, j] == '*')
                    {
                        int dx = j;

                        if (random.Next() % 10 <= 2)
                            dx++;
                        else if (random.Next() % 10 <= 2)
                            dx--;

                        if (dx < 0)
                            dx = 0;
                        else if (dx >= snow.GetLength(1))
                            dx = snow.GetLength(1) - 1;

                        snow[i + 1, dx] = '*';
                    }
                }

                ClearLine(i);
            }
        }

        static void Show()
        {
            for (int i = 0; i < snow.GetLength(0); i++)
            {
                for (int j = 0; j < snow.GetLength(1); j++)
                    Console.Write(snow[i, j]);

                if(i != snow.GetLength(0)-1)
                    Console.WriteLine();
            }
        }
    }
}
