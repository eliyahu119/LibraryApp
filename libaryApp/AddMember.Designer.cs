
namespace libaryApp
{
    partial class AddMember
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
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.bookNameLabel = new System.Windows.Forms.Label();
            this.AdressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PersonIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Location = new System.Drawing.Point(50, 121);
            this.phoneNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.phoneNumberTextBox.MaxLength = 10;
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(138, 27);
            this.phoneNumberTextBox.TabIndex = 12;
            this.phoneNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Utils.AllowOnlyNumeric);
            // 
            // bookNameLabel
            // 
            this.bookNameLabel.AutoSize = true;
            this.bookNameLabel.Location = new System.Drawing.Point(206, 128);
            this.bookNameLabel.Name = "bookNameLabel";
            this.bookNameLabel.Size = new System.Drawing.Size(94, 20);
            this.bookNameLabel.TabIndex = 11;
            this.bookNameLabel.Text = "מספר פלאפון";
            // 
            // AdressTextBox
            // 
            this.AdressTextBox.Location = new System.Drawing.Point(50, 156);
            this.AdressTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AdressTextBox.Name = "AdressTextBox";
            this.AdressTextBox.Size = new System.Drawing.Size(138, 27);
            this.AdressTextBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "כתובת";
            // 
            // PersonIDTextBox
            // 
            this.PersonIDTextBox.Location = new System.Drawing.Point(49, 51);
            this.PersonIDTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PersonIDTextBox.MaxLength = 9;
            this.PersonIDTextBox.Name = "PersonIDTextBox";
            this.PersonIDTextBox.Size = new System.Drawing.Size(138, 27);
            this.PersonIDTextBox.TabIndex = 16;
            this.PersonIDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Utils.AllowOnlyNumeric);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "ת\"ז";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(49, 86);
            this.fullNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(138, 27);
            this.fullNameTextBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "שם מלא";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(118, 213);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(113, 31);
            this.SubmitButton.TabIndex = 19;
            this.SubmitButton.Text = "הוסף מנוי";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // AddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 295);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.fullNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PersonIDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdressTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.bookNameLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddMember";
            this.Text = "AddMember";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddMember_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.Label bookNameLabel;
        private System.Windows.Forms.TextBox AdressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PersonIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SubmitButton;
    }
}