using Microsoft.AspNetCore.Mvc;
using FarmaciaProjecto.Adaptors.SQLServerDataAccess.Contexts;
using FarmaciaProjecto.Core.Application.UseCases;
using FarmaciaProjecto.Core.Infraestructure.Repository.Concrete;
using System.Collections.Generic;
using FarmaciaProjecto.Core.Domain.Models;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmaciaProjecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministracionController : ControllerBase
    {

        public AdministracionUseCase CreateService()
        {
            FarmaciaDB db = new FarmaciaDB();
            AdministracionRepository repository = new AdministracionRepository(db);
            AdministracionUseCase service = new AdministracionUseCase(repository);
            return service;
        }


        // GET: api/<AdministracionController>
        [HttpGet]
        public ActionResult <IEnumerable<Administracion>> Get()
        {
            AdministracionUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<AdministracionController>/5
        [HttpGet("{id}")]
        public ActionResult <Administracion> Get(Guid id)
        {
            AdministracionUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // POST api/<AdministracionController>
        [HttpPost]
        public ActionResult<Administracion>Post([FromBody] Administracion administracion)
        {
            AdministracionUseCase service = CreateService();
            var result = service.Create(administracion);
            return Ok(result);
        }

        // PUT api/<AdministracionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Administracion administracion)
        {
            AdministracionUseCase service = CreateService();
            administracion.ID = id;
            service.Update(administracion);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<AdministracionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            AdministracionUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
