namespace DemoExam.UIDesign
{
    partial class ProductForm
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
            ProductsViewTable = new TableLayoutPanel();
            BasketListBox = new ListBox();
            SearchTextBox = new TextBox();
            label1 = new Label();
            searchButton = new Button();
            SuspendLayout();
            // 
            // ProductsViewTable
            // 
            ProductsViewTable.AutoScroll = true;
            ProductsViewTable.ColumnCount = 3;
            ProductsViewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            ProductsViewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            ProductsViewTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            ProductsViewTable.Location = new Point(0, 218);
            ProductsViewTable.Name = "ProductsViewTable";
            ProductsViewTable.RowCount = 2;
            ProductsViewTable.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            ProductsViewTable.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            ProductsViewTable.Size = new Size(895, 328);
            ProductsViewTable.TabIndex = 2;
            // 
            // BasketListBox
            // 
            BasketListBox.DisplayMember = "(нет)";
            BasketListBox.FormattingEnabled = true;
            BasketListBox.ItemHeight = 15;
            BasketListBox.Location = new Point(736, 1);
            BasketListBox.Name = "BasketListBox";
            BasketListBox.SelectionMode = SelectionMode.MultiSimple;
            BasketListBox.Size = new Size(171, 169);
            BasketListBox.Sorted = true;
            BasketListBox.TabIndex = 3;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(94, 50);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(404, 23);
            SearchTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 50);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "Поиск:";
            // 
            // searchButton
            // 
            searchButton.Location = new Point(520, 50);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 6;
            searchButton.Text = "Найти";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += Search;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 546);
            Controls.Add(searchButton);
            Controls.Add(label1);
            Controls.Add(SearchTextBox);
            Controls.Add(BasketListBox);
            Controls.Add(ProductsViewTable);
            Name = "ProductForm";
            Text = "ProductForm";
            Load += ProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel ProductsViewTable;
        private TextBox SearchTextBox;
        private Label label1;
        private Button searchButton;
        private ListBox BasketListBox;
    }
}