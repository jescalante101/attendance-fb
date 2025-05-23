using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("acc_accterminal")]
[Index("TerminalId", Name = "acc_accterminal_terminal_id_fc92cce2")]
public partial class AccAccterminal
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

    [Column("door_name")]
    [StringLength(50)]
    public string? DoorName { get; set; }

    [Column("door_lock_delay")]
    public int DoorLockDelay { get; set; }

    [Column("door_sensor_delay")]
    public int DoorSensorDelay { get; set; }

    [Column("door_sensor_type")]
    public short DoorSensorType { get; set; }

    [Column("door_alarm_delay")]
    public int DoorAlarmDelay { get; set; }

    [Column("retry_times")]
    public short RetryTimes { get; set; }

    [Column("valid_holiday")]
    public short ValidHoliday { get; set; }

    [Column("nc_time_period")]
    public int NcTimePeriod { get; set; }

    [Column("no_time_period")]
    public int NoTimePeriod { get; set; }

    [Column("speaker_alarm")]
    public short SpeakerAlarm { get; set; }

    [Column("duress_fun_on")]
    public short DuressFunOn { get; set; }

    [Column("alarm_1_1")]
    public short Alarm11 { get; set; }

    [Column("alarm_1_n")]
    public short Alarm1N { get; set; }

    [Column("alarm_password")]
    public short AlarmPassword { get; set; }

    [Column("duress_alarm_delay")]
    public int DuressAlarmDelay { get; set; }

    [Column("anti_passback_mode")]
    public short AntiPassbackMode { get; set; }

    [Column("anti_door_direction")]
    public short AntiDoorDirection { get; set; }

    [Column("verify_mode_485")]
    public short VerifyMode485 { get; set; }

    [Column("push_time", TypeName = "datetime")]
    public DateTime? PushTime { get; set; }

    [Column("terminal_id")]
    public int TerminalId { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("AccAccterminals")]
    public virtual IclockTerminal Terminal { get; set; } = null!;
}
