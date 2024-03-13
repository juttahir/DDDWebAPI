using DDDWebAPI.Application.DTO.DTO;

namespace DDDWebAPI.Application.Interfaces;

public interface IApplicationServiceProduto
{
    void Add(ProdutoDTO obj);

    ProdutoDTO GetById(int id);

    IEnumerable<ProdutoDTO> GetAll();

    void Update(ProdutoDTO obj);

    void Remove(ProdutoDTO obj);

    void Dispose();
}