using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchLogic;

namespace EventsProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Timers();
            var phone = new Phone();
            phone.Register(obj);
            var microwave = new Microwave();
            microwave.Register(obj);
            obj.Start(5," Time is over");
           
            obj.Start(6,"second out");
            
            Console.ReadKey();

        }

    }
}
