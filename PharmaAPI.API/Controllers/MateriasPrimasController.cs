using Microsoft.AspNetCore.Mvc;
using PharmaAPI.Business.Business.Interface;

namespace PharmaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaController : ControllerBase
    {
        private readonly IMateriaPrimaBusiness materiaPrimaBusiness;

        public MateriaPrimaController(IMateriaPrimaBusiness materiaPrimaBusiness)
        {
            this.materiaPrimaBusiness = materiaPrimaBusiness;
        }

        // POST: api/MateriaPrima
        [HttpPost]
        public async Task<ActionResult<MateriasPrimas>> Create(MateriasPrimas request)
        {
            var materiaPrima = await materiaPrimaBusiness.Create(request);
            return Ok(materiaPrima);
        }

        // GET: api/MateriaPrima
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriasPrimas>>> GetAll()
        {
            return await materiaPrimaBusiness.GetAll();
        }

        // GET: api/MateriaPrima/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MateriasPrimas>> Get(int id)
        {
            var materiaPrima = await materiaPrimaBusiness.GetById(id);

            if (materiaPrima == null)
            {
                return NotFound();
            }

            return materiaPrima;
        }

        // PUT: api/MateriaPrima/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MateriasPrimas request)
        {
            var materiaPrima = await materiaPrimaBusiness.Update(id, request);
            if (materiaPrima == null)
            {
                return NotFound(new { message = "Materia Prima não encontrado." });
            }
            return Ok("Registro atualizado com sucesso!");

        }

        // DELETE: api/MateriaPrima/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MateriasPrimas>> Delete(int id)
        {
            var materiaPrima = await materiaPrimaBusiness.Delete(id);
            if (!materiaPrima)
            {
                return NotFound(new { message = "Materia Prima não encontrado." });
            }
            return Ok("Remoção realizada com sucesso!");
        }
    }
}
