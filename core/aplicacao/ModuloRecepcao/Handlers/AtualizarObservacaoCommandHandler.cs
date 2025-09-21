using FluentResults;
using GestaoParaEstacionamento.Core.Aplicacao.Compartilhado;
using GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
using GestaoParaEstacionamento.Core.Dominio.Compartilhado;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Handlers;
public class AtualizarObservacaoCommandHandler(IRepositorioEntrada repositorioEntrada,
                                               IUnitOfWork unitOfWork,
                                               ILogger<AtualizarObservacaoCommandHandler> logger)
    : IRequestHandler<AtualizarObservacaoCommand, Result<AtualizarObservacaoResult>>
{
    public async Task<Result<AtualizarObservacaoResult>> Handle(AtualizarObservacaoCommand command, 
                                                                CancellationToken cancellationToken) {
        var registros = await repositorioEntrada.SelecionarRegistroPorIdAsync(command.Id);

        if (registros is null) {
           return Result.Fail(ResultadosErro.RegistroNaoEncontradoErro(command.Id));
        }

        try {
            registros.DefinirObservacoes(command.Observacao);

            await unitOfWork.CommitAsync();

            var result = new AtualizarObservacaoResult(
                $"T-{registros.Ticket.Numero:D4}",
                registros.Observacoes
            );
            
            return Result.Ok(result);

        } catch (Exception ex) {
            logger.LogError(
                ex,
                "Ocorreu um erro durante a atualização de {@Registro}",
                command);
            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
