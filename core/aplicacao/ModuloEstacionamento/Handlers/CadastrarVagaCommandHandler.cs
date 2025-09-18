using FluentResults;
using GestaoParaEstacionamento.Core.Aplicacao.ModuloEstacionamento.Commands;
using GestaoParaEstacionamento.Core.Aplicacao.Compartilhado;
using GestaoParaEstacionamento.Core.Dominio.Compartilhado;
using GestaoParaEstacionamento.Core.Dominio.ModuloEstacionamento;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloEstacionamento.Handlers;
public class CadastrarVagaCommandHandler(IRepositorioVaga repositorioVaga,
                                         IUnitOfWork unitOfWork,
                                         ILogger<CadastrarVagaCommandHandler> logger)
    : IRequestHandler<CadastrarVagaCommand, Result<CadastrarVagaResult>>
{
    public async Task<Result<CadastrarVagaResult>> Handle(CadastrarVagaCommand command, 
                                                          CancellationToken cancellationToken) {
        if (command.Identificador <= 0)
            return Result.Fail(ResultadosErro.RequisicaoInvalidaErro("O identificador da vaga deve ser positivo."));

        if (string.IsNullOrWhiteSpace(command.Zona))
            return Result.Fail(ResultadosErro.RequisicaoInvalidaErro("A zona da vaga é obrigatória."));

        var registros = await repositorioVaga.SelecionarRegistrosAsync();

        var idStr = command.Identificador.ToString();

        foreach (var vaga in registros) {

            if (vaga.Identificador == idStr && vaga.Zona.Equals(command.Zona, StringComparison.OrdinalIgnoreCase))
                return Result.Fail(ResultadosErro.RegistroDuplicadoErro
                    ("Já existe uma vaga com este identificador nessa mesma zona."));
        }

        try {
            var novaVaga = new VagaEstacionamento(idStr, command.Zona);

            await repositorioVaga.CadastrarAsync(novaVaga);
            await unitOfWork.CommitAsync();

            return Result.Ok(new CadastrarVagaResult(novaVaga.Id));

        } catch (Exception ex) {
            await unitOfWork.RollbackAsync();

            logger.LogError(ex, "Erro ao cadastrar {@Command}", command);

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}