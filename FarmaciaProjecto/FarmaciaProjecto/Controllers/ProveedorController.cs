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
    public class ProveedorController : ControllerBase
    {
        public ProveedorUseCase CreateService()
        {
            FarmaciaDB db = new FarmaciaDB();
            ProveedorRepository repository = new ProveedorRepository(db);
            ProveedorUseCase service = new ProveedorUseCase(repository);
            return service;
        }

        // GET: api/<ProveedorController>
        [HttpGet]
        public ActionResult <IEnumerable<Proveedor>> Get()
        {
            ProveedorUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<ProveedorController>/5
        [HttpGet("{id}")]
        public ActionResult<Proveedor> Get(Guid id)
        {
            ProveedorUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // POST api/<ProveedorController>
        [HttpPost]
        public ActionResult Post([FromBody] Proveedor proveedor)
        {
            ProveedorUseCase service = CreateService();
            var result = service.Create(proveedor);
            return Ok(result);
        }

        // PUT api/<ProveedorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Proveedor proveedor)
        {
            ProveedorUseCase service = CreateService();
            proveedor.ID_Proveedor = id;
            service.Update(proveedor);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<ProveedorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ProveedorUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");

        }
    }
}
