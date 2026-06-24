using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly ApplicationContext _context;

    public DepartamentoRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Departamento departamento)
    {
        await _context.Departamentos.AddAsync(departamento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var departamento = await _context.Departamentos.FindAsync(id);
        if (departamento != null)
        {
            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos.ToListAsync();
    }

    public async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.Departamentos.FindAsync(id);
    }

    public Task UpdateAsync(Departamento departamento)
    {
        _context.Departamentos.Update(departamento);
        return _context.SaveChangesAsync();
    }
}
