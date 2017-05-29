using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemAdministration.Model
{
    class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Meter> Meters { get; set; }

        public List<Meter> AddMeter(Meter meter)
        {
            Meters.Add(meter);
            return Meters;
        }

        public List<Meter> Remove(Meter meter)
        {
            Meters.Remove(meter);
            return Meters;
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + Address;
        }

    }
}
