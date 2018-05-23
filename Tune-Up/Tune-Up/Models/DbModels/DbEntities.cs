using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tune_Up.Models.DbModels
{
    public class DbEntities : DbContext
    {
        public DbSet<Autopart> Autoparts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbEntities() : base("DataDB")
        {

        }
    }
}