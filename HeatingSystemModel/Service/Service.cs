using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HeatingSystemModel.Model;
using HeatingSystemModel.Storage;
using System.Data.Entity.Migrations;

namespace HeatingSystemAdministration.Service
{
    public class Service
    {
        
        public static void InitStorage()
        {
            using (var db = new StorageContext())
            {
                
                db.Database.Delete();
                db.Set<Customer>();
                db.Set<Meter>();
                db.Set<MeterReading>();

                db.SaveChanges();
            }
          
            Customer c1 = new Customer() { Id = 1, Name = "Cristian Leahu", Address = "Fynsgade", Meters= new List<Meter>()};
            Customer c2 = new Customer() { Id = 2, Name = "Benn", Address = "School", Meters = new List<Meter>() }; 
            Customer c3 = new Customer() { Id = 3, Name = "Donald Trump", Address = "White house", Meters = new List<Meter>() };
            Customer c4 = new Customer() { Id = 4, Name = "Hilary Clinton", Address = "No house", Meters = new List<Meter>() };

            Meter m01 = new Meter() { Id = 1,  Customer = c1, MeterReadings = new List<MeterReading>() };
            MeterReading mr01 = new MeterReading() { Id = 1, CubeMeters = 5.21, kWh = 553.2, UsageHours = 22, Year = new DateTime(2016, 1, 18), Meter=m01 };

            Meter m1 = new Meter() { Id =2, Customer = c1, MeterReadings = new List<MeterReading>() };
            MeterReading mr1 = new MeterReading() { Id = 2, CubeMeters = 73.21, kWh = 433.7, UsageHours = 17, Year = new DateTime(2017, 1, 18),Meter= m1 };
         
            Meter m2 = new Meter() { Id = 3, Customer = c2, MeterReadings = new List<MeterReading>() };
            MeterReading mr2 = new MeterReading() { Id = 3, CubeMeters = 13.89, kWh = 221, UsageHours = 9, Year = new DateTime(2016, 1, 18), Meter = m2 };

            Meter m3 = new Meter() { Id = 4, Customer = c3, MeterReadings = new List<MeterReading>() };
            MeterReading mr3 = new MeterReading() { Id = 4, CubeMeters = 9.33, kWh = 114.5, UsageHours = 10, Year = new DateTime(2016, 1, 18), Meter = m3 };

            Meter m4 = new Meter() { Id = 5, Customer = c4, MeterReadings = new List<MeterReading>() };
            MeterReading mr4 = new MeterReading() { Id = 5, CubeMeters = 88.1, kWh = 1011.2, UsageHours = 12, Year = new DateTime(2016, 1, 18),Meter= m4 };
            MeterReading mr42 = new MeterReading() { Id = 6, CubeMeters = 155.2, kWh = 2112.7, UsageHours = 42, Year = new DateTime(2017, 1, 18), Meter = m4 };

            AddCustomer(c1); AddCustomer(c2); AddCustomer(c3); AddCustomer(c4);
            AddMeter(m01); AddMeter(m1); AddMeter(m2); AddMeter(m3); AddMeter(m4);
            AddMeterReading(mr01); AddMeterReading(mr1); AddMeterReading(mr2); AddMeterReading(mr3); AddMeterReading(mr4);AddMeterReading(mr42);

        }

        public static List<Customer> AddCustomer(Customer customer)
        {
            using (var db = new StorageContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return db.Customers.ToList();
            }
        }

        public static List<Customer> DeleteCustomer(int customerId)
        {
            using (var db = new StorageContext())
            {
                Customer customer = db.Customers.Where(c => c.Id == customerId).First();
                customer.Meters.ToList().ForEach(m =>{
                    m.MeterReadings.ToList().ForEach(mr =>{
                        db.MeterReadings.Remove(mr);
                    });
                    db.Meters.Remove(m);
                });
                db.Customers.Remove(customer);
                db.SaveChanges();

                return db.Customers.ToList();
            }
        }

        public static List<Customer> CreateOrUpdateCustomer(Customer c)
        {
            using (var db = new StorageContext())
            {
                db.Customers.AddOrUpdate(c);
                db.SaveChanges();

                return db.Customers.ToList();
            }
        }


        public static List<Meter> CreateMeter(int customerId)
        {
            using (var db = new StorageContext())
            {
                int id = db.Meters.Max(m => m.Id);
                var customer = db.Customers.Where(c => c.Id == customerId).First();
                Meter newMeter = new Meter() { Id = id + 1, Customer = customer, MeterReadings = new List<MeterReading>() };
                db.Meters.Add(newMeter);

                db.SaveChanges();
                return db.Meters.ToList();
            }
        }

        public static List<MeterReading> CreateMeterReading(int meterId,DateTime newYearDate)
        {
            using (var db = new StorageContext())
            {
                int id = db.MeterReadings.Max(mr => mr.Id);
                Meter meter = db.Meters.Where(m => m.Id == meterId).First();

                MeterReading newMeterReading = new MeterReading() { Id = id+1, CubeMeters = 0, kWh = 0, Meter = meter, UsageHours = 0, Year = newYearDate };
                db.MeterReadings.Add(newMeterReading);
                db.SaveChanges();

                return db.MeterReadings.ToList();
            }
        }

        public static List<Meter> AddMeter(Meter meter)
        {
            using (var db = new StorageContext())
            {
                db.Customers.Attach(meter.Customer);
                db.Meters.Add(meter);

                db.SaveChanges();
                return db.Meters.ToList();
            }
        }

        public static List<MeterReading> AddMeterReading(MeterReading meterReading)
        {
            using (var db = new StorageContext())
            {
                //meterReading.Meter = meter;
                db.Meters.Attach(meterReading.Meter);
                db.MeterReadings.Add(meterReading);
          
                db.SaveChanges();
                return db.MeterReadings.ToList();
            }
        }

        public static List<Customer> GetCustomers()
        {
            using (var db = new StorageContext())
            {
                return db.Customers.ToList();
            }
        }

        public static List<Meter> GetMeters()
        {
            using (var db = new StorageContext())
            {
                return db.Meters.ToList();
            }
        }

        public static List<MeterReading> GetMeterReadings()
        {
            using (var db = new StorageContext())
            {
                return db.MeterReadings.ToList();
            }
        }
    }
}
