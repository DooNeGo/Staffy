namespace CourseWork2.Model;

public class WorkerModel : DataModelBase
{
    public string Surname { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Patronymic { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public bool MilitaryRegistration { get; set; }

    public int DepartmentId { get; set; }
}