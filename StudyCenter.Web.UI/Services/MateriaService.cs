using StudyCenter.Dominio.Entidades.ViewModels;
using Entidade = StudyCenter.Dominio.Entidades.Entities;

public class MateriaService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public MateriaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<Entidade.Materias[]> GetMateriasAsync()
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Materias";
        return await _httpClient.GetFromJsonAsync<Entidade.Materias[]>(url);
    }

    public async Task<Entidade.Materias> CreateMateriaAsync(MateriasViewModel materiaViewModel)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Materias";
        var response = await _httpClient.PostAsJsonAsync(url, materiaViewModel);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Entidade.Materias>();
    }

    public async Task<Entidade.Materias> UpdateMateriaAsync(int idMateria, MateriasViewModel materiaViewModel)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Materias/{idMateria}";
        var response = await _httpClient.PutAsJsonAsync(url, materiaViewModel);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Entidade.Materias>();
    }

    public async Task DeleteMateriaAsync(int idMateria)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Materias/{idMateria}";
        var response = await _httpClient.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }
}
