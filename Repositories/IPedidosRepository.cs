public interface IPedidosRepository
{
    public Task<List<Pedido>> GetTodosPedidos();
    public Task<Pedido> GetPedido(int id);
    public Task AdicionarPedido(Pedido pedido);
    public Task<Pedido> AtualizarPedido(int id, Pedido pedidoAtualizado);
    public Task<Pedido> DeletaPedido(int id); 
}