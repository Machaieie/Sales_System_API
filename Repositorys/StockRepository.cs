using API_Gestao_Sock.Data;
using API_Gestao_Sock.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys
{
    public class StockRepository : IStockRepository
    {
        private readonly DataContext _dataContext;
        public StockRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

       
        public async Task<StockModel> AddStock(StockModel stock)
        {
            await _dataContext.Estoques.AddAsync(stock);
            await _dataContext.SaveChangesAsync();
            return stock;
        }

        public async Task<bool> DeleteStockById(int id)
        {
            StockModel stockModel = await GetStockById(id);
            if (stockModel == null)
            {
                throw new Exception($"Estoque com o id: {id} não encontrado");
            }
            _dataContext.Estoques.Remove(stockModel);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<StockModel>> GetAllStock()
        {
            return await _dataContext.Estoques.ToListAsync();   
        }

        public async Task<StockModel> GetStockById(int id)
        {
            return await _dataContext.Estoques.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<StockModel> updateStockById(StockModel stock, int id)
        {
            StockModel stockModel = await GetStockById(id);
            if (stockModel == null)
            {
                throw new Exception($"Estoque com o id: {id} não encontrado");
            }

            stockModel.CodigoProduto = stock.CodigoProduto;
            stockModel.Quantidade = stock.Quantidade;
            stockModel.PrecoUnitario = stock.PrecoUnitario;

            _dataContext.Estoques.Update(stockModel);
            await _dataContext.SaveChangesAsync();
            return stockModel;

        }
    }
}
