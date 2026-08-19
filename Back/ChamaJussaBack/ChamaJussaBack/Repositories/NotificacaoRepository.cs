using ChamaJussaBack.Context;
using ChamaJussaBack.Interfaces;
using ChamaJussaBack.Models;

namespace ChamaJussaBack.Repositories
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly dbTecnicoChamadosContext _context;

        public NotificacaoRepository(dbTecnicoChamadosContext context)
        {
            _context = context;
        }



        //------------------------------------ATUALIZAÇÃO DE STATUS/iNFORMAÇÕES DA NOTIFICAÇÃO------------------------------------//


        public void Atualizar(Notificacao notificacaoAtualizada)
        {
            try
            {
                Notificacao? notificacaoBuscada =
                    _context.Notificacaos.Find(notificacaoAtualizada.IdNotificacao);

                if (notificacaoBuscada != null)
                {
                    notificacaoBuscada.Titulo = notificacaoAtualizada.Titulo;
                    notificacaoBuscada.Mensagem = notificacaoAtualizada.Mensagem;

                    _context.SaveChanges();
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao atualizar notificação: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //------------------------------------

        public void AtualizarVerificada(Guid id, bool verificada)
        {
            try
            {
                Notificacao? notificacaoBuscada = _context.Notificacaos.Find(id);

                if (notificacaoBuscada != null)
                {
                    notificacaoBuscada.Verificada = verificada;
                    _context.SaveChanges();
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao atualizar verificação da notificação: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //------------------------------------BUSCA DE NOTIFICAÇÕES----------------------------------------------------------------//

        public Notificacao BuscarPorId(Guid id)
        {
            try
            {
                Notificacao? notificacaoBuscada = _context.Notificacaos.Find(id);

                if (notificacaoBuscada == null)
                {
                    throw new Exception("Notificação não encontrada.");
                }

                return notificacaoBuscada;
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro na busca da notificação: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //------------------------------------CADASTRO E DELEÇÃO DE NOTIFICAÇÕES---------------------------------------------------//

        public void Cadastrar(Notificacao novaNotificacao)
        {
            try
            {
                novaNotificacao.IdNotificacao = Guid.NewGuid();

                _context.Notificacaos.Add(novaNotificacao);
                _context.SaveChanges();
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao cadastrar notificação: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //------------------------------------DELEÇÃO DE NOTIFICAÇÕES--------------------------------------------------------------//

        public void Deletar(Guid id)
        {
            try
            {
                Notificacao? notificacaoBuscada = _context.Notificacaos.Find(id);

                if (notificacaoBuscada != null)
                {
                    _context.Notificacaos.Remove(notificacaoBuscada);
                    _context.SaveChanges();
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao deletar notificação: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //------------------------------------LISTAGEM DE NOTIFICAÇÕES--------------------------------------------------------------//

        public List<Notificacao> ListarNotificacoes()
        {
            try
            {
                List<Notificacao> listaNotificacaos = _context.Notificacaos.ToList();

                return listaNotificacaos;
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao Listar as notificação: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }
    }
}
