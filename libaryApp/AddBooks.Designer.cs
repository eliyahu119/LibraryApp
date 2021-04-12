
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
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bookNameLabel
            // 
            this.bookNameLabel.AutoSize = true;
            this.bookNameLabel.Location = new System.Drawing.Point(303, 68);
            this.bookNameLabel.Name = "bookNameLabel";
            this.bookNameLabel.Size = new System.Drawing.Size(72, 20);
            this.bookNameLabel.TabIndex = 0;
            this.bookNameLabel.Text = "שם הספר";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(322, 156);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(46, 20);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "מחבר";
            // 
            // GenereLabel
            // 
            this.GenereLabel.AutoSize = true;
            this.GenereLabel.Location = new System.Drawing.Point(328, 111);
            this.GenereLabel.Name = "GenereLabel";
            this.GenereLabel.Size = new System.Drawing.Size(38, 20);
            this.GenereLabel.TabIndex = 4;
            this.GenereLabel.Text = "זאנר";
            // 
            // publicationLabel
            // 
            this.publicationLabel.AutoSize = true;
            this.publicationLabel.Location = new System.Drawing.Point(289, 201);
            this.publicationLabel.Name = "publicationLabel";
            this.publicationLabel.Size = new System.Drawing.Size(86, 20);
            this.publicationLabel.TabIndex = 6;
            this.publicationLabel.Text = "הוצאה לאור";
            // 
            // publicationYearLabel
            // 
            this.publicationYearLabel.AutoSize = true;
            this.publicationYearLabel.Location = new System.Drawing.Point(273, 237);
            this.publicationYearLabel.Name = "publicationYearLabel";
            this.publicationYearLabel.Size = new System.Drawing.Size(119, 20);
            this.publicationYearLabel.TabIndex = 7;
            this.publicationYearLabel.Text = "שנת הוצאה לאור";
            // 
            // copiesLabel
            // 
            this.copiesLabel.AutoSize = true;
            this.copiesLabel.Location = new System.Drawing.Point(289, 277);
            this.copiesLabel.Name = "copiesLabel";
            this.copiesLabel.Size = new System.Drawing.Size(98, 20);
            this.copiesLabel.TabIndex = 8;
            this.copiesLabel.Text = "מספר עותקים";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(14, 292);
            this.submit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(78, 52);
            this.submit.TabIndex = 9;
            this.submit.Text = "הוסף ספר";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // AddBookTxt
            // 
            this.AddBookTxt.Location = new System.Drawing.Point(130, 61);
            this.AddBookTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddBookTxt.Name = "AddBookTxt";
            this.AddBookTxt.Size = new System.Drawing.Size(138, 27);
            this.AddBookTxt.TabIndex = 10;
            // 
            // NumberOfCopiesTxt
            // 
            this.NumberOfCopiesTxt.Location = new System.Drawing.Point(207, 273);
            this.NumberOfCopiesTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumberOfCopiesTxt.MaxLength = 1;
            this.NumberOfCopiesTxt.Name = "NumberOfCopiesTxt";
            this.NumberOfCopiesTxt.Size = new System.Drawing.Size(61, 27);
            this.NumberOfCopiesTxt.TabIndex = 11;
            // 
            // publicationYearTxt
            // 
            this.publicationYearTxt.Location = new System.Drawing.Point(207, 227);
            this.publicationYearTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.publicationYearTxt.MaxLength = 4;
            this.publicationYearTxt.Name = "publicationYearTxt";
            this.publicationYearTxt.Size = new System.Drawing.Size(61, 27);
            this.publicationYearTxt.TabIndex = 12;
            // 
            // authorComboBox
            // 
            this.authorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authorComboBox.FormattingEnabled = true;
            this.authorComboBox.Location = new System.Drawing.Point(130, 152);
            this.authorComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.authorComboBox.Name = "authorComboBox";
            this.authorComboBox.Size = new System.Drawing.Size(138, 28);
            this.authorComboBox.TabIndex = 14;
            this.authorComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // publicationComboBox
            // 
            this.publicationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.publicationComboBox.FormattingEnabled = true;
            this.publicationComboBox.Location = new System.Drawing.Point(130, 191);
            this.publicationComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.publicationComboBox.Name = "publicationComboBox";
            this.publicationComboBox.Size = new System.Drawing.Size(138, 28);
            this.publicationComboBox.TabIndex = 15;
            this.publicationComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // GenereComboBox
            // 
            this.GenereComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenereComboBox.FormattingEnabled = true;
            this.GenereComboBox.Location = new System.Drawing.Point(130, 111);
            this.GenereComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GenereComboBox.Name = "GenereComboBox";
            this.GenereComboBox.Size = new System.Drawing.Size(138, 28);
            this.GenereComboBox.TabIndex = 16;
            this.GenereComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 13);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(89, 35);
            this.BackButton.TabIndex = 17;
            this.BackButton.Text = "חזור";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 360);
            this.Controls.Add(this.BackButton);
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
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddBooks";
            this.Text = "AddBooks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddBooks_FormClosing);
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
        private System.Windows.Forms.Button BackButton;
    }
}