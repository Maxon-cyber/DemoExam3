using AccessingDatabase;
using AccessingDatabase.EnumerationOfDatabases;
using DemoExam.ModelClasses.User;
using DemoExam.UIDesign.SignIn.Registration;
using DemoExam.UIDesign.SQLQueries;

namespace DemoExam.UIDesign.SignIn.CheckUser;

internal sealed class CheckoutUserInput
{
    private UserModel? _user = default;
    private readonly Lazy<RegistrationForm> _registrationForm = new Lazy<RegistrationForm>();

    internal UserModel User 
    {
        get
        {
            if(_user is not null)
                return _user;
            return new UserModel();
        }
        private set => _user = value; 
    }
    
    internal CheckoutUserInput() { }

    internal async Task<bool> Check(string name, string login, string password, EntryForm entryForm)
    {
        _user = await Databases
                              .SelectRelationalDatabase(CurrentRelationalDatabase.MSSQLDatabase)
                              .ExecuteReaderAsync<UserModel>(SQLQuery.GetUser(name, login, password));

        if ((name, login, password) == (_user.Name, _user.Login, _user.Password))
        {
            MessageBox.Show($"Добро Пожаловать, {_user.Name}!");
            return true;
        }   
        else
        {
            if (MessageBox.Show("Зарегистрироваться?", "Регистрация", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                entryForm.Hide();
                _registrationForm.Value.Show();
            }
        }

        return false;
    }
}