using FibraAttendance.Data;
using FibraAttendance.DTOs;
using FibraAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Controllers.ShiftController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ShiftController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("lstShifts")]
        public async Task<ActionResult<IEnumerable<AttAttshift>>> getAttShift([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var totalTransactions = await _context.AttAttshifts.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalTransactions / pageSize);

            if (page < 1 || page > totalPages)
            {
                return BadRequest("Número de páginas inválido");
            }

            var lstAttShift = await _context.AttAttshifts
                 .Select(shift => new
                 {
                     shift.Id,
                     shift.Alias,
                     shift.ShiftCycle,
                     shift.CycleUnit,
                     shift.AutoShift,
                     shift.WorkDayOff,
                     shift.WeekendType,
                     horario = shift.AttShiftdetails
                         .Select(det => new
                         {
                             det.DayIndex,
                             det.TimeInterval.Alias,
                             det.TimeInterval.InTime,
                             det.TimeInterval.WorkTimeDuration
                         })
                         .Distinct()
                         .ToList()
                 })
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();


            return Ok(
                new
                {
                    data = lstAttShift,
                    totalRecords = totalTransactions
                });

        }

        [HttpGet("shiftPorId/{id}")]
        public async Task<ActionResult> GetShiftById(int id)
        {
            var shift = await _context.AttAttshifts
                .Where(s => s.Id == id)
                .Select(shift => new
                {
                    shift.Id,
                    shift.Alias,
                    shift.ShiftCycle,
                    shift.CycleUnit,
                    shift.AutoShift,
                    shift.WorkDayOff,
                    shift.WeekendType,
                    horario = shift.AttShiftdetails.Select(det => new
                    {
                        det.TimeInterval.Alias
                    }).Distinct(),
                    thoras = shift.AttShiftdetails.Select(tho => new
                    {
                        tho.DayIndex,
                        tho.TimeInterval.InTime,
                        tho.TimeInterval.WorkTimeDuration
                    })
                })
                .FirstOrDefaultAsync();

            if (shift == null)
                return NotFound(new { mensaje = "Turno no encontrado." });

            return Ok(shift);
        }


        [HttpPost("nuevoShift")]
        public async Task<IActionResult> NuevoShift([FromBody] ShiftCreateDto dto)
        {
            var shift = new AttAttshift
            {
                Alias = dto.Alias,
                CycleUnit = dto.CycleUnit,
                ShiftCycle = dto.ShiftCycle,
                WorkWeekend = dto.WorkWeekend,
                WeekendType = dto.WeekendType,
                WorkDayOff = dto.WorkDayOff,
                DayOffType = dto.DayOffType,
                AutoShift = dto.AutoShift,
                AttShiftdetails = new List<AttShiftdetail>()
            };

            foreach (var det in dto.Detalles)
            {
                // Busca el intervalo para obtener el in_time y out_time
                var intervalo = await _context.AttTimeintervals.FindAsync(det.TimeIntervalId);
                if (intervalo == null)
                    return BadRequest($"No existe el intervalo con id {det.TimeIntervalId}");

                var detalle = new AttShiftdetail
                {
                    InTime = intervalo.InTime,
                    OutTime = intervalo.InTime.AddMinutes(intervalo.WorkTimeDuration),
                    DayIndex = det.DayIndex,
                    TimeIntervalId = det.TimeIntervalId
                    // ShiftId se asigna automáticamente al guardar el shift
                };
                shift.AttShiftdetails.Add(detalle);
            }

            _context.AttAttshifts.Add(shift);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Shift creado correctamente", id = shift.Id });
        }

    }
}
