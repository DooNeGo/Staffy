namespace CourseWork2.Model;

public class AcceptedWorkerModel : IDataModel
{
    public int Id { get; set; }

    public string Surname { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Patronymic { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public string AcceptDate { get; set; } = string.Empty;
    
    public decimal Salary { get; set; }
}