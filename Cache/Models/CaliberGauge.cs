using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cache.Models
{

    public class CaliberGauge
    {

        public int Id { get; set; }

        public string UserId { get; set; }

        [Required,
        Display(Name = "Caliber/Gauge")]
        public string Name { get; set; }
        
    }

}