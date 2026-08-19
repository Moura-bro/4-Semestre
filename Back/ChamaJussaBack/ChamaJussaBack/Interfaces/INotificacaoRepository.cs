using ChamaJussaBack.Models;

namespace ChamaJussaBack.Interfaces
{
    public interface INotificacaoRepository
    {
        Notificacao BuscarPorId(Guid id);
        List<Notificacao> ListarNotificacoes();
        void Cadastrar(Notificacao novaNotificacao);
        void Deletar(Guid id);
        void Atualizar(Notificacao notificacaoAtualizada);

        void AtualizarVerificada(Guid id, bool verificada);
    }
}
