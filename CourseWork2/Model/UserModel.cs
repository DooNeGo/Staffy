namespace CourseWork2.Model;

public class UserModel : IDataModel
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    //public byte[]? ProfilePicture { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is UserModel user
               && user.Id == Id;
    }
}