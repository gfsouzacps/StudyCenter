using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
public class AnotacoesTopicosCommandRepository : IAnotacoesTopicosCommandRepository
{
    private readonly StudyCenterDbContext _context;

    public AnotacoesTopicosCommandRepository(StudyCenterDbContext context)
    {
        _context = context;
    }

    public void Registrar(AnotacoesTopicos AnotacoesTopicos)
    {
        _context.Add(AnotacoesTopicos);
    }

    public void Atualizar(AnotacoesTopicos AnotacoesTopicos)
    {
        _context.AnotacoesTopicos.Update(AnotacoesTopicos);
    }

    public void Remover(AnotacoesTopicos AnotacoesTopicos)
    {
        _context.AnotacoesTopicos.Remove(AnotacoesTopicos);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}