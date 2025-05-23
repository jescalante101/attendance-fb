using System;
using System.Collections.Generic;
using FibraAttendance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;

namespace FibraAttendance.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
       
    }

    public virtual DbSet<AccAcccombination> AccAcccombinations { get; set; }

    public virtual DbSet<AccAccgroup> AccAccgroups { get; set; }

    public virtual DbSet<AccAccholiday> AccAccholidays { get; set; }

    public virtual DbSet<AccAccprivilege> AccAccprivileges { get; set; }

    public virtual DbSet<AccAccterminal> AccAccterminals { get; set; }

    public virtual DbSet<AccAcctimezone> AccAcctimezones { get; set; }

    public virtual DbSet<AttAttcalclog> AttAttcalclogs { get; set; }

    public virtual DbSet<AttAttreportsetting> AttAttreportsettings { get; set; }

    public virtual DbSet<AttAttrule> AttAttrules { get; set; }

    public virtual DbSet<AttAttschedule> AttAttschedules { get; set; }

    public virtual DbSet<AttAttshift> AttAttshifts { get; set; }

    public virtual DbSet<AttBreaktime> AttBreaktimes { get; set; }

    public virtual DbSet<AttChangeschedule> AttChangeschedules { get; set; }

    public virtual DbSet<AttDepartmentschedule> AttDepartmentschedules { get; set; }

    public virtual DbSet<AttDeptattrule> AttDeptattrules { get; set; }

    public virtual DbSet<AttHoliday> AttHolidays { get; set; }

    public virtual DbSet<AttLeave> AttLeaves { get; set; }

    public virtual DbSet<AttLeavecategory> AttLeavecategories { get; set; }

    public virtual DbSet<AttManuallog> AttManuallogs { get; set; }

    public virtual DbSet<AttOvertime> AttOvertimes { get; set; }

    public virtual DbSet<AttPayloadbase> AttPayloadbases { get; set; }

    public virtual DbSet<AttPayloadbreak> AttPayloadbreaks { get; set; }

    public virtual DbSet<AttPayloadexception> AttPayloadexceptions { get; set; }

    public virtual DbSet<AttPayloadmulpunchset> AttPayloadmulpunchsets { get; set; }

    public virtual DbSet<AttPayloadovertime> AttPayloadovertimes { get; set; }

    public virtual DbSet<AttPayloadpunch> AttPayloadpunches { get; set; }

    public virtual DbSet<AttReportparam> AttReportparams { get; set; }

    public virtual DbSet<AttShiftdetail> AttShiftdetails { get; set; }

    public virtual DbSet<AttTempschedule> AttTempschedules { get; set; }

    public virtual DbSet<AttTimeinterval> AttTimeintervals { get; set; }

    public virtual DbSet<AttTimeintervalBreakTime> AttTimeintervalBreakTimes { get; set; }

    public virtual DbSet<AttTraining> AttTrainings { get; set; }

    public virtual DbSet<AttTrainingcategory> AttTrainingcategories { get; set; }

    public virtual DbSet<Attparam> Attparams { get; set; }

    public virtual DbSet<AuthGroup> AuthGroups { get; set; }

    public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; }

    public virtual DbSet<AuthPermission> AuthPermissions { get; set; }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<AuthUserAuthArea> AuthUserAuthAreas { get; set; }

    public virtual DbSet<AuthUserAuthDept> AuthUserAuthDepts { get; set; }

    public virtual DbSet<AuthUserGroup> AuthUserGroups { get; set; }

    public virtual DbSet<AuthUserProfile> AuthUserProfiles { get; set; }

    public virtual DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; }

    public virtual DbSet<AuthtokenToken> AuthtokenTokens { get; set; }

    public virtual DbSet<BaseAdminlog> BaseAdminlogs { get; set; }

    public virtual DbSet<BaseAttparamdept> BaseAttparamdepts { get; set; }

    public virtual DbSet<BaseAutoexporttask> BaseAutoexporttasks { get; set; }

    public virtual DbSet<BaseBookmark> BaseBookmarks { get; set; }

    public virtual DbSet<BaseDbbackuplog> BaseDbbackuplogs { get; set; }

    public virtual DbSet<BaseDbmigrate> BaseDbmigrates { get; set; }

    public virtual DbSet<BaseLinenotifysetting> BaseLinenotifysettings { get; set; }

    public virtual DbSet<BaseSendemail> BaseSendemails { get; set; }

    public virtual DbSet<BaseSftpsetting> BaseSftpsettings { get; set; }

    public virtual DbSet<BaseSysparam> BaseSysparams { get; set; }

    public virtual DbSet<BaseSysparamdept> BaseSysparamdepts { get; set; }

    public virtual DbSet<BaseSystemsetting> BaseSystemsettings { get; set; }

    public virtual DbSet<BaseTaskresultlog> BaseTaskresultlogs { get; set; }

    public virtual DbSet<CeleryTaskmetum> CeleryTaskmeta { get; set; }

    public virtual DbSet<CeleryTasksetmetum> CeleryTasksetmeta { get; set; }

    public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; }

    public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; }

    public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; }

    public virtual DbSet<DjangoSession> DjangoSessions { get; set; }

    public virtual DbSet<DjceleryCrontabschedule> DjceleryCrontabschedules { get; set; }

    public virtual DbSet<DjceleryIntervalschedule> DjceleryIntervalschedules { get; set; }

    public virtual DbSet<DjceleryPeriodictask> DjceleryPeriodictasks { get; set; }

    public virtual DbSet<DjceleryPeriodictask1> DjceleryPeriodictasks1 { get; set; }

    public virtual DbSet<DjceleryTaskstate> DjceleryTaskstates { get; set; }

    public virtual DbSet<DjceleryWorkerstate> DjceleryWorkerstates { get; set; }

    public virtual DbSet<EpEpsetup> EpEpsetups { get; set; }

    public virtual DbSet<EpEptransaction> EpEptransactions { get; set; }

    public virtual DbSet<GuardianGroupobjectpermission> GuardianGroupobjectpermissions { get; set; }

    public virtual DbSet<GuardianUserobjectpermission> GuardianUserobjectpermissions { get; set; }

    public virtual DbSet<IclockBiodatum> IclockBiodata { get; set; }

    public virtual DbSet<IclockBiophoto> IclockBiophotos { get; set; }

    public virtual DbSet<IclockDeviceconfig> IclockDeviceconfigs { get; set; }

    public virtual DbSet<IclockErrorcommandlog> IclockErrorcommandlogs { get; set; }

    public virtual DbSet<IclockPrivatemessage> IclockPrivatemessages { get; set; }

    public virtual DbSet<IclockPublicmessage> IclockPublicmessages { get; set; }

    public virtual DbSet<IclockTerminal> IclockTerminals { get; set; }

    public virtual DbSet<IclockTerminalcommand> IclockTerminalcommands { get; set; }

    public virtual DbSet<IclockTerminalemployee> IclockTerminalemployees { get; set; }

    public virtual DbSet<IclockTerminallog> IclockTerminallogs { get; set; }

    public virtual DbSet<IclockTerminalparameter> IclockTerminalparameters { get; set; }

    public virtual DbSet<IclockTerminaluploadlog> IclockTerminaluploadlogs { get; set; }

    public virtual DbSet<IclockTerminalworkcode> IclockTerminalworkcodes { get; set; }

    public virtual DbSet<IclockTransaction> IclockTransactions { get; set; }

    public virtual DbSet<IclockTransactionproofcmd> IclockTransactionproofcmds { get; set; }

    public virtual DbSet<MobileAnnouncement> MobileAnnouncements { get; set; }

    public virtual DbSet<MobileAppactionlog> MobileAppactionlogs { get; set; }

    public virtual DbSet<MobileApplist> MobileApplists { get; set; }

    public virtual DbSet<MobileAppnotification> MobileAppnotifications { get; set; }

    public virtual DbSet<MobileGpsfordepartment> MobileGpsfordepartments { get; set; }

    public virtual DbSet<MobileGpsforemployee> MobileGpsforemployees { get; set; }

    public virtual DbSet<PayrollDeductionformula> PayrollDeductionformulas { get; set; }

    public virtual DbSet<PayrollEmploan> PayrollEmploans { get; set; }

    public virtual DbSet<PayrollEmppayrollprofile> PayrollEmppayrollprofiles { get; set; }

    public virtual DbSet<PayrollExceptionformula> PayrollExceptionformulas { get; set; }

    public virtual DbSet<PayrollExtradeduction> PayrollExtradeductions { get; set; }

    public virtual DbSet<PayrollExtraincrease> PayrollExtraincreases { get; set; }

    public virtual DbSet<PayrollIncreasementformula> PayrollIncreasementformulas { get; set; }

    public virtual DbSet<PayrollLeaveformula> PayrollLeaveformulas { get; set; }

    public virtual DbSet<PayrollMonthlysalary> PayrollMonthlysalaries { get; set; }

    public virtual DbSet<PayrollOvertimeformula> PayrollOvertimeformulas { get; set; }

    public virtual DbSet<PayrollReimbursement> PayrollReimbursements { get; set; }

    public virtual DbSet<PayrollSalaryadvance> PayrollSalaryadvances { get; set; }

    public virtual DbSet<PayrollSalarystructure> PayrollSalarystructures { get; set; }

    public virtual DbSet<PayrollSalarystructureDeductionformula> PayrollSalarystructureDeductionformulas { get; set; }

    public virtual DbSet<PayrollSalarystructureExceptionformula> PayrollSalarystructureExceptionformulas { get; set; }

    public virtual DbSet<PayrollSalarystructureIncreasementformula> PayrollSalarystructureIncreasementformulas { get; set; }

    public virtual DbSet<PayrollSalarystructureLeaveformula> PayrollSalarystructureLeaveformulas { get; set; }

    public virtual DbSet<PayrollSalarystructureOvertimeformula> PayrollSalarystructureOvertimeformulas { get; set; }

    public virtual DbSet<PersonnelArea> PersonnelAreas { get; set; }

    public virtual DbSet<PersonnelAreaAntiguo> PersonnelAreaAntiguos { get; set; }

    public virtual DbSet<PersonnelAssignareaemployee> PersonnelAssignareaemployees { get; set; }

    public virtual DbSet<PersonnelCertification> PersonnelCertifications { get; set; }

    public virtual DbSet<PersonnelCompany> PersonnelCompanies { get; set; }

    public virtual DbSet<PersonnelCompanyAntiguo> PersonnelCompanyAntiguos { get; set; }

    public virtual DbSet<PersonnelDepartment> PersonnelDepartments { get; set; }

    public virtual DbSet<PersonnelDepartmentAntiguo> PersonnelDepartmentAntiguos { get; set; }

    public virtual DbSet<PersonnelEmployee> PersonnelEmployees { get; set; }

    public virtual DbSet<PersonnelEmployeeAntiguo> PersonnelEmployeeAntiguos { get; set; }

    public virtual DbSet<PersonnelEmployeeArea> PersonnelEmployeeAreas { get; set; }

    public virtual DbSet<PersonnelEmployeeAreaAntiguo> PersonnelEmployeeAreaAntiguos { get; set; }

    public virtual DbSet<PersonnelEmployeeFlowRole> PersonnelEmployeeFlowRoles { get; set; }

    public virtual DbSet<PersonnelEmployeecertification> PersonnelEmployeecertifications { get; set; }

    public virtual DbSet<PersonnelEmployeeprofile> PersonnelEmployeeprofiles { get; set; }

    public virtual DbSet<PersonnelPosition> PersonnelPositions { get; set; }

    public virtual DbSet<PersonnelResign> PersonnelResigns { get; set; }

    public virtual DbSet<StaffStafftoken> StaffStafftokens { get; set; }

    public virtual DbSet<SyncArea> SyncAreas { get; set; }

    public virtual DbSet<SyncDepartment> SyncDepartments { get; set; }

    public virtual DbSet<SyncEmployee> SyncEmployees { get; set; }

    public virtual DbSet<SyncJob> SyncJobs { get; set; }

    public virtual DbSet<WorkflowAbstractexception> WorkflowAbstractexceptions { get; set; }

    public virtual DbSet<WorkflowNodeinstance> WorkflowNodeinstances { get; set; }

    public virtual DbSet<WorkflowWorkflowengine> WorkflowWorkflowengines { get; set; }

    public virtual DbSet<WorkflowWorkflowengineEmployee> WorkflowWorkflowengineEmployees { get; set; }

    public virtual DbSet<WorkflowWorkflowinstance> WorkflowWorkflowinstances { get; set; }

    public virtual DbSet<WorkflowWorkflownode> WorkflowWorkflownodes { get; set; }

    public virtual DbSet<WorkflowWorkflownodeApprover> WorkflowWorkflownodeApprovers { get; set; }

    public virtual DbSet<WorkflowWorkflownodeNotifier> WorkflowWorkflownodeNotifiers { get; set; }

    public virtual DbSet<WorkflowWorkflowrole> WorkflowWorkflowroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=192.168.20.10;Database=zk_bioti_TEST_12_05_25;User Id=jescalante;Password=Fibra76095492;Encrypt=False;TrustServerCertificate=True;");
        //optionsBuilder.AddInterceptors(new QueryLogger(this.GetService<ILogger<QueryLogger>>()));
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccAcccombination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__acc_accc__3213E83FB0C03B48");

            entity.HasOne(d => d.Area).WithMany(p => p.AccAcccombinations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_acccombination_area_id_0d22c34e_fk_personnel_area_id");
        });

        modelBuilder.Entity<AccAccgroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__acc_accg__3213E83FDBAA3628");

            entity.HasOne(d => d.Area).WithMany(p => p.AccAccgroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_accgroups_area_id_b83745c3_fk_personnel_area_id");
        });

        modelBuilder.Entity<AccAccholiday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__acc_acch__3213E83F16DE1490");

            entity.HasOne(d => d.Area).WithMany(p => p.AccAccholidays)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_accholiday_area_id_d15c19da_fk_personnel_area_id");

            entity.HasOne(d => d.Holiday).WithMany(p => p.AccAccholidays)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_accholiday_holiday_id_a9efe924_fk_att_holiday_id");

            entity.HasOne(d => d.Timezone).WithMany(p => p.AccAccholidays)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_accholiday_timezone_id_450d2d1e_fk_acc_acctimezone_id");
        });

        modelBuilder.Entity<AccAccprivilege>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__acc_accp__3213E83F84F5BF75");

            entity.HasOne(d => d.Area).WithMany(p => p.AccAccprivileges)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_accprivilege_area_id_2123ff6f_fk_personnel_area_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.AccAccprivileges)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_accprivilege_employee_id_5fc55f95_fk_personnel_employee_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AccAccprivileges)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_accprivilege_group_id_c5ed7003_fk_acc_accgroups_id");
        });

        modelBuilder.Entity<AccAccterminal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__acc_acct__3213E83FB7EF596C");

            entity.HasOne(d => d.Terminal).WithMany(p => p.AccAccterminals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_accterminal_terminal_id_fc92cce2_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<AccAcctimezone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__acc_acct__3213E83FF5D78C97");

            entity.HasOne(d => d.Area).WithMany(p => p.AccAcctimezones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acc_acctimezone_area_id_e9ce7a7a_fk_personnel_area_id");
        });

        modelBuilder.Entity<AttAttcalclog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_attc__3213E83F40C60309");
        });

        modelBuilder.Entity<AttAttreportsetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_attr__3213E83F6FEE2ABF");
        });

        modelBuilder.Entity<AttAttrule>(entity =>
        {
            entity.HasKey(e => e.ParamName).HasName("PK__att_attr__71F4BD70E9A854B3");
        });

        modelBuilder.Entity<AttAttschedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_atts__3213E83FABFDACD5");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttAttschedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_attschedule_employee_id_caa61686_fk_personnel_employee_id");

            entity.HasOne(d => d.Shift).WithMany(p => p.AttAttschedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_attschedule_shift_id_13d2db9a_fk_att_attshift_id");
        });

        modelBuilder.Entity<AttAttshift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_atts__3213E83F266F1424");
        });

        modelBuilder.Entity<AttBreaktime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_brea__3213E83F837437E8");
        });

        modelBuilder.Entity<AttChangeschedule>(entity =>
        {
            entity.HasKey(e => e.AbstractexceptionPtrId).HasName("PK__att_chan__8D9209C932C6847F");

            entity.Property(e => e.AbstractexceptionPtrId).ValueGeneratedNever();

            entity.HasOne(d => d.AbstractexceptionPtr).WithOne(p => p.AttChangeschedule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_changeschedule_abstractexception_ptr_id_6bf48cd8_fk_workflow_abstractexception_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttChangeschedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_changeschedule_employee_id_7871a2b6_fk_personnel_employee_id");

            entity.HasOne(d => d.Timeinterval).WithMany(p => p.AttChangeschedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_changeschedule_timeinterval_id_d41ac077_fk_att_timeinterval_id");
        });

        modelBuilder.Entity<AttDepartmentschedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_depa__3213E83F478ED7A0");

            entity.HasOne(d => d.Department).WithMany(p => p.AttDepartmentschedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_departmentschedule_department_id_c68fca3d_fk_personnel_department_id");

            entity.HasOne(d => d.Shift).WithMany(p => p.AttDepartmentschedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_departmentschedule_shift_id_c37d5ade_fk_att_attshift_id");
        });

        modelBuilder.Entity<AttDeptattrule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_dept__3213E83FF3A8140E");

            entity.HasOne(d => d.Department).WithMany(p => p.AttDeptattrules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_deptattrule_department_id_f333c8f0_fk_personnel_department_id");
        });

        modelBuilder.Entity<AttHoliday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_holi__3213E83F1CA16F64");

            entity.HasOne(d => d.Department).WithMany(p => p.AttHolidays).HasConstraintName("att_holiday_department_id_fbbbd185_fk_personnel_department_id");
        });

        modelBuilder.Entity<AttLeave>(entity =>
        {
            entity.HasKey(e => e.AbstractexceptionPtrId).HasName("PK__att_leav__8D9209C956D1A1AE");

            entity.Property(e => e.AbstractexceptionPtrId).ValueGeneratedNever();

            entity.HasOne(d => d.AbstractexceptionPtr).WithOne(p => p.AttLeave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_leave_abstractexception_ptr_id_7d182abd_fk_workflow_abstractexception_id");

            entity.HasOne(d => d.Category).WithMany(p => p.AttLeaves)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_leave_category_id_bbba39ba_fk_att_leavecategory_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttLeaves)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_leave_employee_id_bb231627_fk_personnel_employee_id");
        });

        modelBuilder.Entity<AttLeavecategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_leav__3213E83F81AC52D9");
        });

        modelBuilder.Entity<AttManuallog>(entity =>
        {
            entity.HasKey(e => e.AbstractexceptionPtrId).HasName("PK__att_manu__8D9209C97E1ADA60");

            entity.Property(e => e.AbstractexceptionPtrId).ValueGeneratedNever();

            entity.HasOne(d => d.AbstractexceptionPtr).WithOne(p => p.AttManuallog)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_manuallog_abstractexception_ptr_id_f1e1b292_fk_workflow_abstractexception_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttManuallogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_manuallog_employee_id_dc8cc2ad_fk_personnel_employee_id");
        });

        modelBuilder.Entity<AttOvertime>(entity =>
        {
            entity.HasKey(e => e.AbstractexceptionPtrId).HasName("PK__att_over__8D9209C93DC1CC65");

            entity.Property(e => e.AbstractexceptionPtrId).ValueGeneratedNever();

            entity.HasOne(d => d.AbstractexceptionPtr).WithOne(p => p.AttOvertime)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_overtime_abstractexception_ptr_id_94834697_fk_workflow_abstractexception_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttOvertimes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_overtime_employee_id_0c0d39dc_fk_personnel_employee_id");
        });

        modelBuilder.Entity<AttPayloadbase>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__att_payl__7F427930CFD4CC27");

            entity.HasOne(d => d.Emp).WithMany(p => p.AttPayloadbases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_payloadbase_emp_id_2c0f6a7b_fk_personnel_employee_id");

            entity.HasOne(d => d.Timetable).WithMany(p => p.AttPayloadbases).HasConstraintName("att_payloadbase_timetable_id_a389e3d8_fk_att_timeinterval_id");

            entity.HasOne(d => d.TransIn).WithMany(p => p.AttPayloadbaseTransIns).HasConstraintName("att_payloadbase_trans_in_id_3b8fd648_fk_iclock_transaction_id");

            entity.HasOne(d => d.TransOut).WithMany(p => p.AttPayloadbaseTransOuts).HasConstraintName("att_payloadbase_trans_out_id_ec63bbcc_fk_iclock_transaction_id");
        });

        modelBuilder.Entity<AttPayloadbreak>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__att_payl__7F427930767368DB");
        });

        modelBuilder.Entity<AttPayloadexception>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__att_payl__7F427930B370FF5D");

            entity.HasOne(d => d.Item).WithMany(p => p.AttPayloadexceptions).HasConstraintName("att_payloadexception_item_id_a08bfe48_fk_att_leave_abstractexception_ptr_id");
        });

        modelBuilder.Entity<AttPayloadmulpunchset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_payl__3213E83F81F247F5");

            entity.HasOne(d => d.Emp).WithMany(p => p.AttPayloadmulpunchsets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_payloadmulpunchset_emp_id_f47610c8_fk_personnel_employee_id");
        });

        modelBuilder.Entity<AttPayloadovertime>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__att_payl__7F427930308A59F6");
        });

        modelBuilder.Entity<AttPayloadpunch>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__att_payl__7F4279309FD0CF97");

            entity.HasOne(d => d.Emp).WithMany(p => p.AttPayloadpunches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_payloadpunch_emp_id_053da2f0_fk_personnel_employee_id");

            entity.HasOne(d => d.Orig).WithMany(p => p.AttPayloadpunches).HasConstraintName("att_payloadpunch_orig_id_16b26416_fk_iclock_transaction_id");
        });

        modelBuilder.Entity<AttReportparam>(entity =>
        {
            entity.HasKey(e => e.ParamName).HasName("PK__att_repo__71F4BD70AC8EFC21");
        });

        modelBuilder.Entity<AttShiftdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_shif__3213E83FE5914618");

            entity.HasOne(d => d.Shift).WithMany(p => p.AttShiftdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_shiftdetail_shift_id_7d694501_fk_att_attshift_id");

            entity.HasOne(d => d.TimeInterval).WithMany(p => p.AttShiftdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_shiftdetail_time_interval_id_777dde8f_fk_att_timeinterval_id");
        });

        modelBuilder.Entity<AttTempschedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_temp__3213E83FB20A136C");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttTempschedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_tempschedule_employee_id_b89c7e54_fk_personnel_employee_id");
        });

        modelBuilder.Entity<AttTimeinterval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_time__3213E83FF06930D4");
        });

        modelBuilder.Entity<AttTimeintervalBreakTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_time__3213E83F3FB75137");

            entity.HasOne(d => d.Breaktime).WithMany(p => p.AttTimeintervalBreakTimes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_timeinterval_break_time_breaktime_id_08462308_fk_att_breaktime_id");

            entity.HasOne(d => d.Timeinterval).WithMany(p => p.AttTimeintervalBreakTimes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_timeinterval_break_time_timeinterval_id_2287017e_fk_att_timeinterval_id");
        });

        modelBuilder.Entity<AttTraining>(entity =>
        {
            entity.HasKey(e => e.AbstractexceptionPtrId).HasName("PK__att_trai__8D9209C92B8E5661");

            entity.Property(e => e.AbstractexceptionPtrId).ValueGeneratedNever();

            entity.HasOne(d => d.AbstractexceptionPtr).WithOne(p => p.AttTraining)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_training_abstractexception_ptr_id_60a3e8f3_fk_workflow_abstractexception_id");

            entity.HasOne(d => d.Category).WithMany(p => p.AttTrainings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_training_category_id_fb38e891_fk_att_trainingcategory_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttTrainings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("att_training_employee_id_44af8319_fk_personnel_employee_id");
        });

        modelBuilder.Entity<AttTrainingcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__att_trai__3213E83F9DE21D88");
        });

        modelBuilder.Entity<Attparam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__attparam__3213E83FACEAB3A9");
        });

        modelBuilder.Entity<AuthGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83F225949A5");
        });

        modelBuilder.Entity<AuthGroupPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83FDAD6309D");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthGroupPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthGroupPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_permission_id_84c5c92e_fk_auth_permission_id");
        });

        modelBuilder.Entity<AuthPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_per__3213E83F69FB28D6");

            entity.HasOne(d => d.ContentType).WithMany(p => p.AuthPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_content_type_id");
        });

        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83F6550F554");
        });

        modelBuilder.Entity<AuthUserAuthArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83F1F51C54A");

            entity.HasOne(d => d.Area).WithMany(p => p.AuthUserAuthAreas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_auth_area_area_id_d1e54c70_fk_personnel_area_id");

            entity.HasOne(d => d.Myuser).WithMany(p => p.AuthUserAuthAreas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_auth_area_myuser_id_5fb9a803_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserAuthDept>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83F7801F0F6");

            entity.HasOne(d => d.Department).WithMany(p => p.AuthUserAuthDepts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_auth_dept_department_id_5866c514_fk_personnel_department_id");

            entity.HasOne(d => d.Myuser).WithMany(p => p.AuthUserAuthDepts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_auth_dept_myuser_id_18a51b27_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83F61ADC7ED");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthUserGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_group_id_97559544_fk_auth_group_id");

            entity.HasOne(d => d.Myuser).WithMany(p => p.AuthUserGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_myuser_id_d03e8dcc_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83F2B30940F");

            entity.HasOne(d => d.User).WithOne(p => p.AuthUserProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_profile_user_id_f9aded29_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserUserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83F8AA29EBB");

            entity.HasOne(d => d.Myuser).WithMany(p => p.AuthUserUserPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_myuser_id_679b1527_fk_auth_user_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthUserUserPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_permission_id_1fbb5f2c_fk_auth_permission_id");
        });

        modelBuilder.Entity<AuthtokenToken>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK__authtoke__DFD83CAECF444165");

            entity.HasOne(d => d.User).WithOne(p => p.AuthtokenToken)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("authtoken_token_user_id_35299eff_fk_auth_user_id");
        });

        modelBuilder.Entity<BaseAdminlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_adm__3213E83F697CB160");

            entity.HasOne(d => d.ContentType).WithMany(p => p.BaseAdminlogs).HasConstraintName("base_adminlog_content_type_id_3e553c30_fk_django_content_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.BaseAdminlogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("base_adminlog_user_id_ecf659f8_fk_auth_user_id");
        });

        modelBuilder.Entity<BaseAttparamdept>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_att__3213E83F01BBDFE7");
        });

        modelBuilder.Entity<BaseAutoexporttask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_aut__3213E83F27C2212A");
        });

        modelBuilder.Entity<BaseBookmark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_boo__3213E83F421D48BA");

            entity.HasOne(d => d.ContentType).WithMany(p => p.BaseBookmarks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("base_bookmark_content_type_id_b6a0e799_fk_django_content_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.BaseBookmarks).HasConstraintName("base_bookmark_user_id_5f2d5ca2_fk_auth_user_id");
        });

        modelBuilder.Entity<BaseDbbackuplog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_dbb__3213E83F764026A2");
        });

        modelBuilder.Entity<BaseDbmigrate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_dbm__3213E83F65B36DB3");
        });

        modelBuilder.Entity<BaseLinenotifysetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_lin__3213E83FA197FFC9");

            entity.HasOne(d => d.LineNotifyDept).WithMany(p => p.BaseLinenotifysettings).HasConstraintName("base_linenotifysetting_line_notify_dept_id_0643a5ed_fk_personnel_department_id");
        });

        modelBuilder.Entity<BaseSendemail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_sen__3213E83F52E29B56");
        });

        modelBuilder.Entity<BaseSftpsetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_sft__3213E83FAEB4CDD4");
        });

        modelBuilder.Entity<BaseSysparam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_sys__3213E83FF4019914");
        });

        modelBuilder.Entity<BaseSysparamdept>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_sys__3213E83F3410805B");
        });

        modelBuilder.Entity<BaseSystemsetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_sys__3213E83F30B5E67A");
        });

        modelBuilder.Entity<BaseTaskresultlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__base_tas__3213E83F01D6CE15");
        });

        modelBuilder.Entity<CeleryTaskmetum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__celery_t__3213E83F6D7A5AFC");
        });

        modelBuilder.Entity<CeleryTasksetmetum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__celery_t__3213E83F47DE7712");
        });

        modelBuilder.Entity<DjangoAdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_a__3213E83F0DF81B54");

            entity.HasOne(d => d.ContentType).WithMany(p => p.DjangoAdminLogs).HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_content_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.DjangoAdminLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("django_admin_log_user_id_c564eba6_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_c__3213E83F57F78525");
        });

        modelBuilder.Entity<DjangoMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_m__3213E83FC40E1238");
        });

        modelBuilder.Entity<DjangoSession>(entity =>
        {
            entity.HasKey(e => e.SessionKey).HasName("PK__django_s__B3BA0F1F91026340");
        });

        modelBuilder.Entity<DjceleryCrontabschedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__djcelery__3213E83F0E4A7319");
        });

        modelBuilder.Entity<DjceleryIntervalschedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__djcelery__3213E83F53F9E338");
        });

        modelBuilder.Entity<DjceleryPeriodictask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__djcelery__3213E83FB57C651F");

            entity.HasOne(d => d.Crontab).WithMany(p => p.DjceleryPeriodictasks).HasConstraintName("djcelery_periodictask_crontab_id_75609bab_fk_djcelery_crontabschedule_id");

            entity.HasOne(d => d.Interval).WithMany(p => p.DjceleryPeriodictasks).HasConstraintName("djcelery_periodictask_interval_id_b426ab02_fk_djcelery_intervalschedule_id");
        });

        modelBuilder.Entity<DjceleryPeriodictask1>(entity =>
        {
            entity.HasKey(e => e.Ident).HasName("PK__djcelery__07D87A798D69F81E");

            entity.Property(e => e.Ident).ValueGeneratedNever();
        });

        modelBuilder.Entity<DjceleryTaskstate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__djcelery__3213E83FDC166B0D");

            entity.HasOne(d => d.Worker).WithMany(p => p.DjceleryTaskstates).HasConstraintName("djcelery_taskstate_worker_id_f7f57a05_fk_djcelery_workerstate_id");
        });

        modelBuilder.Entity<DjceleryWorkerstate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__djcelery__3213E83FA9C4FE4B");
        });

        modelBuilder.Entity<EpEpsetup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ep_epset__3213E83F6F373266");
        });

        modelBuilder.Entity<EpEptransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ep_eptra__3213E83FBE513C76");

            entity.HasOne(d => d.Emp).WithMany(p => p.EpEptransactions).HasConstraintName("ep_eptransaction_emp_id_1006883f_fk_personnel_employee_id");

            entity.HasOne(d => d.Terminal).WithMany(p => p.EpEptransactions).HasConstraintName("ep_eptransaction_terminal_id_4490b209_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<GuardianGroupobjectpermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__guardian__3213E83FEBF39118");

            entity.HasOne(d => d.ContentType).WithMany(p => p.GuardianGroupobjectpermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("guardian_groupobjectpermission_content_type_id_7ade36b8_fk_django_content_type_id");

            entity.HasOne(d => d.Group).WithMany(p => p.GuardianGroupobjectpermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("guardian_groupobjectpermission_group_id_4bbbfb62_fk_auth_group_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.GuardianGroupobjectpermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("guardian_groupobjectpermission_permission_id_36572738_fk_auth_permission_id");
        });

        modelBuilder.Entity<GuardianUserobjectpermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__guardian__3213E83FC12593AF");

            entity.HasOne(d => d.ContentType).WithMany(p => p.GuardianUserobjectpermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("guardian_userobjectpermission_content_type_id_2e892405_fk_django_content_type_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.GuardianUserobjectpermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("guardian_userobjectpermission_permission_id_71807bfc_fk_auth_permission_id");

            entity.HasOne(d => d.User).WithMany(p => p.GuardianUserobjectpermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("guardian_userobjectpermission_user_id_d5c1e964_fk_auth_user_id");
        });

        modelBuilder.Entity<IclockBiodatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_b__3213E83FB6E767ED");

            entity.HasOne(d => d.Employee).WithMany(p => p.IclockBiodata)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_biodata_employee_id_ff748ea7_fk_personnel_employee_id");
        });

        modelBuilder.Entity<IclockBiophoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_b__3213E83FF374696F");

            entity.HasOne(d => d.Employee).WithMany(p => p.IclockBiophotos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_biophoto_employee_id_3dba5819_fk_personnel_employee_id");
        });

        modelBuilder.Entity<IclockDeviceconfig>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__iclock_d__7F42793084CFD3D8");
        });

        modelBuilder.Entity<IclockErrorcommandlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_e__3213E83FF1C37284");

            entity.HasOne(d => d.Terminal).WithMany(p => p.IclockErrorcommandlogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_errorcommandlog_terminal_id_3b2d7cbd_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<IclockPrivatemessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_p__3213E83F34FE3B43");

            entity.HasOne(d => d.Employee).WithMany(p => p.IclockPrivatemessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_privatemessage_employee_id_e84a34c0_fk_personnel_employee_id");
        });

        modelBuilder.Entity<IclockPublicmessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_p__3213E83FB4386624");

            entity.HasOne(d => d.Terminal).WithMany(p => p.IclockPublicmessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_publicmessage_terminal_id_c3b5e4cf_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<IclockTerminal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_t__3213E83F3339C402");

            entity.HasOne(d => d.Area).WithMany(p => p.IclockTerminals).HasConstraintName("iclock_terminal_area_id_c019c6f0_fk_personnel_area_id");
        });

        modelBuilder.Entity<IclockTerminalcommand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_t__3213E83F3DD6BC1A");

            entity.HasOne(d => d.Terminal).WithMany(p => p.IclockTerminalcommands)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_terminalcommand_terminal_id_3dcf836f_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<IclockTerminalemployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_t__3213E83FD4330E30");
        });

        modelBuilder.Entity<IclockTerminallog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_t__3213E83F25FFEC88");

            entity.HasOne(d => d.Terminal).WithMany(p => p.IclockTerminallogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_terminallog_terminal_id_667b3ea7_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<IclockTerminalparameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_t__3213E83FDFFE338F");

            entity.HasOne(d => d.Terminal).WithMany(p => p.IclockTerminalparameters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_terminalparameter_terminal_id_443872e3_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<IclockTerminaluploadlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_t__3213E83F7ED8AA8D");

            entity.HasOne(d => d.Terminal).WithMany(p => p.IclockTerminaluploadlogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_terminaluploadlog_terminal_id_9c9a7664_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<IclockTerminalworkcode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_t__3213E83FA7DDC82E");
        });

        modelBuilder.Entity<IclockTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_t__3213E83F6BC2015E");

            entity.HasOne(d => d.Emp).WithMany(p => p.IclockTransactions).HasConstraintName("iclock_transaction_emp_id_60fa3521_fk_personnel_employee_id");

            entity.HasOne(d => d.Terminal).WithMany(p => p.IclockTransactions).HasConstraintName("iclock_transaction_terminal_id_451c81c2_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<IclockTransactionproofcmd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__iclock_t__3213E83F08E60C6C");

            entity.HasOne(d => d.Terminal).WithMany(p => p.IclockTransactionproofcmds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iclock_transactionproofcmd_terminal_id_08b81e1e_fk_iclock_terminal_id");
        });

        modelBuilder.Entity<MobileAnnouncement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mobile_a__3213E83FE463940A");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MobileAnnouncements).HasConstraintName("mobile_announcement_receiver_id_ddf2a860_fk_personnel_employee_id");
        });

        modelBuilder.Entity<MobileAppactionlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mobile_a__3213E83FC2AEE712");
        });

        modelBuilder.Entity<MobileApplist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mobile_a__3213E83FB54E1A6B");
        });

        modelBuilder.Entity<MobileAppnotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mobile_a__3213E83FC5272B57");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MobileAppnotifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mobile_appnotification_receiver_id_90c4a355_fk_personnel_employee_id");
        });

        modelBuilder.Entity<MobileGpsfordepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mobile_g__3213E83F15E7AB1E");

            entity.HasOne(d => d.Department).WithMany(p => p.MobileGpsfordepartments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mobile_gpsfordepartment_department_id_988ccf22_fk_personnel_department_id");
        });

        modelBuilder.Entity<MobileGpsforemployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mobile_g__3213E83F59D8F3BE");

            entity.HasOne(d => d.Employee).WithMany(p => p.MobileGpsforemployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mobile_gpsforemployee_employee_id_982b7cef_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PayrollDeductionformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F63361A0C");
        });

        modelBuilder.Entity<PayrollEmploan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83FFE27CBB8");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayrollEmploans).HasConstraintName("payroll_emploan_employee_id_97a251ef_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PayrollEmppayrollprofile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83FA681248F");

            entity.HasOne(d => d.Employee).WithOne(p => p.PayrollEmppayrollprofile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_emppayrollprofile_employee_id_6c97078c_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PayrollExceptionformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F9B19B79B");
        });

        modelBuilder.Entity<PayrollExtradeduction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F880532BC");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayrollExtradeductions).HasConstraintName("payroll_extradeduction_employee_id_53072441_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PayrollExtraincrease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83FAAD7AB84");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayrollExtraincreases).HasConstraintName("payroll_extraincrease_employee_id_f902e6bb_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PayrollIncreasementformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F63D5D059");
        });

        modelBuilder.Entity<PayrollLeaveformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F4AFBD69A");

            entity.HasOne(d => d.Category).WithMany(p => p.PayrollLeaveformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_leaveformula_category_id_945b2054_fk_att_leavecategory_id");
        });

        modelBuilder.Entity<PayrollMonthlysalary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F46B62D0F");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayrollMonthlysalaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_monthlysalary_employee_id_97fdc6a9_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PayrollOvertimeformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F9571C40B");
        });

        modelBuilder.Entity<PayrollReimbursement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F72893FC3");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayrollReimbursements).HasConstraintName("payroll_reimbursement_employee_id_c4bbde36_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PayrollSalaryadvance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F68D0570B");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayrollSalaryadvances).HasConstraintName("payroll_salaryadvance_employee_id_2abd43e5_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PayrollSalarystructure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F24438468");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayrollSalarystructures).HasConstraintName("payroll_salarystructure_employee_id_98996e15_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PayrollSalarystructureDeductionformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F82C53260");

            entity.HasOne(d => d.Deductionformula).WithMany(p => p.PayrollSalarystructureDeductionformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_deductionformula_deductionformula_id_b174d5b6_fk_payroll_deductionformula_id");

            entity.HasOne(d => d.Salarystructure).WithMany(p => p.PayrollSalarystructureDeductionformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_deductionformula_salarystructure_id_5ca7cdb5_fk_payroll_salarystructure_id");
        });

        modelBuilder.Entity<PayrollSalarystructureExceptionformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F7128136D");

            entity.HasOne(d => d.Exceptionformula).WithMany(p => p.PayrollSalarystructureExceptionformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_exceptionformula_exceptionformula_id_8f6dadb3_fk_payroll_exceptionformula_id");

            entity.HasOne(d => d.Salarystructure).WithMany(p => p.PayrollSalarystructureExceptionformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_exceptionformula_salarystructure_id_3c087208_fk_payroll_salarystructure_id");
        });

        modelBuilder.Entity<PayrollSalarystructureIncreasementformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83F537392B4");

            entity.HasOne(d => d.Increasementformula).WithMany(p => p.PayrollSalarystructureIncreasementformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_increasementformula_increasementformula_id_3cd77082_fk_payroll_increasementformula_id");

            entity.HasOne(d => d.Salarystructure).WithMany(p => p.PayrollSalarystructureIncreasementformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_increasementformula_salarystructure_id_8752401c_fk_payroll_salarystructure_id");
        });

        modelBuilder.Entity<PayrollSalarystructureLeaveformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83FFE8B3B33");

            entity.HasOne(d => d.Leaveformula).WithMany(p => p.PayrollSalarystructureLeaveformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_leaveformula_leaveformula_id_049f9024_fk_payroll_leaveformula_id");

            entity.HasOne(d => d.Salarystructure).WithMany(p => p.PayrollSalarystructureLeaveformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_leaveformula_salarystructure_id_cf98fdd7_fk_payroll_salarystructure_id");
        });

        modelBuilder.Entity<PayrollSalarystructureOvertimeformula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payroll___3213E83FD0876AD5");

            entity.HasOne(d => d.Overtimeformula).WithMany(p => p.PayrollSalarystructureOvertimeformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_overtimeformula_overtimeformula_id_40ad89ef_fk_payroll_overtimeformula_id");

            entity.HasOne(d => d.Salarystructure).WithMany(p => p.PayrollSalarystructureOvertimeformulas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payroll_salarystructure_overtimeformula_salarystructure_id_64f75042_fk_payroll_salarystructure_id");
        });

        modelBuilder.Entity<PersonnelArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83F10374B2D");

            entity.HasOne(d => d.ParentArea).WithMany(p => p.InverseParentArea).HasConstraintName("personnel_area_parent_area_id_39028fda_fk_personnel_area_id");
        });

        modelBuilder.Entity<PersonnelAssignareaemployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83F42890241");

            entity.HasOne(d => d.Area).WithMany(p => p.PersonnelAssignareaemployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_assignareaemployee_area_id_6f049d6a_fk_personnel_area_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.PersonnelAssignareaemployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_assignareaemployee_employee_id_a3d4dd25_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PersonnelCertification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83FF74C85EF");
        });

        modelBuilder.Entity<PersonnelCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83FBAE9797A");
        });

        modelBuilder.Entity<PersonnelDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83FEC498342");

            entity.HasOne(d => d.Company).WithMany(p => p.PersonnelDepartments).HasConstraintName("personnel_department_company_id_00867fd8_fk_personnel_company_id");

            entity.HasOne(d => d.ParentDept).WithMany(p => p.InverseParentDept).HasConstraintName("personnel_department_parent_dept_id_d0b44024_fk_personnel_department_id");
        });

        modelBuilder.Entity<PersonnelEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83F1BC63646");

            entity.HasOne(d => d.Department).WithMany(p => p.PersonnelEmployees).HasConstraintName("personnel_employee_department_id_068bbd08_fk_personnel_department_id");

            entity.HasOne(d => d.Position).WithMany(p => p.PersonnelEmployees).HasConstraintName("personnel_employee_position_id_c9321343_fk_personnel_position_id");
        });

        modelBuilder.Entity<PersonnelEmployeeArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83F4BF23381");

            entity.HasOne(d => d.Area).WithMany(p => p.PersonnelEmployeeAreas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_employee_area_area_id_64c21925_fk_personnel_area_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.PersonnelEmployeeAreas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_employee_area_employee_id_8e5cec21_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PersonnelEmployeeFlowRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83F5CB77B42");

            entity.HasOne(d => d.Employee).WithMany(p => p.PersonnelEmployeeFlowRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_employee_flow_role_employee_id_c27f8a56_fk_personnel_employee_id");

            entity.HasOne(d => d.Workflowrole).WithMany(p => p.PersonnelEmployeeFlowRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_employee_flow_role_workflowrole_id_4704db32_fk_workflow_workflowrole_id");
        });

        modelBuilder.Entity<PersonnelEmployeecertification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83F4D9636F9");

            entity.HasOne(d => d.Certification).WithMany(p => p.PersonnelEmployeecertifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_employeecertification_certification_id_faabed40_fk_personnel_certification_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.PersonnelEmployeecertifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_employeecertification_employee_id_b7bd3867_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PersonnelEmployeeprofile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83F389D9EB5");

            entity.HasOne(d => d.Emp).WithOne(p => p.PersonnelEmployeeprofile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_employeeprofile_emp_id_3a69c313_fk_personnel_employee_id");
        });

        modelBuilder.Entity<PersonnelPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83F03280C06");

            entity.HasOne(d => d.ParentPosition).WithMany(p => p.InverseParentPosition).HasConstraintName("personnel_position_parent_position_id_a496a36b_fk_personnel_position_id");
        });

        modelBuilder.Entity<PersonnelResign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personne__3213E83F9B2FAF54");

            entity.HasOne(d => d.Employee).WithOne(p => p.PersonnelResign)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personnel_resign_employee_id_dd9b7e08_fk_personnel_employee_id");
        });

        modelBuilder.Entity<StaffStafftoken>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK__staff_st__DFD83CAEA575DFC0");

            entity.HasOne(d => d.User).WithOne(p => p.StaffStafftoken)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staff_stafftoken_user_id_39c937fa_fk_personnel_employee_id");
        });

        modelBuilder.Entity<SyncArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sync_are__3213E83F6465ECCD");
        });

        modelBuilder.Entity<SyncDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sync_dep__3213E83FBAF135FD");
        });

        modelBuilder.Entity<SyncEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sync_emp__3213E83FB4B703E7");
        });

        modelBuilder.Entity<SyncJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sync_job__3213E83FDE7822C4");
        });

        modelBuilder.Entity<WorkflowAbstractexception>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workflow__3213E83F1FC0262B");
        });

        modelBuilder.Entity<WorkflowNodeinstance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workflow__3213E83FDC754B71");

            entity.HasOne(d => d.ApproverAdmin).WithMany(p => p.WorkflowNodeinstances).HasConstraintName("workflow_nodeinstance_approver_admin_id_dff58806_fk_auth_user_id");

            entity.HasOne(d => d.ApproverEmployee).WithMany(p => p.WorkflowNodeinstances).HasConstraintName("workflow_nodeinstance_approver_employee_id_d36cd45d_fk_personnel_employee_id");

            entity.HasOne(d => d.Departments).WithMany(p => p.WorkflowNodeinstances).HasConstraintName("workflow_nodeinstance_departments_id_b0dc2bdb_fk_personnel_department_id");

            entity.HasOne(d => d.NodeEngine).WithMany(p => p.WorkflowNodeinstances).HasConstraintName("workflow_nodeinstance_node_engine_id_4533f12d_fk_workflow_workflownode_id");

            entity.HasOne(d => d.WorkflowInstance).WithMany(p => p.WorkflowNodeinstances).HasConstraintName("workflow_nodeinstance_workflow_instance_id_afe84fe4_fk_workflow_workflowinstance_id");
        });

        modelBuilder.Entity<WorkflowWorkflowengine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workflow__3213E83F591BC9BE");

            entity.HasOne(d => d.ApplicantPosition).WithMany(p => p.WorkflowWorkflowengines).HasConstraintName("workflow_workflowengine_applicant_position_id_8a65e03a_fk_personnel_position_id");

            entity.HasOne(d => d.ContentType).WithMany(p => p.WorkflowWorkflowengines).HasConstraintName("workflow_workflowengine_content_type_id_f7345c20_fk_django_content_type_id");

            entity.HasOne(d => d.Departments).WithMany(p => p.WorkflowWorkflowengines).HasConstraintName("workflow_workflowengine_departments_id_0f06d4c7_fk_personnel_department_id");
        });

        modelBuilder.Entity<WorkflowWorkflowengineEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workflow__3213E83FF4001AC6");

            entity.HasOne(d => d.Employee).WithMany(p => p.WorkflowWorkflowengineEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workflow_workflowengine_employee_employee_id_803a409e_fk_personnel_employee_id");

            entity.HasOne(d => d.Workflowengine).WithMany(p => p.WorkflowWorkflowengineEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workflow_workflowengine_employee_workflowengine_id_6ebcc5f2_fk_workflow_workflowengine_id");
        });

        modelBuilder.Entity<WorkflowWorkflowinstance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workflow__3213E83FF53DE06D");

            entity.HasOne(d => d.Employee).WithMany(p => p.WorkflowWorkflowinstances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workflow_workflowinstance_employee_id_c7cff08e_fk_personnel_employee_id");

            entity.HasOne(d => d.Exception).WithOne(p => p.WorkflowWorkflowinstance).HasConstraintName("workflow_workflowinstance_exception_id_6c82a5d8_fk_workflow_abstractexception_id");

            entity.HasOne(d => d.WorkflowEngine).WithMany(p => p.WorkflowWorkflowinstances).HasConstraintName("workflow_workflowinstance_workflow_engine_id_1e6ac40f_fk_workflow_workflowengine_id");
        });

        modelBuilder.Entity<WorkflowWorkflownode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workflow__3213E83FB92987C9");
        });

        modelBuilder.Entity<WorkflowWorkflownodeApprover>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workflow__3213E83F29302A6E");

            entity.HasOne(d => d.Workflownode).WithMany(p => p.WorkflowWorkflownodeApprovers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workflow_workflownode_approver_workflownode_id_d814c941_fk_workflow_workflownode_id");

            entity.HasOne(d => d.Workflowrole).WithMany(p => p.WorkflowWorkflownodeApprovers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workflow_workflownode_approver_workflowrole_id_c8e00d42_fk_workflow_workflowrole_id");
        });

        modelBuilder.Entity<WorkflowWorkflownodeNotifier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workflow__3213E83F7D19B382");

            entity.HasOne(d => d.Workflownode).WithMany(p => p.WorkflowWorkflownodeNotifiers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workflow_workflownode_notifier_workflownode_id_57298016_fk_workflow_workflownode_id");

            entity.HasOne(d => d.Workflowrole).WithMany(p => p.WorkflowWorkflownodeNotifiers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workflow_workflownode_notifier_workflowrole_id_73de7fc2_fk_workflow_workflowrole_id");
        });

        modelBuilder.Entity<WorkflowWorkflowrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workflow__3213E83FDAE96D2E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
