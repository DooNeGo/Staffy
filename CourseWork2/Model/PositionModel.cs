namespace CourseWork2.Model;

public class PositionModel : IDataModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public string Department { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        return obj is PositionModel position
               && position.Id == Id;
    }
}