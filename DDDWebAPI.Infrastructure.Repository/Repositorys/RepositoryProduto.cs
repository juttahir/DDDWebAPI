using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.Data;
using DDDWebAPI.Infrastructure.Repository.Repositorys;

namespace DDDWebAPI.Infrastructure.Repository.Repositorys;

public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
{
    private readonly SqlContext _context;
    public RepositoryProduto(SqlContext Context)
        : base(Context)
    {
        _context = Context;
    }
}