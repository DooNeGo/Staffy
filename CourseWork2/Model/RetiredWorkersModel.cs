namespace CourseWork2.Model;

public class RetiredWorkersModel : IDataModel
{
    public int Id { get; set; }
    
    public string Surname { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    
    public string Patronymic { get; set; } = string.Empty;
    
    public string RetiredDate { get; set; } = string.Empty;

    public decimal Pension { get; set; }
}