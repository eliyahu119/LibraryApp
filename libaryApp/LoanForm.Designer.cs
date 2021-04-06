
namespace libaryApp
{
    partial class LoanForm
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
            this.CurrentLoadGrid = new System.Windows.Forms.DataGridView();
            this.loanBook = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.MemberNameLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLoadGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentLoadGrid
            // 
            this.CurrentLoadGrid.AllowUserToAddRows = false;
            this.CurrentLoadGrid.AllowUserToDeleteRows = false;
            this.CurrentLoadGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentLoadGrid.Location = new System.Drawing.Point(279, 53);
            this.CurrentLoadGrid.Name = "CurrentLoadGrid";
            this.CurrentLoadGrid.ReadOnly = true;
            this.CurrentLoadGrid.RowTemplate.Height = 25;
            this.CurrentLoadGrid.Size = new System.Drawing.Size(332, 371);
            this.CurrentLoadGrid.TabIndex = 9;
            // 
            // loanBook
            // 
            this.loanBook.Location = new System.Drawing.Point(65, 193);
            this.loanBook.Name = "loanBook";
            this.loanBook.Size = new System.Drawing.Size(189, 47);
            this.loanBook.TabIndex = 8;
            this.loanBook.Text = "השאל ספר";
            this.loanBook.UseVisualStyleBackColor = true;
            this.loanBook.Click += new System.EventHandler(this.loanBook_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 51);
            this.button1.TabIndex = 10;
            this.button1.Text = "חלון השאלות";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MemberNameLabel
            // 
            this.MemberNameLabel.AutoSize = true;
            this.MemberNameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MemberNameLabel.Location = new System.Drawing.Point(376, 9);
            this.MemberNameLabel.Name = "MemberNameLabel";
            this.MemberNameLabel.Size = new System.Drawing.Size(98, 30);
            this.MemberNameLabel.TabIndex = 11;
            this.MemberNameLabel.Text = "שם המנוי";
            this.MemberNameLabel.Click += new System.EventHandler(this.MemberNameLabel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 52);
            this.button2.TabIndex = 12;
            this.button2.Text = "חזור למסך הראשי";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 509);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MemberNameLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CurrentLoadGrid);
            this.Controls.Add(this.loanBook);
            this.Name = "LoanForm";
            this.Text = "LoanForm";
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLoadGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CurrentLoadGrid;
        private System.Windows.Forms.Button loanBook;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label MemberNameLabel;
        private System.Windows.Forms.Button button2;
    }
}