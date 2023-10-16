using API_Gestao_Sock.Model;

namespace API_Gestao_Sock.Repositorys.Interfaces
{
    public interface IUser
    {
        Task<List<User>> findAllusers();
        Task<User> findById(int id);

        Task<User> addUser(User user);

        Task<bool> removeById(int id);
        Task<User> updateUser(User user, int id);
    }
}
