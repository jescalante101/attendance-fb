using AutoMapper;
using FibraAttendance.Data;
using FibraAttendance.DTOs;
using FibraAttendance.Models;
using FibraAttendance.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace FibraAttendance.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AttendanceController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AttendanceController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("lstDescansos")]
        public async Task<ActionResult<IEnumerable<AttBreaktime>>> getAttBreakTime([FromQuery] int page = 1, [FromQuery] int pageSize=10)
        {
            var totalTransactions = await _context.AttBreaktimes.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalTransactions / pageSize);

            if(page<1 || page> totalPages)
            {
                return BadRequest("Número de páginas inválido");
            }

            var lstAttBreaksTimes = await _context.AttBreaktimes.
                Skip((page - 1) / pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(
                   new {
                data=lstAttBreaksTimes,
                totalRecords=totalTransactions
            }
                );


        }

        [HttpGet("lstHorarios")]
        public async Task<ActionResult<IEnumerable<AttTimeinterval>>> getListShiftDetails([FromQuery] int page = 1, [FromQuery] int pageSize=15)
        {
            var totalTransactions = await _context.AttTimeintervals.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalTransactions / pageSize);

            if (page < 1 || page > totalPages)
            {
                return BadRequest("Número de página inválido.");
            }

            var lstShiftDetails = await _context.AttTimeintervals
                .Skip((page - 1) * pageSize)
            .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                data=lstShiftDetails,
                totalRecords=totalTransactions
            });
        }

        [HttpGet("lstHoraiosMap")]
        public async Task<ActionResult<IEnumerable<HorarioInfoDto>>> getHorarioslst([FromQuery] int page = 1, [FromQuery] int pageSize = 15)
        {
            var totalTransactions = await _context.AttTimeintervals.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalTransactions / pageSize);

            if (page < 1 || page > totalPages)
            {
                return BadRequest("Número de página inválido.");
            }

            var lstShiftDetails = await _context.AttTimeintervals
                .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(h=>h.AttTimeintervalBreakTimes)
            .ThenInclude(br=>br.Breaktime)
                .ToListAsync();
            var newDate = _mapper.Map<List<HorarioInfoDto>>(lstShiftDetails);

            return Ok(new
            {
                data = newDate,
                totalRecords = totalTransactions
            });
        }


        [HttpGet("horarioPorId/{id}")]
        public async Task<ActionResult<HorarioInfoDto>> findById( int id)
        {

            var horario = await _context.AttTimeintervals
                             .Include(h => h.AttTimeintervalBreakTimes) // Cargar la colección
                                 .ThenInclude(bt => bt.Breaktime)     // Y luego la relación dentro de la colección
                             .Where(t => t.Id == id)
                             .FirstOrDefaultAsync();

            if (horario == null)
            {
                return NotFound();
            }

            var newData = _mapper.Map<HorarioInfoDto>(horario);

            var breaktime = await _context.AttTimeintervalBreakTimes.Where(t => t.TimeintervalId == id).FirstOrDefaultAsync();


            return Ok(new
            {
                horario=newData,
                breaktime.BreaktimeId
            });
        }

        

        [HttpPost("nuevoHorario")]
        public async Task<ActionResult<AttTimeinterval>> GuardarHorario([FromBody] HorarioInfoDto attTimeinterval)
        {

            //_context.AttTimeintervals.Add(attTimeinterval);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction(nameof(getListShiftDetails),
            //    new { id = attTimeinterval.Id }, attTimeinterval);
            AttTimeinterval interval = new AttTimeinterval();

            interval.Alias = attTimeinterval.Nombre;
            interval.UseMode = short.Parse(attTimeinterval.Tipo.ToString());
            interval.InTime = ConvertirHoras.StringToDateTime(attTimeinterval.HoraEntrada);
            interval.InAheadMargin = (int)ConvertirHoras.ObtenerDiferenciaEnMinutos(attTimeinterval.HoraEntrada, attTimeinterval.HoraEntradaDesde);

            Console.WriteLine(attTimeinterval);
            return Ok(new
            {
                mensaje="Exito",
                attTimeinterval
            });
        }



        [HttpGet("lstShifts")]
        public async Task<ActionResult<IEnumerable<AttAttshift>>> getAttShift([FromQuery] int page=1, [FromQuery] int pageSize=10)
        {
            var totalTransactions = await _context.AttAttshifts.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalTransactions / pageSize);

            if(page<1 || page > totalPages)
            {
                return BadRequest("Número de páginas inválido");
            }

            var lstAttShift = await _context.AttAttshifts
                .Select(shift => new
                {
                    shift.Alias,
                    shift.ShiftCycle,
                    shift.CycleUnit,
                    shift.AutoShift,
                    shift.WorkDayOff,
                    shift.WeekendType,
                    horario=shift.AttShiftdetails.Select(det => new
                    {
                        det.TimeInterval.Alias
                    }).Distinct(),
                    thoras = shift.AttShiftdetails.Select(tho => new
                    {
                        tho.DayIndex,
                        tho.TimeInterval.InTime,
                        tho.TimeInterval.WorkTimeDuration
                    })
                }
                )
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(
                new
                {
                    data= lstAttShift,
                    totalRecords=totalTransactions
                });

        }
    }
}
