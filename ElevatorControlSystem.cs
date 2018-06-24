using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorProgram.enums;

namespace ElevatorProgram
{
    public class ElevatorControlSystem : IElevatorControlSystemFactory
    {
        private readonly Dictionary<int, bool> _floorReady = new Dictionary<int, bool>();
        private int _currentLevel = 0;
        private readonly int _upperLevel;
        private readonly int _lowerLevel;
        private ElevatorDirection _status = ElevatorDirection.ELEVATOR_HOLD;
        private Elevator _elevator;
       private ElevatorFactory objelevatorFactory = new ElevatorFactory();

       public ElevatorControlSystem(ElevatorType elevatorType, int lowerLevel = 0, int upperLevel = 5)
        {
            _upperLevel = upperLevel;
            _lowerLevel = lowerLevel;
            CalculateFloor(lowerLevel,upperLevel);
            _elevator = objelevatorFactory.CreateandReturnObj(elevatorType);                 
        }

        private void CalculateFloor(int lowerLevel, int upperLevel)
        {
            for (int i = lowerLevel; i <= upperLevel; i++)
            {
                _floorReady.Add(i, false);
            }

        }

        public void Step(int floor)
        {
            if (floor > _upperLevel)
            {
                Console.WriteLine("We only have {0} floors", _upperLevel);
                return;
            }

            if (floor < _lowerLevel)
            {
                Console.WriteLine("We only have {0} level", _lowerLevel);
                return;
            }
            _floorReady[floor] = true;

            switch (_status)
            {

                case ElevatorDirection.ELEVATOR_DOWN:
                    _elevator.Descend(floor, _lowerLevel, _floorReady, ref _currentLevel);
                    break;

                case ElevatorDirection.ELEVATOR_HOLD:
                    if (_currentLevel < floor)
                        _elevator.Ascend(floor, _upperLevel, _floorReady, ref _currentLevel);
                    else if (_currentLevel == floor)
                        _elevator.StayPut();
                    else
                        _elevator.Descend(floor, _lowerLevel, _floorReady, ref _currentLevel);
                   
                    break;

                case ElevatorDirection.ELEVATOR_UP:
                    _elevator.Ascend(floor, _upperLevel, _floorReady, ref _currentLevel);
                    break;
            }


        }

    }
}
