using FluentResults;
using GestaoParaEstacionamento.Core.Dominio.ModuloAutenticacao;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloAutenticacao.Commands
{
    public record AutenticarUsuarioCommand(String Email, string Senha) : IRequest<Result<AccessToken>>;
}
