
namespace libaryApp
{
    partial class AddBooks
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
            this.bookNameLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.GenereLabel = new System.Windows.Forms.Label();
            this.publicationLabel = new System.Windows.Forms.Label();
            this.publicationYearLabel = new System.Windows.Forms.Label();
            this.copiesLabel = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.AddBookTxt = new System.Windows.Forms.TextBox();
            this.NumberOfCopiesTxt = new System.Windows.Forms.TextBox();
            this.publicationYearTxt = new System.Windows.Forms.TextBox();
            this.authorComboBox = new System.Windows.Forms.ComboBox();
            this.publicationComboBox = new System.Windows.Forms.ComboBox();
            this.GenereComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bookNameLabel
            // 
            this.bookNameLabel.AutoSize = true;
            this.bookNameLabel.Location = new System.Drawing.Point(260, 54);
            this.bookNameLabel.Name = "bookNameLabel";
            this.bookNameLabel.Size = new System.Drawing.Size(58, 15);
            this.bookNameLabel.TabIndex = 0;
            this.bookNameLabel.Text = "שם הספר";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(282, 117);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(37, 15);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "מחבר";
            // 
            // GenereLabel
            // 
            this.GenereLabel.AutoSize = true;
            this.GenereLabel.Location = new System.Drawing.Point(287, 83);
            this.GenereLabel.Name = "GenereLabel";
            this.GenereLabel.Size = new System.Drawing.Size(31, 15);
            this.GenereLabel.TabIndex = 4;
            this.GenereLabel.Text = "זאנר";
            // 
            // publicationLabel
            // 
            this.publicationLabel.AutoSize = true;
            this.publicationLabel.Location = new System.Drawing.Point(253, 151);
            this.publicationLabel.Name = "publicationLabel";
            this.publicationLabel.Size = new System.Drawing.Size(69, 15);
            this.publicationLabel.TabIndex = 6;
            this.publicationLabel.Text = "הוצאה לאור";
            // 
            // publicationYearLabel
            // 
            this.publicationYearLabel.AutoSize = true;
            this.publicationYearLabel.Location = new System.Drawing.Point(239, 178);
            this.publicationYearLabel.Name = "publicationYearLabel";
            this.publicationYearLabel.Size = new System.Drawing.Size(95, 15);
            this.publicationYearLabel.TabIndex = 7;
            this.publicationYearLabel.Text = "שנת הוצאה לאור";
            // 
            // copiesLabel
            // 
            this.copiesLabel.AutoSize = true;
            this.copiesLabel.Location = new System.Drawing.Point(253, 208);
            this.copiesLabel.Name = "copiesLabel";
            this.copiesLabel.Size = new System.Drawing.Size(79, 15);
            this.copiesLabel.TabIndex = 8;
            this.copiesLabel.Text = "מספר עותקים";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(12, 219);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(68, 39);
            this.submit.TabIndex = 9;
            this.submit.Text = "הוסף ספר";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // AddBookTxt
            // 
            this.AddBookTxt.Location = new System.Drawing.Point(114, 46);
            this.AddBookTxt.Name = "AddBookTxt";
            this.AddBookTxt.Size = new System.Drawing.Size(121, 23);
            this.AddBookTxt.TabIndex = 10;
            // 
            // NumberOfCopiesTxt
            // 
            this.NumberOfCopiesTxt.Location = new System.Drawing.Point(181, 205);
            this.NumberOfCopiesTxt.Name = "NumberOfCopiesTxt";
            this.NumberOfCopiesTxt.Size = new System.Drawing.Size(54, 23);
            this.NumberOfCopiesTxt.TabIndex = 11;
            this.NumberOfCopiesTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Utils.AllowOnlyNumeric);
            // 
            // publicationYearTxt
            // 
            this.publicationYearTxt.Location = new System.Drawing.Point(181, 170);
            this.publicationYearTxt.Name = "publicationYearTxt";
            this.publicationYearTxt.Size = new System.Drawing.Size(54, 23);
            this.publicationYearTxt.TabIndex = 12;
            this.publicationYearTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Utils.AllowOnlyNumeric);
            // 
            // authorComboBox
            // 
            this.authorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authorComboBox.FormattingEnabled = true;
            this.authorComboBox.Location = new System.Drawing.Point(114, 114);
            this.authorComboBox.Name = "authorComboBox";
            this.authorComboBox.Size = new System.Drawing.Size(121, 23);
            this.authorComboBox.TabIndex = 14;
            this.authorComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // publicationComboBox
            // 
            this.publicationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.publicationComboBox.FormattingEnabled = true;
            this.publicationComboBox.Location = new System.Drawing.Point(114, 143);
            this.publicationComboBox.Name = "publicationComboBox";
            this.publicationComboBox.Size = new System.Drawing.Size(121, 23);
            this.publicationComboBox.TabIndex = 15;
            this.publicationComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // GenereComboBox
            // 
            this.GenereComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenereComboBox.FormattingEnabled = true;
            this.GenereComboBox.Location = new System.Drawing.Point(114, 83);
            this.GenereComboBox.Name = "GenereComboBox";
            this.GenereComboBox.Size = new System.Drawing.Size(121, 23);
            this.GenereComboBox.TabIndex = 16;
            this.GenereComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // AddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 270);
            this.Controls.Add(this.GenereComboBox);
            this.Controls.Add(this.publicationComboBox);
            this.Controls.Add(this.authorComboBox);
            this.Controls.Add(this.publicationYearTxt);
            this.Controls.Add(this.NumberOfCopiesTxt);
            this.Controls.Add(this.AddBookTxt);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.copiesLabel);
            this.Controls.Add(this.publicationYearLabel);
            this.Controls.Add(this.publicationLabel);
            this.Controls.Add(this.GenereLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.bookNameLabel);
            this.Name = "AddBooks";
            this.Text = "AddBooks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddBooks_FormClosing);
            this.Load += new System.EventHandler(this.AddBooks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bookNameLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label GenereLabel;
        private System.Windows.Forms.Label publicationLabel;
        private System.Windows.Forms.Label publicationYearLabel;
        private System.Windows.Forms.Label copiesLabel;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TextBox AddBookTxt;
        private System.Windows.Forms.TextBox NumberOfCopiesTxt;
        private System.Windows.Forms.TextBox publicationYearTxt;
        private System.Windows.Forms.ComboBox authorComboBox;
        private System.Windows.Forms.ComboBox publicationComboBox;
        private System.Windows.Forms.ComboBox GenereComboBox;
    }
}