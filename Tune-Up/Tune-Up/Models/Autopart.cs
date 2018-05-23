using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tune_Up.Models
{
    public class Autopart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public byte[] Photo { get; set; }
    }
}