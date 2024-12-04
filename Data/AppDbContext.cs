using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Pedido> Pedidos  { get; set; }
    public DbSet<Fornecedor> Fornecedores{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = PedidoseFornecedores.db");
    }
}