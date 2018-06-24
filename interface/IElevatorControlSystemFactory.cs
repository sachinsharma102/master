using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram
{
   public interface IElevatorControlSystemFactory
    {
          void Step(int floor);
    }
}
