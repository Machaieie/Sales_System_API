using API_Gestao_Sock.Data;
using API_Gestao_Sock.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DataContext _dataContext;
        public SaleRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public async Task<VendaModel> AddSale(VendaModel sale)
        {
           await _dataContext.Venda.AddAsync(sale);
            await _dataContext.SaveChangesAsync();
            return sale;
        }

        public async Task<bool> DeleteSaleById(int id)
        {
            VendaModel venda = await GetSaleById(id);
            if (venda == null)
            {
                throw new Exception($"Venda com o id: {id} não encontrado");
            }
            _dataContext.Venda.Remove(venda);   
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<VendaModel>> GetAllSales()
        {
            return await _dataContext.Venda.ToListAsync();
        }

        public async Task<VendaModel> GetSaleById(int id)
        {
            return await _dataContext.Venda.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<VendaModel> updateSaleById(VendaModel sale, int id)
        {
            VendaModel venda = await GetSaleById(id);
            if (venda == null)
            {
                throw new Exception($"Venda com o id: {id} não encontrado");
            }

            venda.Status = sale.Status;
            venda.PrecoPago = sale.PrecoPago;
            _dataContext.Venda.Update(venda);
            await _dataContext.SaveChangesAsync();
            return venda;
        }
    }
}
