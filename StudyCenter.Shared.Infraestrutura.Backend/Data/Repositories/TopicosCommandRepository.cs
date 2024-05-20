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

    public void Remover(Topicos topicos)
    {
        _context.Topicos.Remove(topicos);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}