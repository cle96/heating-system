using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemAdministration.Model
{
    class MeterReading
    {
        public int Id { get; set; }
        public double kWh { get; set; }
        public double CubicMeter { get; set; }
        public double UsageHours { get; set; }

        public DateTime Year { get; set; }

        public Meter Meter { get; set; }

        public override string ToString()
        {
            return this.kWh + "kWh " + this.CubicMeter + "m^3 " + UsageHours + "hours for year: " +Year;
        }
    }
}
