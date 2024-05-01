using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Models;

[Table("eventstable")]
public partial class eventstable
{
    [Key]
    public int event_id { get; set; }

    [StringLength(255)]
    public string event_name { get; set; } = null!;

    [StringLength(50)]
    public string? category { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime start_date { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? end_date { get; set; }

    [StringLength(100)]
    public string? venue { get; set; }

    [StringLength(20)]
    public string? status { get; set; }

    [StringLength(100)]
    public string? booking_user_name { get; set; }
}
