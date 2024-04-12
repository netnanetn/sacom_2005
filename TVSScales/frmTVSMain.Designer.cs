namespace TVSMain
{
    partial class TVSMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TVSMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsMnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuOnwer = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuConfigDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuDir7 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir8 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDir9 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuScales = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuScalesSys = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuScalesSys1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuReport0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHotlineSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTeamViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMnuRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuIntroduction = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.sslCompany = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbScales = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.MnuDir10 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMnuSystem,
            this.MnuDir,
            this.MnuScales,
            this.MnuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(974, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsMnuSystem
            // 
            this.tsMnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuLogin,
            this.toolStripMenuItem2,
            this.MnuAccount,
            this.MnuChangePass,
            this.toolStripMenuItem3,
            this.MnuOnwer,
            this.MnuConfig,
            this.MnuConfigDataBase,
            this.toolStripMenuItem4,
            this.MnuExitApp});
            this.tsMnuSystem.Name = "tsMnuSystem";
            this.tsMnuSystem.Size = new System.Drawing.Size(69, 20);
            this.tsMnuSystem.Text = "&Hệ thống";
            // 
            // MnuLogin
            // 
            this.MnuLogin.Image = global::TVSScales.Properties.Resources.Login;
            this.MnuLogin.Name = "MnuLogin";
            this.MnuLogin.Size = new System.Drawing.Size(203, 22);
            this.MnuLogin.Text = "Đăng nhập hệ thống";
            this.MnuLogin.Click += new System.EventHandler(this.tvsLogin_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
            // 
            // MnuAccount
            // 
            this.MnuAccount.Image = global::TVSScales.Properties.Resources.acc;
            this.MnuAccount.Name = "MnuAccount";
            this.MnuAccount.Size = new System.Drawing.Size(203, 22);
            this.MnuAccount.Text = "Tài khoản người dùng";
            this.MnuAccount.Click += new System.EventHandler(this.tvsAccount_Click);
            // 
            // MnuChangePass
            // 
            this.MnuChangePass.Image = ((System.Drawing.Image)(resources.GetObject("MnuChangePass.Image")));
            this.MnuChangePass.Name = "MnuChangePass";
            this.MnuChangePass.Size = new System.Drawing.Size(203, 22);
            this.MnuChangePass.Text = "Thay đổi mật khẩu";
            this.MnuChangePass.Click += new System.EventHandler(this.tvsChangePass_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(200, 6);
            // 
            // MnuOnwer
            // 
            this.MnuOnwer.Image = global::TVSScales.Properties.Resources._45;
            this.MnuOnwer.Name = "MnuOnwer";
            this.MnuOnwer.Size = new System.Drawing.Size(203, 22);
            this.MnuOnwer.Text = "Đơn vị sử dụng";
            this.MnuOnwer.Click += new System.EventHandler(this.tvsOnwer_Click);
            // 
            // MnuConfig
            // 
            this.MnuConfig.Image = ((System.Drawing.Image)(resources.GetObject("MnuConfig.Image")));
            this.MnuConfig.Name = "MnuConfig";
            this.MnuConfig.Size = new System.Drawing.Size(203, 22);
            this.MnuConfig.Text = "Cấu hình hệ thống";
            this.MnuConfig.Click += new System.EventHandler(this.MnuConfig_Click);
            // 
            // MnuConfigDataBase
            // 
            this.MnuConfigDataBase.Image = ((System.Drawing.Image)(resources.GetObject("MnuConfigDataBase.Image")));
            this.MnuConfigDataBase.Name = "MnuConfigDataBase";
            this.MnuConfigDataBase.Size = new System.Drawing.Size(203, 22);
            this.MnuConfigDataBase.Text = "Cấu hình Cơ sở dữ liệu";
            this.MnuConfigDataBase.Click += new System.EventHandler(this.tvsConfig_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(200, 6);
            // 
            // MnuExitApp
            // 
            this.MnuExitApp.Image = global::TVSScales.Properties.Resources.Exit1;
            this.MnuExitApp.Name = "MnuExitApp";
            this.MnuExitApp.Size = new System.Drawing.Size(203, 22);
            this.MnuExitApp.Text = "Thoát khỏi hệ thống";
            this.MnuExitApp.Click += new System.EventHandler(this.tvsExit_Click);
            // 
            // MnuDir
            // 
            this.MnuDir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuDir0,
            this.MnuDir1,
            this.MnuDir2,
            this.MnuDir3,
            this.MnuDir4,
            this.MnuDir5,
            this.MnuDir6,
            this.toolStripMenuItem5,
            this.MnuDir7,
            this.MnuDir8,
            this.MnuDir9,
            this.MnuDir10});
            this.MnuDir.Name = "MnuDir";
            this.MnuDir.Size = new System.Drawing.Size(68, 20);
            this.MnuDir.Text = "&Khai báo";
            // 
            // MnuDir0
            // 
            this.MnuDir0.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir0.Image")));
            this.MnuDir0.Name = "MnuDir0";
            this.MnuDir0.Size = new System.Drawing.Size(170, 22);
            this.MnuDir0.Text = "Kích thước";
            this.MnuDir0.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // MnuDir1
            // 
            this.MnuDir1.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir1.Image")));
            this.MnuDir1.Name = "MnuDir1";
            this.MnuDir1.Size = new System.Drawing.Size(170, 22);
            this.MnuDir1.Text = "Tên sản phẩm";
            this.MnuDir1.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // MnuDir2
            // 
            this.MnuDir2.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir2.Image")));
            this.MnuDir2.Name = "MnuDir2";
            this.MnuDir2.Size = new System.Drawing.Size(170, 22);
            this.MnuDir2.Text = "Khối lượng Bobin";
            this.MnuDir2.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // MnuDir3
            // 
            this.MnuDir3.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir3.Image")));
            this.MnuDir3.Name = "MnuDir3";
            this.MnuDir3.Size = new System.Drawing.Size(170, 22);
            this.MnuDir3.Text = "Máy sản xuất";
            this.MnuDir3.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // MnuDir4
            // 
            this.MnuDir4.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir4.Image")));
            this.MnuDir4.Name = "MnuDir4";
            this.MnuDir4.Size = new System.Drawing.Size(170, 22);
            this.MnuDir4.Text = "Dây chuyền";
            this.MnuDir4.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // MnuDir5
            // 
            this.MnuDir5.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir5.Image")));
            this.MnuDir5.Name = "MnuDir5";
            this.MnuDir5.Size = new System.Drawing.Size(170, 22);
            this.MnuDir5.Text = "Cấp nhiệt độ";
            this.MnuDir5.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // MnuDir6
            // 
            this.MnuDir6.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir6.Image")));
            this.MnuDir6.Name = "MnuDir6";
            this.MnuDir6.Size = new System.Drawing.Size(170, 22);
            this.MnuDir6.Text = "Tiêu chuẩn";
            this.MnuDir6.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(167, 6);
            // 
            // MnuDir7
            // 
            this.MnuDir7.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir7.Image")));
            this.MnuDir7.Name = "MnuDir7";
            this.MnuDir7.Size = new System.Drawing.Size(170, 22);
            this.MnuDir7.Text = "Bề rộng";
            this.MnuDir7.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // MnuDir8
            // 
            this.MnuDir8.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir8.Image")));
            this.MnuDir8.Name = "MnuDir8";
            this.MnuDir8.Size = new System.Drawing.Size(170, 22);
            this.MnuDir8.Text = "Bề dày";
            this.MnuDir8.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // MnuDir9
            // 
            this.MnuDir9.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir9.Image")));
            this.MnuDir9.Name = "MnuDir9";
            this.MnuDir9.Size = new System.Drawing.Size(170, 22);
            this.MnuDir9.Text = "Bán kính góc";
            this.MnuDir9.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // MnuScales
            // 
            this.MnuScales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuScalesSys,
            this.MnuScalesSys1,
            this.toolStripMenuItem1,
            this.MnuReport,
            this.MnuReport0});
            this.MnuScales.Name = "MnuScales";
            this.MnuScales.Size = new System.Drawing.Size(71, 20);
            this.MnuScales.Text = "&Trạm cân";
            // 
            // MnuScalesSys
            // 
            this.MnuScalesSys.Image = ((System.Drawing.Image)(resources.GetObject("MnuScalesSys.Image")));
            this.MnuScalesSys.Name = "MnuScalesSys";
            this.MnuScalesSys.Size = new System.Drawing.Size(143, 22);
            this.MnuScalesSys.Text = "Cân dây tròn";
            this.MnuScalesSys.Click += new System.EventHandler(this.MnuScales_Click);
            // 
            // MnuScalesSys1
            // 
            this.MnuScalesSys1.Image = ((System.Drawing.Image)(resources.GetObject("MnuScalesSys1.Image")));
            this.MnuScalesSys1.Name = "MnuScalesSys1";
            this.MnuScalesSys1.Size = new System.Drawing.Size(143, 22);
            this.MnuScalesSys1.Text = "Cân dây dẹp";
            this.MnuScalesSys1.Click += new System.EventHandler(this.MnuScalesSys1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // MnuReport
            // 
            this.MnuReport.Image = ((System.Drawing.Image)(resources.GetObject("MnuReport.Image")));
            this.MnuReport.Name = "MnuReport";
            this.MnuReport.Size = new System.Drawing.Size(143, 22);
            this.MnuReport.Text = "Báo cáo";
            this.MnuReport.Click += new System.EventHandler(this.MnuReport_Click);
            // 
            // MnuReport0
            // 
            this.MnuReport0.Image = ((System.Drawing.Image)(resources.GetObject("MnuReport0.Image")));
            this.MnuReport0.Name = "MnuReport0";
            this.MnuReport0.Size = new System.Drawing.Size(143, 22);
            this.MnuReport0.Text = "Kiểm kê";
            this.MnuReport0.Click += new System.EventHandler(this.MnuReport0_Click);
            // 
            // MnuHelp
            // 
            this.MnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuHotlineSupport,
            this.MnuTeamViewer,
            this.toolStripSeparator9,
            this.tsMnuRegister,
            this.toolStripMenuItem9,
            this.MnuIntroduction});
            this.MnuHelp.Name = "MnuHelp";
            this.MnuHelp.Size = new System.Drawing.Size(65, 20);
            this.MnuHelp.Text = "Trợ giúp";
            // 
            // MnuHotlineSupport
            // 
            this.MnuHotlineSupport.Image = ((System.Drawing.Image)(resources.GetObject("MnuHotlineSupport.Image")));
            this.MnuHotlineSupport.Name = "MnuHotlineSupport";
            this.MnuHotlineSupport.Size = new System.Drawing.Size(200, 22);
            this.MnuHotlineSupport.Text = "Hỗ trợ trực tuyến";
            this.MnuHotlineSupport.Click += new System.EventHandler(this.MnuHotlineSupport_Click);
            // 
            // MnuTeamViewer
            // 
            this.MnuTeamViewer.Image = global::TVSScales.Properties.Resources.TV;
            this.MnuTeamViewer.Name = "MnuTeamViewer";
            this.MnuTeamViewer.Size = new System.Drawing.Size(200, 22);
            this.MnuTeamViewer.Text = "Hỗ trợ từ xa";
            this.MnuTeamViewer.Click += new System.EventHandler(this.MnuTeamViewer_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(197, 6);
            // 
            // tsMnuRegister
            // 
            this.tsMnuRegister.Image = global::TVSScales.Properties.Resources.Key;
            this.tsMnuRegister.Name = "tsMnuRegister";
            this.tsMnuRegister.Size = new System.Drawing.Size(200, 22);
            this.tsMnuRegister.Text = "Đăng ký chương trình";
            this.tsMnuRegister.Click += new System.EventHandler(this.tsMnuRegister_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(197, 6);
            // 
            // MnuIntroduction
            // 
            this.MnuIntroduction.Image = global::TVSScales.Properties.Resources.about;
            this.MnuIntroduction.Name = "MnuIntroduction";
            this.MnuIntroduction.Size = new System.Drawing.Size(200, 22);
            this.MnuIntroduction.Text = "Giới thiệu chương trình";
            this.MnuIntroduction.Click += new System.EventHandler(this.MnuIntroduction_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslCompany,
            this.toolStripStatusLabel1,
            this.lblName});
            this.statusStrip.Location = new System.Drawing.Point(0, 557);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(974, 25);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // sslCompany
            // 
            this.sslCompany.AutoSize = false;
            this.sslCompany.Name = "sslCompany";
            this.sslCompany.Size = new System.Drawing.Size(350, 20);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(107, 20);
            this.toolStripStatusLabel1.Text = "Người đăng nhập:";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 20);
            this.lblName.Text = "Admin";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 561);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Copyright by TRUNGVIET SOFTWARE";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbScales,
            this.toolStripSeparator1,
            this.tsBtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(100, 533);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Visible = false;
            // 
            // tsbScales
            // 
            this.tsbScales.AutoSize = false;
            this.tsbScales.Image = ((System.Drawing.Image)(resources.GetObject("tsbScales.Image")));
            this.tsbScales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbScales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScales.Name = "tsbScales";
            this.tsbScales.Size = new System.Drawing.Size(80, 60);
            this.tsbScales.Text = "Cân điện tử";
            this.tsbScales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbScales.ToolTipText = "Kết thúc tất cả công việc đang làm\r\ntrên phần mềm và đóng phần mềm";
            this.tsbScales.Click += new System.EventHandler(this.MnuScales_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(98, 6);
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.AutoSize = false;
            this.tsBtnExit.Image = global::TVSScales.Properties.Resources.Exit;
            this.tsBtnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(80, 60);
            this.tsBtnExit.Text = "Thoát";
            this.tsBtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnExit.ToolTipText = "Kết thúc tất cả công việc đang làm\r\ntrên phần mềm và đóng phần mềm";
            this.tsBtnExit.Click += new System.EventHandler(this.tvsExit_Click);
            // 
            // MnuDir10
            // 
            this.MnuDir10.Image = ((System.Drawing.Image)(resources.GetObject("MnuDir10.Image")));
            this.MnuDir10.Name = "MnuDir10";
            this.MnuDir10.Size = new System.Drawing.Size(170, 22);
            this.MnuDir10.Text = "Đơn vị";
            this.MnuDir10.Click += new System.EventHandler(this.MnuDir_Click);
            // 
            // TVSMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(974, 582);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TVSMain";
            this.Text = "PHẦN MỀM QUẢN LÝ CÂN ĐIỆN TỬ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTVSMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TVSMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmTVSMain_Resize);
            this.ResizeEnd += new System.EventHandler(this.frmTVSMain_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolStripMenuItem tsMnuSystem;
        private System.Windows.Forms.ToolStripMenuItem MnuLogin;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MnuAccount;
        private System.Windows.Forms.ToolStripMenuItem MnuChangePass;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem MnuOnwer;
        private System.Windows.Forms.ToolStripMenuItem MnuConfigDataBase;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem MnuExitApp;
        private System.Windows.Forms.ToolStripMenuItem MnuHelp;
        private System.Windows.Forms.ToolStripMenuItem MnuTeamViewer;
        private System.Windows.Forms.ToolStripMenuItem tsMnuRegister;
        private System.Windows.Forms.ToolStripMenuItem MnuIntroduction;
        private System.Windows.Forms.ToolStripStatusLabel sslCompany;
        private System.Windows.Forms.ToolStripStatusLabel lblName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.ToolStripMenuItem MnuConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem MnuHotlineSupport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem MnuDir;
        private System.Windows.Forms.ToolStripMenuItem MnuDir0;
        private System.Windows.Forms.ToolStripMenuItem MnuDir1;
        private System.Windows.Forms.ToolStripMenuItem MnuDir2;
        private System.Windows.Forms.ToolStripMenuItem MnuScales;
        private System.Windows.Forms.ToolStripButton tsbScales;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MnuDir3;
        private System.Windows.Forms.ToolStripMenuItem MnuScalesSys;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MnuReport;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStripMenuItem MnuDir4;
        private System.Windows.Forms.ToolStripMenuItem MnuDir5;
        private System.Windows.Forms.ToolStripMenuItem MnuDir6;
        private System.Windows.Forms.ToolStripMenuItem MnuScalesSys1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem MnuDir7;
        private System.Windows.Forms.ToolStripMenuItem MnuDir8;
        private System.Windows.Forms.ToolStripMenuItem MnuDir9;
        private System.Windows.Forms.ToolStripMenuItem MnuReport0;
        private System.Windows.Forms.ToolStripMenuItem MnuDir10;
    }
}



