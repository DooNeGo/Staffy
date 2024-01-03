namespace CourseWork2.Model;

public class DepartmentModel : IDataModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        return obj is DepartmentModel department
               && department.Id == Id;
    }
}