using Job.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    public class MyActivity:IJob
    {
        public MyActivity()
        {
                
        }

        public void Invoke()
        {
            Console.WriteLine("Queue at {0}",DateTime.Now);
        }
    }
}
