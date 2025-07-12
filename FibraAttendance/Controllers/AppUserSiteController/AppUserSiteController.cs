﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Entity.ScireAttendance;
using FibraAttendance.Data;

namespace FibraAttendance.Controllers.AppUserSiteController
{
    /// <summary>
    /// Controlador para gestionar la relación Usuario-Sede (AppUserSite).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserSiteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor con inyección de dependencias del DbContext.
        /// </summary>
        public AppUserSiteController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las relaciones Usuario-Sede.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserSite>>> GetAll()
        {
            var list = await _context.AppUserSites.ToListAsync();
            if (list == null || !list.Any())
                return NotFound(new { message = "No se encontraron relaciones Usuario-Sede." });

            return Ok(list);
        }

        /// <summary>
        /// Obtiene una relación Usuario-Sede por su clave compuesta.
        /// </summary>
        [HttpGet("{userId:int}/{siteId}")]
        public async Task<ActionResult<AppUserSite>> GetById(int userId, string siteId)
        {
            if (userId <= 0 || string.IsNullOrWhiteSpace(siteId))
                return BadRequest(new { message = "El ID de usuario y el ID de sede son obligatorios." });

            var entity = await _context.AppUserSites.FindAsync(userId, siteId);

            if (entity == null)
                return NotFound(new { message = $"No se encontró la relación Usuario-Sede con UserId={userId} y SiteId='{siteId}'." });

            return Ok(entity);
        }

        /// <summary>
        /// Crea una nueva relación Usuario-Sede.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(object))] // Ahora documenta el 201
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<AppUserSite>> Create([FromBody] AppUserSite appUserSite)
        {
            if (appUserSite == null)
                return BadRequest(new { message = "El cuerpo de la solicitud no puede estar vacío." });

            if (appUserSite.UserId <= 0 || string.IsNullOrWhiteSpace(appUserSite.SiteId))
                return BadRequest(new { message = "El ID de usuario y el ID de sede son obligatorios." });

            // Validar si ya existe la relación
            var exists = await _context.AppUserSites.FindAsync(appUserSite.UserId, appUserSite.SiteId);
            if (exists != null)
                return Conflict(new { message = "Ya existe una relación Usuario-Sede con esos identificadores." });

            // Valores por defecto
            appUserSite.Active ??= "Y";
            appUserSite.CreationDate ??= System.DateTime.Now;

            _context.AppUserSites.Add(appUserSite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { userId = appUserSite.UserId, siteId = appUserSite.SiteId },
                new
                {
                    message = "Relación Usuario-Sede creada correctamente.",
                    data=appUserSite
                });
        }

        /// <summary>
        /// Actualiza una relación Usuario-Sede existente.
        /// </summary>
        [HttpPut("{userId:int}/{siteId}")]
        public async Task<IActionResult> Update(int userId, string siteId, [FromBody] AppUserSite updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest(new { message = "El cuerpo de la solicitud no puede estar vacío." });

            if (userId != updatedEntity.UserId || siteId != updatedEntity.SiteId)
                return BadRequest(new { message = "Los identificadores de la ruta y el cuerpo no coinciden." });

            var existing = await _context.AppUserSites.FindAsync(userId, siteId);
            if (existing == null)
                return NotFound(new { message = $"No se encontró la relación Usuario-Sede con UserId={userId} y SiteId='{siteId}'." });

            // Actualizar propiedades
            existing.Observation = updatedEntity.Observation;
            existing.UserName = updatedEntity.UserName;
            existing.SiteName = updatedEntity.SiteName;
            existing.CreatedBy = updatedEntity.CreatedBy;
            existing.CreationDate = updatedEntity.CreationDate;
            existing.Active = updatedEntity.Active;

            _context.Entry(existing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, new { message = "Error al actualizar la relación Usuario-Sede.", details = ex.Message });
            }

            return Ok(existing);
        }

        /// <summary>
        /// Elimina una relación Usuario-Sede por su clave compuesta.
        /// </summary>
        [HttpDelete("{userId:int}/{siteId}")]
        public async Task<IActionResult> Delete(int userId, string siteId)
        {
            if (userId <= 0 || string.IsNullOrWhiteSpace(siteId))
                return BadRequest(new { message = "El ID de usuario y el ID de sede son obligatorios." });

            var entity = await _context.AppUserSites.FindAsync(userId, siteId);
            if (entity == null)
                return NotFound(new { message = $"No se encontró la relación Usuario-Sede con UserId={userId} y SiteId='{siteId}'." });

            _context.AppUserSites.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Relación Usuario-Sede eliminada correctamente." });
        }
    }
}
