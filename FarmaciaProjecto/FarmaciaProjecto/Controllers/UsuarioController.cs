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
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>

        public UsuarioUseCase CreateService()
        {
            FarmaciaDB db = new FarmaciaDB();
            UsuarioRepository repository = new UsuarioRepository(db);
            UsuarioUseCase service = new UsuarioUseCase(repository);
            return service;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            UsuarioUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(Guid id)
        {       
            UsuarioUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Usuario>post([FromBody] Usuario usuario)
        {
            UsuarioUseCase service = CreateService();
            var result = service.Create(usuario);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            UsuarioUseCase service = CreateService();
            usuario.ID_Usuario = id;
            service.Update(usuario);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            UsuarioUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
