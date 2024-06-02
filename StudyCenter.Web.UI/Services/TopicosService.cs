using StudyCenter.Dominio.Entidades.ViewModels;
using Entidade = StudyCenter.Dominio.Entidades.Entities;
public class TopicosService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public TopicosService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<Entidade.Topicos[]> GetTopicosAsync()
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Topicos";
        return await _httpClient.GetFromJsonAsync<Entidade.Topicos[]>(url);
    }

    public async Task<Entidade.Topicos> CreateTopicoAsync(TopicosViewModel topicoViewModel)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Topicos";
        var response = await _httpClient.PostAsJsonAsync(url, topicoViewModel);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Entidade.Topicos>();
    }

    public async Task<Entidade.Topicos> UpdateTopicoAsync(int idTopico, TopicosViewModel topicoViewModel)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Topicos/{idTopico}";
        var response = await _httpClient.PutAsJsonAsync(url, topicoViewModel);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Entidade.Topicos>();
    }

    public async Task DeleteTopicoAsync(int idTopico)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Topicos/{idTopico}";
        var response = await _httpClient.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }
}
