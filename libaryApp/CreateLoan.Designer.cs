
namespace libaryApp
{
    partial class CreateLoan
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
            this.BookCodeTxt = new System.Windows.Forms.TextBox();
            this.CodeMemberTxt = new System.Windows.Forms.TextBox();
            this.copiesLabel = new System.Windows.Forms.Label();
            this.Booo = new System.Windows.Forms.Label();
            this.SubmitLoan = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BookCodeTxt
            // 
            this.BookCodeTxt.Location = new System.Drawing.Point(200, 60);
            this.BookCodeTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookCodeTxt.Name = "BookCodeTxt";
            this.BookCodeTxt.Size = new System.Drawing.Size(126, 27);
            this.BookCodeTxt.TabIndex = 16;
            this.BookCodeTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Utils.AllowOnlyNumeric);
            // 
            // CodeMemberTxt
            // 
            this.CodeMemberTxt.Location = new System.Drawing.Point(200, 107);
            this.CodeMemberTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CodeMemberTxt.Name = "CodeMemberTxt";
            this.CodeMemberTxt.Size = new System.Drawing.Size(126, 27);
            this.CodeMemberTxt.TabIndex = 15;
            this.CodeMemberTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Utils.AllowOnlyNumeric);
            // 
            // copiesLabel
            // 
            this.copiesLabel.AutoSize = true;
            this.copiesLabel.Location = new System.Drawing.Point(347, 111);
            this.copiesLabel.Name = "copiesLabel";
            this.copiesLabel.Size = new System.Drawing.Size(58, 20);
            this.copiesLabel.TabIndex = 14;
            this.copiesLabel.Text = "קוד מנוי";
            // 
            // Booo
            // 
            this.Booo.AutoSize = true;
            this.Booo.Location = new System.Drawing.Point(347, 64);
            this.Booo.Name = "Booo";
            this.Booo.Size = new System.Drawing.Size(61, 20);
            this.Booo.TabIndex = 13;
            this.Booo.Text = "קוד ספר";
            // 
            // SubmitLoan
            // 
            this.SubmitLoan.Location = new System.Drawing.Point(43, 184);
            this.SubmitLoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SubmitLoan.Name = "SubmitLoan";
            this.SubmitLoan.Size = new System.Drawing.Size(136, 49);
            this.SubmitLoan.TabIndex = 17;
            this.SubmitLoan.Text = "צור השאלה";
            this.SubmitLoan.UseVisualStyleBackColor = true;
            this.SubmitLoan.Click += new System.EventHandler(this.SubmitLoan_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(14, 16);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(81, 40);
            this.backButton.TabIndex = 18;
            this.backButton.Text = "חזור";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // CreateLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 267);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.SubmitLoan);
            this.Controls.Add(this.BookCodeTxt);
            this.Controls.Add(this.CodeMemberTxt);
            this.Controls.Add(this.copiesLabel);
            this.Controls.Add(this.Booo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateLoan";
            this.Text = "CreateLoan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BookCodeTxt;
        private System.Windows.Forms.TextBox CodeMemberTxt;
        private System.Windows.Forms.Label copiesLabel;
        private System.Windows.Forms.Label Booo;
        private System.Windows.Forms.Button SubmitLoan;
        private System.Windows.Forms.Button backButton;
    }
}