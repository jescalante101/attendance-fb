using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entity
{
    public class EmployeeScheduleAssignment
    {
        [Column("assignment_id")]
        public int AssignmentId { get; set; }

        [Column("employee_id")]
        public string EmployeeId { get; set; }

        [Column("schedule_id")]
        public int ScheduleId { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Column("remarks")]
        public string? Remarks { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public string? CrearteBY { get; set; }
        // New fields to store full name and shift description
        [Column("fullNameEmployee")]
        public string? FullName { get; set; }  // Store the full name of the employee

        [Column("shiftDescription")]
        public string? ShiftDescription { get; set; }  // Store the shift description

        [Column("NroDoc")]
        public string? NroDoc { get; set; }

        [Column("AreaId")]
        public string? AreaId { get; set; }

        [Column("AreaDescription")]
        public string? AreaDescription { get; set; }  // Store the name of the area

        [Column("LocationId")]
        public string? LocationId { get; set; }  // Store the location ID
        [Column("LocationName")]
        public string? LocationName { get; set; }  // Store the name of the location
    }
}
