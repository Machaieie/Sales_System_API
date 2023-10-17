using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys.Interfaces
{
    public interface IStockRepository
    {

        Task<List<StockModel>> GetAllStock();
        Task<StockModel> GetStockById(int id);

        Task<StockModel> AddSale(StockModel stock);

        Task<bool> DeleteStockById(int id);


        Task<StockModel> updateStockById(StockModel stock, int id);
    }
}
