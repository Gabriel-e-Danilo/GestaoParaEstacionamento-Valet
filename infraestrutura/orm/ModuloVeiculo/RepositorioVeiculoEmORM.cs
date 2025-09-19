using GestaoParaEstacionamento.Core.Dominio.ModuloVeiculo;
using GestaoParaEstacionamento.Infraestrutura.ORM.Compartilhado;

namespace GestaoParaEstacionamento.Infraestrutura.ORM.ModuloVeiculo;
public class RepositorioVeiculoEmORM(AppDbContext contexto)
    : RepositorioBaseEmOrm<Veiculo>(contexto), IRepositorioVeiculo;