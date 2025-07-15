using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_employee")]
[Index("EmpCode", Name = "UQ__personne__B1056ABC7931FB49", IsUnique = true)]
[Index("DepartmentId", Name = "personnel_employee_department_id_068bbd08")]
[Index("PositionId", Name = "personnel_employee_position_id_c9321343")]
public partial class PersonnelEmployee
{
    [Key]
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

    [InverseProperty("Employee")]
    public virtual ICollection<AccAccprivilege> AccAccprivileges { get; set; } = new List<AccAccprivilege>();

    [InverseProperty("Employee")]
    public virtual ICollection<AttAttschedule> AttAttschedules { get; set; } = new List<AttAttschedule>();

    [InverseProperty("Employee")]
    public virtual ICollection<AttChangeschedule> AttChangeschedules { get; set; } = new List<AttChangeschedule>();

    [InverseProperty("Employee")]
    public virtual ICollection<AttLeave> AttLeaves { get; set; } = new List<AttLeave>();

    //[InverseProperty("Employee")]
    //public virtual ICollection<AttManuallog> AttManuallogs { get; set; } = new List<AttManuallog>();

    [InverseProperty("Employee")]
    public virtual ICollection<AttOvertime> AttOvertimes { get; set; } = new List<AttOvertime>();

    [InverseProperty("Emp")]
    public virtual ICollection<AttPayloadbase> AttPayloadbases { get; set; } = new List<AttPayloadbase>();

    [InverseProperty("Emp")]
    public virtual ICollection<AttPayloadmulpunchset> AttPayloadmulpunchsets { get; set; } = new List<AttPayloadmulpunchset>();

    [InverseProperty("Emp")]
    public virtual ICollection<AttPayloadpunch> AttPayloadpunches { get; set; } = new List<AttPayloadpunch>();

    [InverseProperty("Employee")]
    public virtual ICollection<AttTempschedule> AttTempschedules { get; set; } = new List<AttTempschedule>();

    [InverseProperty("Employee")]
    public virtual ICollection<AttTraining> AttTrainings { get; set; } = new List<AttTraining>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("PersonnelEmployees")]
    public virtual PersonnelDepartment? Department { get; set; }

    [InverseProperty("Emp")]
    public virtual ICollection<EpEptransaction> EpEptransactions { get; set; } = new List<EpEptransaction>();

    [InverseProperty("Employee")]
    public virtual ICollection<IclockBiodatum> IclockBiodata { get; set; } = new List<IclockBiodatum>();

    [InverseProperty("Employee")]
    public virtual ICollection<IclockBiophoto> IclockBiophotos { get; set; } = new List<IclockBiophoto>();

    [InverseProperty("Employee")]
    public virtual ICollection<IclockPrivatemessage> IclockPrivatemessages { get; set; } = new List<IclockPrivatemessage>();

    [InverseProperty("Emp")]
    public virtual ICollection<IclockTransaction> IclockTransactions { get; set; } = new List<IclockTransaction>();

    [InverseProperty("Receiver")]
    public virtual ICollection<MobileAnnouncement> MobileAnnouncements { get; set; } = new List<MobileAnnouncement>();

    [InverseProperty("Receiver")]
    public virtual ICollection<MobileAppnotification> MobileAppnotifications { get; set; } = new List<MobileAppnotification>();

    [InverseProperty("Employee")]
    public virtual ICollection<MobileGpsforemployee> MobileGpsforemployees { get; set; } = new List<MobileGpsforemployee>();

    [InverseProperty("Employee")]
    public virtual ICollection<PayrollEmploan> PayrollEmploans { get; set; } = new List<PayrollEmploan>();

    [InverseProperty("Employee")]
    public virtual PayrollEmppayrollprofile? PayrollEmppayrollprofile { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<PayrollExtradeduction> PayrollExtradeductions { get; set; } = new List<PayrollExtradeduction>();

    [InverseProperty("Employee")]
    public virtual ICollection<PayrollExtraincrease> PayrollExtraincreases { get; set; } = new List<PayrollExtraincrease>();

    [InverseProperty("Employee")]
    public virtual ICollection<PayrollMonthlysalary> PayrollMonthlysalaries { get; set; } = new List<PayrollMonthlysalary>();

    [InverseProperty("Employee")]
    public virtual ICollection<PayrollReimbursement> PayrollReimbursements { get; set; } = new List<PayrollReimbursement>();

    [InverseProperty("Employee")]
    public virtual ICollection<PayrollSalaryadvance> PayrollSalaryadvances { get; set; } = new List<PayrollSalaryadvance>();

    [InverseProperty("Employee")]
    public virtual ICollection<PayrollSalarystructure> PayrollSalarystructures { get; set; } = new List<PayrollSalarystructure>();

    [InverseProperty("Employee")]
    public virtual ICollection<PersonnelAssignareaemployee> PersonnelAssignareaemployees { get; set; } = new List<PersonnelAssignareaemployee>();

    [InverseProperty("Employee")]
    public virtual ICollection<PersonnelEmployeeArea> PersonnelEmployeeAreas { get; set; } = new List<PersonnelEmployeeArea>();

    [InverseProperty("Employee")]
    public virtual ICollection<PersonnelEmployeeFlowRole> PersonnelEmployeeFlowRoles { get; set; } = new List<PersonnelEmployeeFlowRole>();

    [InverseProperty("Employee")]
    public virtual ICollection<PersonnelEmployeecertification> PersonnelEmployeecertifications { get; set; } = new List<PersonnelEmployeecertification>();

    [InverseProperty("Emp")]
    public virtual PersonnelEmployeeprofile? PersonnelEmployeeprofile { get; set; }

    [InverseProperty("Employee")]
    public virtual PersonnelResign? PersonnelResign { get; set; }

    [ForeignKey("PositionId")]
    [InverseProperty("PersonnelEmployees")]
    public virtual PersonnelPosition? Position { get; set; }

    [InverseProperty("User")]
    public virtual StaffStafftoken? StaffStafftoken { get; set; }

    [InverseProperty("ApproverEmployee")]
    public virtual ICollection<WorkflowNodeinstance> WorkflowNodeinstances { get; set; } = new List<WorkflowNodeinstance>();

    [InverseProperty("Employee")]
    public virtual ICollection<WorkflowWorkflowengineEmployee> WorkflowWorkflowengineEmployees { get; set; } = new List<WorkflowWorkflowengineEmployee>();

    [InverseProperty("Employee")]
    public virtual ICollection<WorkflowWorkflowinstance> WorkflowWorkflowinstances { get; set; } = new List<WorkflowWorkflowinstance>();
}
