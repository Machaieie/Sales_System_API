using API_Gestao_Sock.Model;
using API_Gestao_Sock.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sales_System_API.Model;

namespace API_Gestao_Sock.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CarinhoModel> Carinho { get; set; }
        public DbSet<StockModel> Estoques { get; set; }
        public DbSet<MovimentosStockModel> Movimentos { get; set; }
        public DbSet<ProdutoModel> Productos { get; set; }
        public DbSet<VendaModel> Venda { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
