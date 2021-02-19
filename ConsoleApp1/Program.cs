using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "  * * * * * * * * * * * *  ";

            Console.WindowWidth = 25;

            bool toRight = true;

            int pos = 0;

            while (true)
            {

                Console.WriteLine(str.Substring(1+pos, 25));

                Task.Delay(1000).Wait();

                if (toRight)
                    pos++;
                else
                    pos--;

                if (Math.Abs(pos) > 1)
                {
                    pos = 0;
                    toRight = !toRight;
                }
            }
        }
    }
}
