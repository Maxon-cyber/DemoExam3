using DemoExam.ModelClasses.User;
using DemoExam.UIDesign.SignIn.CheckUser;

namespace DemoExam.UIDesign;

public partial class EntryForm : Form
{
    private readonly CheckoutUserInput _checkoutUserInput = new CheckoutUserInput();

    public EntryForm() => InitializeComponent();

    private async void CheckoutUserInputBtn_Click(object sender, EventArgs e)
    {
        SingIn.Click -= CheckoutUserInputBtn_Click!;
        (bool isRegistered, UserModel user) = await _checkoutUserInput.Check(FisrtNameTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text, this);
        
        if (!isRegistered)
        {
            SingIn.Click += CheckoutUserInputBtn_Click!;
            return;
        }

        this.Close();

        Thread thread = new Thread(() => Application.Run(new ProductForm(user)));
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
    }
}