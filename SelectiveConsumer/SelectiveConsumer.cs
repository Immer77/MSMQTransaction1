using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SelectiveConsumer
{
    public class SelectiveConsumer
    {
        private MessageQueue inQueue;
        private int Id;

        public SelectiveConsumer(MessageQueue inQueue)
        {
            this.inQueue = inQueue;
            Id = 1337;

            inQueue.Formatter = new XmlMessageFormatter(new Type[]
                {typeof(Flight)});

            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
        }

        private void OnMessage(object source, ReceiveCompletedEventArgs asyncResult) 
        {
            Console.WriteLine("Noticication occured");
            MessageQueue messageQueue = (MessageQueue)source;
           
            Message message = messageQueue.Peek();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(message.Body.ToString());

            XmlElement root = doc.DocumentElement;
            XmlNode id = root.SelectSingleNode("id");


            messageQueue.BeginReceive();
        }
    }
}
