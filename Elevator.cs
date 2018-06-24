using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorProgram.enums;

namespace ElevatorProgram
{
    public abstract class Elevator
    {
        //Defaults and Declarations
      
      
        private ElevatorDirection _status;

        private void Stop(int floor, Dictionary<int, bool> _floorReady, ref int _currentLevel)
        {
            _status = ElevatorDirection.ELEVATOR_HOLD;
            _currentLevel = floor;
            _floorReady[floor] = false;
            Console.WriteLine("Stopped at floor {0}", floor);
        }

        public void Descend(int floor, int _lowerLevel, Dictionary<int, bool> _floorReady, ref int _currentLevel)
        {
            for (int i = _currentLevel-1; i >= _lowerLevel; i--)
            {
                if (_floorReady[i])
                {
                    Stop(floor,_floorReady,ref _currentLevel);
                    break;
                }

                Console.WriteLine("Going Down - Floor {0}",
                    i);
            }

            _status = ElevatorDirection.ELEVATOR_HOLD;
            Console.WriteLine("Waiting..");
        }

        public void Ascend(int floor, int _upperLevel, Dictionary<int, bool> _floorReady, ref int _currentLevel)
        {
            for (int i = _currentLevel+1; i <= _upperLevel; i++)
            {
                if (_floorReady[i])
                {
                    Stop(floor,_floorReady,ref _currentLevel);
                    break;
                }
                Console.WriteLine("Going Up - Floor {0}",
                    i);
            }

            _status = ElevatorDirection.ELEVATOR_HOLD;
            Console.WriteLine("Waiting..");
        }

       public void StayPut()
        {
            Console.WriteLine("That's our current floor");
        }

    
      
    }

    public class PassengerElevator : Elevator
    {
        public PassengerElevator()
        {
            Console.WriteLine("Passenger Elevator");
        }

    }

}
