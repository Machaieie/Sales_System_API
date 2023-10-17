using API_Gestao_Sock.Data;
using API_Gestao_Sock.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys
{
   
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _dataContext;

        public  CartRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<CarinhoModel> AddCart(CarinhoModel cartModel)
        {
            await _dataContext.Carinho.AddAsync(cartModel);
            await _dataContext.SaveChangesAsync();
            return cartModel;
        }

        public async Task<bool> DeleteCartById(int id)
        {
            CarinhoModel cartModel = await GetCartById(id);
            if (cartModel == null)
            {
                throw new Exception($"Carrinho com o id: {id} não encontrado");
            }
            _dataContext.Carinho.Remove(cartModel);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<CarinhoModel>> GetAllCarts()
        {
            return await _dataContext.Carinho.ToListAsync();
        }

        public async Task<CarinhoModel> GetCartById(int id)
        {
            return await _dataContext.Carinho.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CarinhoModel> UpdateCartById(CarinhoModel cart, int id)
        {
            CarinhoModel cartModel = await GetCartById(id);
            if (cartModel == null)
            {
                throw new Exception($"Carrinho com o id: {id} não encontrado");
            }

            cartModel.VendaId = cart.VendaId;
            cartModel.CodigoProduto = cart.CodigoProduto;
            cartModel.Quantidade = cart.Quantidade;
            cartModel.Preco = cart.Preco;
            _dataContext.Carinho.Update(cartModel);
            await _dataContext.SaveChangesAsync();
            return cartModel;

        }
    }
}
