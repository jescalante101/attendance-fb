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

        [HttpGet("descansoPorId/{id}")]
        public async Task<ActionResult<DescansoInfoDto>> getAttBreakTimeById(int id)
        {
            var descanso = await _context.AttBreaktimes
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
            if (descanso == null)
            {
                return NotFound(new { mensaje = "Descanso no encontrado." });
            }
            var descansoDto = _mapper.Map<DescansoInfoDto>(descanso);
            return Ok(descansoDto);
        }

        [HttpPost("nuevoDescanso")]
        public async Task<ActionResult<DescansoInfoDto>> nuevoDescanso([FromBody] DescansoInfoDto descansoInfo)
        {
            AttBreaktime breaktime = new AttBreaktime();
            breaktime.Alias = descansoInfo.Alias;
            breaktime.PeriodStart = ConvertirHoras.ParsearFechaHora(descansoInfo.PeriodStart);
            breaktime.Duration = descansoInfo.Duration;
            breaktime.AvailableIntervalType =(short) descansoInfo.AvailableIntervalType;
            breaktime.AvailableInterval = (short)descansoInfo.AvailableInterval;
            breaktime.EndMargin = ConvertirHoras.ObtenerDiferenciaEnMinutos(descansoInfo.PeriodStart, descansoInfo.EndMargin);
            breaktime.LateIn =(short) descansoInfo.LateIn;
            breaktime.MinLateIn = (short)descansoInfo.MinLateIn;
            breaktime.MinEarlyIn = (short)descansoInfo.MinEarlyIn;
            breaktime.MultiplePunch = (short)descansoInfo.MultiplePunch;
            _context.AttBreaktimes.Add(breaktime);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Horario eliminado correctamente." });
        }

        [HttpPut("actualizarDescanso/")]
        public async Task<ActionResult<DescansoInfoDto>> ActualizarDescanso([FromBody] DescansoInfoDto descansoInfo)
        {
            var descanso = await _context.AttBreaktimes
                .FirstOrDefaultAsync(d => d.Id == descansoInfo.Id);
            if (descanso == null)
                return NotFound(new { mensaje = "Descanso no encontrado." });
            descanso.Alias = descansoInfo.Alias;
            descanso.PeriodStart = ConvertirHoras.ParsearFechaHora(descansoInfo.PeriodStart);
            descanso.Duration = descansoInfo.Duration;
            descanso.AvailableIntervalType = (short)descansoInfo.AvailableIntervalType;
            descanso.AvailableInterval = (short)descansoInfo.AvailableInterval;
            descanso.EndMargin = ConvertirHoras.ObtenerDiferenciaEnMinutos(descansoInfo.PeriodStart, descansoInfo.EndMargin);
            descanso.LateIn = (short)descansoInfo.LateIn;
            descanso.MinLateIn = (short)descansoInfo.MinLateIn;
            descanso.MinEarlyIn = (short)descansoInfo.MinEarlyIn;
            descanso.MultiplePunch = (short)descansoInfo.MultiplePunch;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Actualizado con éxito." });
        }

        [HttpDelete("eliminarDescanso/{id}")]
        public async Task<IActionResult> EliminarDescanso(int id)
        {
            var descanso = await _context.AttBreaktimes
                .FirstOrDefaultAsync(d => d.Id == id);
            if (descanso == null)
            {
                return NotFound(new { mensaje = "Descanso no encontrado." });
            }
            _context.AttBreaktimes.Remove(descanso);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Descanso eliminado correctamente." });
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
                 .OrderByDescending(h => h.Id)
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
                BreaktimeId = breaktime?.BreaktimeId ?? 0

            });
        }

        

        [HttpPost("nuevoHorario")]
        public async Task<ActionResult<AttTimeinterval>> GuardarHorario([FromBody] HorarioInfoDto attTimeinterval)
        {
            AttTimeinterval interval = new AttTimeinterval();

            if (attTimeinterval.Tipo == 0)
            {



                interval.Alias = attTimeinterval.Nombre;
                interval.UseMode = short.Parse(attTimeinterval.Tipo.ToString());
                interval.InTime = ConvertirHoras.ParsearFechaHora(attTimeinterval.HoraEntrada);

                var tolerancias = CalcularTolerancias.ObtenerTolerancias(
                    attTimeinterval.HoraEntrada,
                    attTimeinterval.HoraSalida,
                    attTimeinterval.HoraEntradaDesde,
                    attTimeinterval.HoraEntradaHasta,
                    attTimeinterval.HoraSalidaDesde,
                    attTimeinterval.HoraSalidaHasta
                );

                interval.InAheadMargin = Convert.ToInt32(tolerancias.ToleranciaEntradaDesdeMinutos);
                interval.InAboveMargin = Convert.ToInt32(tolerancias.ToleranciaEntradaHastaMinutos);
                interval.OutAheadMargin = Convert.ToInt32(tolerancias.ToleranciaSalidaDesdeMinutos);
                interval.OutAboveMargin = Convert.ToInt32(tolerancias.ToleranciaSalidaHastaMinutos);
                interval.Duration = Convert.ToInt32(tolerancias.TiempoTrabajoMinutos);
                interval.InRequired = Convert.ToInt32(attTimeinterval.MarcarEntrada) == 0 ? (short)0 : (short)1;
                interval.OutRequired = Convert.ToInt32(attTimeinterval.MarcarSalida) == 0 ? (short)0 : (short)1;
                interval.AllowLate = Convert.ToInt32(attTimeinterval.PSalidaT);
                interval.AllowLeaveEarly = Convert.ToInt32(attTimeinterval.PLlegadaT);
                interval.AvailableIntervalType = (short)attTimeinterval.TipoIntervalo;
                interval.WorkDay = Convert.ToDouble(attTimeinterval.DiasLaboral);
                interval.MultiplePunch = (short)attTimeinterval.BasadoM;
                interval.AvailableInterval = attTimeinterval.PeriodoMarcacion;
                interval.WorkType = 0;

                interval.DayChange = DateTime.Today;


                interval.OvertimeLv = (short)attTimeinterval.Hnivel;
                interval.OvertimeLv1 = (short)attTimeinterval.HNivel1;
                interval.OvertimeLv2 = (short)attTimeinterval.HNivel2;
                interval.OvertimeLv3 = (short)attTimeinterval.HNivel3;
                interval.WorkTimeDuration = Convert.ToInt32(tolerancias.TiempoTrabajoMinutos);
                interval.MinEarlyIn = Convert.ToInt32(attTimeinterval.MinEntradaTemprana);
                interval.MinLateOut = Convert.ToInt32(attTimeinterval.MinSalidaTarde);
                interval.LateOut = (short)Convert.ToInt32(attTimeinterval.EntradaTarde);
                interval.EarlyIn = (short)Convert.ToInt32(attTimeinterval.EntradaTemprana);
                interval.AttTimeintervalBreakTimes = new List<AttTimeintervalBreakTime>();

                // Fix: Ensure Descanso is treated as a collection of integers
                var breakTimeIds = new List<int> { attTimeinterval.Descanso }; // Assuming Descanso is a single int, wrap it in a list
                foreach (var breakTimeId in breakTimeIds)
                {
                    var breakTimeEntity = await _context.AttBreaktimes.FindAsync(breakTimeId);
                    if (breakTimeEntity != null)
                    {
                        var attTimeintervalBreakTime = new AttTimeintervalBreakTime
                        {
                            BreaktimeId = breakTimeId,
                            TimeintervalId = interval.Id
                        };
                        interval.AttTimeintervalBreakTimes.Add(attTimeintervalBreakTime);
                    }
                }
                _context.AttTimeintervals.Add(interval);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(getHorarioslst), new { id = interval.Id });
            }
            else
            {
                interval.Alias = attTimeinterval.Nombre;
                interval.UseMode = short.Parse(attTimeinterval.Tipo.ToString());
                interval.InTime = ConvertirHoras.ParsearFechaHora(attTimeinterval.HoraEntrada);
                interval.WorkTimeDuration = ConvertirHoras.ObtenerDiferenciaEnMinutos(attTimeinterval.HoraEntrada,attTimeinterval.HoraSalida);
                interval.EarlyIn = (short)Convert.ToInt32(attTimeinterval.EntradaTemprana);
                interval.MinEarlyIn = (short)Convert.ToInt32(attTimeinterval.MinEntradaTemprana);
                interval.OvertimeLv = (short)attTimeinterval.Hnivel;
                interval.OvertimeLv1 = (short)attTimeinterval.HNivel1;
                interval.OvertimeLv2 = (short)attTimeinterval.HNivel2;
                interval.OvertimeLv3 = (short)attTimeinterval.HNivel3;

                interval.InRequired = Convert.ToInt32(attTimeinterval.MarcarEntrada) == 0 ? (short)0 : (short)1;
                interval.OutRequired = Convert.ToInt32(attTimeinterval.MarcarSalida) == 0 ? (short)0 : (short)1;
                interval.AvailableIntervalType = (short)attTimeinterval.TipoIntervalo;
                interval.AvailableInterval = attTimeinterval.PeriodoMarcacion;
                interval.MultiplePunch = (short)attTimeinterval.BasadoM;

                interval.DayChange = DateTime.Today;

                _context.AttTimeintervals.Add(interval);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(getHorarioslst), new { id = interval.Id });


            }
        }

        [HttpPut("actualizarHorario/")]
        public async Task<ActionResult<AttTimeinterval>> ActualizarHorario( [FromBody] HorarioInfoDto attTimeinterval)
        {
            var interval = await _context.AttTimeintervals
                .Include(i => i.AttTimeintervalBreakTimes)
                .FirstOrDefaultAsync(i => i.Id == attTimeinterval.IdHorio);

            if (interval == null)
                return NotFound(new { mensaje = "Horario no encontrado." });

            interval.Alias = attTimeinterval.Nombre;
            interval.UseMode = short.Parse(attTimeinterval.Tipo.ToString());
            interval.InTime = ConvertirHoras.ParsearFechaHora(attTimeinterval.HoraEntrada);

            var tolerancias = CalcularTolerancias.ObtenerTolerancias(
                attTimeinterval.HoraEntrada,
                attTimeinterval.HoraSalida,
                attTimeinterval.HoraEntradaDesde,
                attTimeinterval.HoraEntradaHasta,
                attTimeinterval.HoraSalidaDesde,
                attTimeinterval.HoraSalidaHasta
            );

            interval.InAheadMargin = Convert.ToInt32(tolerancias.ToleranciaEntradaDesdeMinutos);
            interval.InAboveMargin = Convert.ToInt32(tolerancias.ToleranciaEntradaHastaMinutos);
            interval.OutAheadMargin = Convert.ToInt32(tolerancias.ToleranciaSalidaDesdeMinutos);
            interval.OutAboveMargin = Convert.ToInt32(tolerancias.ToleranciaSalidaHastaMinutos);
            interval.Duration = Convert.ToInt32(tolerancias.TiempoTrabajoMinutos);
            interval.InRequired = Convert.ToInt32(attTimeinterval.MarcarEntrada) == 0 ? (short)0 : (short)1;
            interval.OutRequired = Convert.ToInt32(attTimeinterval.MarcarSalida) == 0 ? (short)0 : (short)1;
            interval.AllowLate = Convert.ToInt32(attTimeinterval.PSalidaT);
            interval.AllowLeaveEarly = Convert.ToInt32(attTimeinterval.PLlegadaT);
            interval.AvailableIntervalType = (short)attTimeinterval.TipoIntervalo;
            interval.WorkDay = Convert.ToDouble(attTimeinterval.DiasLaboral);
            interval.MultiplePunch = (short)attTimeinterval.BasadoM;
            interval.AvailableInterval = attTimeinterval.PeriodoMarcacion;
            interval.WorkType = 0;
            interval.DayChange = DateTime.Today;
            interval.OvertimeLv = (short)attTimeinterval.Hnivel;
            interval.OvertimeLv1 = (short)attTimeinterval.HNivel1;
            interval.OvertimeLv2 = (short)attTimeinterval.HNivel2;
            interval.OvertimeLv3 = (short)attTimeinterval.HNivel3;
            interval.WorkTimeDuration = Convert.ToInt32(tolerancias.TiempoTrabajoMinutos);
            interval.MinEarlyIn = Convert.ToInt32(attTimeinterval.MinEntradaTemprana);
            interval.MinLateOut = Convert.ToInt32(attTimeinterval.MinSalidaTarde);
            interval.LateOut = (short)Convert.ToInt32(attTimeinterval.EntradaTarde);
            interval.EarlyIn = (short)Convert.ToInt32(attTimeinterval.EntradaTemprana);

            // Actualizar descansos
            if (interval.AttTimeintervalBreakTimes != null)
                _context.AttTimeintervalBreakTimes.RemoveRange(interval.AttTimeintervalBreakTimes);

            interval.AttTimeintervalBreakTimes = new List<AttTimeintervalBreakTime>();
            var breakTimeIds = new List<int> { attTimeinterval.Descanso };
            foreach (var breakTimeId in breakTimeIds)
            {
                var breakTimeEntity = await _context.AttBreaktimes.FindAsync(breakTimeId);
                if (breakTimeEntity != null)
                {
                    var attTimeintervalBreakTime = new AttTimeintervalBreakTime
                    {
                        BreaktimeId = breakTimeId,
                        TimeintervalId = interval.Id
                    };
                    interval.AttTimeintervalBreakTimes.Add(attTimeintervalBreakTime);
                }
            }

            await _context.SaveChangesAsync();
            return Ok(new
            {
                message="Actualizado co Exito",
                id=attTimeinterval.IdHorio
            });
        }


        [HttpDelete("eliminarHorario/{id}")]
        public async Task<IActionResult> EliminarHorario(int id)
        {
            var horario = await _context.AttTimeintervals
                .Include(h => h.AttTimeintervalBreakTimes)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (horario == null)
            {
                return NotFound(new { mensaje = "Horario no encontrado." });
            }

            // Eliminar relaciones en AttTimeintervalBreakTime
            if (horario.AttTimeintervalBreakTimes != null && horario.AttTimeintervalBreakTimes.Any())
            {
                _context.AttTimeintervalBreakTimes.RemoveRange(horario.AttTimeintervalBreakTimes);
            }

            _context.AttTimeintervals.Remove(horario);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Horario eliminado correctamente." });
        }






    }
}
