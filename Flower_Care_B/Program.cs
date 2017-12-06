using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Flower_Care_B
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Flower f = new Flower("palmtree", 0, 2, 11, 23, "0");
            Console.WriteLine(f.print());
            Flower g = new Flower("daisy", 1, 4, 12, 1, "0");
             Flower h = new Flower("rose", 2, 4, 11, 30, "1");
             Flower i = new Flower("cactus", 0, 1, 10, 22, "1");*/
            string fn = "flower2.txt";
            if (File.Exists(fn)){
                FlowerCare fc = new FlowerCare(fn, 12, 3);
                //Console.WriteLine(fc.print());
                string input = "";
                Console.Clear();
                do
                {
                    Console.Write("Choose an option (p=print, a=add, r=remove, e=edit, s=save, q=quit):");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "p": Console.WriteLine(fc.allFlowers()); break;
                        case "a": fc.addNewFlower(); //Console.WriteLine(fc.print()); 
                            break;
                        case "r":
                            fc.removeFlower(); //Console.WriteLine(fc.print());
                            break;
                        case "e":
                            fc.editFlower(); Console.WriteLine(fc.print());
                            break;
                        case "s": fc.safeToFile();  break;
                        case "q": Console.WriteLine("Program terminated!"); break;
                    }
                    Console.WriteLine();
                } while (input != "q");
            }
            else
            {
                Console.WriteLine("There are no flowers so far! Use of the program not possible!");
            }
            Console.WriteLine("\nThe End");
            Console.ReadKey();
        }
    }
}
