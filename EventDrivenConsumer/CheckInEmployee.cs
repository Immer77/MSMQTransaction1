using System;
using System.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Threading;

namespace EventDrivenConsumer
{
    internal class CheckInEmployee
    {
        private MessageQueue TicketQueue;
        private ListOfCheckedInPassengers CheckedInPassengers;
        public CheckInEmployee(MessageQueue ticketQueue)
        {
            TicketQueue = ticketQueue;
            CheckedInPassengers = new ListOfCheckedInPassengers();

            TicketQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            TicketQueue.BeginReceive();
           
        }

        private void OnMessage(object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(message.Body.ToString());

            XmlElement root = doc.DocumentElement;
            XmlNodeList passengers = root.SelectNodes("Passenger");

            foreach(XmlNode passenger in passengers)
            {
                string name = passenger.SelectSingleNode("Name").InnerText;
                string ticketNo = passenger.SelectSingleNode("TicketNo").InnerText;
                string passportNo = passenger.SelectSingleNode("PassportNo").InnerText;
                string flightNo = passenger.SelectSingleNode("FlightNo").InnerText;
                Passenger PassengerToCheckIn = new Passenger(ticketNo, name, flightNo, passportNo);
                Predicate<Passenger> validate = pass =>
                {
                    string fno = pass.FlightNo;

                    // Check if the flightNo matches the specified format (e.g., AA1234).
                    // You can modify this regular expression to match your specific format.
                    string pattern = @"^[A-Z]{2}\d{4}$";

                    return System.Text.RegularExpressions.Regex.IsMatch(flightNo, pattern);
                };

                CheckInPassenger(PassengerToCheckIn, validate);
                Console.WriteLine(PassengerToCheckIn.ToString());
                Thread.Sleep(4000);
            }
            mq.BeginReceive();
        }

        public void CheckInPassenger(Passenger passenger, Predicate<Passenger> validate) 
        {
            if(validate(passenger))
            {
                CheckedInPassengers.AddPassenger(passenger);
            }
        }
    }
}
