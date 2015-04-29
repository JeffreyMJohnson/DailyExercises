using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * An international shipping company is trying to figure out how to manufacture various types of 

containers. Given a volume they want to figure out the dimensions of various shapes that would 

all hold the same volume.

Dimensions of containers of various types that would hold the volume. The following containers 

are possible.

● Cube -> V = a^3 -> a (edge) = V ^ 1/3

● Ball (Sphere) -> V = 4/3 pi r^3 -> r (radius) = (3 * V/4*pi)^1/3

● Cylinder -> V = pi r^2 H -> h (height) = V / pi * r^2 (radius)

● Cone -> V = pi r^2 H/3 -> h (height) = 3*(v/pi*r^2)
 */

namespace _4_27
{
    class Program
    {

        enum Container
        {
            Cube,
            Ball,
            Cylinder,
            Cone
        }

        static void Main(string[] args)
        {
            OutputMenu();
            ConsoleKeyInfo c = Console.ReadKey();

            double height = 0;
            double radius = 0;
            double volume = 0;

            if (c.Key == ConsoleKey.D0)
            {
                Console.WriteLine("\nCube");
                volume = GetVolume();
            }
            Console.ReadKey();
        }

        static double GetVolume()
        {
            Console.Write("Volume needed: ");
            return Double.Parse(Console.ReadLine());
        }

        static void OutputMenu()
        {
            Console.WriteLine("What type of container do you want to pack?");
            Console.WriteLine("0 - Cube");
            Console.WriteLine("1 - Ball (sphere)");
            Console.WriteLine("2 - Cylinder");
            Console.WriteLine("3 - Cone");
            Console.Write("->");
            
        }

        static void GetHeight(Container type, double volume, out double height, out double radius)
        {
            switch (type)
            {
                case Container.Cube:
                    height = Math.Pow(volume, 1 / 3);
                    radius = 0;
                    break;
                case Container.Ball:
                    radius = Math.Pow(3 * (volume / (4 * Math.PI)), 1 / 3);
                    height = 0;
                    break;
            }
            radius = 0;
            height = 0;
        }

        static double GetHeight(Container type, double volume, double radius)
        {
            switch (type)
            {
                case Container.Cylinder:
                    return volume / (Math.PI * Math.Pow(radius, 2));
                    break;
                case Container.Cone:
                    return 3 * (volume / (Math.PI * Math.Pow(radius, 2)));
            }
            return 0;
        }
    }
}
