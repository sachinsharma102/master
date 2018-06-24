using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElevatorProgram.enums;

namespace ElevatorProgram
{
    class Program
    {
        private const string Quit = "q";
        static void Main(string[] args)
        {
            IElevatorControlSystemFactory elevator = new ElevatorControlSystem(ElevatorType.PassengerElevator);
          
            var input = string.Empty;

            while (input != Quit)
            {
                Console.WriteLine("Please press which floor you would like to go to");
                input = Console.ReadLine();
                int floor;
                if (int.TryParse(input, out floor))
                    elevator.Step(floor);
                else if (input == Quit)
                    Console.WriteLine("GoodBye!");
                else
                    Console.WriteLine("You have pressed an incorrect floor, Please try again");
            }
        }
    }
}
