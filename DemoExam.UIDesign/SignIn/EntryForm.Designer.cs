namespace DemoExam.UIDesign
{
    partial class EntryForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            SingIn = new Button();
            FisrtNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(88, 298);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.Size = new Size(100, 23);
            LoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(88, 327);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(100, 23);
            PasswordTextBox.TabIndex = 1;
            // 
            // SingIn
            // 
            SingIn.Location = new Point(100, 368);
            SingIn.Name = "SingIn";
            SingIn.Size = new Size(75, 23);
            SingIn.TabIndex = 3;
            SingIn.Text = "SingIn";
            SingIn.UseVisualStyleBackColor = true;
            SingIn.Click += CheckoutUserInputBtn_Click;
            // 
            // FisrtNameTextBox
            // 
            FisrtNameTextBox.Location = new Point(88, 269);
            FisrtNameTextBox.Name = "FisrtNameTextBox";
            FisrtNameTextBox.Size = new Size(100, 23);
            FisrtNameTextBox.TabIndex = 4;
            // 
            // EntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 407);
            Controls.Add(FisrtNameTextBox);
            Controls.Add(SingIn);
            Controls.Add(PasswordTextBox);
            Controls.Add(LoginTextBox);
            Name = "EntryForm";
            Text = "SingInForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginTextBox;
        private TextBox PasswordTextBox;
        private Button SingIn;
        private TextBox FisrtNameTextBox;
    }
}