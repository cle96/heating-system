using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemAdministration.Model
{
    class Meter
    {
        public string Number { get; set; }

        public string Amount { get; set; }

        public Customer Customer { get; set; }

        public DateTime Year { get; set; }

        public override string ToString()
        {
            return this.Amount+ " for year: " + this.Year;
        }
    }
}
