using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloAutenticacao
{
    public interface ITenantProvider
    {
        Guid? UsuarioId { get; }
        bool IsInRole(string role);
    }
}
