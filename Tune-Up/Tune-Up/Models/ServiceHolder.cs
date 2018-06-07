using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tune_Up.Models
{
    public class ServiceHolder
    {
        public Vehicle Vehicle { get; set; }
        public Autopart Autopart { get; set; }
        public Service Service { get; set; }
    }
}