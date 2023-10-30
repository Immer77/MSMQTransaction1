using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectiveConsumer
{
    [Serializable]
    public class Flight
    {
        public int Id { get; set; }
        public string Company { get; set; }

        public Flight() { }
        public Flight(int id, string company)
        {
            Id = id;
            Company = company;
        }

        public override string ToString()
        {
            return $"Id: {Id} \n Company: {Company}";
        }
    }
}
