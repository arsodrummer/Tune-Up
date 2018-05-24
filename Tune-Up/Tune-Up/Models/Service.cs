using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tune_Up.Models
{
    public class Service
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public Autopart Autopart { get; set; }
        [DataType(DataType.Date)/*, Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)*/]
        public DateTime ServiceDate { get; set; }
        public string Master { get; set; }
        public int Distance { get; set; }
    }
}