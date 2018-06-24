using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorProgram.enums;

namespace ElevatorProgram
{
   public class ElevatorFactory
    {

       public Elevator CreateandReturnObj(ElevatorType _eletype)
            {
                Elevator ObjSelector = null;

                switch ((int)_eletype)
                {
                    case 1:
                        ObjSelector = new PassengerElevator();
                        break;                  
                    default:
                        ObjSelector = new PassengerElevator();
                        break;
                }
                return ObjSelector;

            }
        
    }
}
