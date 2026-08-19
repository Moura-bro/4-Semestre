using ChamaJussaBack.Context;
using ChamaJussaBack.Interfaces;
using ChamaJussaBack.Models;

namespace ChamaJussaBack.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dbTecnicoChamadosContext _context;

        public UsuarioRepository(dbTecnicoChamadosContext context)
        {
            _context = context;
        }

        //------------------------------------ATUALIZAÇÃO DE INFORMAÇÕES DO USUÁRIO------------------------------------//


        public void Atualizar(Usuario usuarioAtualizado)
        {
            try
            {
                Usuario? usuarioBuscado =
                    _context.Usuarios.Find(usuarioAtualizado.IdUsuario);

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Nome = usuarioAtualizado.Nome;
                    usuarioBuscado.Email = usuarioAtualizado.Email;
                    usuarioBuscado.FotoPerfil = usuarioAtualizado.FotoPerfil;

                    _context.SaveChanges();
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao atualizar usuário: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }


        //------------------------------------ATUALIZAÇÃO DE SENHA DO USUÁRIO------------------------------------//

        public void AtualizarSenha(Guid id, string novaSenha)
        {
            try
            {
                Usuario? usuarioBuscado = _context.Usuarios.Find(id);

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Senha = novaSenha;

                    _context.SaveChanges();
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao atualizar senha do usuário: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }


        //------------------------------------BUSCA DE INFORMAÇÕES DO USUÁRIO------------------------------------//
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario? usuarioBuscado = _context.Usuarios.Find(id);

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }

                throw new InvalidOperationException("Usuário não encontrado");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao buscar usuário: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //------------------------------------CADASTRO E DELEÇÃO DE USUÁRIO------------------------------------//

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.IdUsuario = Guid.NewGuid();

                _context.Usuarios.Add(novoUsuario);
                _context.SaveChanges();
            }
            catch (Exception erro)
            {

                Console.WriteLine($"Erro ao cadastrar usuário: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //------------------------------------DELEÇÃO DE USUÁRIO------------------------------------//

        public void Deletar(Guid id)
        {
            try
            {
                Usuario? usuarioBuscado = _context.Usuarios.Find(id);

                if (usuarioBuscado != null)
                {
                    _context.Usuarios.Remove(usuarioBuscado);
                    _context.SaveChanges();
                }

            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao deletar usuario: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //------------------------------------LISTAGEM DE USUÁRIOS------------------------------------//

        public List<Usuario> ListarUsuarios()
        {
            try
            {
                List<Usuario> listaUsuarios = _context.Usuarios.ToList();
                return listaUsuarios;
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao buscar usuário: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }
    }
}
