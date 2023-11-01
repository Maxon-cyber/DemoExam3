using AccessingDatabase;
using AccessingDatabase.EnumerationOfDatabases;
using DemoExam.ModelClasses.User;
using DemoExam.UIDesign.SignIn.Registration;
using DemoExam.UIDesign.SQLQueries;

namespace DemoExam.UIDesign.SignIn.CheckUser;

internal sealed class CheckoutUserInput
{
    private readonly Lazy<RegistrationForm> _registrationForm = new Lazy<RegistrationForm>();

    internal CheckoutUserInput() { }

    internal async Task<(bool IsRegistered, UserModel User)> Check(string name, string login, string password, EntryForm entryForm)
    {
        UserModel user = await Databases
                              .SelectRelationalDatabase(CurrentRelationalDatabase.MSSQLDatabase)
                              .ExecuteReaderAsync<UserModel>(SQLQuery.GetUser(name, login, password));

        if ((name, login, password) == (user.FirstName, user.Login, user.Password))
        {
            MessageBox.Show($"Добро Пожаловать, {user.FirstName}!");
            return (true, user);
        }   
        else
        {
            if (MessageBox.Show("Зарегистрироваться?", "Регистрация", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                entryForm.Hide();
                _registrationForm.Value.Show();
            }
        }

        return (false, new UserModel());
    }
}