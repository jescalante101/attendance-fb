using FibraAttendance.Data;
using FibraAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonalController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("listCompany")]
        public async Task<ActionResult<IEnumerable<PersonnelCompany>>> GetCompanys()
        {
            var companys = await _context.PersonnelCompanies
             .Select(c => new 
             {
                 c.Id,
                 c.CompanyName,
                 c.CompanyCode,
                 c.Logo,
                 c.Country,
                 c.City,
                 c.Fax,
                 c.Email,
                 c.State,
                 c.Phone,
                 c.Website,
                 c.PostalCode,
                 c.Address,
                 c.Address2,
                 c.ShowInReport,
                 c.IsDefault,
                 CantidadDepartamentos = c.PersonnelDepartments.Count()
             })
             .ToListAsync();
            return Ok(companys);
        }

        [HttpGet("listDepartment")]
        public async Task<ActionResult<IEnumerable<PersonnelDepartment>>> getDepartments()
        {
            var departments = await _context.PersonnelDepartments.
                Select( c=>new
                {
                    c.Id,
                    c.DeptCode,
                    c.DeptName,
                    c.IsDefault,
                    CompanyName = c.Company != null ? c.Company.CompanyName : null, // Protección por si Company es null
                    TotalEmpleados = c.PersonnelEmployees.Count()
                }
                ).ToListAsync();
            return Ok(departments);
        }

        [HttpGet("listPositions")]
        public async Task<ActionResult<IEnumerable<PersonnelPosition>>> getPersonnelPositions()
        {
            var positions = await _context.PersonnelPositions
                .Select(p => new
                {
                    p.PositionCode,
                    p.PositionName,
                    superior = p.ParentPositionId ?? 0, // Usando el operador null-coalescing para asignar 0 si es null
                    cantEmpleados = p.PersonnelEmployees.Count(),
                    renuncias = p.PersonnelEmployees.Count(e => e.PersonnelResign != null)
                })
                .ToListAsync();

            return Ok(positions);
        }

        [HttpGet("listAreas")]
        public async Task<ActionResult<IEnumerable<PersonnelArea>>> getPersonnelAreas()
        {
            var areas = await _context.PersonnelAreas
            .Select(pa => new
            {
                codArea = pa.AreaCode,
                nombreArea = pa.AreaName,
                superior = pa.ParentArea != null ? pa.ParentArea.AreaName : null, 
                cantidadDispositivos = pa.IclockTerminals.Count(), 
                cantidadEmpleados = pa.PersonnelEmployeeAreas.Count(), 
                numeroRenuncias = pa.PersonnelEmployeeAreas.Count(pea => pea.Employee.PersonnelResign != null) 
            })
            .ToListAsync();
            return Ok(areas);
        }


        /********* Empleados  ***********/
        [HttpGet("organizacion/listarEmpleados")]
        public async Task<ActionResult<IEnumerable<PersonnelEmployee>>> getListEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 15)
        {
            var lstEmployee =  _context.PersonnelEmployees.
                Select(emp=>new
                {
                    id=emp.Id,
                    emp.CreateTime,
                    emp.CreateUser,
                    emp.ChangeTime,
                    emp.ChangeUser,
                    emp.Status,
                    emp.EmpCode,
                    emp.FirstName,
                    emp.LastName,
                    emp.Nickname,
                    emp.Passport,
                    emp.DriverLicenseAutomobile,
                    emp.DriverLicenseMotorcycle,
                    emp.Photo,
                    emp.DevPrivilege,
                    emp.CardNo,
                    emp.AccGroup,
                    emp.AccTimezone,
                    emp.Gender,
                    emp.Birthday,
                    emp.Address,
                    emp.Mobile,
                    emp.HireDate,
                    emp.Email,
                    emp.Department.DeptName,
                    emp.Position.PositionName,
                    estadoApp=emp.AppStatus,
                    area = emp.PersonnelEmployeeAreas.Select(a => new
                        {
                            a.Area.AreaName,
                            a.Area.AreaCode
                        }
                     )
                }
                )
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToList();

            var totalRecords = await _context.PersonnelEmployees.CountAsync();

            return Ok(new
            {
                data = lstEmployee,
                page,
                pageSize,
                totalRecords,
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            });
        }

        [HttpGet("organizacion/listarCeses")]
        public async Task<ActionResult<IEnumerable<PersonnelResign>>> getPersonnelResign()
        {
            var lstResign = await _context.PersonnelResigns.
                Select(re => new
                    {
                        re.Id,
                        re.ResignDate,
                        re.Reason,
                        re.ResignType,
                        re.EmployeeId,
                        empName=re.Employee.FirstName,
                        departamento=re.Employee.Department.DeptName,
                        cargo=re.Employee.Position.PositionName
                    }

                ).ToListAsync();

            return Ok(lstResign);
        }



    }
}
