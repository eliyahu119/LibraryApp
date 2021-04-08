
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
            this.ActiveLoanGrid = new System.Windows.Forms.DataGridView();
            this.loanBook = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.MemberNameLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Memberlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveLoanGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ActiveLoanGrid
            // 
            this.ActiveLoanGrid.AllowUserToAddRows = false;
            this.ActiveLoanGrid.AllowUserToDeleteRows = false;
            this.ActiveLoanGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActiveLoanGrid.Location = new System.Drawing.Point(14, 145);
            this.ActiveLoanGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ActiveLoanGrid.Name = "ActiveLoanGrid";
            this.ActiveLoanGrid.ReadOnly = true;
            this.ActiveLoanGrid.RowHeadersWidth = 51;
            this.ActiveLoanGrid.RowTemplate.Height = 25;
            this.ActiveLoanGrid.Size = new System.Drawing.Size(719, 432);
            this.ActiveLoanGrid.TabIndex = 9;
            this.ActiveLoanGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ActiveLoanGrid_CellContentClick);
            // 
            // loanBook
            // 
            this.loanBook.Location = new System.Drawing.Point(160, 589);
            this.loanBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loanBook.Name = "loanBook";
            this.loanBook.Size = new System.Drawing.Size(134, 73);
            this.loanBook.TabIndex = 8;
            this.loanBook.Text = "השאל ספר";
            this.loanBook.UseVisualStyleBackColor = true;
            this.loanBook.Click += new System.EventHandler(this.loanBook_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 589);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 73);
            this.button1.TabIndex = 10;
            this.button1.Text = "חלון השאלות";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MemberNameLabel
            // 
            this.MemberNameLabel.AutoSize = true;
            this.MemberNameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MemberNameLabel.Location = new System.Drawing.Point(423, 12);
            this.MemberNameLabel.Name = "MemberNameLabel";
            this.MemberNameLabel.Size = new System.Drawing.Size(125, 37);
            this.MemberNameLabel.TabIndex = 11;
            this.MemberNameLabel.Text = "שם המנוי";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(433, 589);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 73);
            this.button2.TabIndex = 12;
            this.button2.Text = "חזור למסך הראשי";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(623, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "השאלות פעילות";
            // 
            // Memberlabel
            // 
            this.Memberlabel.AutoSize = true;
            this.Memberlabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Memberlabel.Location = new System.Drawing.Point(160, 81);
            this.Memberlabel.Name = "Memberlabel";
            this.Memberlabel.Size = new System.Drawing.Size(91, 23);
            this.Memberlabel.TabIndex = 14;
            this.Memberlabel.Text = "memberID";
            // 
            // LoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 679);
            this.Controls.Add(this.Memberlabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MemberNameLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ActiveLoanGrid);
            this.Controls.Add(this.loanBook);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoanForm";
            this.Text = "LoanForm";
            this.Load += new System.EventHandler(this.LoanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ActiveLoanGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ActiveLoanGrid;
        private System.Windows.Forms.Button loanBook;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label MemberNameLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Memberlabel;
    }
}