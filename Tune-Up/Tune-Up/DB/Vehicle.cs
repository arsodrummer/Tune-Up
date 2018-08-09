namespace Tune_Up.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Vehicle : DbContext
    {
        public Vehicle()
            : base("name=Vehicle")
        {
        }

        public virtual DbSet<Vehicles> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
