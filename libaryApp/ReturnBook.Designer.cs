
namespace libaryApp
{
    partial class ReturnBook
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
            this.backButton = new System.Windows.Forms.Button();
            this.SubmitReturn = new System.Windows.Forms.Button();
            this.BookCodeTxt = new System.Windows.Forms.TextBox();
            this.Booo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(71, 30);
            this.backButton.TabIndex = 24;
            this.backButton.Text = "חזור";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // SubmitReturn
            // 
            this.SubmitReturn.Location = new System.Drawing.Point(60, 130);
            this.SubmitReturn.Name = "SubmitReturn";
            this.SubmitReturn.Size = new System.Drawing.Size(119, 37);
            this.SubmitReturn.TabIndex = 23;
            this.SubmitReturn.Text = "החזר ספר";
            this.SubmitReturn.UseVisualStyleBackColor = true;
            this.SubmitReturn.Click += new System.EventHandler(this.SubmitReturn_Click);
            // 
            // BookCodeTxt
            // 
            this.BookCodeTxt.Location = new System.Drawing.Point(207, 63);
            this.BookCodeTxt.Name = "BookCodeTxt";
            this.BookCodeTxt.Size = new System.Drawing.Size(111, 23);
            this.BookCodeTxt.TabIndex = 22;
            // 
            // Booo
            // 
            this.Booo.AutoSize = true;
            this.Booo.Location = new System.Drawing.Point(336, 66);
            this.Booo.Name = "Booo";
            this.Booo.Size = new System.Drawing.Size(50, 15);
            this.Booo.TabIndex = 19;
            this.Booo.Text = "קוד ספר";
            // 
            // ReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 196);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.SubmitReturn);
            this.Controls.Add(this.BookCodeTxt);
            this.Controls.Add(this.Booo);
            this.Name = "ReturnBook";
            this.Text = "ReturnBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button SubmitReturn;
        private System.Windows.Forms.TextBox BookCodeTxt;
        private System.Windows.Forms.Label Booo;
    }
}