using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class FizzBuzzProgram
    {
        static void Main(string[] args)
        {
            for(int x=1; x < 100; x++)
            {
                if (x%15==0) { Console.Write(x + " = FizzBuzz\n"); Console.ReadKey(); }
                else if (x%3==0) { Console.Write(x + " = Fizz\n"); Console.ReadKey(); }
                else if (x%5==0) { Console.Write(x + " = Buzz\n"); Console.ReadKey(); }
                else { Console.Write(x+"\n"); Console.ReadKey(); }
            }
        }
    }
}
