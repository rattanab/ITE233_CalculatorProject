namespace Project_Calculator_Reborn
{
    partial class Form3
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
            this.decGroupBox = new System.Windows.Forms.GroupBox();
            this.decInputBox = new System.Windows.Forms.TextBox();
            this.biTextBox = new System.Windows.Forms.TextBox();
            this.biGroupBox = new System.Windows.Forms.GroupBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.decGroupBox.SuspendLayout();
            this.biGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // decGroupBox
            // 
            this.decGroupBox.Controls.Add(this.decInputBox);
            this.decGroupBox.Location = new System.Drawing.Point(12, 12);
            this.decGroupBox.Name = "decGroupBox";
            this.decGroupBox.Size = new System.Drawing.Size(118, 52);
            this.decGroupBox.TabIndex = 0;
            this.decGroupBox.TabStop = false;
            this.decGroupBox.Text = "Decimal Value";
            // 
            // decInputBox
            // 
            this.decInputBox.Location = new System.Drawing.Point(6, 19);
            this.decInputBox.Name = "decInputBox";
            this.decInputBox.Size = new System.Drawing.Size(100, 20);
            this.decInputBox.TabIndex = 0;
            // 
            // biTextBox
            // 
            this.biTextBox.Location = new System.Drawing.Point(6, 19);
            this.biTextBox.Name = "biTextBox";
            this.biTextBox.Size = new System.Drawing.Size(100, 20);
            this.biTextBox.TabIndex = 1;
            // 
            // biGroupBox
            // 
            this.biGroupBox.Controls.Add(this.biTextBox);
            this.biGroupBox.Location = new System.Drawing.Point(12, 70);
            this.biGroupBox.Name = "biGroupBox";
            this.biGroupBox.Size = new System.Drawing.Size(118, 54);
            this.biGroupBox.TabIndex = 2;
            this.biGroupBox.TabStop = false;
            this.biGroupBox.Text = "Binary Value";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(136, 47);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(112, 50);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "Convert to Binary";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 137);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.biGroupBox);
            this.Controls.Add(this.decGroupBox);
            this.Name = "Form3";
            this.Text = "Binary Conversion";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.decGroupBox.ResumeLayout(false);
            this.decGroupBox.PerformLayout();
            this.biGroupBox.ResumeLayout(false);
            this.biGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox decGroupBox;
        private System.Windows.Forms.TextBox decInputBox;
        private System.Windows.Forms.TextBox biTextBox;
        private System.Windows.Forms.GroupBox biGroupBox;
        private System.Windows.Forms.Button convertButton;
    }
}