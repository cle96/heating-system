using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemAdministration.Model
{
    class Meter
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public List<MeterReading> Readings { get; set; }


        public override string ToString()
        {
            return Id.ToString();
        }

        public List<MeterReading> AddMeterReading(MeterReading mr)
        {
            Readings.Add(mr);
            return Readings;
        }

        public List<MeterReading> RemoveMeterReading(MeterReading mr)
        {
            Readings.Remove(mr);
            return Readings;
        }
    }
}
