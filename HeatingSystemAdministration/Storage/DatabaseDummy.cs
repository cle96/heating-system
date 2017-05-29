using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemAdministration.Storage
{
   
    class DatabaseDummy
    {
        public static List<Customer> customers = new List<Customer>();
        public static List<Model.Meter> meters = new List<Model.Meter>();
        public static List<Model.MeterReading> metersReadings = new List<Model.MeterReading>();

        public static List<Customer> GetCustomers()
        {
            return customers;
        }

        public static List<Model.Meter> GetMeters()
        {
            return meters;
        }
        public static List<Model.MeterReading> GetMetersReadings()
        {
            return metersReadings;
        }
    }
}
