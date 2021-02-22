using System;
using System.Collections.Generic;
using System.Linq;

namespace PreparationFor14._10
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = 0;
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }

                else if (command == "green")
                {
                    int currTime = greenLight;

                    while (currTime > 0 && cars.Count > 0)
                    {
                        string currCar = cars.Dequeue();
                        count++;
                        int carLenght = currCar.Length;

                        currTime -= carLenght;

                        if (currTime < 0)
                        {
                            int currWindow = freeWindow + (carLenght-Math.Abs(currTime));
                           
                            if (carLenght > currWindow)
                            {

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currCar} was hit at {currCar[currWindow]}.");
                                return;
                            }
                        }
                    }

                }


                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");

        }
    }
}
