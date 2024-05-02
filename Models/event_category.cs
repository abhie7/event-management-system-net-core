using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Models;

public partial class event_category
{
    [Key]
    public int category_id { get; set; }

    [StringLength(255)]
    public string category { get; set; } = null!;

    public string? description { get; set; }

    [Precision(10, 2)]
    public decimal? price_per_hour { get; set; }

    [Precision(10, 2)]
    public decimal? price_per_day { get; set; }

    public bool? is_active { get; set; }

    public int? max_capacity { get; set; }
}
