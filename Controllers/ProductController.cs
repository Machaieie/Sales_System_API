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
        private readonly ProductRepository _productRepository;

        public  ProductController(ProductRepository productRepository)
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
        public async Task<ActionResult<ProdutoModel>> getProductById(String id)
        {
            ProdutoModel produtoModel = await _productRepository.GetProdutoByCode(id);
            if(produtoModel == null){
                return NotFound();
            }
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
