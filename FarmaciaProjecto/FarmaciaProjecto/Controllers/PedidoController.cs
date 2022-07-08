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
    public class PedidoController : ControllerBase
    {

        public PedidoUseCase CreateService()
        {
            FarmaciaDB db = new FarmaciaDB();
            PedidoRepository repository = new PedidoRepository(db);
            PedidoUseCase service = new PedidoUseCase(repository);
            return service;
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public ActionResult <IEnumerable<Pedido>> Get()
        {
            PedidoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(Guid id)
        {
            PedidoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // POST api/<PedidoController>
        [HttpPost]
        public ActionResult Post([FromBody] Pedido pedido)
        {
            PedidoUseCase service = CreateService();
            var result = service.Create(pedido);
            return Ok(result);
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Pedido pedido)
        {
            PedidoUseCase service = CreateService();
            pedido.ID_Pedido = id;
            service.Update(pedido);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            PedidoUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
