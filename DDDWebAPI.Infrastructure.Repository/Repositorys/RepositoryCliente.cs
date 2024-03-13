using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.Data;
using DDDWebAPI.Domain.Core.Interfaces.Repositorys;

namespace DDDWebAPI.Infrastructure.Repository.Repositorys;

public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
{
    private readonly SqlContext _context;
    public RepositoryCliente(SqlContext context)
        : base(context)
    {
        _context = context;
    }
}