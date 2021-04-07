
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
            this.backButton.Location = new System.Drawing.Point(14, 16);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(81, 40);
            this.backButton.TabIndex = 24;
            this.backButton.Text = "חזור";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // SubmitReturn
            // 
            this.SubmitReturn.Location = new System.Drawing.Point(69, 173);
            this.SubmitReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SubmitReturn.Name = "SubmitReturn";
            this.SubmitReturn.Size = new System.Drawing.Size(136, 49);
            this.SubmitReturn.TabIndex = 23;
            this.SubmitReturn.Text = "החזר ספר";
            this.SubmitReturn.UseVisualStyleBackColor = true;
            this.SubmitReturn.Click += new System.EventHandler(this.SubmitReturn_Click);
            // 
            // BookCodeTxt
            // 
            this.BookCodeTxt.Location = new System.Drawing.Point(237, 84);
            this.BookCodeTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookCodeTxt.Name = "BookCodeTxt";
            this.BookCodeTxt.Size = new System.Drawing.Size(126, 27);
            this.BookCodeTxt.TabIndex = 22;
            this.BookCodeTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Utils.AllowOnlyNumeric);
            // 
            // Booo
            // 
            this.Booo.AutoSize = true;
            this.Booo.Location = new System.Drawing.Point(384, 88);
            this.Booo.Name = "Booo";
            this.Booo.Size = new System.Drawing.Size(61, 20);
            this.Booo.TabIndex = 19;
            this.Booo.Text = "קוד ספר";
            // 
            // ReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 261);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.SubmitReturn);
            this.Controls.Add(this.BookCodeTxt);
            this.Controls.Add(this.Booo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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