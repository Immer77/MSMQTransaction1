using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SelectiveConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageQueue flightQueue = new MessageQueue(@".\private$\flights");
  

            flightQueue.Send("Hej1");
            flightQueue.Send("Hej2");
            flightQueue.Send("Hej3");

            Cursor cursor = flightQueue.CreateCursor();
            PeekAction action = PeekAction.Current;
            while (true)
            {
                Message msg = flightQueue.Peek(new TimeSpan(20,20,20),cursor,action);
                if (msg.Body.ToString().Equals("Hej2"))
                {
                    Console.WriteLine("Found Message2");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    action = PeekAction.Next;
                }
                
            }

            
        }
    }
}
