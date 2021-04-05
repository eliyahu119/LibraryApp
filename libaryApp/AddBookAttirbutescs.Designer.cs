
namespace libaryApp
{
    partial class AddBookAttirbutes
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
            this.bookAttirbuteLabel = new System.Windows.Forms.Label();
            this.bookAttirbuteTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bookAttirbuteLabel
            // 
            this.bookAttirbuteLabel.AutoSize = true;
            this.bookAttirbuteLabel.Location = new System.Drawing.Point(247, 26);
            this.bookAttirbuteLabel.Name = "bookAttirbuteLabel";
            this.bookAttirbuteLabel.Size = new System.Drawing.Size(50, 15);
            this.bookAttirbuteLabel.TabIndex = 0;
            this.bookAttirbuteLabel.Text = "הוסף {0}";
            // 
            // bookAttirbuteTextBox
            // 
            this.bookAttirbuteTextBox.Location = new System.Drawing.Point(115, 23);
            this.bookAttirbuteTextBox.Name = "bookAttirbuteTextBox";
            this.bookAttirbuteTextBox.Size = new System.Drawing.Size(100, 23);
            this.bookAttirbuteTextBox.TabIndex = 1;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 68);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "הוסף";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // AddBookAttirbutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 103);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.bookAttirbuteTextBox);
            this.Controls.Add(this.bookAttirbuteLabel);
            this.Name = "AddBookAttirbutes";
            this.Text = "AddBookAttirbutescs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.TextBox bookAttirbuteTextBox;
        private System.Windows.Forms.Label bookAttirbuteLabel;
        private System.Windows.Forms.Button submitButton;
    }
}