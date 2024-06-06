using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
public class TopicosCommandRepository : ITopicosCommandRepository
{
    private readonly StudyCenterDbContext _context;

    public TopicosCommandRepository(StudyCenterDbContext context)
    {
        _context = context;
    }

    public void Registrar(Topicos topicos)
    {
        _context.Add(topicos);
    }

    public void Atualizar(Topicos topicos)
    {
        _context.Topicos.Update(topicos);
    }

    public void Remover(Topicos topico)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var sessaoTopicos = _context.SessaoTopicos.Where(st => st.IdTopico == topico.IdTopico).ToList();
                foreach (var sessaoTopico in sessaoTopicos)
                {
                    var anotacoesTopicos = _context.AnotacoesTopicos.Where(at => at.IdSessaoTopico == sessaoTopico.IdSessaoTopico).ToList();
                    foreach (var anotacaoTopico in anotacoesTopicos)
                    {
                        _context.AnotacoesTopicos.Remove(anotacaoTopico);
                    }
                    _context.SessaoTopicos.Remove(sessaoTopico);
                }

                _context.Topicos.Remove(topico);
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