namespace TVSSys
{
    partial class FrmupdtUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmupdtUser));
            this.tSBClose = new System.Windows.Forms.Button();
            this.tSBSave = new System.Windows.Forms.Button();
            this.lsvGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tSBAdd = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.ckBSActive = new System.Windows.Forms.CheckBox();
            this.txtPassCofirm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tSBClose
            // 
            this.tSBClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tSBClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tSBClose.Location = new System.Drawing.Point(456, 159);
            this.tSBClose.Name = "tSBClose";
            this.tSBClose.Size = new System.Drawing.Size(80, 28);
            this.tSBClose.TabIndex = 24;
            this.tSBClose.Text = "Th&oát";
            this.tSBClose.UseVisualStyleBackColor = true;
            this.tSBClose.Click += new System.EventHandler(this.tSBClose_Click);
            // 
            // tSBSave
            // 
            this.tSBSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tSBSave.Location = new System.Drawing.Point(370, 159);
            this.tSBSave.Name = "tSBSave";
            this.tSBSave.Size = new System.Drawing.Size(80, 28);
            this.tSBSave.TabIndex = 23;
            this.tSBSave.Text = "&Ghi nhận";
            this.tSBSave.UseVisualStyleBackColor = true;
            this.tSBSave.Click += new System.EventHandler(this.tSBSave_Click);
            // 
            // lsvGroup
            // 
            this.lsvGroup.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvGroup.BackColor = System.Drawing.Color.White;
            this.lsvGroup.CheckBoxes = true;
            this.lsvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvGroup.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvGroup.FullRowSelect = true;
            this.lsvGroup.GridLines = true;
            this.lsvGroup.Location = new System.Drawing.Point(271, 9);
            this.lsvGroup.Name = "lsvGroup";
            this.lsvGroup.Size = new System.Drawing.Size(265, 113);
            this.lsvGroup.TabIndex = 7;
            this.lsvGroup.UseCompatibleStateImageBehavior = false;
            this.lsvGroup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "    Nhóm";
            this.columnHeader1.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "           Tên nhóm";
            this.columnHeader2.Width = 179;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // tSBAdd
            // 
            this.tSBAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tSBAdd.Location = new System.Drawing.Point(284, 159);
            this.tSBAdd.Name = "tSBAdd";
            this.tSBAdd.Size = new System.Drawing.Size(80, 28);
            this.tSBAdd.TabIndex = 22;
            this.tSBAdd.Text = "&Thêm mới";
            this.tSBAdd.UseVisualStyleBackColor = true;
            this.tSBAdd.Click += new System.EventHandler(this.tSBAdd_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(12, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(12, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(12, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(58, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ghi chú :";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(116, 129);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(420, 21);
            this.txtNote.TabIndex = 5;
            this.txtNote.Leave += new System.EventHandler(this.txtLeave);
            this.txtNote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNote_KeyPress);
            this.txtNote.Enter += new System.EventHandler(this.txtEnter);
            // 
            // ckBSActive
            // 
            this.ckBSActive.AutoSize = true;
            this.ckBSActive.BackColor = System.Drawing.Color.Transparent;
            this.ckBSActive.Location = new System.Drawing.Point(111, 156);
            this.ckBSActive.Name = "ckBSActive";
            this.ckBSActive.Size = new System.Drawing.Size(77, 19);
            this.ckBSActive.TabIndex = 6;
            this.ckBSActive.Text = "Kích hoạt";
            this.ckBSActive.UseVisualStyleBackColor = false;
            // 
            // txtPassCofirm
            // 
            this.txtPassCofirm.Location = new System.Drawing.Point(116, 99);
            this.txtPassCofirm.Name = "txtPassCofirm";
            this.txtPassCofirm.Size = new System.Drawing.Size(150, 21);
            this.txtPassCofirm.TabIndex = 4;
            this.txtPassCofirm.Leave += new System.EventHandler(this.txtLeave);
            this.txtPassCofirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassCofirm_KeyPress);
            this.txtPassCofirm.Enter += new System.EventHandler(this.txtEnter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(9, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Lặp lại mật khẩu :";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(116, 69);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(150, 21);
            this.txtPass.TabIndex = 3;
            this.txtPass.Leave += new System.EventHandler(this.txtLeave);
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            this.txtPass.Enter += new System.EventHandler(this.txtEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(51, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mật khẩu :";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(116, 39);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(150, 21);
            this.txtFullName.TabIndex = 2;
            this.txtFullName.Leave += new System.EventHandler(this.txtLeave);
            this.txtFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFullName_KeyPress);
            this.txtFullName.Enter += new System.EventHandler(this.txtEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(36, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên hiển thị :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(116, 9);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(150, 21);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Leave += new System.EventHandler(this.txtLeave);
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            this.txtUserName.Enter += new System.EventHandler(this.txtEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(26, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên tài khoản :";
            // 
            // FrmupdtUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.tSBClose;
            this.ClientSize = new System.Drawing.Size(542, 197);
            this.Controls.Add(this.tSBClose);
            this.Controls.Add(this.tSBSave);
            this.Controls.Add(this.lsvGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tSBAdd);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ckBSActive);
            this.Controls.Add(this.txtPassCofirm);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(558, 235);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(558, 235);
            this.Name = "FrmupdtUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " .: Tài khoản";
            this.Load += new System.EventHandler(this.FrmupdtUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.CheckBox ckBSActive;
        private System.Windows.Forms.TextBox txtPassCofirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lsvGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button tSBClose;
        private System.Windows.Forms.Button tSBSave;
        private System.Windows.Forms.Button tSBAdd;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}