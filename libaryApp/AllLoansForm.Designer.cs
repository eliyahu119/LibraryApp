
namespace libaryApp
{
    partial class AllLoansForm
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
            this.AllLoanGrid = new System.Windows.Forms.DataGridView();
            this.allLoanLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AllLoanGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AllLoanGrid
            // 
            this.AllLoanGrid.AllowUserToAddRows = false;
            this.AllLoanGrid.AllowUserToDeleteRows = false;
            this.AllLoanGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllLoanGrid.Location = new System.Drawing.Point(6, 71);
            this.AllLoanGrid.Name = "AllLoanGrid";
            this.AllLoanGrid.ReadOnly = true;
            this.AllLoanGrid.RowHeadersVisible = false;
            this.AllLoanGrid.RowTemplate.Height = 25;
            this.AllLoanGrid.Size = new System.Drawing.Size(414, 471);
            this.AllLoanGrid.TabIndex = 4;
            this.AllLoanGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllLoanGrid_CellContentClick);
            // 
            // allLoanLabel
            // 
            this.allLoanLabel.AutoSize = true;
            this.allLoanLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.allLoanLabel.Location = new System.Drawing.Point(158, 38);
            this.allLoanLabel.Name = "allLoanLabel";
            this.allLoanLabel.Size = new System.Drawing.Size(212, 30);
            this.allLoanLabel.TabIndex = 5;
            this.allLoanLabel.Text = "כל ההשאלות למנוי {0}";
            this.allLoanLabel.Click += new System.EventHandler(this.allLoanLabel_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(95, 33);
            this.BackButton.TabIndex = 6;
            this.BackButton.Text = "חזור";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AllLoansForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 554);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.allLoanLabel);
            this.Controls.Add(this.AllLoanGrid);
            this.Name = "AllLoansForm";
            this.Text = "AllLoansForm";
            ((System.ComponentModel.ISupportInitialize)(this.AllLoanGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AllLoanGrid;
        private System.Windows.Forms.Label allLoanLabel;
        private System.Windows.Forms.Button BackButton;
    }
}