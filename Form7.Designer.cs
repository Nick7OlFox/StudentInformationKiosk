namespace StudentInformationKiosk
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.oldPassTxt = new System.Windows.Forms.TextBox();
            this.newPassTxt = new System.Windows.Forms.TextBox();
            this.confirmTxt = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oldPassTxt
            // 
            this.oldPassTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.oldPassTxt.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.oldPassTxt.Location = new System.Drawing.Point(35, 124);
            this.oldPassTxt.Name = "oldPassTxt";
            this.oldPassTxt.PasswordChar = '*';
            this.oldPassTxt.Size = new System.Drawing.Size(279, 25);
            this.oldPassTxt.TabIndex = 0;
            // 
            // newPassTxt
            // 
            this.newPassTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newPassTxt.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newPassTxt.Location = new System.Drawing.Point(35, 216);
            this.newPassTxt.Name = "newPassTxt";
            this.newPassTxt.PasswordChar = '*';
            this.newPassTxt.Size = new System.Drawing.Size(279, 25);
            this.newPassTxt.TabIndex = 1;
            // 
            // confirmTxt
            // 
            this.confirmTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.confirmTxt.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirmTxt.Location = new System.Drawing.Point(35, 316);
            this.confirmTxt.Name = "confirmTxt";
            this.confirmTxt.PasswordChar = '*';
            this.confirmTxt.Size = new System.Drawing.Size(279, 25);
            this.confirmTxt.TabIndex = 2;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.Transparent;
            this.submitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("submitBtn.BackgroundImage")));
            this.submitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Location = new System.Drawing.Point(80, 355);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(190, 40);
            this.submitBtn.TabIndex = 3;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelBtn.BackgroundImage")));
            this.cancelBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Location = new System.Drawing.Point(80, 410);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(190, 40);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Form7
            // 
            this.AcceptButton = this.submitBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(350, 475);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.confirmTxt);
            this.Controls.Add(this.newPassTxt);
            this.Controls.Add(this.oldPassTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form7";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox oldPassTxt;
        private System.Windows.Forms.TextBox newPassTxt;
        private System.Windows.Forms.TextBox confirmTxt;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}