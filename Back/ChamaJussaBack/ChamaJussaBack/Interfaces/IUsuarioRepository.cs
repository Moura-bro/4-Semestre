using ChamaJussaBack.Models;

namespace ChamaJussaBack.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPorId(Guid id);
        List<Usuario> ListarUsuarios();
        void Cadastrar(Usuario novoUsuario);
        void Deletar(Guid id);
        void Atualizar(Usuario usuarioAtualizado);      
        void AtualizarSenha(Guid id, string novaSenha);
    }
}
