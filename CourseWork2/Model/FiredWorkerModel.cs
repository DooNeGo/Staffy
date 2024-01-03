namespace CourseWork2.Model;

public class FiredWorkerModel : IDataModel
{
    public int Id { get; set; }

    public string Surname { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    
    public string Patronymic { get; set; } = string.Empty;
    
    public string FireDate { get; set; } = string.Empty;

    public string FireReason { get; set; } = string.Empty;
}