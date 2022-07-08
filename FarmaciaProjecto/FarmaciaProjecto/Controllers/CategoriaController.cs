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
    public class CategoriaController : ControllerBase
    {

        public CategoriaUseCase CreateService()
        {
            FarmaciaDB db = new FarmaciaDB();
            CategoriaRepository repository = new CategoriaRepository(db);
            CategoriaUseCase service = new CategoriaUseCase(repository);
            return service;
        }


        // GET: api/<AdministracionController>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            CategoriaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<AdministracionController>/5
        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(Guid id)
        {
           CategoriaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // POST api/<AdministracionController>
        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria categoria)
        {
            CategoriaUseCase service = CreateService();
            var result = service.Create(categoria);
            return Ok(result);
        }

        // PUT api/<AdministracionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            CategoriaUseCase service = CreateService();
            categoria.ID_Categoria = id;
            service.Update(categoria);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<AdministracionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            CategoriaUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}