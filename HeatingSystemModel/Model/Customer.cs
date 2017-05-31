using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemModel.Model
{
    public class Customer
    {
        public Customer()
        {
            this.Meters = new HashSet<Meter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Meter> Meters { get; set; }
    }
}
