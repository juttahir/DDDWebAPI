using System;
using System.Collections.Generic;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Domain.Core.Interfaces.Repositorys;

namespace DDDWebAPI.Domain.Services.Services;

public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
{
    private readonly IRepositoryBase<TEntity> _repository;

    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
        _repository = repository;
    }
    public virtual void Add(TEntity obj)
    {
        _repository.Add(obj);
    }
    public virtual TEntity GetById(int id)
    {
        return _repository.GetById(id);
    }
    public virtual IEnumerable<TEntity> GetAll()
    {
        return _repository.GetAll();
    }
    public virtual void Update(TEntity obj)
    {
        _repository.Update(obj);
    }
    public virtual void Remove(TEntity obj)
    {
        _repository.Remove(obj);
    }

    public virtual void Dispose()
    {
        _repository.Dispose();
    }
}