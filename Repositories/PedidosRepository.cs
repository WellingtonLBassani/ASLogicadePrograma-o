    
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

public class PedidoRepository : IPedidosRepository
{
    private readonly AppDbContext _context;
    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AdicionarPedido(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task<Pedido> AtualizarPedido(int id, Pedido pedidoAtualizado)
    {
         var Pedido = await _context.Pedidos.FindAsync(id);
        if(Pedido == null)
            return Pedido;

        Pedido.Data = pedidoAtualizado.Data;
        Pedido.Id = pedidoAtualizado.Id;
        Pedido.ValorTotal = pedidoAtualizado.ValorTotal;
        Pedido.Status = pedidoAtualizado.Status;
        Pedido.Descricao = pedidoAtualizado.Descricao;
        await _context.SaveChangesAsync();
        return Pedido;
    }

    public async Task<Pedido> DeletaPedido(int id)
    {


        var pedido = await _context.Pedidos.FindAsync(id);
        if(pedido == null)
            return pedido;  
        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido> GetPedido(int id)
    {
        return await _context.Pedidos.FindAsync(id);    
    }

    public async Task<List<Pedido>> GetTodosPedidos()
    {
        return await _context.Pedidos.ToListAsync();    
    }
}
