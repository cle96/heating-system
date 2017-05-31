using HeatingSystemModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingSystemModel.Storage
{
    public class StorageContext : DbContext
    {
            public StorageContext() : base("name=StorageContext") { }

            public DbSet<Meter> Meters { get; set; }
            public DbSet<Customer> Customers { get; set; }

            public DbSet<MeterReading> MeterReadings { get; set; }

    }
}
