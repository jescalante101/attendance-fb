using Entities.DTO;
using Entities.Entity;
using FibraAttendance.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FibraAttendance.Controllers
{
    [ApiController]
    [Route("api/employee-schedule-assignment")]
    public class EmployeeScheduleAssignmentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public EmployeeScheduleAssignmentController(ApplicationDbContext context)
        {
            _db = context;
        }

        [HttpGet("search")]
        public async Task<ActionResult<ResultadoConsulta<EmployeeScheduleAssignmentDTO>>> Search(
      [FromQuery] string searchText = "",
      [FromQuery] int pageNumber = 1,
      [FromQuery] int pageSize = 15,
      [FromQuery] DateTime? startDate = null,
      [FromQuery] DateTime? endDate = null
  )
        {
            try
            {
                // Validar parámetros de entrada
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1 || pageSize > 100) pageSize = 15;

                // Query base
                var query = _db.EmployeeScheduleAssignments.AsQueryable();

                // Filtro por texto de búsqueda
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    var searchLower = searchText.ToLower();
                    query = query.Where(x =>
                        x.FullName.ToLower().Contains(searchLower) ||
                        x.ShiftDescription.ToLower().Contains(searchLower)
                    );
                }

                // Filtro por rango de fechas - CORREGIDO
                if (startDate.HasValue)
                {
                    // Convertir a fecha sin hora para comparación desde el inicio del día
                    var startDateOnly = startDate.Value.Date;
                    query = query.Where(x => x.StartDate >= startDateOnly);
                }

                if (endDate.HasValue)
                {
                    // Convertir a fecha sin hora y agregar 23:59:59 para incluir todo el día
                    var endDateOnly = endDate.Value.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(x => x.EndDate <= endDateOnly);
                }

                // Ordenar por fecha de creación (más recientes primero)
                query = query.OrderByDescending(x => x.CreatedAt);

                // Contar total de registros
                var totalCount = await query.CountAsync();

                // Obtener registros paginados
                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(x => new EmployeeScheduleAssignmentDTO
                    {
                        AssignmentId = x.AssignmentId,
                        EmployeeId = x.EmployeeId,
                        FullNameEmployee = x.FullName,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Remarks = x.Remarks,
                        ScheduleName = x.ShiftDescription,
                        ScheduleId = x.ScheduleId,
                        NroDoc =x.NroDoc ?? "-",
                        AreaId = x.AreaId,
                        AreaName = x.AreaDescription ?? "-",
                        CreatedAt = x.CreatedAt,
                        CreatedWeek = ISOWeek.GetWeekOfYear(x.CreatedAt),
                        LocationId = x.LocationId,
                        LocationName = x.LocationName ?? "-" // Asegurarse de que LocationName no sea nulo
                    })
                    .ToListAsync();

                // Crear objeto paginado
                var paginated = new PaginatedList<EmployeeScheduleAssignmentDTO>(items, totalCount, pageNumber, pageSize);

                // Crear resultado final
                var result = new ResultadoConsulta<EmployeeScheduleAssignmentDTO>
                {
                    Exito = true, // Siempre es exitoso si no hay excepción
                    Mensaje = totalCount > 0 ? $"Se encontraron {totalCount} registros" : "No se encontraron registros",
                    Data = paginated
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log del error (asegúrate de tener un logger configurado)
                // _logger.LogError(ex, "Error en búsqueda de asignaciones de horarios");

                var errorResult = new ResultadoConsulta<EmployeeScheduleAssignmentDTO>
                {
                    Exito = false,
                    Mensaje = "Error interno del servidor al procesar la búsqueda",
                    Data = new PaginatedList<EmployeeScheduleAssignmentDTO>(new List<EmployeeScheduleAssignmentDTO>(), 0, pageNumber, pageSize)
                };

                return StatusCode(500, errorResult);
            }
        }

        // GET: api/employee-schedule-assignment/get-by-id/{id}
        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<ResultadoConsulta<EmployeeScheduleAssignmentDTO>>> GetAssignmentById(int id)
        {
            var resultado = new ResultadoConsulta<EmployeeScheduleAssignmentDTO>();
            try
            {
                var query = from a in _db.EmployeeScheduleAssignments
                            where a.AssignmentId == id
                            select new EmployeeScheduleAssignmentDTO
                            {
                                AssignmentId = a.AssignmentId,
                                EmployeeId = a.EmployeeId,
                                FullNameEmployee= a.FullName,
                                ScheduleName = a.ShiftDescription,
                                StartDate = a.StartDate,
                                EndDate = a.EndDate,
                                Remarks = a.Remarks,
                                CreatedAt = a.CreatedAt,
                                CreatedWeek = ISOWeek.GetWeekOfYear(a.CreatedAt)
                            };

                var assignment = await query.FirstOrDefaultAsync();

                if (assignment == null)
                {
                    resultado.Exito = false;
                    resultado.Mensaje = "Assignment not found.";
                    resultado.Data = null;
                    return NotFound(resultado);
                }

                resultado.Exito = true;
                resultado.Mensaje = "Assignment found.";
                resultado.Data = new PaginatedList<EmployeeScheduleAssignmentDTO>(
                    new List<EmployeeScheduleAssignmentDTO> { assignment }, 1, 1, 1
                );
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.Data = null;
                return StatusCode(500, resultado);
            }
        }

        // POST: api/employee-schedule-assignment/insert
        [HttpPost("insert")]
        public async Task<ActionResult<ResultadoConsulta<EmployeeScheduleAssignmentDTO>>> InsertAssignment(
            [FromBody] List<EmployeeScheduleAssignment> models)
        {
            var resultado = new ResultadoConsulta<EmployeeScheduleAssignmentDTO>();
            try
            {
                if (models == null || !models.Any())
                {
                    resultado.Exito = false;
                    resultado.Mensaje = "El arreglo no debe estar vacío.";
                    resultado.Data = null;
                    return BadRequest(resultado);
                }

                // Agrega todos los modelos de una sola vez
                _db.EmployeeScheduleAssignments.AddRange(models);
                await _db.SaveChangesAsync();

                // Mapea cada modelo a su DTO
                var dtos = models.Select(model => new EmployeeScheduleAssignmentDTO
                {
                    AssignmentId = model.AssignmentId,
                    EmployeeId = model.EmployeeId,
                    FullNameEmployee = model.FullName,
                    ScheduleName = model.ShiftDescription,
                    ScheduleId = model.ScheduleId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Remarks = model.Remarks,
                    CreatedAt = model.CreatedAt,
                    NroDoc = model.NroDoc ?? "-",
                    AreaId = model.AreaId,
                    AreaName = model.AreaDescription ?? "-",
                    CreatedWeek = ISOWeek.GetWeekOfYear(model.CreatedAt),
                    LocationId = model.LocationId,
                    LocationName = model.LocationName ?? "-"
                }).ToList();

                resultado.Exito = true;
                resultado.Mensaje = "Asignaciones creadas correctamente.";
                resultado.Data = new PaginatedList<EmployeeScheduleAssignmentDTO>(dtos, dtos.Count, 1, dtos.Count);
            }
            catch (Exception ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.Data = null;
            }
            return Ok(resultado);
        }




        // PUT: api/employee-schedule-assignment/update/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult<ResultadoConsulta<EmployeeScheduleAssignmentDTO>>> UpdateAssignment(
            int id, [FromBody] EmployeeScheduleAssignment model)
        {
            var resultado = new ResultadoConsulta<EmployeeScheduleAssignmentDTO>();
            try
            {
                var entity = await _db.EmployeeScheduleAssignments.FindAsync(id);
                if (entity == null)
                {
                    resultado.Exito = false;
                    resultado.Mensaje = "Assignment not found.";
                    return NotFound(resultado);
                }

                entity.ScheduleId = model.ScheduleId;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.Remarks = model.Remarks;
                await _db.SaveChangesAsync();

              
                var dto = new EmployeeScheduleAssignmentDTO
                {
                    AssignmentId = entity.AssignmentId,
                    EmployeeId = entity.EmployeeId,
                    ScheduleName = entity.ShiftDescription,
                    ScheduleId = entity.ScheduleId,
                    FullNameEmployee = entity.FullName,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    Remarks = entity.Remarks,
                    CreatedAt = entity.CreatedAt,
                    CreatedWeek = ISOWeek.GetWeekOfYear(entity.CreatedAt),
                    NroDoc = entity.NroDoc ?? "-",
                    AreaId = entity.AreaId,
                    AreaName = entity.AreaDescription ?? "-",
                    LocationId = entity.LocationId,
                    LocationName = entity.LocationName ?? "-" // Asegurarse de que LocationName no sea nulo

                };

                resultado.Exito = true;
                resultado.Mensaje = "Assignment updated successfully.";
                resultado.Data = new PaginatedList<EmployeeScheduleAssignmentDTO>(new List<EmployeeScheduleAssignmentDTO> { dto }, 1, 1, 1);
            }
            catch (Exception ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.Data = null;
            }
            return Ok(resultado);
        }

        // DELETE: api/employee-schedule-assignment/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResultadoConsulta<EmployeeScheduleAssignmentDTO>>> DeleteAssignment(int id)
        {
            var resultado = new ResultadoConsulta<EmployeeScheduleAssignmentDTO>();
            try
            {
                var entity = await _db.EmployeeScheduleAssignments.FindAsync(id);
                if (entity == null)
                {
                    resultado.Exito = false;
                    resultado.Mensaje = "Assignment not found.";
                    return NotFound(resultado);
                }

                _db.EmployeeScheduleAssignments.Remove(entity);
                await _db.SaveChangesAsync();

                resultado.Exito = true;
                resultado.Mensaje = "Assignment deleted successfully.";
                resultado.Data = null;
            }
            catch (Exception ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.Data = null;
            }
            return Ok(resultado);
        }


        // obtner por nro de documento del empleado
        [HttpGet("get-by-nrodoc/{nroDoc}")]
        public async Task<ActionResult<ResultadoConsulta<EmployeeScheduleAssignmentDTO>>> GetAssignmentById(string nroDoc)
        {
            var resultado = new ResultadoConsulta<EmployeeScheduleAssignmentDTO>();
            try
            {
                var query = from a in _db.EmployeeScheduleAssignments
                            where a.NroDoc == nroDoc
                            select new EmployeeScheduleAssignmentDTO
                            {
                                AssignmentId = a.AssignmentId,
                                EmployeeId = a.EmployeeId,
                                FullNameEmployee = a.FullName,
                                StartDate = a.StartDate,
                                EndDate = a.EndDate,
                                Remarks = a.Remarks,
                                ScheduleName = a.ShiftDescription,
                                ScheduleId = a.ScheduleId,
                                NroDoc = a.NroDoc ?? "-",
                                AreaId = a.AreaId,
                                AreaName = a.AreaDescription ?? "-",
                                CreatedAt = a.CreatedAt,
                                CreatedWeek = ISOWeek.GetWeekOfYear(a.CreatedAt),
                                LocationId = a.LocationId,
                                LocationName = a.LocationName ?? "-"
                            };

                var assignment = await query.FirstOrDefaultAsync();

                if (assignment == null)
                {
                    resultado.Exito = false;
                    resultado.Mensaje = "Assignment not found.";
                    resultado.Data = null;
                    return NotFound(resultado);
                }

                resultado.Exito = true;
                resultado.Mensaje = "Assignment found.";
                resultado.Data = new PaginatedList<EmployeeScheduleAssignmentDTO>(
                    new List<EmployeeScheduleAssignmentDTO> { assignment }, 1, 1, 1
                );
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.Data = null;
                return StatusCode(500, resultado);
            }
        }

        //obtnermos horarios:
        [HttpGet("get-horaio-by-doc/{nroDoc}")]
        public IActionResult GetEmployeeSchedules(string nroDoc)
        {
            var result = (from e in _db.EmployeeScheduleAssignments
                          join a in _db.AttAttshifts on e.ScheduleId equals a.Id
                          join de in _db.AttShiftdetails on a.Id equals de.ShiftId
                          where e.NroDoc == nroDoc
                          orderby a.Id, de.InTime
                          select new EmployeeScheduleDto
                          {
                              Id = a.Id,
                              FullNameEmployee = e.FullName,
                              Alias = a.Alias,
                              InTime = de.InTime.ToString("HH:mm"),
                              OutTime = de.InTime.ToLocalTime().AddMinutes(de.TimeInterval.WorkTimeDuration).ToString("HH:mm")
                          })
                          .Distinct()
                          .ToList();

            if (result == null || !result.Any())
            {
                return NotFound();  // Si no se encuentran resultados, se retorna un 404
            }

            return Ok(result);  // Si se encuentran resultados, se retorna un 200 OK con los datos
        }

    }

}
