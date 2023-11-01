namespace DemoExam.UIDesign.SignIn.Registration;

public partial class RegistrationForm : Form
{
    private readonly EntryForm _entryForm = new EntryForm();
    private readonly UserRegistration _userRegistration = new UserRegistration();

    public RegistrationForm() => InitializeComponent();

    private async void RegistrBtn_Click(object sender, EventArgs e)
    {        
        if (await _userRegistration.RegistrationAsync(NameTextBox.Text, EmailTextBox.Text, PasswordTextBox.Text))
        {
            MessageBox.Show($"Пользователь {NameTextBox.Text} зарегистрирован");
            this.Close();
            _entryForm.Show();
        }
        else
            MessageBox.Show("Произошла ошибка\nПользователь с таким паролем или логином уже существует",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
    }
}