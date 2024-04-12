namespace TVSSys
{
    partial class FrmGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroup));
            this.tSBClose = new System.Windows.Forms.Button();
            this.tSBSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tSBAdd = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.ckBSActive = new System.Windows.Forms.CheckBox();
            this.txtGName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tSBClose
            // 
            this.tSBClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tSBClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tSBClose.Location = new System.Drawing.Point(363, 79);
            this.tSBClose.Name = "tSBClose";
            this.tSBClose.Size = new System.Drawing.Size(80, 28);
            this.tSBClose.TabIndex = 27;
            this.tSBClose.Text = "Th&oát";
            this.tSBClose.UseVisualStyleBackColor = true;
            this.tSBClose.Click += new System.EventHandler(this.tSBClose_Click);
            // 
            // tSBSave
            // 
            this.tSBSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tSBSave.Location = new System.Drawing.Point(277, 79);
            this.tSBSave.Name = "tSBSave";
            this.tSBSave.Size = new System.Drawing.Size(80, 28);
            this.tSBSave.TabIndex = 26;
            this.tSBSave.Text = "&Ghi nhận";
            this.tSBSave.UseVisualStyleBackColor = true;
            this.tSBSave.Click += new System.EventHandler(this.tSBSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Mô tả :";
            // 
            // tSBAdd
            // 
            this.tSBAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tSBAdd.Location = new System.Drawing.Point(191, 79);
            this.tSBAdd.Name = "tSBAdd";
            this.tSBAdd.Size = new System.Drawing.Size(80, 28);
            this.tSBAdd.TabIndex = 25;
            this.tSBAdd.Text = "&Thêm mới";
            this.tSBAdd.UseVisualStyleBackColor = true;
            this.tSBAdd.Click += new System.EventHandler(this.tSBAdd_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(83, 45);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(360, 24);
            this.txtNote.TabIndex = 2;
            this.txtNote.Leave += new System.EventHandler(this.txtLeave);
            this.txtNote.Enter += new System.EventHandler(this.txtEnter);
            // 
            // ckBSActive
            // 
            this.ckBSActive.AutoSize = true;
            this.ckBSActive.Location = new System.Drawing.Point(241, 18);
            this.ckBSActive.Name = "ckBSActive";
            this.ckBSActive.Size = new System.Drawing.Size(77, 19);
            this.ckBSActive.TabIndex = 4;
            this.ckBSActive.Text = "Kích hoạt";
            this.ckBSActive.UseVisualStyleBackColor = true;
            // 
            // txtGName
            // 
            this.txtGName.Location = new System.Drawing.Point(83, 16);
            this.txtGName.Name = "txtGName";
            this.txtGName.Size = new System.Drawing.Size(152, 21);
            this.txtGName.TabIndex = 1;
            this.txtGName.Leave += new System.EventHandler(this.txtLeave);
            this.txtGName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGName_KeyPress);
            this.txtGName.Enter += new System.EventHandler(this.txtEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tên nhóm :";
            // 
            // FrmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(449, 114);
            this.Controls.Add(this.tSBClose);
            this.Controls.Add(this.tSBSave);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tSBAdd);
            this.Controls.Add(this.txtGName);
            this.Controls.Add(this.ckBSActive);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(465, 152);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(465, 152);
            this.Name = "FrmGroup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " .: Nhóm người dùng";
            this.Load += new System.EventHandler(this.FrmGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.CheckBox ckBSActive;
        public System.Windows.Forms.TextBox txtGName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button tSBClose;
        private System.Windows.Forms.Button tSBSave;
        private System.Windows.Forms.Button tSBAdd;
    }
}