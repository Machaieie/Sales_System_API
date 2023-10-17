using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProdutoModel>> GetAllProducts();
        Task<ProdutoModel> GetProdutoByCode(string code);

        Task<ProdutoModel> AddProduct(ProdutoModel product);

        Task<ProdutoModel> GetProductByName(string name);

        

        Task<bool> DeleteprodutoByCode(string code); 

       
        Task<ProdutoModel> updateProductByCode(ProdutoModel model, string code);
    }
}
