namespace TVSMain
{
    partial class frmPictures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPictures));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ptbIn1 = new System.Windows.Forms.PictureBox();
            this.ptbIn = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAllExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIn)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ptbIn1);
            this.groupBox1.Controls.Add(this.ptbIn);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 328);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // ptbIn1
            // 
            this.ptbIn1.BackColor = System.Drawing.Color.Transparent;
            this.ptbIn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbIn1.Location = new System.Drawing.Point(416, 17);
            this.ptbIn1.Name = "ptbIn1";
            this.ptbIn1.Size = new System.Drawing.Size(400, 300);
            this.ptbIn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbIn1.TabIndex = 1;
            this.ptbIn1.TabStop = false;
            // 
            // ptbIn
            // 
            this.ptbIn.BackColor = System.Drawing.Color.Transparent;
            this.ptbIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbIn.Location = new System.Drawing.Point(10, 17);
            this.ptbIn.Name = "ptbIn";
            this.ptbIn.Size = new System.Drawing.Size(400, 300);
            this.ptbIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbIn.TabIndex = 0;
            this.ptbIn.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDelete.Image = global::TVSScales.Properties.Resources.Delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(550, 22);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 35);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa ảnh  [ F4 ]";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAllExit
            // 
            this.btnAllExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAllExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAllExit.Image = global::TVSScales.Properties.Resources.Exit1;
            this.btnAllExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllExit.Location = new System.Drawing.Point(686, 22);
            this.btnAllExit.Name = "btnAllExit";
            this.btnAllExit.Size = new System.Drawing.Size(130, 35);
            this.btnAllExit.TabIndex = 3;
            this.btnAllExit.Text = "Th&oát   [ ESC ]";
            this.btnAllExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllExit.UseVisualStyleBackColor = true;
            this.btnAllExit.Click += new System.EventHandler(this.btnAllExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAllExit);
            this.groupBox2.Location = new System.Drawing.Point(8, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(827, 73);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // frmPictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAllExit;
            this.ClientSize = new System.Drawing.Size(844, 415);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(860, 453);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 453);
            this.Name = "frmPictures";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XEM ẢNH";
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbIn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIn)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox ptbIn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAllExit;
        private System.Windows.Forms.PictureBox ptbIn1;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}