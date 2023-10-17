using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys.Interfaces
{
    public interface ICartRepository
    {
        Task<List<CarinhoModel>> GetAllCarts();
        Task<CarinhoModel> GetCartById(int id);
        Task<CarinhoModel> AddCart(CarinhoModel cart);

        Task<CarinhoModel> UpdateCartById(CarinhoModel cart, int id);

        Task<bool> DeleteCartById(int id);
    }
}
