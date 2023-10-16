using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProdutoModel>> GetAllProducts();
        Task<ProdutoModel> GetProdutoByCode(int id);

        Task<ProdutoModel> GetProductByName(string name);

        Task<ProdutoModel> DeleteproductByName(string id);

        Task DeleteprodutoByCode(int id); 

       
        Task updateProductByCode(ProdutoModel model, int id);
    }
}
