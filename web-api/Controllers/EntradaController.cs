using GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;
using GestaoParaEstacionamento.WebApi.Models.Entrada;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoParaEstacionamento.WebApi.Controllers;

[Route("entradas")]
[ApiController]
public class EntradaController(IMediator mediator, ISender sender) : ControllerBase
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

    [HttpGet]
    public async Task<ActionResult<SelecionarEntradasResult>> SelecionarRegistros(
        [FromQuery] SelecionarEntradasRequest request
    ) {
        var query = new SelecionarEntradasQuery(request?.Quantidade);

        var result = await mediator.Send(query);

        if (result.IsFailed) return BadRequest();

        var response = new SelecionarEntradasResponse(
            result.Value.Entradas.Count,
            result.Value.Entradas
        );

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SelecionarEntradaPorIdResponse>> SelecionarRegistroPorId(
        Guid id
    ) {
        var query = new SelecionarEntradaPorIdQuery(id);

        var result = await mediator.Send(query);

        if (result.IsFailed) return NotFound(id);
        
        var response = new SelecionarEntradaPorIdResponse(
            result.Value.Id,
            result.Value.Ticket,
            result.Value.DataHoraEntrada,
            result.Value.Placa,
            result.Value.Modelo,
            result.Value.Cor,
            result.Value.CpfHospede,
            result.Value.Observacoes
        );

        return Ok(response);
    }

    [HttpPatch("{id:guid}/observacoes")]
    public async Task<ActionResult<AtualizarObservacaoResult>> AtualizarObservacoes(
        Guid id, 
        AtualizarObservacaoRequest body
    ) {
        var cmd = new AtualizarObservacaoCommand(id, body.Observacao ?? string.Empty);

        var result = await sender.Send(cmd);

        if (result.IsFailed) return BadRequest();

        return Ok(result.Value);
    }


    [HttpGet("entradas/ticket/{input}")]
    public async Task<IActionResult> GetByTicket(string input, ISender sender) {

        if (!TryParseTicket(input, out var numero))
            return BadRequest(new { erro = "Formato de ticket inválido. Use 123 ou T-0123." });

        var result = await sender.Send(new SelecionarEntradaPorTicketQuery(numero));

        if (result.IsFailed) return NotFound(new { erros = result.Errors.Select(e => e.Message) });

        return Ok(result.Value);
    }

    private static bool TryParseTicket(string input, out int numero) {
        input = input.Trim();
        if (input.StartsWith("T-", StringComparison.OrdinalIgnoreCase))
            input = input[2..];

        return int.TryParse(input, out numero) && numero > 0;
    }
}
