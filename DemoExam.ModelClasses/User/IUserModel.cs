namespace DemoExam.ModelClasses.User;

public interface IUserModel : IModel
{
    string Name { get; set; }
    string Role { get; set; }
    string Login { get; set; }
    string Password { get; set; }
}