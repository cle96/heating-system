using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemModel.Model
{
    public class Meter
    {
        public Meter()
        {
            this.MeterReadings = new HashSet<MeterReading>();
        }

        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<MeterReading> MeterReadings { get; set; }
    }
}
