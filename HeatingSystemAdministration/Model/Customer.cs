using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemAdministration
{
    class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Model.Meter> Meters { get; set; }

        public List<Model.Meter> AddMeter(Model.Meter meter)
        {
            Meters.Add(meter);
            return Meters;
        }

        public List<Model.Meter> Remove(Model.Meter meter)
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
