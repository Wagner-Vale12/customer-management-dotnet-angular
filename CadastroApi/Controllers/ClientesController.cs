using CadastroApi.Data;
using CadastroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar(
        [FromQuery] string? termo)
    {
        var query = _context.Clientes
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(termo))
        {
            query = query.Where(cliente =>
                cliente.Nome.Contains(termo) ||
                cliente.Email.Contains(termo) ||
                cliente.Cpf.Contains(termo));
        }

        var clientes = await query
            .OrderBy(cliente => cliente.Nome)
            .ToListAsync();

        return Ok(clientes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Cliente>> BuscarPorId(int id)
    {
        var cliente = await _context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(cliente => cliente.Id == id);

        if (cliente is null)
            return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Cadastrar(Cliente cliente)
    {
        cliente.Email = cliente.Email.Trim().ToLowerInvariant();
        cliente.Cpf = cliente.Cpf.Trim();

        var emailJaExiste = await _context.Clientes
            .AnyAsync(c => c.Email.ToLower() == cliente.Email);

        if (emailJaExiste)
            return Conflict(new { message = "Este e-mail já está cadastrado." });

        var cpfJaExiste = await _context.Clientes
            .AnyAsync(c => c.Cpf == cliente.Cpf);

        if (cpfJaExiste)
            return Conflict(new { message = "Este CPF já está cadastrado." });

        _context.Clientes.Add(cliente);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = cliente.Id },
            cliente
        );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(
        int id,
        Cliente cliente)
    {
        if (id != cliente.Id)
            return BadRequest();

        var clienteExistente =
            await _context.Clientes.FindAsync(id);

        if (clienteExistente is null)
            return NotFound();

        cliente.Email = cliente.Email.Trim().ToLowerInvariant();
        var emailJaExiste = await _context.Clientes
            .AnyAsync(c => c.Id != id && c.Email.ToLower() == cliente.Email);

        if (emailJaExiste)
            return Conflict(new { message = "Este e-mail já está cadastrado para outro cliente." });

        clienteExistente.Nome = cliente.Nome;
        clienteExistente.Email = cliente.Email;
        clienteExistente.Telefone = cliente.Telefone;
        clienteExistente.DataNascimento = cliente.DataNascimento;
        clienteExistente.Cidade = cliente.Cidade;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
public async Task<IActionResult> Excluir(int id)
{
    var cliente = await _context.Clientes.FindAsync(id);

    if (cliente is null)
        return NotFound();

    _context.Clientes.Remove(cliente);

    await _context.SaveChangesAsync();

    return NoContent();
}
}
