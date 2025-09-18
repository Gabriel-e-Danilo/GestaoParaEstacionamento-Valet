namespace GestaoParaEstacionamento.Core.Dominio.Compartilhado;

public abstract class EntidadeBase<T>
{
    public Guid Id { get; set; }

    public virtual void AtualizarRegistro(T registroEditado) { }
}