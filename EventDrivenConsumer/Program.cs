using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EventDrivenConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageQueue ticketQueue = new MessageQueue(@".\private$\tickets");
            CheckInEmployee Employee = new CheckInEmployee(ticketQueue);

            XElement CheckInFile = XElement.Load(@"ListOfCheckedInPassengers.xml");

            ticketQueue.Send(CheckInFile.ToString());


            Console.ReadLine();

        }
    }
}
