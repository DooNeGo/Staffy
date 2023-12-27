namespace CourseWork2.Model;

public class UserModel : IDataModel
{
    public int Id { get; set; }
    
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
}