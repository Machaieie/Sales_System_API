using API_Gestao_Sock.Data;
using API_Gestao_Sock.Model;
using API_Gestao_Sock.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys
{
    public class UserRepository : IUser
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public async Task<User> addUser(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> findAllusers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User> findById(int id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> removeById(int id)
        {
            User users = await findById(id);
            if (users == null)
            {
                throw new Exception($"Usuario com o id: {id} não encontrado");
            }
            _dataContext.Users.Remove(users);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> updateUser(User user, int id)
        {
            User usery = await findById(id);
            if (usery == null)
            {
                throw new Exception($"Usuario com o id: {id} não encontrado");
            }
            usery.Username = user.Username;
            usery.Password = user.Password;
            usery.Role = user.Role;
            _dataContext.Users.Update(usery);
            await _dataContext.SaveChangesAsync();
            return usery;
        }
    }
}
