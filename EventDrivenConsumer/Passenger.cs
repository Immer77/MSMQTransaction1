using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenConsumer
{
    [Serializable]
    internal class Passenger
    {
        public string TicketNo { get; set; }
        public string Name { get; set; }
        public string FlightNo { get; set; }
        public string PassportNo { get; set; }

        public Passenger() { }
        public Passenger(string ticketNo, string name, string flightNo, string passportNo)
        {
            TicketNo = ticketNo;
            Name = name;
            FlightNo = flightNo;
            PassportNo = passportNo;
        }

        public override string ToString()
        {
            return $"Name: {Name} \n TicketNo: {TicketNo} \n FlightNo: {FlightNo} \n PassportNo; {PassportNo}";
        }
    }
}
