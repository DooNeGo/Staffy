namespace CourseWork2.Model;

public class WorkerModel : IDataModel
{
    public int Id { get; set; }

    public string Surname { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Patronymic { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public bool MilitaryRegistration { get; set; }

    public dynamic Department { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        return obj is WorkerModel worker
               && worker.Id == Id;
    }
}