using FibraAttendance.Core.Models;
using FibraAttendance.Data;
using FibraAttendance.Infrastructure.Core.Model;
using FibraAttendance.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerminalController : ControllerBase
    {
        private ZktecoDeviceService _zktecoService;
        private readonly ApplicationDbContext _context;
        public TerminalController(ZktecoDeviceService deviceService, ApplicationDbContext context)
        {
            _zktecoService = deviceService;
            _context = context;
        }


        [HttpPost("connectDivice")]
        public IActionResult Connect([FromBody] ConnectionRequest request)
        {
            if (_zktecoService.Connect(request.IpAddress, request.Port))
            {
                return Ok(new { message = "Conexión exitosa." });
            }
            else
            {
                return BadRequest(new { message = "Error al conectar con el dispositivo." });
            }
        }

        [HttpPut("verifyConnection")]
        public IActionResult VerifyConnection([FromBody] ConnectionRequest request)
        {
            if (_zktecoService.Connect(request.IpAddress, 4370))
            {
                var terminal = _context.IclockTerminals.FirstOrDefault(e => e.Id == request.Port);
                if (terminal != null)
                {
                    terminal.Status = 1;
                    _context.SaveChangesAsync();
                    return Ok(new { message = "Actualizado con exito", });
                }
                else
                {
                    return Ok(new { message = "No se ha Encontrado el registro", });
                }

            }
            else
            {
                return BadRequest(new { message = "Error al conectar con el dispositivo." });
            }
        }

        [HttpGet("deviceUser")]
        public async Task<ActionResult<IEnumerable<AttendanceUser>>> GetUsers([FromQuery] string ipAddress, [FromQuery] int port)
        {
            if (string.IsNullOrEmpty(ipAddress) || port == 0)
            {
                return BadRequest("Se requiere la dirección IP y el puerto del dispositivo.");
            }

            if (!_zktecoService.Connect(ipAddress, port))
            {
                return BadRequest("Error al conectar con el dispositivo.");
            }
            var users = await _zktecoService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("list_records_transaction")]
        public async Task<ActionResult<IEnumerable<AttendanceRecord>>> GetRecords([FromQuery] string ipAddress, [FromQuery] int port, [FromQuery] int idDevice)
        {
            if (string.IsNullOrEmpty(ipAddress) || port == 0)
            {
                return BadRequest("Se requiere la dirección IP y el puerto del dispositivo.");
            }

            var dbDevices = await _context.IclockTerminals.FirstOrDefaultAsync(d => d.Id == idDevice);

            if (dbDevices == null || dbDevices.State == 0)
            {
                return BadRequest("No hay conexión con el dispositivo");
            }


            //if (!_zktecoservice.connect(ipaddress, port))
            //{
            //    return badrequest("error al conectar con el dispositivo.");
            //}

            if (!_zktecoService.Connect(ipAddress, port))
            {
                return BadRequest("Error al conectar con el dispositivo.");
            }
            var records = await _zktecoService.GetAllAttendanceRecordsAsync();
            return Ok(records);
        }

        [HttpGet("list_records_transaction_today")]
        public async Task<ActionResult<IEnumerable<AttendanceRecord>>> GetRecordsToday([FromQuery] string ipAddress, [FromQuery] int port, [FromQuery] int idDevice)
        {
            if (string.IsNullOrEmpty(ipAddress) || port == 0)
            {
                return BadRequest("Se requiere la dirección IP y el puerto del dispositivo.");
            }

            var dbDevices = await _context.IclockTerminals.FirstOrDefaultAsync(d => d.Id == idDevice);

            if (dbDevices == null || dbDevices.State == 0)
            {
                return BadRequest("No hay conexión con el dispositivo");
            }

            if (!_zktecoService.Connect(ipAddress, port))
            {
                return BadRequest("Error al conectar con el dispositivo.");
            }
            var records = await _zktecoService.GetTodayAttendanceRecordsAsync();
            return Ok(records);

        }



        [HttpGet("list_new_records_transaction_today")]
        public async Task<ActionResult<IEnumerable<AttendanceRecord>>> GetNewRecordsToday([FromQuery] string ipAddress, [FromQuery] int port, [FromQuery] int idDevice)
        {
            if (string.IsNullOrEmpty(ipAddress) || port == 0)
            {
                return BadRequest("Se requiere la dirección IP y el puerto del dispositivo.");
            }

            var dbDevices = await _context.IclockTerminals.FirstOrDefaultAsync(d => d.Id == idDevice);

            if (dbDevices == null || dbDevices.State == 0)
            {
                return BadRequest("No hay conexión con el dispositivo");
            }

            if (!_zktecoService.Connect(ipAddress, port))
            {
                return BadRequest("Error al conectar con el dispositivo.");
            }
            var records = await _zktecoService.GetLastAttendanceRecord();
            return Ok(records);

        }


    }
}
