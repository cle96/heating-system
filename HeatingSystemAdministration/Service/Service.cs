using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeatingSystemAdministration.Storage;

namespace HeatingSystemAdministration.Service
{
    class Service
    {

        public static void InitStorage()
        {
            Customer c1 = new Customer() { Id = 1, Name="Cristian Leahu", Address="Fynsgade", Meters = new List<Model.Meter>() };
            Model.Meter m01 = new Model.Meter() { Id = 1,  Customer = c1, Readings = new List<Model.MeterReading>() };
            Model.MeterReading mr01 = new Model.MeterReading() { Id = 1, CubicMeter = 5.21, kWh = 553.2, UsageHours = 22, Year = new DateTime(2016, 1, 18) };
            Model.Meter m1 = new Model.Meter() { Id =2, Customer = c1, Readings = new List<Model.MeterReading>() };
            Model.MeterReading mr1 = new Model.MeterReading() { Id = 2, CubicMeter = 7.11, kWh = 451.2, UsageHours = 17, Year = new DateTime(2016, 1, 18) };

            Customer c2 = new Customer() { Id = 2, Name = "Benn", Address = "School", Meters = new List<Model.Meter>() };
            Model.Meter m2 = new Model.Meter() { Id = 3, Customer = c2, Readings = new List<Model.MeterReading>() };
            Model.MeterReading mr2 = new Model.MeterReading() { Id = 3, CubicMeter = 13.89, kWh = 221, UsageHours = 9, Year = new DateTime(2016, 1, 18) };

            Customer c3 = new Customer() { Id = 3, Name = "Donald Trump", Address = "White house", Meters = new List<Model.Meter>() };
            Model.Meter m3 = new Model.Meter() { Id = 4, Customer = c3, Readings = new List<Model.MeterReading>() };
            Model.MeterReading mr3 = new Model.MeterReading() { Id = 4, CubicMeter = 9.33, kWh = 114.5, UsageHours = 10, Year = new DateTime(2016, 1, 18) };

            Customer c4 = new Customer() { Id = 4, Name = "Hilary Clinton", Address = "No house", Meters = new List<Model.Meter>() };
            Model.Meter m4 = new Model.Meter() { Id = 5, Customer = c4, Readings = new List<Model.MeterReading>() };
            Model.MeterReading mr4 = new Model.MeterReading() { Id = 5, CubicMeter = 88.1, kWh = 1011.2, UsageHours = 12, Year = new DateTime(2016, 1, 18) };

            AddCustomer(c1); AddCustomer(c2); AddCustomer(c3); AddCustomer(c4);
            AddMeter(m1,c1); AddMeter(m01,c1); AddMeter(m2,c2); AddMeter(m3,c3); AddMeter(m4,c3);
            AddMeterReading(mr01, m1); AddMeterReading(mr1, m1); AddMeterReading(mr2, m2); AddMeterReading(mr3, m3); AddMeterReading(mr4, m4);
        }

        public static List<Customer> AddCustomer(Customer customer)
        {
            DatabaseDummy.customers.Add(customer);
            return DatabaseDummy.GetCustomers();
        }

        public static List<Model.Meter> AddMeter(Model.Meter meter,Customer customer)
        {
            DatabaseDummy.meters.Add(meter);
            customer.AddMeter(meter);

            return DatabaseDummy.GetMeters();
        }

        public static List<Model.MeterReading> AddMeterReading(Model.MeterReading meterReading, Model.Meter meter)
        {
            meter.AddMeterReading(meterReading);
            meterReading.Meter = meter;
            DatabaseDummy.metersReadings.Add(meterReading);

            return DatabaseDummy.GetMetersReadings();
        }
    }
}
