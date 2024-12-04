public interface IFornecedorRepository
{
    public Task<List<Fornecedor>> GetTodosFornecedores();
    public Task<Fornecedor> GetFornecedor(int id);
    public Task AdicionarFornecedor(Fornecedor fornecedor);
    public Task<Fornecedor> AtualizarFornecedor(int id, Fornecedor fornecedorAtualizado);
    public Task<Fornecedor> DeletaFornecedor(int id);
}