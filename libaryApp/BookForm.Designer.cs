
namespace libaryApp
{
    partial class BookForm
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
            this.BackButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.AddBook = new System.Windows.Forms.Button();
            this.BookGrid = new System.Windows.Forms.DataGridView();
            this.searchableButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BookGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(95, 33);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "חזור";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(239, 40);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(368, 23);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.Text = "שורת חיפוש";
            this.searchTextBox.GotFocus += new System.EventHandler(Utils.RemoveText);
            this.searchTextBox.LostFocus += new System.EventHandler(Utils.AddText);
            // 
            // AddBook
            // 
            this.AddBook.Location = new System.Drawing.Point(305, 385);
            this.AddBook.Name = "AddBook";
            this.AddBook.Size = new System.Drawing.Size(259, 47);
            this.AddBook.TabIndex = 2;
            this.AddBook.Text = "הוסף ספר";
            this.AddBook.UseVisualStyleBackColor = true;
            this.AddBook.Click += new System.EventHandler(this.AddBook_Click);
            // 
            // BookGrid
            // 
            this.BookGrid.AllowUserToAddRows = false;
            this.BookGrid.AllowUserToDeleteRows = false;
            this.BookGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookGrid.Location = new System.Drawing.Point(140, 91);
            this.BookGrid.Name = "BookGrid";
            this.BookGrid.ReadOnly = true;
            this.BookGrid.RowTemplate.Height = 25;
            this.BookGrid.Size = new System.Drawing.Size(583, 288);
            this.BookGrid.TabIndex = 3;
            this.BookGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BookGrid_CellDoubleClick);
            // 
            // searchableButton
            // 
            this.searchableButton.Location = new System.Drawing.Point(165, 40);
            this.searchableButton.Name = "searchableButton";
            this.searchableButton.Size = new System.Drawing.Size(75, 23);
            this.searchableButton.TabIndex = 4;
            this.searchableButton.Text = "חפש";
            this.searchableButton.UseVisualStyleBackColor = true;
            this.searchableButton.Click += new System.EventHandler(this.SearchAndDisplayBooks);
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 472);
            this.Controls.Add(this.searchableButton);
            this.Controls.Add(this.BookGrid);
            this.Controls.Add(this.AddBook);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.BackButton);
            this.Name = "BookForm";
            this.Text = "BookForm";
            this.Load += new System.EventHandler(this.BookForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BookGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button AddBook;
        private System.Windows.Forms.DataGridView BookGrid;
        private System.Windows.Forms.Button searchableButton;
    }
}