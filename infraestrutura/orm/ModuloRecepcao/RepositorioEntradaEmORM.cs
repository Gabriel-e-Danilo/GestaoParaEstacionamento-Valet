using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
using GestaoParaEstacionamento.Infraestrutura.ORM.Compartilhado;

namespace GestaoParaEstacionamento.Infraestrutura.ORM.ModuloRecepcao;
public class RepositorioEntradaEmORM(AppDbContext contexto)
    : RepositorioBaseEmOrm<Entrada>(contexto), IRepositorioEntrada;