namespace DemoExam.ModelClasses.User;

public class UserModel : IUserModel
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
}