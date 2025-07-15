using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.DTO.IclockTransaction;
using FibraAttendance.Data;

namespace FibraAttendance.Controllers.IclockTransaction
{
    [ApiController]
    [Route("api/[controller]")]
    public class IclockTransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IclockTransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/IclockTransaction
        // GET: api/IclockTransaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IclockTransactionDTO>>> GetAll(
            [FromQuery] string? empCode,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 50
        )
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0 || pageSize > 200) pageSize = 50;

            var query = _context.IclockTransactions.AsNoTracking();

            // Filtro opcional por código de empleado
            if (!string.IsNullOrWhiteSpace(empCode))
                query = query.Where(x => x.EmpCode == empCode);

            // Filtro opcional por rango de fechas de PunchTime
            if (startDate.HasValue)
                query = query.Where(x => x.PunchTime >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(x => x.PunchTime <= endDate.Value);

            // Ordena por fecha descendente (opcional)
            query = query.OrderByDescending(x => x.PunchTime);

            // Total para frontend (opcional)
            var totalCount = await query.CountAsync();

            // Paginación
            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new IclockTransactionDTO
                {
                    Id = x.Id,
                    EmpCode = x.EmpCode,
                    PunchTime = x.PunchTime,
                    PunchState = x.PunchState,
                    VerifyType = x.VerifyType,
                    WorkCode = x.WorkCode,
                    TerminalSn = x.TerminalSn,
                    TerminalAlias = x.TerminalAlias,
                    AreaAlias = x.AreaAlias,
                    Longitude = x.Longitude,
                    Latitude = x.Latitude,
                    GpsLocation = x.GpsLocation,
                    Mobile = x.Mobile,
                    Source = x.Source,
                    Purpose = x.Purpose,
                    Crc = x.Crc,
                    IsAttendance = x.IsAttendance,
                    UploadTime = x.UploadTime,
                    SyncStatus = x.SyncStatus,
                    SyncTime = x.SyncTime,
                    EmpId = x.EmpId,
                    TerminalId = x.TerminalId,
                    IsMask = x.IsMask,
                    Temperature = x.Temperature
                })
                .ToListAsync();

            // Respuesta con datos y total para frontend
            return Ok(new
            {
                Total = totalCount,
                Page = page,
                PageSize = pageSize,
                Data = data
            });
        }


        // POST: api/IclockTransaction
        [HttpPost]
        public async Task<ActionResult<IclockTransactionDTO>> Create(CreateIclockTransactionDTO dto)
        {
            var now = DateTime.Now;

            var entity = new Models.IclockTransaction
            {
                EmpCode = dto.EmpCode,
                PunchTime = dto.PunchTime ?? now,
                PunchState = dto.PunchState,
                VerifyType = dto.VerifyType,
                WorkCode = dto.WorkCode,
                TerminalSn = dto.TerminalSn,
                TerminalAlias = dto.TerminalAlias,
                AreaAlias = dto.AreaAlias,
                Longitude = dto.Longitude,
                Latitude = dto.Latitude,
                GpsLocation = dto.GpsLocation,
                Mobile = dto.Mobile,
                Source = dto.Source,
                Purpose = dto.Purpose,
                Crc = dto.Crc,
                IsAttendance = dto.IsAttendance,
                UploadTime = dto.UploadTime ?? now,
                SyncStatus = dto.SyncStatus,
                SyncTime = dto.SyncTime,
                EmpId = dto.EmpId,
                TerminalId = dto.TerminalId,
                IsMask = dto.IsMask,
                Temperature = dto.Temperature
            };

            _context.IclockTransactions.Add(entity);
            await _context.SaveChangesAsync();

            var result = new IclockTransactionDTO
            {
                Id = entity.Id,
                EmpCode = entity.EmpCode,
                PunchTime = entity.PunchTime,
                PunchState = entity.PunchState,
                VerifyType = entity.VerifyType,
                WorkCode = entity.WorkCode,
                TerminalSn = entity.TerminalSn,
                TerminalAlias = entity.TerminalAlias,
                AreaAlias = entity.AreaAlias,
                Longitude = entity.Longitude,
                Latitude = entity.Latitude,
                GpsLocation = entity.GpsLocation,
                Mobile = entity.Mobile,
                Source = entity.Source,
                Purpose = entity.Purpose,
                Crc = entity.Crc,
                IsAttendance = entity.IsAttendance,
                UploadTime = entity.UploadTime,
                SyncStatus = entity.SyncStatus,
                SyncTime = entity.SyncTime,
                EmpId = entity.EmpId,
                TerminalId = entity.TerminalId,
                IsMask = entity.IsMask,
                Temperature = entity.Temperature
            };

            return CreatedAtAction(nameof(GetAll), new { id = entity.Id }, result);
        }
    }
}
