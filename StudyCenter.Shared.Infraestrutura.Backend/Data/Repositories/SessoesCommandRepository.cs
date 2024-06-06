using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
public class SessoesCommandRepository : ISessoesCommandRepository
{
    private readonly StudyCenterDbContext _context;

    public SessoesCommandRepository(StudyCenterDbContext context)
    {
        _context = context;
    }

    public void Registrar(Sessoes sessoes)
    {
        _context.Add(sessoes);
    }

    public void Atualizar(Sessoes sessoes)
    {
        _context.Sessoes.Update(sessoes);
    }

    public void Remover(Sessoes sessao)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var sessaoTopicos = _context.SessaoTopicos.Where(st => st.IdSessao == sessao.IdSessao).ToList();
                foreach (var sessaoTopico in sessaoTopicos)
                {
                    var anotacoesTopicos = _context.AnotacoesTopicos.Where(at => at.IdSessaoTopico == sessaoTopico.IdSessaoTopico).ToList();
                    foreach (var anotacaoTopico in anotacoesTopicos)
                    {
                        _context.AnotacoesTopicos.Remove(anotacaoTopico);
                    }
                    _context.SessaoTopicos.Remove(sessaoTopico);
                }

                _context.Sessoes.Remove(sessao);
                _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}