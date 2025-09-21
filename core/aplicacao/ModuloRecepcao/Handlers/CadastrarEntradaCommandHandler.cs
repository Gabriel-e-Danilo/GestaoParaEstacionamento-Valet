using FluentResults;
using GestaoParaEstacionamento.Core.Aplicacao.Compartilhado;
using GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
using GestaoParaEstacionamento.Core.Dominio.Compartilhado;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Handlers;
public class CadastrarEntradaCommandHandler(IRepositorioEntrada repositorioEntrada,
                                            IUnitOfWork unitOfWork,
                                            ILogger<CadastrarEntradaCommandHandler> logger)
    : IRequestHandler<CadastrarEntradaCommand, Result<CadastrarEntradaResult>>
{
    public async Task<Result<CadastrarEntradaResult>> Handle(CadastrarEntradaCommand command, 
                                                             CancellationToken cancellationToken) {
        var registros = await repositorioEntrada.SelecionarRegistrosAsync();

        if (registros.Any(e => e.Veiculo.Placa.Equals(command.VeiculoInfo))) {
           return Result.Fail(ResultadosErro
                             .RegistroDuplicadoErro("Já existe uma entrada cadastrada com a placa informada."));
        }

        try {
            var entrada = Entrada.Criar(command.VeiculoInfo, command.Observacoes);

            await repositorioEntrada.CadastrarAsync(entrada);
            await unitOfWork.CommitAsync();

            var result = new CadastrarEntradaResult(entrada.Id, entrada.Ticket);

            return Result.Ok(result);

        } catch (Exception ex) {

            await unitOfWork.RollbackAsync();

            logger.LogError("Ocorreu um erro durante o registro de {@Registro}", command);

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
