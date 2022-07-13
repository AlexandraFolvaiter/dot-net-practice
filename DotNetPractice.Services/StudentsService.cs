using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using DotNetPractice.Models;

namespace DotNetPractice.Services;

public class StudentsService : IStudentsService
{
    private readonly HttpClient _httpClient;

    public StudentsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<Student>> GetAll()
    {
        return _httpClient.GetFromJsonAsync<IEnumerable<Student>>(string.Empty);
    }

    public Task<Student> GetById(Guid id)
    {
        var requestUri = $"{_httpClient.BaseAddress}/{id}";

        return _httpClient.GetFromJsonAsync<Student>(requestUri);
    }


    public Task Add(StudentCreate student)
    {
        var studentAsString = JsonSerializer.Serialize(student);
        var requestContent = new StringContent(studentAsString, Encoding.UTF8, "application/json");

        return _httpClient.PostAsync(string.Empty, requestContent);
    }

    public Task Update(Guid id, Student student)
    {
        student.Id = id; // this is a workaround since the API doesn't have the same way to implement the update
        var studentAsString = JsonSerializer.Serialize(student);

        var requestContent = new StringContent(studentAsString, Encoding.UTF8, "application/json");

        return _httpClient.PutAsync(string.Empty, requestContent);
    }

    public Task Delete(Guid id)
    {
        var path = $"/{id}";
        return _httpClient.DeleteAsync(path);
    }
}