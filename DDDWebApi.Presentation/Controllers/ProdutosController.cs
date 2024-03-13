using Microsoft.AspNetCore.Mvc;
using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Application.Interfaces;

namespace DDDWebAPI.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutosController(IApplicationServiceProduto ApplicationServiceProduto)
        {
            _applicationServiceProduto = ApplicationServiceProduto;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_applicationServiceProduto.GetAll());
        }

        // GET api/values/5\
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_applicationServiceProduto.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();


                _applicationServiceProduto.Add(produtoDTO);
                return Ok("O produto foi cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {

            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Update(produtoDTO);
                return Ok("O produto foi atualizado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public IActionResult Delete([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Remove(produtoDTO);
                return Ok("O produto foi removido com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
}