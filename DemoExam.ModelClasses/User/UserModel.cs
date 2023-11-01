namespace DemoExam.ModelClasses.User;

public class UserModel : IUserModel
{
    public long Id { get; set; }
    public DateTime DateOfRegistartion { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public int Role { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
}