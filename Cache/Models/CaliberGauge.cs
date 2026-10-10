using System.ComponentModel.DataAnnotations;

namespace Cache.Models;

public class CaliberGauge
{

    public Guid Id { get; set; }

    [Required]
    [Display(Name = "Caliber/Gauge")]
    public string? Name { get; set; }

}