namespace DemoExam.UIDesign.SignIn.Registration
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            EmailTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(175, 173);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(100, 23);
            NameTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(175, 231);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(100, 23);
            PasswordTextBox.TabIndex = 1;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(175, 202);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(100, 23);
            EmailTextBox.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(211, 329);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += RegistrBtn_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(EmailTextBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(NameTextBox);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private TextBox PasswordTextBox;
        private TextBox EmailTextBox;
        private Button button1;
    }
}