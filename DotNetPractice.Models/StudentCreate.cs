namespace DotNetPractice.Models;

public class StudentCreate
{
    public string RegistrationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Group { get; set; }
    public int Year { get; set; }
    public double Scholarship { get; set; }
}