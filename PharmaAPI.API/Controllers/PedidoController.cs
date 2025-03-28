using Microsoft.AspNetCore.Mvc;
using PharmaAPI.Business.Business.Interface;

namespace PharmaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoBusiness pedidoBusiness;

        public PedidoController(IPedidoBusiness PedidoBusiness)
        {
            this.pedidoBusiness = PedidoBusiness;
        }

        // POST: api/pedido
        [HttpPost]
        public async Task<ActionResult<Pedidos>> PostPedido(Pedidos request)
        {
            var pedido = await pedidoBusiness.Create(request);
            return Ok(pedido);
        }

        // GET: api/pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedidos>>> GetAll()
        {
            return await pedidoBusiness.GetAll();
        }

        // GET: api/pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> Get(int id)
        {
            var pedido = await pedidoBusiness.GetById(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedido/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pedidos request)
        {
            var pedido = await pedidoBusiness.Update(id, request);
            if (pedido == null)
            {
                return NotFound(new { message = "Pedido não encontrado." });
            }
            return Ok("Registro atualizado com sucesso!");

        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedidos>> Delete(int id)
        {
            var pedido = await pedidoBusiness.Delete(id);
            if (!pedido)
            {
                return NotFound(new { message = "Pedido não encontrado." });
            }
            return Ok("Remoção realizada com sucesso!");
        }
    }
}
