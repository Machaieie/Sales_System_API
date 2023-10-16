using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys.Interfaces
{
    public interface ICartRepository
    {
        Task<List<CarrinhoModel>> GetAllCarts();
        Task<CarrinhoModel> GetCartById(int id);
        Task<CarrinhoModel> AddCart(CarrinhoModel cart);

        Task<CarrinhoModel> UpdateCartById(CarrinhoModel cart, int id);

        Task<bool> DeleteCartById(int id);
    }
}
