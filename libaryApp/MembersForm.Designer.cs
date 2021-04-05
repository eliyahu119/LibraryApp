
namespace libaryApp
{
    partial class MembersForm
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
            this.searchableButton = new System.Windows.Forms.Button();
            this.MemberGrid = new System.Windows.Forms.DataGridView();
            this.AddBook = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MemberGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(95, 33);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "חזור";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // searchableButton
            // 
            this.searchableButton.Location = new System.Drawing.Point(172, 42);
            this.searchableButton.Name = "searchableButton";
            this.searchableButton.Size = new System.Drawing.Size(75, 23);
            this.searchableButton.TabIndex = 8;
            this.searchableButton.Text = "חפש";
            this.searchableButton.UseVisualStyleBackColor = true;
            this.searchableButton.Click += new System.EventHandler(this.SearchAndDisplayMember);
            // 
            // MemberGrid
            // 
            this.MemberGrid.AllowUserToAddRows = false;
            this.MemberGrid.AllowUserToDeleteRows = false;
            this.MemberGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemberGrid.Location = new System.Drawing.Point(100, 71);
            this.MemberGrid.Name = "MemberGrid";
            this.MemberGrid.ReadOnly = true;
            this.MemberGrid.RowTemplate.Height = 25;
            this.MemberGrid.Size = new System.Drawing.Size(737, 288);
            this.MemberGrid.TabIndex = 7;
            this.MemberGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MemberGrid_CellContentClick);
            // 
            // AddBook
            // 
            this.AddBook.Location = new System.Drawing.Point(289, 365);
            this.AddBook.Name = "AddBook";
            this.AddBook.Size = new System.Drawing.Size(259, 47);
            this.AddBook.TabIndex = 6;
            this.AddBook.Text = "הוסף מנוי";
            this.AddBook.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(253, 42);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(368, 23);
            this.searchTextBox.TabIndex = 5;
            this.searchTextBox.Text = "שורת חיפוש";
            // 
            // MembersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 472);
            this.Controls.Add(this.searchableButton);
            this.Controls.Add(this.MemberGrid);
            this.Controls.Add(this.AddBook);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.BackButton);
            this.Name = "MembersForm";
            this.Text = "Members";
            this.Load += new System.EventHandler(this.Members_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MemberGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button searchableButton;
        private System.Windows.Forms.DataGridView MemberGrid;
        private System.Windows.Forms.Button AddBook;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}