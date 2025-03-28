using Microsoft.AspNetCore.Mvc;
using PharmaAPI.Business.Business.Interface;
using PharmaAPI.Domain.Entities;

namespace PharmaAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicamentoController : ControllerBase
{
    private readonly IMedicamentoBusiness medicamentoBusiness;

    public MedicamentoController(IMedicamentoBusiness medicamentoBusiness)
    {
        this.medicamentoBusiness = medicamentoBusiness;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Medicamentos request)
    {
        var medicamento = await medicamentoBusiness.Create(request);
        return Ok(medicamento);        
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var medicamentos = await medicamentoBusiness.GetAll();         

        return Ok(medicamentos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var medicamento = await medicamentoBusiness.GetById(id);

        if(medicamento == null)
        {
            return NotFound(new { message = "Medicamento não encontrado." });
        }

        return Ok(medicamento);
    }    


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Medicamentos medicamentoAtualizado)
    {       
        var medicamento = await medicamentoBusiness.Update(id, medicamentoAtualizado);
        if (medicamento == null)
        {
            return NotFound(new { message = "Medicamento não encontrado." });
        }

        return Ok("Registro atualizado com sucesso!");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var medicamento = await medicamentoBusiness.Delete(id);
        if(!medicamento)
        {
            return NotFound(new { message = "Medicamento não encontrado." });
        }

        return Ok("Remoção realizada com sucesso!");
    }
}
