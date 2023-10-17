using API_Gestao_Sock.Repositorys;
using API_Gestao_Sock.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sales_System_API.Model;

namespace API_Gestao_Sock.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public  ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> getAllProducts()
        {
            List<ProdutoModel> produtoModels = await _productRepository.GetAllProducts();
            return Ok(produtoModels);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<ProdutoModel>> getProductById(String codigo)
        {
            ProdutoModel produtoModel = await _productRepository.GetProdutoByCode(codigo);
            return Ok(produtoModel);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> AddProduct([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _productRepository.AddProduct(produtoModel);
            return Ok(produto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> UpdateProduct([FromBody] ProdutoModel productModel, string codigo)
        {
            productModel.Codigo = codigo;
            ProdutoModel produto = await _productRepository.updateProductByCode(productModel, codigo);
            return Ok(produto);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> DeleteProduct(ProdutoModel productModel, string codigo)
        {
            productModel.Codigo = codigo;
            bool productDeleted = await _productRepository.DeleteprodutoByCode(codigo);
            return Ok(productDeleted);

        }

    }
}
