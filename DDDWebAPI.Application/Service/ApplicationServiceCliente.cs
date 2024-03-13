using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace DDDWebAPI.Application.Service;

public class ApplicationServiceCliente : IApplicationServiceCliente
{
    private readonly IServiceCliente _serviceCliente;
    private readonly IMapperCliente _mapperCliente;
     
    public ApplicationServiceCliente(IServiceCliente serviceCliente
        , IMapperCliente mapperCliente)
                                              
    {
        _serviceCliente = serviceCliente;
        _mapperCliente = mapperCliente;
    }


    public void Add(ClienteDTO obj)
    {
        var objCliente = _mapperCliente.MapperToEntity(obj);
        _serviceCliente.Add(objCliente);
    }

    public void Dispose()
    {
        _serviceCliente.Dispose();
    }

    public IEnumerable<ClienteDTO> GetAll()
    {
        var objProdutos = _serviceCliente.GetAll();
        return _mapperCliente.MapperListClientes(objProdutos);
    }

    public ClienteDTO GetById(int id)
    {
        var objcliente = _serviceCliente.GetById(id);
        return _mapperCliente.MapperToDTO(objcliente);
    }

    public void Remove(ClienteDTO obj)
    {
        var objCliente = _mapperCliente.MapperToEntity(obj);
        _serviceCliente.Remove(objCliente);
    }

    public void Update(ClienteDTO obj)
    {
        var objCliente = _mapperCliente.MapperToEntity(obj);
        _serviceCliente.Update(objCliente);
    }
}