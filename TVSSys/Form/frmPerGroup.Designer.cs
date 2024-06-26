namespace TVSSys
{
    partial class frmPerGroup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerGroup));
            this.tvwUser = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.tSBClose = new System.Windows.Forms.Button();
            this.cMSTreeview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmtAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmtEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmtDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmtStep = new System.Windows.Forms.ToolStripSeparator();
            this.tsmtStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tvWPerGroup = new System.Windows.Forms.TreeView();
            this.cMSTreeview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvwUser
            // 
            this.tvwUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvwUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvwUser.FullRowSelect = true;
            this.tvwUser.ImageIndex = 1;
            this.tvwUser.ImageList = this.imageList1;
            this.tvwUser.Indent = 26;
            this.tvwUser.ItemHeight = 22;
            this.tvwUser.Location = new System.Drawing.Point(6, 6);
            this.tvwUser.Name = "tvwUser";
            this.tvwUser.SelectedImageIndex = 1;
            this.tvwUser.Size = new System.Drawing.Size(260, 475);
            this.tvwUser.TabIndex = 0;
            this.tvwUser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwUser_AfterSelect);
            this.tvwUser.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwUser_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Group.png");
            this.imageList1.Images.SetKeyName(1, "User.png");
            this.imageList1.Images.SetKeyName(2, "UserOff.png");
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(272, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Ghi nhận";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(313, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 61;
            // 
            // LblName
            // 
            this.LblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.ForeColor = System.Drawing.Color.Red;
            this.LblName.Location = new System.Drawing.Point(366, 460);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(41, 15);
            this.LblName.TabIndex = 62;
            this.LblName.Text = "label2";
            // 
            // tSBClose
            // 
            this.tSBClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tSBClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tSBClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tSBClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSBClose.Location = new System.Drawing.Point(780, 452);
            this.tSBClose.Name = "tSBClose";
            this.tSBClose.Size = new System.Drawing.Size(90, 30);
            this.tSBClose.TabIndex = 63;
            this.tSBClose.Text = "Th&oát";
            this.tSBClose.UseVisualStyleBackColor = true;
            this.tSBClose.Click += new System.EventHandler(this.tSBClose_Click);
            // 
            // cMSTreeview
            // 
            this.cMSTreeview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmtAdd,
            this.tsmtEdit,
            this.tsmtDelete,
            this.tsmtStep,
            this.tsmtStatus});
            this.cMSTreeview.Name = "cMSTreeview";
            this.cMSTreeview.Size = new System.Drawing.Size(190, 98);
            // 
            // tsmtAdd
            // 
            this.tsmtAdd.Name = "tsmtAdd";
            this.tsmtAdd.Size = new System.Drawing.Size(189, 22);
            this.tsmtAdd.Text = "Thêm mới";
            this.tsmtAdd.Click += new System.EventHandler(this.tsmtAdd_Click);
            // 
            // tsmtEdit
            // 
            this.tsmtEdit.Name = "tsmtEdit";
            this.tsmtEdit.Size = new System.Drawing.Size(189, 22);
            this.tsmtEdit.Text = "Sửa";
            this.tsmtEdit.Click += new System.EventHandler(this.tsmtEdit_Click);
            // 
            // tsmtDelete
            // 
            this.tsmtDelete.Name = "tsmtDelete";
            this.tsmtDelete.Size = new System.Drawing.Size(189, 22);
            this.tsmtDelete.Text = "Xoá";
            this.tsmtDelete.Click += new System.EventHandler(this.tsmtDelete_Click);
            // 
            // tsmtStep
            // 
            this.tsmtStep.Name = "tsmtStep";
            this.tsmtStep.Size = new System.Drawing.Size(186, 6);
            // 
            // tsmtStatus
            // 
            this.tsmtStatus.Name = "tsmtStatus";
            this.tsmtStatus.Size = new System.Drawing.Size(189, 22);
            this.tsmtStatus.Text = "Thiết lập lại trạng thái";
            this.tsmtStatus.Click += new System.EventHandler(this.tsmtStatus_Click);
            // 
            // tvWPerGroup
            // 
            this.tvWPerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvWPerGroup.CheckBoxes = true;
            this.tvWPerGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvWPerGroup.FullRowSelect = true;
            this.tvWPerGroup.Indent = 26;
            this.tvWPerGroup.ItemHeight = 22;
            this.tvWPerGroup.Location = new System.Drawing.Point(271, 6);
            this.tvWPerGroup.Name = "tvWPerGroup";
            this.tvWPerGroup.Size = new System.Drawing.Size(599, 441);
            this.tvWPerGroup.TabIndex = 64;
            this.tvWPerGroup.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWPerGroup_NodeMouseClick);
            // 
            // frmPerGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(876, 487);
            this.ControlBox = false;
            this.Controls.Add(this.tvWPerGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvwUser);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tSBClose);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPerGroup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tham số hệ thống";
            this.Load += new System.EventHandler(this.frmPer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPer_KeyDown);
            this.cMSTreeview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvwUser;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Button tSBClose;
        private System.Windows.Forms.ContextMenuStrip cMSTreeview;
        private System.Windows.Forms.ToolStripMenuItem tsmtAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmtEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmtDelete;
        private System.Windows.Forms.TreeView tvWPerGroup;
        private System.Windows.Forms.ToolStripSeparator tsmtStep;
        private System.Windows.Forms.ToolStripMenuItem tsmtStatus;

    }
}