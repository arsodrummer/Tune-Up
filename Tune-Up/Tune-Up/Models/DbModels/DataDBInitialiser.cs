using System.Data.Entity;

namespace Tune_Up.Models.DbModels
{
    public class DataDBInitialiser : DropCreateDatabaseAlways<DbEntities>
    {
        protected override void Seed(DbEntities context)
        {
            context.Autoparts.Add(new Autopart { Name = "Топливный фильтр", Manufacturer = "UFI" });
            context.Vehicles.Add(new Vehicle { Name = "Fiat Linea", EngineVolume = 1.3, Fuel = FuelType.Diesel, ManufacturingDate = new System.DateTime(2013, 1, 1)/*, Photo = null*/});
            base.Seed(context);
        }
    }
}