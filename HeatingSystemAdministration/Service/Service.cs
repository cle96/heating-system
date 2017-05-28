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
            Customer c1 = new Customer() { UniqueNumber = 1, Name="Cristian Leahu", Address="Fynsgade", Meters = new List<Model.Meter>() };
            Model.Meter m01 = new Model.Meter() { Number = "00001", Amount = "765743", Customer = c1, Year = new DateTime(2016, 1, 18) };
            Model.Meter m1 = new Model.Meter() { Number = "00002", Amount = "865743", Customer = c1, Year = new DateTime(2017, 1, 18) };
            c1.AddMeter(m1);
            c1.AddMeter(m01);

            Customer c2 = new Customer() { UniqueNumber = 2, Name = "Benn", Address = "School", Meters = new List<Model.Meter>() };
            Model.Meter m2 = new Model.Meter() { Number = "00003", Amount = "2324", Customer = c2, Year = new DateTime(2017, 1, 18) };
            c2.AddMeter(m2);

            Customer c3 = new Customer() { UniqueNumber = 3, Name = "Donald Trump", Address = "White house", Meters = new List<Model.Meter>() };
            Model.Meter m3 = new Model.Meter() { Number = "00004", Amount = "11983", Customer = c3, Year = new DateTime(2017, 1, 18) };
            c3.AddMeter(m3);

            Customer c4 = new Customer() { UniqueNumber = 4, Name = "Hilary Clinton", Address = "No house", Meters = new List<Model.Meter>() };
            Model.Meter m4 = new Model.Meter() { Number = "00005", Amount = "477296", Customer = c4, Year = new DateTime(2017, 1, 18) };
            c4.AddMeter(m4);

            AddCustomer(c1); AddCustomer(c2); AddCustomer(c3); AddCustomer(c4);
            AddMeter(m1); AddMeter(m01); AddMeter(m2); AddMeter(m3); AddMeter(m4);
        }

        public static List<Customer> AddCustomer(Customer customer)
        {
            DatabaseDummy.customers.Add(customer);
            return DatabaseDummy.GetCustomers();
        }

        public static List<Model.Meter> AddMeter(Model.Meter meter)
        {
            DatabaseDummy.meters.Add(meter);
            return DatabaseDummy.GetMeters();
        }
    }
}
