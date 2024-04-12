namespace TVSSys
{
    partial class FrmChangePW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangePW));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPWOld = new System.Windows.Forms.TextBox();
            this.txtPWNew = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPWRepeat = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu mới :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPWOld
            // 
            this.txtPWOld.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPWOld.Location = new System.Drawing.Point(130, 24);
            this.txtPWOld.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPWOld.Name = "txtPWOld";
            this.txtPWOld.PasswordChar = '*';
            this.txtPWOld.Size = new System.Drawing.Size(197, 21);
            this.txtPWOld.TabIndex = 1;
            this.txtPWOld.UseSystemPasswordChar = true;
            this.txtPWOld.Leave += new System.EventHandler(this.txtLeave);
            this.txtPWOld.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPWOld_KeyPress);
            this.txtPWOld.Enter += new System.EventHandler(this.txtEnter);
            // 
            // txtPWNew
            // 
            this.txtPWNew.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPWNew.Location = new System.Drawing.Point(130, 51);
            this.txtPWNew.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPWNew.Name = "txtPWNew";
            this.txtPWNew.PasswordChar = '*';
            this.txtPWNew.Size = new System.Drawing.Size(197, 21);
            this.txtPWNew.TabIndex = 2;
            this.txtPWNew.UseSystemPasswordChar = true;
            this.txtPWNew.Leave += new System.EventHandler(this.txtLeave);
            this.txtPWNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPWNew_KeyPress);
            this.txtPWNew.Enter += new System.EventHandler(this.txtEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhắc lại mật khẩu :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPWRepeat
            // 
            this.txtPWRepeat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPWRepeat.Location = new System.Drawing.Point(130, 78);
            this.txtPWRepeat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPWRepeat.Name = "txtPWRepeat";
            this.txtPWRepeat.PasswordChar = '*';
            this.txtPWRepeat.Size = new System.Drawing.Size(197, 21);
            this.txtPWRepeat.TabIndex = 3;
            this.txtPWRepeat.UseSystemPasswordChar = true;
            this.txtPWRepeat.Leave += new System.EventHandler(this.txtLeave);
            this.txtPWRepeat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPWRepeat_KeyPress);
            this.txtPWRepeat.Enter += new System.EventHandler(this.txtEnter);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.Transparent;
            this.cmdSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmdSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(163, 119);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(80, 28);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "&Ghi nhận";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.Transparent;
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmdExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(247, 119);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(80, 28);
            this.cmdExit.TabIndex = 5;
            this.cmdExit.Text = "Th&oát";
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // FrmChangePW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(337, 156);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtPWRepeat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPWNew);
            this.Controls.Add(this.txtPWOld);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(353, 190);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(353, 190);
            this.Name = "FrmChangePW";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " .: Thay đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPWOld;
        private System.Windows.Forms.TextBox txtPWNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPWRepeat;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdExit;
    }
}