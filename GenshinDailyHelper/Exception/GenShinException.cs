using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinDailyCheckIn.Exception
{
    public class GenShinException : System.Exception
    {
        public GenShinException(string message) : base(message)
        {

        }
    }
}
