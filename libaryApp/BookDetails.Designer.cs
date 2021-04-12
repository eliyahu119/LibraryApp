
namespace libaryApp
{
    partial class BookDetails
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
            this.BookName = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.CopiesGrid = new System.Windows.Forms.DataGridView();
            this.availableBooks = new System.Windows.Forms.Label();
            this.EditBook = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CopiesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // BookName
            // 
            this.BookName.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BookName.Location = new System.Drawing.Point(154, 5);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(336, 40);
            this.BookName.TabIndex = 0;
            this.BookName.Text = "BookName";
            this.BookName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Author
            // 
            this.Author.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Author.Location = new System.Drawing.Point(177, 52);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(257, 21);
            this.Author.TabIndex = 1;
            this.Author.Text = "Author";
            // 
            // CopiesGrid
            // 
            this.CopiesGrid.AllowUserToAddRows = false;
            this.CopiesGrid.AllowUserToDeleteRows = false;
            this.CopiesGrid.AllowUserToResizeColumns = false;
            this.CopiesGrid.AllowUserToResizeRows = false;
            this.CopiesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CopiesGrid.Location = new System.Drawing.Point(231, 76);
            this.CopiesGrid.Name = "CopiesGrid";
            this.CopiesGrid.RowHeadersVisible = false;
            this.CopiesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.CopiesGrid.RowTemplate.Height = 25;
            this.CopiesGrid.Size = new System.Drawing.Size(203, 331);
            this.CopiesGrid.TabIndex = 2;
            // 
            // availableBooks
            // 
            this.availableBooks.AutoSize = true;
            this.availableBooks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.availableBooks.Location = new System.Drawing.Point(31, 99);
            this.availableBooks.Name = "availableBooks";
            this.availableBooks.Size = new System.Drawing.Size(108, 17);
            this.availableBooks.TabIndex = 3;
            this.availableBooks.Text = "{0}: עותקים זמינים";
            // 
            // EditBook
            // 
            this.EditBook.Location = new System.Drawing.Point(44, 142);
            this.EditBook.Name = "EditBook";
            this.EditBook.Size = new System.Drawing.Size(95, 38);
            this.EditBook.TabIndex = 4;
            this.EditBook.Text = "ערוך  פרטי ספר";
            this.EditBook.UseVisualStyleBackColor = true;
            this.EditBook.Click += new System.EventHandler(this.EditBook_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 5);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(95, 33);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "חזור";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // BookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 435);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.EditBook);
            this.Controls.Add(this.availableBooks);
            this.Controls.Add(this.CopiesGrid);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.BookName);
            this.Name = "BookDetails";
            this.Text = "BookDetails";
            this.Load += new System.EventHandler(this.BookDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CopiesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BookName;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.DataGridView CopiesGrid;
        private System.Windows.Forms.Label availableBooks;
        private System.Windows.Forms.Button EditBook;
        private System.Windows.Forms.Button BackButton;
    }
}