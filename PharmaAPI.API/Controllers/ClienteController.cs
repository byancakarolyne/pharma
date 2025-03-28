using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaAPI.Business.Business;
using PharmaAPI.Business.Business.Interface;

namespace PharmaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBusiness clienteBusiness;

        public ClienteController(IClienteBusiness clienteBusiness)
        {
            this.clienteBusiness = clienteBusiness;
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<ActionResult<Clientes>> Create(Clientes request)
        {
            var cliente = await clienteBusiness.Create(request);
            return Ok(cliente);
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetAll()
        {
            return await clienteBusiness.GetAll();
        }

        // GET: api/cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> Get(int id)
        {
            var cliente = await clienteBusiness.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Clientes request)
        {
            var cliente = await clienteBusiness.Update(id, request);
            if (cliente == null)
            {
                return NotFound(new { message = "Cliente não encontrado." });
            }
            return Ok("Registro atualizado com sucesso!");

        }

        // DELETE: api/cliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientes>> Delete(int id)
        {
            var cliente = await clienteBusiness.Delete(id);
            if (!cliente)
            {
                return NotFound(new { message = "Cliente não encontrado." });
            }
            return Ok();
        }
    }
}
