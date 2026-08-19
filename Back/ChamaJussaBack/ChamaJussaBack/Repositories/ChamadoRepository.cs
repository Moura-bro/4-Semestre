using ChamaJussaBack.Context;
using ChamaJussaBack.Interfaces;
using ChamaJussaBack.Models;

namespace ChamaJussaBack.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly dbTecnicoChamadosContext _context;

        public ChamadoRepository(dbTecnicoChamadosContext context)
        {
            _context = context;
        }



        //------------------------------------ATUALIZAÇÃO DE STATUS/iNFORMAÇÕES DO CHAMADO------------------------------------//
        public void Atualizar(Chamado chamadoAtualizado)
        {
            // Lógica para atualizar o chamado no banco de dados
            try
            {
                Chamado chamadoBuscado = _context.Chamados.Find(chamadoAtualizado.IdChamado);

                if (chamadoBuscado != null)
                {
                    // Atualiza as propriedades do chamado
                    chamadoBuscado.Titulo = chamadoAtualizado.Titulo;
                    chamadoBuscado.Equipamento = chamadoAtualizado.Equipamento;
                    chamadoBuscado.Setor = chamadoAtualizado.Setor;
                    chamadoBuscado.Descricao = chamadoAtualizado.Descricao;
                    chamadoBuscado.FotoDoProblema = chamadoAtualizado.FotoDoProblema;
                    chamadoBuscado.DataAtualizacao = DateTime.Now;

                    // ... outras propriedades a serem atualizadas

                    _context.Chamados.Update(chamadoBuscado);
                    _context.SaveChanges();
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao atualizar chamado: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //-----------------------------------//


        public void AtualizarStatus(Guid id, string status)
        {
            try
            {
                Chamado? chamadoBuscado = _context.Chamados.Find(id);

                if (chamadoBuscado != null)
                {

                    chamadoBuscado.StatusOs = status;
                    chamadoBuscado.DataAtualizacao = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao atualizar status do chamado: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }


        //------------------------------------CRUD DE CHAMADOS------------------------------------//

        public Chamado BuscarPorId(Guid id)
        {
            try
            {
                Chamado? chamadoBuscado = _context.Chamados.Find(id);

                if (chamadoBuscado == null)
                {
                    throw new Exception("Chamado não encontrado.");
                }

                return chamadoBuscado;
            }
            catch (Exception erro)
            {

                Console.WriteLine($"Erro ao buscar chamado: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //-----------------------------------CADASTRO E LISTAGEM DE CHAMADOS------------------------------------//

        public void Cadastrar(Chamado novochamado)
        {
            try
            {
                novochamado.IdChamado = Guid.NewGuid();
                novochamado.DataAtualizacao = DateTime.Now;

                _context.Chamados.Add(novochamado);
                _context.SaveChanges();
            }
            catch (Exception erro)
            {

                Console.WriteLine($"Erro ao cadastrar chamado: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }
        }

        //-----------------------------------DELETAÇÃO DE CHAMADOS------------------------------------//

        public void Deletar(Guid id)
        {
            try
            {
                Chamado? chamadoBuscado = _context.Chamados.Find(id);

                if (chamadoBuscado != null)
                {
                    _context.Chamados.Remove(chamadoBuscado);
                    _context.SaveChanges();
                }

            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao deletar chamado: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }

        }

        //-----------------------------------LISTAGEM DE CHAMADOS------------------------------------//

        public List<Chamado> ListarChamados()
        {
            try
            {
                List<Chamado> listaChamados = _context.Chamados.ToList();
                return listaChamados;
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao buscar chamado: {erro.Message}");
                Console.WriteLine($"Tipo do erro: {erro.GetType().Name}");
                Console.WriteLine($"Detalhes: {erro.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {erro.StackTrace}");

                throw;
            }

        }
    }
}
