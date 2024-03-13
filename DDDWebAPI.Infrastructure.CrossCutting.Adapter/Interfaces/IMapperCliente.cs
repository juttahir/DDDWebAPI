using DDDWebAPI.Domain.Models;
using DDDWebAPI.Application.DTO;
using System.Collections.Generic;
using DDDWebAPI.Application.DTO.DTO;

namespace DDDWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

public interface IMapperCliente
{
    #region Mappers

    Cliente MapperToEntity(ClienteDTO clienteDTO);

    IEnumerable<ClienteDTO> MapperListClientes(IEnumerable<Cliente> clientes);

    ClienteDTO MapperToDTO(Cliente cliente);

    #endregion
}