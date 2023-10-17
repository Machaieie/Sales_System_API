using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<VendaModel>> GetAllSales();
        Task<VendaModel> GetSaleById(int id);

        Task<VendaModel> AddSale(VendaModel sale);

        Task<bool> DeleteSaleById(int id);


        Task<VendaModel> updateSaleById(VendaModel sale, int id);
    }
}
