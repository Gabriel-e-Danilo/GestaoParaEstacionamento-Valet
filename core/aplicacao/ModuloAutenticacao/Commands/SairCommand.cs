using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloAutenticacao.Commands
{
    public record SairCommand : IRequest<Result>;
}
