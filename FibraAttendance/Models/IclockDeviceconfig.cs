using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_deviceconfig")]
public partial class IclockDeviceconfig
{
    [Key]
    [Column("uuid")]
    [StringLength(36)]
    public string Uuid { get; set; } = null!;

    [Column("enable_registration")]
    public bool EnableRegistration { get; set; }

    [Column("enable_resigned_filter")]
    public bool EnableResignedFilter { get; set; }

    [Column("enable_auto_add")]
    public bool EnableAutoAdd { get; set; }

    [Column("enable_name_upload")]
    public bool EnableNameUpload { get; set; }

    [Column("enable_card_upload")]
    public bool EnableCardUpload { get; set; }

    [Column("transaction_retention")]
    public int TransactionRetention { get; set; }

    [Column("command_retention")]
    public int CommandRetention { get; set; }

    [Column("dev_log_retention")]
    public int DevLogRetention { get; set; }

    [Column("upload_log_retention")]
    public int UploadLogRetention { get; set; }

    [Column("edit_policy")]
    public short EditPolicy { get; set; }

    [Column("import_policy")]
    public short ImportPolicy { get; set; }

    [Column("mobile_policy")]
    public short MobilePolicy { get; set; }

    [Column("device_policy")]
    public short DevicePolicy { get; set; }
}
