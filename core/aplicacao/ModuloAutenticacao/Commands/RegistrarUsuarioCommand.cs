using FluentResults;
using GestaoParaEstacionamento.Core.Dominio.ModuloAutenticacao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloAutenticacao.Commands
{
    public record RegistrarUsuarioCommand(string NomeCompleto, string Email, string Senha) : IRequest<Result<AccessToken>>;
}
