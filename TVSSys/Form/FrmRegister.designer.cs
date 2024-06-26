namespace TVSSys
{
    partial class FrmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegister));
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdRegister = new System.Windows.Forms.Button();
            this.lblCDKey = new System.Windows.Forms.Label();
            this.TxtCDKey1 = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.TxtRegister = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCDKey2 = new System.Windows.Forms.TextBox();
            this.TxtCDKey3 = new System.Windows.Forms.TextBox();
            this.TxtCDKey4 = new System.Windows.Forms.TextBox();
            this.lblSpace1 = new System.Windows.Forms.Label();
            this.lblSpace2 = new System.Windows.Forms.Label();
            this.lblSpace3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CmdExit
            // 
            this.CmdExit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CmdExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmdExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CmdExit.Location = new System.Drawing.Point(317, 213);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(103, 28);
            this.CmdExit.TabIndex = 25;
            this.CmdExit.Text = "Thoát  [ESC]";
            this.CmdExit.UseVisualStyleBackColor = false;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdRegister
            // 
            this.CmdRegister.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CmdRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmdRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CmdRegister.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmdRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdRegister.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CmdRegister.Location = new System.Drawing.Point(230, 213);
            this.CmdRegister.Name = "CmdRegister";
            this.CmdRegister.Size = new System.Drawing.Size(85, 28);
            this.CmdRegister.TabIndex = 24;
            this.CmdRegister.Text = "Kích hoạt";
            this.CmdRegister.UseVisualStyleBackColor = false;
            this.CmdRegister.Click += new System.EventHandler(this.CmdRegister_Click);
            // 
            // lblCDKey
            // 
            this.lblCDKey.AutoSize = true;
            this.lblCDKey.BackColor = System.Drawing.Color.Transparent;
            this.lblCDKey.Location = new System.Drawing.Point(24, 135);
            this.lblCDKey.Name = "lblCDKey";
            this.lblCDKey.Size = new System.Drawing.Size(57, 15);
            this.lblCDKey.TabIndex = 7;
            this.lblCDKey.Text = "CD Key : ";
            // 
            // TxtCDKey1
            // 
            this.TxtCDKey1.BackColor = System.Drawing.Color.White;
            this.TxtCDKey1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCDKey1.Location = new System.Drawing.Point(84, 132);
            this.TxtCDKey1.MaxLength = 5;
            this.TxtCDKey1.Name = "TxtCDKey1";
            this.TxtCDKey1.Size = new System.Drawing.Size(55, 21);
            this.TxtCDKey1.TabIndex = 6;
            this.TxtCDKey1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(4, 67);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(415, 58);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInformation
            // 
            this.lblInformation.BackColor = System.Drawing.Color.White;
            this.lblInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInformation.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.ForeColor = System.Drawing.Color.Red;
            this.lblInformation.Location = new System.Drawing.Point(4, 6);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(415, 26);
            this.lblInformation.TabIndex = 1;
            this.lblInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtRegister
            // 
            this.TxtRegister.BackColor = System.Drawing.Color.White;
            this.TxtRegister.Location = new System.Drawing.Point(84, 39);
            this.TxtRegister.Name = "TxtRegister";
            this.TxtRegister.ReadOnly = true;
            this.TxtRegister.Size = new System.Drawing.Size(335, 21);
            this.TxtRegister.TabIndex = 2;
            this.TxtRegister.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã đăng ký : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "ĐT hỗ trợ : 0388.903.452 - 0383.552.896 - 0904.686.357";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(6, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Email : info@trungvietsoftware.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(156, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "[Nhập vào số CD Key hợp lệ đã được cung cấp]";
            // 
            // TxtCDKey2
            // 
            this.TxtCDKey2.BackColor = System.Drawing.Color.White;
            this.TxtCDKey2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCDKey2.Location = new System.Drawing.Point(154, 132);
            this.TxtCDKey2.MaxLength = 5;
            this.TxtCDKey2.Name = "TxtCDKey2";
            this.TxtCDKey2.Size = new System.Drawing.Size(55, 21);
            this.TxtCDKey2.TabIndex = 29;
            this.TxtCDKey2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtCDKey3
            // 
            this.TxtCDKey3.BackColor = System.Drawing.Color.White;
            this.TxtCDKey3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCDKey3.Location = new System.Drawing.Point(224, 132);
            this.TxtCDKey3.MaxLength = 5;
            this.TxtCDKey3.Name = "TxtCDKey3";
            this.TxtCDKey3.Size = new System.Drawing.Size(55, 21);
            this.TxtCDKey3.TabIndex = 30;
            this.TxtCDKey3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtCDKey4
            // 
            this.TxtCDKey4.BackColor = System.Drawing.Color.White;
            this.TxtCDKey4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCDKey4.Location = new System.Drawing.Point(294, 132);
            this.TxtCDKey4.MaxLength = 5;
            this.TxtCDKey4.Name = "TxtCDKey4";
            this.TxtCDKey4.Size = new System.Drawing.Size(55, 21);
            this.TxtCDKey4.TabIndex = 31;
            this.TxtCDKey4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSpace1
            // 
            this.lblSpace1.AutoSize = true;
            this.lblSpace1.BackColor = System.Drawing.Color.Transparent;
            this.lblSpace1.Location = new System.Drawing.Point(140, 135);
            this.lblSpace1.Name = "lblSpace1";
            this.lblSpace1.Size = new System.Drawing.Size(11, 15);
            this.lblSpace1.TabIndex = 33;
            this.lblSpace1.Text = "-";
            // 
            // lblSpace2
            // 
            this.lblSpace2.AutoSize = true;
            this.lblSpace2.BackColor = System.Drawing.Color.Transparent;
            this.lblSpace2.Location = new System.Drawing.Point(211, 135);
            this.lblSpace2.Name = "lblSpace2";
            this.lblSpace2.Size = new System.Drawing.Size(11, 15);
            this.lblSpace2.TabIndex = 34;
            this.lblSpace2.Text = "-";
            // 
            // lblSpace3
            // 
            this.lblSpace3.AutoSize = true;
            this.lblSpace3.BackColor = System.Drawing.Color.Transparent;
            this.lblSpace3.Location = new System.Drawing.Point(281, 135);
            this.lblSpace3.Name = "lblSpace3";
            this.lblSpace3.Size = new System.Drawing.Size(11, 15);
            this.lblSpace3.TabIndex = 35;
            this.lblSpace3.Text = "-";
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 245);
            this.Controls.Add(this.lblSpace3);
            this.Controls.Add(this.lblSpace2);
            this.Controls.Add(this.lblSpace1);
            this.Controls.Add(this.TxtCDKey4);
            this.Controls.Add(this.TxtCDKey3);
            this.Controls.Add(this.TxtCDKey2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdRegister);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCDKey);
            this.Controls.Add(this.TxtCDKey1);
            this.Controls.Add(this.TxtRegister);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 279);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 279);
            this.Name = "FrmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " .: Bản quyền sử dụng";
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRegister_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRegister;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCDKey;
        private System.Windows.Forms.TextBox TxtCDKey1;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdRegister;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.TextBox TxtCDKey2;
        private System.Windows.Forms.TextBox TxtCDKey3;
        private System.Windows.Forms.TextBox TxtCDKey4;
        private System.Windows.Forms.Label lblSpace1;
        private System.Windows.Forms.Label lblSpace2;
        private System.Windows.Forms.Label lblSpace3;
    }
}