using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Xml.Linq;

namespace MSMQTransaction1
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueueTransaction msgTx = new MessageQueueTransaction();
            MessageQueue msgQ = new MessageQueue(@".\private$\Orders");
            XElement CheckInFile = XElement.Load(@"CheckedInPassenger.xml");

            MessageQueue luggageQueue = new MessageQueue(@".\Private$\luggagehandling");
            MessageQueue personQueue = new MessageQueue(@".\Private$\personqueue");
            CheckInSplitter splitter = new CheckInSplitter(msgQ, luggageQueue, personQueue);

            msgQ.Send(CheckInFile.ToString(), "SAS");
            /*
            msgTx.Begin();

            try
            {
                msgQ.Send(CheckInFile.ToString(), msgTx);
                //Environment.Exit(1);
                //msgQ.Send("Second Message", msgTx);
                msgTx.Commit();
            }
            catch
            {
                msgTx.Abort();
            }
            finally
            {
                msgQ.Close();
            }
            */
            Console.ReadLine();
        }
    }
}
