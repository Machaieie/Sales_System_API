using API_Gestao_Sock.Data;
using API_Gestao_Sock.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys
{
    public class MovimentsRepository : IMovimentsRepository
    {
        private readonly DataContext _dataContext;

        public MovimentsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<MovimentosStockModel> AddMovimentStock(MovimentosStockModel movimentosStock)
        {
            await _dataContext.Movimentos.AddAsync(movimentosStock);
            await _dataContext.SaveChangesAsync();
            return movimentosStock;
        }

        public async Task<bool> DeleteMovimentStockById(int id)
        {
            MovimentosStockModel movimentosStock = await GetMovimentStockById(id);
            if (movimentosStock == null)
            {
                throw new Exception($"Movimento com o id: {id} não encontrado");
            }
            _dataContext.Movimentos.Remove(movimentosStock);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<MovimentosStockModel>> GetAllMovimentStock()
        {
            return await _dataContext.Movimentos.ToListAsync();
        }

        public async Task<MovimentosStockModel> GetMovimentStockById(int id)
        {
            return await _dataContext.Movimentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MovimentosStockModel> updateMovimentStockById(MovimentosStockModel movimentosStock, int id)
        {
            MovimentosStockModel movimentos = await GetMovimentStockById(id);
            if (movimentos == null)
            {
                throw new Exception($"Movimento com o id: {id} não encontrado");
            }
            movimentos.StockId = movimentosStock.Id;
            movimentos.Quantidade = movimentosStock.Quantidade;
            movimentos.Data = movimentosStock.Data;
            _dataContext.Movimentos.Update(movimentos);
            await _dataContext.SaveChangesAsync();
            return movimentos;

        }
    }
}
