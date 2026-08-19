using ChamaJussaBack.Models;

namespace ChamaJussaBack.Interfaces
{
    public interface IChamadoRepository
    {
        Chamado BuscarPorId(Guid id);
        List<Chamado> ListarChamados();
        void Cadastrar(Chamado novochamado);
        void Deletar(Guid id);
        void Atualizar(Chamado chamadoAtualizado);
        void AtualizarStatus(Guid id, string status);
    }
}
