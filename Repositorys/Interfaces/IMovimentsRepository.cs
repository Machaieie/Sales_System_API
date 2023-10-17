using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys.Interfaces
{
    public interface IMovimentsRepository
    {
        Task<List<MovimentosStockModel>> GetAllMovimentStock();
        Task<MovimentosStockModel> GetMovimentStockById(int id);

        Task<MovimentosStockModel> AddMovimentStock(MovimentosStockModel movimentosStock);

        Task<bool> DeleteMovimentStockById(int id);


        Task<MovimentosStockModel> updateMovimentStockById(MovimentosStockModel movimentosStock, int id);
    }
}
