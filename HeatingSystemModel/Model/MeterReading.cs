using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemModel.Model
{
    public class MeterReading
    {
        public int Id { get; set; }
        public double kWh { get; set; }
        public double CubeMeters { get; set; }
        public double UsageHours { get; set; }
        public System.DateTime Year { get; set; }

        public virtual Meter Meter { get; set; }

        public Boolean isEnabled { get; set; }

        public bool CoolingIsSufficient()
        {
            double cooling = 0;
            if (CubeMeters != 0 && kWh != 0 && UsageHours != 0)
            {
                cooling = 0.86 * ((this.kWh - UsageHours) / CubeMeters);

                return cooling > 30;
            }
            return false;
        }

        public Double calculatePrice()
        {
            double price = 0;
            if (CubeMeters != 0 && kWh != 0 && UsageHours != 0)
            {
                price = kWh * 0.875;
            }
            return price;
        }

        public override string ToString()
        {
            String fullDescription = this.kWh + "kWh " + this.CubeMeters + "m^3 " + UsageHours + "hours for year: " + Year.Year;
            fullDescription += CoolingIsSufficient() ? " [Sufficient cooling]" : " [Insufficient cooling]";
            fullDescription += " Price: " + calculatePrice() + "kr.";
            return fullDescription;
        }
    }
}
