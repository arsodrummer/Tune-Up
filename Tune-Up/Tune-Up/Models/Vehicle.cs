using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tune_Up.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public double EngineVolume { get; set; }
        public FuelType Fuel { get; set; }
        public int? PhotoId { get; set; }
    }
}