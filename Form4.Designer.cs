namespace StudentInformationKiosk
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.descriptionTxt = new System.Windows.Forms.RichTextBox();
            this.providerCombo = new System.Windows.Forms.ComboBox();
            this.providerTxt = new System.Windows.Forms.TextBox();
            this.campusCombo = new System.Windows.Forms.ComboBox();
            this.campusTxt = new System.Windows.Forms.TextBox();
            this.roomTxt = new System.Windows.Forms.TextBox();
            this.capacityTxt = new System.Windows.Forms.TextBox();
            this.dayTxt = new System.Windows.Forms.TextBox();
            this.monthTxt = new System.Windows.Forms.TextBox();
            this.yearTxt = new System.Windows.Forms.TextBox();
            this.startTxt = new System.Windows.Forms.TextBox();
            this.durationTxt = new System.Windows.Forms.TextBox();
            this.bookBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.saveServiceBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTxt
            // 
            this.nameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameTxt.Location = new System.Drawing.Point(150, 130);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(375, 22);
            this.nameTxt.TabIndex = 0;
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionTxt.Location = new System.Drawing.Point(150, 158);
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.descriptionTxt.Size = new System.Drawing.Size(375, 141);
            this.descriptionTxt.TabIndex = 1;
            this.descriptionTxt.Text = "";
            // 
            // providerCombo
            // 
            this.providerCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.providerCombo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.providerCombo.FormattingEnabled = true;
            this.providerCombo.Location = new System.Drawing.Point(125, 300);
            this.providerCombo.Name = "providerCombo";
            this.providerCombo.Size = new System.Drawing.Size(90, 23);
            this.providerCombo.TabIndex = 2;
            // 
            // providerTxt
            // 
            this.providerTxt.BackColor = System.Drawing.SystemColors.Window;
            this.providerTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.providerTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.providerTxt.Location = new System.Drawing.Point(125, 300);
            this.providerTxt.Name = "providerTxt";
            this.providerTxt.Size = new System.Drawing.Size(90, 22);
            this.providerTxt.TabIndex = 3;
            // 
            // campusCombo
            // 
            this.campusCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.campusCombo.FormattingEnabled = true;
            this.campusCombo.Location = new System.Drawing.Point(125, 325);
            this.campusCombo.Name = "campusCombo";
            this.campusCombo.Size = new System.Drawing.Size(90, 23);
            this.campusCombo.TabIndex = 4;
            // 
            // campusTxt
            // 
            this.campusTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campusTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.campusTxt.Location = new System.Drawing.Point(125, 325);
            this.campusTxt.Name = "campusTxt";
            this.campusTxt.Size = new System.Drawing.Size(90, 22);
            this.campusTxt.TabIndex = 5;
            // 
            // roomTxt
            // 
            this.roomTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roomTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.roomTxt.Location = new System.Drawing.Point(276, 326);
            this.roomTxt.Name = "roomTxt";
            this.roomTxt.Size = new System.Drawing.Size(90, 22);
            this.roomTxt.TabIndex = 6;
            // 
            // capacityTxt
            // 
            this.capacityTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.capacityTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.capacityTxt.Location = new System.Drawing.Point(450, 326);
            this.capacityTxt.Name = "capacityTxt";
            this.capacityTxt.Size = new System.Drawing.Size(75, 22);
            this.capacityTxt.TabIndex = 7;
            // 
            // dayTxt
            // 
            this.dayTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dayTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dayTxt.Location = new System.Drawing.Point(90, 350);
            this.dayTxt.MaxLength = 2;
            this.dayTxt.Name = "dayTxt";
            this.dayTxt.Size = new System.Drawing.Size(30, 22);
            this.dayTxt.TabIndex = 8;
            // 
            // monthTxt
            // 
            this.monthTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.monthTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.monthTxt.Location = new System.Drawing.Point(125, 350);
            this.monthTxt.MaxLength = 2;
            this.monthTxt.Name = "monthTxt";
            this.monthTxt.Size = new System.Drawing.Size(39, 22);
            this.monthTxt.TabIndex = 9;
            // 
            // yearTxt
            // 
            this.yearTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yearTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yearTxt.Location = new System.Drawing.Point(171, 350);
            this.yearTxt.MaxLength = 4;
            this.yearTxt.Name = "yearTxt";
            this.yearTxt.Size = new System.Drawing.Size(44, 22);
            this.yearTxt.TabIndex = 10;
            // 
            // startTxt
            // 
            this.startTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startTxt.Location = new System.Drawing.Point(309, 350);
            this.startTxt.MaxLength = 5;
            this.startTxt.Name = "startTxt";
            this.startTxt.Size = new System.Drawing.Size(57, 22);
            this.startTxt.TabIndex = 11;
            // 
            // durationTxt
            // 
            this.durationTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.durationTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.durationTxt.Location = new System.Drawing.Point(450, 350);
            this.durationTxt.MaxLength = 5;
            this.durationTxt.Name = "durationTxt";
            this.durationTxt.Size = new System.Drawing.Size(75, 22);
            this.durationTxt.TabIndex = 12;
            // 
            // bookBtn
            // 
            this.bookBtn.BackColor = System.Drawing.Color.Transparent;
            this.bookBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bookBtn.BackgroundImage")));
            this.bookBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bookBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookBtn.FlatAppearance.BorderSize = 0;
            this.bookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookBtn.Location = new System.Drawing.Point(40, 400);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(190, 40);
            this.bookBtn.TabIndex = 13;
            this.bookBtn.UseVisualStyleBackColor = false;
            this.bookBtn.Click += new System.EventHandler(this.bookServices_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveBtn.BackgroundImage")));
            this.saveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(250, 400);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(190, 40);
            this.saveBtn.TabIndex = 14;
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // saveServiceBtn
            // 
            this.saveServiceBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveServiceBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveServiceBtn.BackgroundImage")));
            this.saveServiceBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.saveServiceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveServiceBtn.FlatAppearance.BorderSize = 0;
            this.saveServiceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveServiceBtn.Location = new System.Drawing.Point(40, 400);
            this.saveServiceBtn.Name = "saveServiceBtn";
            this.saveServiceBtn.Size = new System.Drawing.Size(190, 40);
            this.saveServiceBtn.TabIndex = 15;
            this.saveServiceBtn.UseVisualStyleBackColor = false;
            this.saveServiceBtn.Click += new System.EventHandler(this.saveServiceBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Transparent;
            this.deleteBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteBtn.BackgroundImage")));
            this.deleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Location = new System.Drawing.Point(470, 400);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(55, 40);
            this.deleteBtn.TabIndex = 16;
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Visible = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.saveServiceBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.bookBtn);
            this.Controls.Add(this.durationTxt);
            this.Controls.Add(this.startTxt);
            this.Controls.Add(this.yearTxt);
            this.Controls.Add(this.monthTxt);
            this.Controls.Add(this.dayTxt);
            this.Controls.Add(this.capacityTxt);
            this.Controls.Add(this.roomTxt);
            this.Controls.Add(this.campusTxt);
            this.Controls.Add(this.campusCombo);
            this.Controls.Add(this.providerTxt);
            this.Controls.Add(this.providerCombo);
            this.Controls.Add(this.descriptionTxt);
            this.Controls.Add(this.nameTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Information";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.RichTextBox descriptionTxt;
        private System.Windows.Forms.ComboBox providerCombo;
        private System.Windows.Forms.TextBox providerTxt;
        private System.Windows.Forms.ComboBox campusCombo;
        private System.Windows.Forms.TextBox campusTxt;
        private System.Windows.Forms.TextBox roomTxt;
        private System.Windows.Forms.TextBox capacityTxt;
        private System.Windows.Forms.TextBox dayTxt;
        private System.Windows.Forms.TextBox monthTxt;
        private System.Windows.Forms.TextBox yearTxt;
        private System.Windows.Forms.TextBox startTxt;
        private System.Windows.Forms.TextBox durationTxt;
        private System.Windows.Forms.Button bookBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button saveServiceBtn;
        private System.Windows.Forms.Button deleteBtn;
    }
}