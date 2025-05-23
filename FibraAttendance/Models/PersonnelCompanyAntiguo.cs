using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Keyless]
[Table("personnel_company_ANTIGUO")]
public partial class PersonnelCompanyAntiguo
{
    [Column("id")]
    public int Id { get; set; }

    [Column("company_name")]
    [StringLength(100)]
    public string CompanyName { get; set; } = null!;

    [Column("company_code")]
    [StringLength(11)]
    public string CompanyCode { get; set; } = null!;

    [Column("logo")]
    [StringLength(200)]
    public string? Logo { get; set; }

    [Column("country")]
    [StringLength(10)]
    public string? Country { get; set; }

    [Column("city")]
    [StringLength(10)]
    public string? City { get; set; }

    [Column("fax")]
    [StringLength(20)]
    public string? Fax { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column("state")]
    [StringLength(20)]
    public string? State { get; set; }

    [Column("phone")]
    [StringLength(20)]
    public string? Phone { get; set; }

    [Column("website")]
    [StringLength(50)]
    public string? Website { get; set; }

    [Column("postal_code")]
    [StringLength(20)]
    public string? PostalCode { get; set; }

    [Column("address")]
    [StringLength(200)]
    public string? Address { get; set; }

    [Column("address2")]
    [StringLength(200)]
    public string? Address2 { get; set; }

    [Column("show_in_report")]
    public bool ShowInReport { get; set; }

    [Column("is_default")]
    public bool IsDefault { get; set; }
}
