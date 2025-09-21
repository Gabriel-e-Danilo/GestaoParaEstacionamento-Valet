using GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
using GestaoParaEstacionamento.WebApi.Models.Entrada;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoParaEstacionamento.WebApi.Controllers;

[Route("entradas")]
[ApiController]
public class EntradaController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CadastrarEntradaResponse>> Cadastrar(CadastrarEntradaRequest request) {
        var command = new CadastrarEntradaCommand(
            request.VeiculoInfo,
            request.Observacoes
        );

        var result = await mediator.Send(command);

        if (result.IsFailed) return BadRequest();

        var response = new CadastrarEntradaResponse(
            result.Value.Id,
            result.Value.Ticket
        );

        return Created(string.Empty, response);
    }
}
