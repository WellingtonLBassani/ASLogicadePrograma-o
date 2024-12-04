using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]

public class  FornecedorController : ControllerBase
{
    private readonly IFornecedorRepository _repository;

    public FornecedorController(IFornecedorRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<ActionResult<List<Fornecedor>>> Get()
    {
        var fornecedores = await _repository.GetTodosFornecedores();
        return Ok(fornecedores); 
    }
    [HttpGet ("{id}")]
    public async Task<ActionResult<Fornecedor>> Get(int id)
    {
        var fornecedor = await _repository.GetFornecedor(id);
        if(fornecedor == null)
            return NotFound();
        return Ok(fornecedor);
    }
    [HttpPost]
    public async Task<ActionResult> Post(Fornecedor fornecedor)
    {
        await _repository.AdicionarFornecedor(fornecedor);
        return Created();
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Fornecedor fornecedorAtualizado)
    {
        var fornecedor = await _repository.AtualizarFornecedor(id, fornecedorAtualizado);
        if(fornecedor == null)
            return NotFound();

        return Ok();

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var fornecedorParaRemover = await _repository.DeletaFornecedor(id);
        if(fornecedorParaRemover == null)
            return NotFound();
        return NoContent();
    }


}