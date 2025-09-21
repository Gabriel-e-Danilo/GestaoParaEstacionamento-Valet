using GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;
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
        var veiculo = VeiculoInfo.From(
            request.Placa, 
            request.Modelo, 
            request.Cor, 
            request.CpfHospede
        );

        var command = new CadastrarEntradaCommand(
            veiculo,
            request.Observacoes
        );

        var result = await mediator.Send(command);

        if (result.IsFailed) return BadRequest();

        var response = new CadastrarEntradaResponse(
            result.Value.Id
        );

        return Created(string.Empty, response);
    }
}
