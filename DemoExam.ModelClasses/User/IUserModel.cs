namespace DemoExam.ModelClasses.User;

public interface IUserModel : IModel
{
    long Id { get; set; }
    string FirstName { get; set; }
    string SecondName { get; set; }
    string Patronymic { get; set; }
    int Role { get; set; }
    string Login { get; set; }
    string Password { get; set; }
    string Description { get; set; }
}