
namespace libaryApp
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.LoanBook = new System.Windows.Forms.Button();
            this.ReturnBook = new System.Windows.Forms.Button();
            this.Books = new System.Windows.Forms.Button();
            this.Members = new System.Windows.Forms.Button();
            this.belonging = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.headline = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoanBook
            // 
            this.LoanBook.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoanBook.Location = new System.Drawing.Point(309, 111);
            this.LoanBook.Name = "LoanBook";
            this.LoanBook.Size = new System.Drawing.Size(224, 100);
            this.LoanBook.TabIndex = 0;
            this.LoanBook.Text = "השאל ספרים";
            this.LoanBook.UseVisualStyleBackColor = true;
            // 
            // ReturnBook
            // 
            this.ReturnBook.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReturnBook.Location = new System.Drawing.Point(309, 252);
            this.ReturnBook.Name = "ReturnBook";
            this.ReturnBook.Size = new System.Drawing.Size(224, 100);
            this.ReturnBook.TabIndex = 1;
            this.ReturnBook.Text = "החזר ספר";
            this.ReturnBook.UseVisualStyleBackColor = true;
            // 
            // Books
            // 
            this.Books.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Books.Location = new System.Drawing.Point(57, 127);
            this.Books.Name = "Books";
            this.Books.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Books.Size = new System.Drawing.Size(165, 68);
            this.Books.TabIndex = 2;
            this.Books.Text = "ספרים";
            this.Books.UseVisualStyleBackColor = true;
            this.Books.Click += new System.EventHandler(this.Books_Click);
            // 
            // Members
            // 
            this.Members.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Members.Location = new System.Drawing.Point(57, 220);
            this.Members.Name = "Members";
            this.Members.Size = new System.Drawing.Size(165, 68);
            this.Members.TabIndex = 3;
            this.Members.Text = "מנויים";
            this.Members.UseVisualStyleBackColor = true;
            // 
            // belonging
            // 
            this.belonging.AutoSize = true;
            this.belonging.Location = new System.Drawing.Point(12, 472);
            this.belonging.Name = "belonging";
            this.belonging.Size = new System.Drawing.Size(103, 15);
            this.belonging.TabIndex = 4;
            this.belonging.Text = "created by eliyahu";
            this.belonging.UseWaitCursor = true;
            this.belonging.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2232, -60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "created by eliyahu";
            this.label1.UseWaitCursor = true;
            // 
            // headline
            // 
            this.headline.AutoSize = true;
            this.headline.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.headline.Location = new System.Drawing.Point(619, 9);
            this.headline.Name = "headline";
            this.headline.Size = new System.Drawing.Size(171, 50);
            this.headline.TabIndex = 7;
            this.headline.Text = "הספרייה ";
            this.headline.UseWaitCursor = true;
            this.headline.Click += new System.EventHandler(this.headline_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(619, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Size = new System.Drawing.Size(156, 146);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 472);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.headline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.belonging);
            this.Controls.Add(this.Members);
            this.Controls.Add(this.Books);
            this.Controls.Add(this.ReturnBook);
            this.Controls.Add(this.LoanBook);
            this.Name = "MainWindow";
            this.Text = "liberyApp";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoanBook;
        private System.Windows.Forms.Button ReturnBook;
        private System.Windows.Forms.Button Books;
        private System.Windows.Forms.Button Members;
        private System.Windows.Forms.Label belonging;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label headline;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

