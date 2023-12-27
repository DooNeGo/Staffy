namespace CourseWork2.Model;

public class PositionModel : IDataModel
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public decimal Salary { get; set; }
}