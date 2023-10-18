using DemoExam.UIDesign.SignIn.CheckUser;

namespace DemoExam.UIDesign;

public partial class EntryForm : Form
{
    private readonly CheckoutUserInput _checkoutUserInput = new CheckoutUserInput();

    public EntryForm() => InitializeComponent();

    private async void CheckoutUserInputBtn_Click(object sender, EventArgs e)
    {
        if (!await _checkoutUserInput.Check(NameTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text, this))
            return;

        this.Close();

        Thread thread = new Thread(() => Application.Run(new ProductForm(_checkoutUserInput.User)));
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
    }
}