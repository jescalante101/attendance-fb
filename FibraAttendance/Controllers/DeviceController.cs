using AutoMapper;
using FibraAttendance.Core.Models;
using FibraAttendance.Data;
using FibraAttendance.DTOs;
using FibraAttendance.Infrastructure.Core.Model;
using FibraAttendance.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FibraAttendance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController: ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private ZktecoDeviceService _zktecoService;
        private readonly ILoggerFactory _loggerFactory;

        public DeviceController(ApplicationDbContext context,IMapper mapper,ZktecoDeviceService deviceService, ILoggerFactory loggerFactory)
        {
            _context = context;
            _mapper = mapper;
            _zktecoService = deviceService;
            _loggerFactory = loggerFactory;
        }





        [HttpGet("listDevice_db")]
        public ActionResult<IEnumerable<TerminalInfoDto>> GetTerminales()
        {
            var terminales = _context.IclockTerminals.Include(t => t.Area).ToList();
            var terminalesDto = _mapper.Map<IEnumerable<TerminalInfoDto>>(terminales);
            return Ok(terminalesDto);
        }

        [HttpGet("{id}")]
        public ActionResult<TerminalInfoDto> GetTerminal(int id)
        {
            var terminal = _context.IclockTerminals.Include(t => t.Area).FirstOrDefault(t => t.Id == id);
            if (terminal == null)
            {
                return NotFound();
            }
            var terminalDto = _mapper.Map<TerminalInfoDto>(terminal);
            return Ok(terminalDto);
        }

        // Marcaciones 
        [HttpGet("marcaciones_db")]
        public async Task<ActionResult<IEnumerable<TransactionEmployeeDepartmentDto>>> GetTransactionsTerminalAsync([FromQuery] int page = 1, [FromQuery] string queryFilter="")
        {
            const int pageSize = 15;

            var totalTransactions = _context.IclockTransactions.Count();
            var totalPages = (int)Math.Ceiling((double)totalTransactions / pageSize);

            if (page < 1 || page > totalPages)
            {
                return BadRequest("Número de página inválido.");
            }
            //var logger = _loggerFactory.CreateLogger<QueryLogger>();
            var transactions = _context.IclockTransactions
                .AsNoTracking()
            .Include(t => t.Emp)
                .ThenInclude(e => e.Department)
            .Include(t => t.Emp) // Vuelve a especificar Include para navegar desde Emp
                .ThenInclude(e => e.Position)// Incluye la tabla PersonnelPosition a través de la propiedad 'Position' de Emp
               
             .Where(
                   t=>t.Emp.FirstName.Contains(queryFilter) ||
                   t.Emp.LastName.Contains(queryFilter) ||
                   t.EmpCode.ToString().Contains(queryFilter)
                )
            .OrderByDescending(t => t.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
                .ToList();

            var transactionsDto = _mapper.Map<List<TransactionEmployeeDepartmentDto>>(transactions);

            // Opcional: puedes incluir información de paginación en la respuesta
            var paginationMetadata = new
            {
                TotalCount = totalTransactions,
                PageSize = pageSize,
                CurrentPage = page,
                TotalPages = totalPages
            };

            Response.Headers.Add("x-pagination", System.Text.Json.JsonSerializer.Serialize(paginationMetadata));

            return Ok(transactionsDto);
        }

    }
}
