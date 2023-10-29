using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenConsumer
{
    internal class ListOfCheckedInPassengers
    {
        private List<Passenger> checkedInPassengers;

        public ListOfCheckedInPassengers()
        {
            checkedInPassengers = new List<Passenger>();
        }

        public void AddPassenger(Passenger passenger)
        {
            if(!checkedInPassengers.Contains(passenger)) 
            {
                checkedInPassengers.Add(passenger);
            }   
        }

        public List<Passenger> GetPassengers() 
        {
            List<Passenger> temp = new List<Passenger>();
            temp = checkedInPassengers;
            return temp;
        }
    }
}
