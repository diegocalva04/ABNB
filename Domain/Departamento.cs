namespace Domain;

public class Departamento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}

public interface IDepartamentoRepository
{
    Task<Departamento> GetByIdAsync(int id);
    Task<List<Departamento>> GetAllAsync();
    Task AddAsync(Departamento departamento);
    Task UpdateAsync(Departamento departamento);
    Task DeleteAsync(int id);
}

