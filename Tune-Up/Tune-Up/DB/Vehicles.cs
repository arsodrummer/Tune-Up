namespace Tune_Up.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vehicles
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public double EngineVolume { get; set; }

        public int Fuel { get; set; }

        public string Photo { get; set; }

        public int? PhotoId { get; set; }
    }
}
