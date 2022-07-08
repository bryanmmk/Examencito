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
    public class MedicamentosController : ControllerBase
    {

        public MedicamentosUseCase CreateService()
        {
        FarmaciaDB db = new FarmaciaDB();
        MedicamentosRepository repository = new MedicamentosRepository(db);
        MedicamentosUseCase service = new MedicamentosUseCase(repository);
        return service;
        }

        // GET: api/<MedicamentosController>
        [HttpGet]
        public ActionResult<IEnumerable<Medicamentos>> Get()
        {
            MedicamentosUseCase service = CreateService();
            return Ok(service.GetAll());
        }   

        // GET api/<MedicamentosController>/5
        [HttpGet("{id}")]
        public ActionResult <Medicamentos> Get(Guid id)
        {
            MedicamentosUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // POST api/<MedicamentosController>
        [HttpPost]
        public ActionResult Post([FromBody] Medicamentos medicamentos)
        {
            MedicamentosUseCase service = CreateService();
            var result = service.Create(medicamentos);
            return Ok(result);
        }

        // PUT api/<MedicamentosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Medicamentos medicamentos)
        {
            MedicamentosUseCase service = CreateService();
            medicamentos.ID_Medicamento = id;
            service.Update(medicamentos);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<MedicamentosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            MedicamentosUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
