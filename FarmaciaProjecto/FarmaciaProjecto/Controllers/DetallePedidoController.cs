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
    public class DetallePedidoController : ControllerBase
    {
        public DetallePedidoUseCase CreateService()
        {
            FarmaciaDB db = new FarmaciaDB();
            DetallePedidoRepository repository = new DetallePedidoRepository(db);
            DetallePedidoUseCase service = new DetallePedidoUseCase(repository);
            return service;
        }

        // GET: api/<DetallePedidoController>
        [HttpGet]
        public ActionResult<IEnumerable<DetallePedido>> Get()
        {
            DetallePedidoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<DetallePedidoController>/5
        [HttpGet("{id}")]
        public ActionResult<DetallePedido> Get(Guid id)
        {
            DetallePedidoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // POST api/<DetallePedidoController>
        [HttpPost]
        public ActionResult<DetallePedido>Post([FromBody] DetallePedido detallePedido)
        {
            DetallePedidoUseCase service = CreateService();
            var result = service.Create(detallePedido);
            return Ok(result);
        }

        // PUT api/<DetallePedidoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] DetallePedido detallePedido)
        {
            DetallePedidoUseCase service = CreateService();
            detallePedido.ID_DetallePedido = id;
            service.Update(detallePedido);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<DetallePedidoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            DetallePedidoUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
