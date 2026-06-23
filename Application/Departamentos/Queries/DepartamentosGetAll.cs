using Domain;

namespace Application.Departamentos.Queries;

public interface IDepartamentoGetAll
{
    Task<IList<DepartamentoGetAllDto>> Execute();
}

public class DepartamentoGetAll : IDepartamentoGetAll
{
    private readonly IDepartamentoRepository _departamentoRepository;

    public DepartamentoGetAll(IDepartamentoRepository departamentoRepository)
    {
        _departamentoRepository = departamentoRepository;
    }

    public async Task<IList<DepartamentoGetAllDto>> Execute()
    {
        var departamentos = await _departamentoRepository.GetAllAsync();
        return departamentos.Select(d => new DepartamentoGetAllDto(d.Id, d.Nombre)).ToList();
    }
}

public record DepartamentoGetAllDto(int Id, string Nombre);
