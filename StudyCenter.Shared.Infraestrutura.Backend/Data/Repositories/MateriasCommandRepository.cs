using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
public class MateriasCommandRepository : IMateriasCommandRepository
{
    private readonly StudyCenterDbContext _context;

    public MateriasCommandRepository(StudyCenterDbContext context)
    {
        _context = context;
    }

    public void Registrar(Materias materias)
    {
        _context.Add(materias);
    }

    public void Atualizar(Materias materias)
    {
        _context.Materias.Update(materias);
    }

    public void Remover(Materias materias)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var topicos = materias.Topicos.ToList();
            foreach (var topico in topicos)
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
            }

            _context.Materias.Remove(materias);
            _context.SaveChanges();

            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

        public void Dispose()
    {
        _context.Dispose();
    }
}