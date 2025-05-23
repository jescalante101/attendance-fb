using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Keyless]
[Table("personnel_employee_area_ANTIGUO")]
public partial class PersonnelEmployeeAreaAntiguo
{
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("area_id")]
    public int AreaId { get; set; }
}
