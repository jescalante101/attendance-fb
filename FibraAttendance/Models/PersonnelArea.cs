using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_area")]
[Index("AreaCode", Name = "UQ__personne__8B1398D64F8EA061", IsUnique = true)]
[Index("ParentAreaId", Name = "personnel_area_parent_area_id_39028fda")]
public partial class PersonnelArea
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("area_code")]
    [StringLength(30)]
    public string AreaCode { get; set; } = null!;

    [Column("area_name")]
    [StringLength(30)]
    public string AreaName { get; set; } = null!;

    [Column("is_default")]
    public bool IsDefault { get; set; }

    [Column("parent_area_id")]
    public int? ParentAreaId { get; set; }

    [InverseProperty("Area")]
    public virtual ICollection<AccAcccombination> AccAcccombinations { get; set; } = new List<AccAcccombination>();

    [InverseProperty("Area")]
    public virtual ICollection<AccAccgroup> AccAccgroups { get; set; } = new List<AccAccgroup>();

    [InverseProperty("Area")]
    public virtual ICollection<AccAccholiday> AccAccholidays { get; set; } = new List<AccAccholiday>();

    [InverseProperty("Area")]
    public virtual ICollection<AccAccprivilege> AccAccprivileges { get; set; } = new List<AccAccprivilege>();

    [InverseProperty("Area")]
    public virtual ICollection<AccAcctimezone> AccAcctimezones { get; set; } = new List<AccAcctimezone>();

    [InverseProperty("Area")]
    public virtual ICollection<AuthUserAuthArea> AuthUserAuthAreas { get; set; } = new List<AuthUserAuthArea>();

    [InverseProperty("Area")]
    public virtual ICollection<IclockTerminal> IclockTerminals { get; set; } = new List<IclockTerminal>();

    [InverseProperty("ParentArea")]
    public virtual ICollection<PersonnelArea> InverseParentArea { get; set; } = new List<PersonnelArea>();

    [ForeignKey("ParentAreaId")]
    [InverseProperty("InverseParentArea")]
    public virtual PersonnelArea? ParentArea { get; set; }

    [InverseProperty("Area")]
    public virtual ICollection<PersonnelAssignareaemployee> PersonnelAssignareaemployees { get; set; } = new List<PersonnelAssignareaemployee>();

    [InverseProperty("Area")]
    public virtual ICollection<PersonnelEmployeeArea> PersonnelEmployeeAreas { get; set; } = new List<PersonnelEmployeeArea>();
}
