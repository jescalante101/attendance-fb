using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_trainingcategory")]
public partial class AttTrainingcategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("category_name")]
    [StringLength(50)]
    public string CategoryName { get; set; } = null!;

    [Column("minimum_unit")]
    public double MinimumUnit { get; set; }

    [Column("unit")]
    public short Unit { get; set; }

    [Column("round_off")]
    public short RoundOff { get; set; }

    [Column("report_symbol")]
    [StringLength(5)]
    public string ReportSymbol { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<AttTraining> AttTrainings { get; set; } = new List<AttTraining>();
}
