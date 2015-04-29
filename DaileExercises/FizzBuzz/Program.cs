using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Param: " + i + " outputs: " + FizzBuzz(i));
            }
            Console.Read();
        }

        private static string FizzBuzz(int param)
        {
            string result = "";
            if (param % 3 == 0)
            {
                result += "Fizz";
            }
            if (param % 5 == 0)
            {
                result += "Buzz";
            }
            return result;
        }
    }
}
