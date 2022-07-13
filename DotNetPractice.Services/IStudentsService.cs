using DotNetPractice.Models;

namespace DotNetPractice.Services;

public interface IStudentsService
{
    Task<IEnumerable<Student>> GetAll();
    Task<Student> GetById(Guid id);
    Task Add(StudentCreate student);
    Task Update(Guid id, Student student);
    Task Delete(Guid id);
}