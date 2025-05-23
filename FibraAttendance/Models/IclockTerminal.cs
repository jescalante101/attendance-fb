using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_terminal")]
[Index("Sn", Name = "UQ__iclock_t__3214186DA4EEF1B0", IsUnique = true)]
[Index("AreaId", Name = "iclock_terminal_area_id_c019c6f0")]
public partial class IclockTerminal
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

    [Column("sn")]
    [StringLength(50)]
    public string Sn { get; set; } = null!;

    [Column("alias")]
    [StringLength(50)]
    public string Alias { get; set; } = null!;

    [Column("ip_address")]
    [StringLength(39)]
    public string IpAddress { get; set; } = null!;

    [Column("real_ip")]
    [StringLength(39)]
    public string? RealIp { get; set; }

    [Column("state")]
    public int State { get; set; }

    [Column("terminal_tz")]
    public short TerminalTz { get; set; }

    [Column("heartbeat")]
    public int Heartbeat { get; set; }

    [Column("transfer_mode")]
    public short TransferMode { get; set; }

    [Column("transfer_interval")]
    public int TransferInterval { get; set; }

    [Column("transfer_time")]
    [StringLength(100)]
    public string TransferTime { get; set; } = null!;

    [Column("product_type")]
    public short? ProductType { get; set; }

    [Column("is_attendance")]
    public short IsAttendance { get; set; }

    [Column("is_registration")]
    public short IsRegistration { get; set; }

    [Column("purpose")]
    public short? Purpose { get; set; }

    [Column("controller_type")]
    public short? ControllerType { get; set; }

    [Column("authentication")]
    public short Authentication { get; set; }

    [Column("style")]
    [StringLength(20)]
    public string? Style { get; set; }

    [Column("upload_flag")]
    [StringLength(10)]
    public string? UploadFlag { get; set; }

    [Column("fw_ver")]
    [StringLength(100)]
    public string? FwVer { get; set; }

    [Column("push_protocol")]
    [StringLength(30)]
    public string PushProtocol { get; set; } = null!;

    [Column("push_ver")]
    [StringLength(30)]
    public string? PushVer { get; set; }

    [Column("language")]
    public int? Language { get; set; }

    [Column("is_tft")]
    public bool IsTft { get; set; }

    [Column("terminal_name")]
    [StringLength(30)]
    public string? TerminalName { get; set; }

    [Column("platform")]
    [StringLength(30)]
    public string? Platform { get; set; }

    [Column("oem_vendor")]
    [StringLength(50)]
    public string? OemVendor { get; set; }

    [Column("log_stamp")]
    [StringLength(30)]
    public string? LogStamp { get; set; }

    [Column("op_log_stamp")]
    [StringLength(30)]
    public string? OpLogStamp { get; set; }

    [Column("capture_stamp")]
    [StringLength(30)]
    public string? CaptureStamp { get; set; }

    [Column("user_count")]
    public int? UserCount { get; set; }

    [Column("user_capacity")]
    public int? UserCapacity { get; set; }

    [Column("photo_func_on")]
    public bool PhotoFuncOn { get; set; }

    [Column("transaction_count")]
    public int? TransactionCount { get; set; }

    [Column("transaction_capacity")]
    public int? TransactionCapacity { get; set; }

    [Column("fp_func_on")]
    public bool FpFuncOn { get; set; }

    [Column("fp_count")]
    public int? FpCount { get; set; }

    [Column("fp_capacity")]
    public int? FpCapacity { get; set; }

    [Column("fp_alg_ver")]
    [StringLength(10)]
    public string? FpAlgVer { get; set; }

    [Column("face_func_on")]
    public bool FaceFuncOn { get; set; }

    [Column("face_count")]
    public int? FaceCount { get; set; }

    [Column("face_capacity")]
    public int? FaceCapacity { get; set; }

    [Column("face_alg_ver")]
    [StringLength(10)]
    public string? FaceAlgVer { get; set; }

    [Column("fv_func_on")]
    public bool FvFuncOn { get; set; }

    [Column("fv_count")]
    public int? FvCount { get; set; }

    [Column("fv_capacity")]
    public int? FvCapacity { get; set; }

    [Column("fv_alg_ver")]
    [StringLength(10)]
    public string? FvAlgVer { get; set; }

    [Column("palm_func_on")]
    public bool PalmFuncOn { get; set; }

    [Column("palm_count")]
    public int? PalmCount { get; set; }

    [Column("palm_capacity")]
    public int? PalmCapacity { get; set; }

    [Column("palm_alg_ver")]
    [StringLength(10)]
    public string? PalmAlgVer { get; set; }

    [Column("last_activity", TypeName = "datetime")]
    public DateTime? LastActivity { get; set; }

    [Column("upload_time", TypeName = "datetime")]
    public DateTime? UploadTime { get; set; }

    [Column("push_time", TypeName = "datetime")]
    public DateTime? PushTime { get; set; }

    [Column("area_id")]
    public int? AreaId { get; set; }

    [Column("is_access")]
    public short IsAccess { get; set; }

    [Column("lock_func")]
    public short LockFunc { get; set; }

    [InverseProperty("Terminal")]
    public virtual ICollection<AccAccterminal> AccAccterminals { get; set; } = new List<AccAccterminal>();

    [ForeignKey("AreaId")]
    [InverseProperty("IclockTerminals")]
    public virtual PersonnelArea? Area { get; set; }

    [InverseProperty("Terminal")]
    public virtual ICollection<EpEptransaction> EpEptransactions { get; set; } = new List<EpEptransaction>();

    [InverseProperty("Terminal")]
    public virtual ICollection<IclockErrorcommandlog> IclockErrorcommandlogs { get; set; } = new List<IclockErrorcommandlog>();

    [InverseProperty("Terminal")]
    public virtual ICollection<IclockPublicmessage> IclockPublicmessages { get; set; } = new List<IclockPublicmessage>();

    [InverseProperty("Terminal")]
    public virtual ICollection<IclockTerminalcommand> IclockTerminalcommands { get; set; } = new List<IclockTerminalcommand>();

    [InverseProperty("Terminal")]
    public virtual ICollection<IclockTerminallog> IclockTerminallogs { get; set; } = new List<IclockTerminallog>();

    [InverseProperty("Terminal")]
    public virtual ICollection<IclockTerminalparameter> IclockTerminalparameters { get; set; } = new List<IclockTerminalparameter>();

    [InverseProperty("Terminal")]
    public virtual ICollection<IclockTerminaluploadlog> IclockTerminaluploadlogs { get; set; } = new List<IclockTerminaluploadlog>();

    [InverseProperty("Terminal")]
    public virtual ICollection<IclockTransactionproofcmd> IclockTransactionproofcmds { get; set; } = new List<IclockTransactionproofcmd>();

    [InverseProperty("Terminal")]
    public virtual ICollection<IclockTransaction> IclockTransactions { get; set; } = new List<IclockTransaction>();
}
