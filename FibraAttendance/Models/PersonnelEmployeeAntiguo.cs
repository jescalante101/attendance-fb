using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Keyless]
[Table("personnel_employee_ANTIGUO")]
public partial class PersonnelEmployeeAntiguo
{
    [Column("id")]
    public int Id { get; set; }

    [Column("create_time", TypeName = "datetime")]
    public DateTime? CreateTime { get; set; }

    [Column("create_user")]
    [StringLength(150)]
    public string? CreateUser { get; set; }

    [Column("change_time", TypeName = "datetime")]
    public DateTime? ChangeTime { get; set; }

    [Column("change_user")]
    [StringLength(150)]
    public string? ChangeUser { get; set; }

    [Column("status")]
    public short Status { get; set; }

    [Column("emp_code")]
    [StringLength(20)]
    public string EmpCode { get; set; } = null!;

    [Column("first_name")]
    [StringLength(25)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(25)]
    public string? LastName { get; set; }

    [Column("nickname")]
    [StringLength(25)]
    public string? Nickname { get; set; }

    [Column("passport")]
    [StringLength(30)]
    public string? Passport { get; set; }

    [Column("driver_license_automobile")]
    [StringLength(30)]
    public string? DriverLicenseAutomobile { get; set; }

    [Column("driver_license_motorcycle")]
    [StringLength(30)]
    public string? DriverLicenseMotorcycle { get; set; }

    [Column("photo")]
    [StringLength(200)]
    public string? Photo { get; set; }

    [Column("self_password")]
    [StringLength(128)]
    public string? SelfPassword { get; set; }

    [Column("device_password")]
    [StringLength(20)]
    public string? DevicePassword { get; set; }

    [Column("dev_privilege")]
    public int? DevPrivilege { get; set; }

    [Column("card_no")]
    [StringLength(20)]
    public string? CardNo { get; set; }

    [Column("acc_group")]
    [StringLength(5)]
    public string? AccGroup { get; set; }

    [Column("acc_timezone")]
    [StringLength(20)]
    public string? AccTimezone { get; set; }

    [Column("gender")]
    [StringLength(1)]
    public string? Gender { get; set; }

    [Column("birthday", TypeName = "datetime")]
    public DateTime? Birthday { get; set; }

    [Column("address")]
    [StringLength(200)]
    public string? Address { get; set; }

    [Column("postcode")]
    [StringLength(10)]
    public string? Postcode { get; set; }

    [Column("office_tel")]
    [StringLength(20)]
    public string? OfficeTel { get; set; }

    [Column("contact_tel")]
    [StringLength(20)]
    public string? ContactTel { get; set; }

    [Column("mobile")]
    [StringLength(20)]
    public string? Mobile { get; set; }

    [Column("national")]
    [StringLength(50)]
    public string? National { get; set; }

    [Column("religion")]
    [StringLength(20)]
    public string? Religion { get; set; }

    [Column("title")]
    [StringLength(20)]
    public string? Title { get; set; }

    [Column("enroll_sn")]
    [StringLength(20)]
    public string? EnrollSn { get; set; }

    [Column("ssn")]
    [StringLength(20)]
    public string? Ssn { get; set; }

    [Column("update_time", TypeName = "datetime")]
    public DateTime? UpdateTime { get; set; }

    [Column("hire_date", TypeName = "datetime")]
    public DateTime? HireDate { get; set; }

    [Column("verify_mode")]
    public int? VerifyMode { get; set; }

    [Column("city")]
    [StringLength(20)]
    public string? City { get; set; }

    [Column("is_admin")]
    public bool IsAdmin { get; set; }

    [Column("emp_type")]
    public int? EmpType { get; set; }

    [Column("enable_att")]
    public bool EnableAtt { get; set; }

    [Column("enable_overtime")]
    public bool EnableOvertime { get; set; }

    [Column("enable_holiday")]
    public bool EnableHoliday { get; set; }

    [Column("deleted")]
    public bool Deleted { get; set; }

    [Column("reserved")]
    public int? Reserved { get; set; }

    [Column("del_tag")]
    public int? DelTag { get; set; }

    [Column("app_status")]
    public short? AppStatus { get; set; }

    [Column("app_role")]
    public short? AppRole { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column("last_login", TypeName = "datetime")]
    public DateTime? LastLogin { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("position_id")]
    public int? PositionId { get; set; }

    [Column("enable_payroll")]
    public bool EnablePayroll { get; set; }
}
