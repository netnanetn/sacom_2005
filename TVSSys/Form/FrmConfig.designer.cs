namespace TVSSys
{
    partial class FrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.btnAllExit = new System.Windows.Forms.Button();
            this.btnAllUpdate = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.TxtSourcePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkContractExpires = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbContractExpiresExt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkShowBirthday = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbBirthdayExt = new System.Windows.Forms.ComboBox();
            this.chkShowMenuLeft = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCodeID = new System.Windows.Forms.TabControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFolderAttach = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.tabCodeID.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAllExit
            // 
            this.btnAllExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAllExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAllExit.Location = new System.Drawing.Point(372, 244);
            this.btnAllExit.Name = "btnAllExit";
            this.btnAllExit.Size = new System.Drawing.Size(100, 30);
            this.btnAllExit.TabIndex = 10;
            this.btnAllExit.Text = "Th&oát";
            this.btnAllExit.UseVisualStyleBackColor = true;
            this.btnAllExit.Click += new System.EventHandler(this.btnAllExit_Click);
            // 
            // btnAllUpdate
            // 
            this.btnAllUpdate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAllUpdate.Location = new System.Drawing.Point(266, 244);
            this.btnAllUpdate.Name = "btnAllUpdate";
            this.btnAllUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnAllUpdate.TabIndex = 9;
            this.btnAllUpdate.Text = "Cập nhật";
            this.btnAllUpdate.UseVisualStyleBackColor = true;
            this.btnAllUpdate.Click += new System.EventHandler(this.btnAllUpdate_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtFolderAttach);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btnOpen);
            this.tabPage1.Controls.Add(this.TxtSourcePath);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chkContractExpires);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cbbContractExpiresExt);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.chkShowBirthday);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbbBirthdayExt);
            this.tabPage1.Controls.Add(this.chkShowMenuLeft);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 202);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cấu hình chung";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(386, 150);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(29, 23);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // TxtSourcePath
            // 
            this.TxtSourcePath.BackColor = System.Drawing.Color.White;
            this.TxtSourcePath.Location = new System.Drawing.Point(173, 150);
            this.TxtSourcePath.Name = "TxtSourcePath";
            this.TxtSourcePath.ReadOnly = true;
            this.TxtSourcePath.Size = new System.Drawing.Size(207, 21);
            this.TxtSourcePath.TabIndex = 22;
            this.TxtSourcePath.Leave += new System.EventHandler(this.txtLeave);
            this.TxtSourcePath.Enter += new System.EventHandler(this.txtEnter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Dữ liệu chấm công :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(198, 88);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ngày cần xem :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkContractExpires
            // 
            this.chkContractExpires.AutoSize = true;
            this.chkContractExpires.Location = new System.Drawing.Point(173, 92);
            this.chkContractExpires.Name = "chkContractExpires";
            this.chkContractExpires.Size = new System.Drawing.Size(15, 14);
            this.chkContractExpires.TabIndex = 5;
            this.chkContractExpires.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 88);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Hiện thị hết hạn HĐ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbContractExpiresExt
            // 
            this.cbbContractExpiresExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbContractExpiresExt.FormattingEnabled = true;
            this.cbbContractExpiresExt.Location = new System.Drawing.Point(287, 88);
            this.cbbContractExpiresExt.Name = "cbbContractExpiresExt";
            this.cbbContractExpiresExt.Size = new System.Drawing.Size(93, 23);
            this.cbbContractExpiresExt.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(198, 58);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ngày cần xem :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShowBirthday
            // 
            this.chkShowBirthday.AutoSize = true;
            this.chkShowBirthday.Location = new System.Drawing.Point(173, 62);
            this.chkShowBirthday.Name = "chkShowBirthday";
            this.chkShowBirthday.Size = new System.Drawing.Size(15, 14);
            this.chkShowBirthday.TabIndex = 3;
            this.chkShowBirthday.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 58);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Hiện thị Sinh nhật :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbBirthdayExt
            // 
            this.cbbBirthdayExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBirthdayExt.FormattingEnabled = true;
            this.cbbBirthdayExt.Location = new System.Drawing.Point(287, 58);
            this.cbbBirthdayExt.Name = "cbbBirthdayExt";
            this.cbbBirthdayExt.Size = new System.Drawing.Size(93, 23);
            this.cbbBirthdayExt.TabIndex = 4;
            // 
            // chkShowMenuLeft
            // 
            this.chkShowMenuLeft.AutoSize = true;
            this.chkShowMenuLeft.Location = new System.Drawing.Point(173, 33);
            this.chkShowMenuLeft.Name = "chkShowMenuLeft";
            this.chkShowMenuLeft.Size = new System.Drawing.Size(15, 14);
            this.chkShowMenuLeft.TabIndex = 2;
            this.chkShowMenuLeft.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(43, 29);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hiện thị Menu trái :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabCodeID
            // 
            this.tabCodeID.Controls.Add(this.tabPage1);
            this.tabCodeID.Location = new System.Drawing.Point(8, 8);
            this.tabCodeID.Name = "tabCodeID";
            this.tabCodeID.SelectedIndex = 0;
            this.tabCodeID.Size = new System.Drawing.Size(464, 230);
            this.tabCodeID.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFolderAttach
            // 
            this.txtFolderAttach.BackColor = System.Drawing.Color.White;
            this.txtFolderAttach.Location = new System.Drawing.Point(173, 119);
            this.txtFolderAttach.Name = "txtFolderAttach";
            this.txtFolderAttach.Size = new System.Drawing.Size(207, 21);
            this.txtFolderAttach.TabIndex = 7;
            this.txtFolderAttach.Leave += new System.EventHandler(this.txtLeave);
            this.txtFolderAttach.Enter += new System.EventHandler(this.txtEnter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "Thư mục đính kèm file :";
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAllExit;
            this.ClientSize = new System.Drawing.Size(479, 283);
            this.Controls.Add(this.btnAllUpdate);
            this.Controls.Add(this.btnAllExit);
            this.Controls.Add(this.tabCodeID);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(495, 321);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(495, 321);
            this.Name = "FrmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " .: Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.FrmCongif_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCongif_KeyDown);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabCodeID.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllExit;
        private System.Windows.Forms.Button btnAllUpdate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbbBirthdayExt;
        private System.Windows.Forms.CheckBox chkShowMenuLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabCodeID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkShowBirthday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkContractExpires;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbContractExpiresExt;
        private System.Windows.Forms.TextBox TxtSourcePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFolderAttach;
        private System.Windows.Forms.Label label7;

    }
}