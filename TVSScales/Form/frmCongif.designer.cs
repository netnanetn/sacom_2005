namespace TVSMain
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.btnAllExit = new System.Windows.Forms.Button();
            this.btnAllUpdate = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtStartNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtMaxNumber = new System.Windows.Forms.TextBox();
            this.cbbStopBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbDataBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbParity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbPortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCodeID = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbbPrintBillDefault = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbbPrintBill88 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.chkAutobackup = new System.Windows.Forms.CheckBox();
            this.cbbRepType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbbUnit = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkRepPrintView = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtServerPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.camera2Combo = new System.Windows.Forms.ComboBox();
            this.camera1Combo = new System.Windows.Forms.ComboBox();
            this.cbbRepType2 = new System.Windows.Forms.ComboBox();
            this.tabPage1.SuspendLayout();
            this.tabCodeID.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAllExit
            // 
            this.btnAllExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAllExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAllExit.Image = global::TVSScales.Properties.Resources.Exit1;
            this.btnAllExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllExit.Location = new System.Drawing.Point(345, 225);
            this.btnAllExit.Name = "btnAllExit";
            this.btnAllExit.Size = new System.Drawing.Size(130, 35);
            this.btnAllExit.TabIndex = 1;
            this.btnAllExit.Text = "Th&oát   [ ESC ]";
            this.btnAllExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllExit.UseVisualStyleBackColor = true;
            this.btnAllExit.Click += new System.EventHandler(this.btnAllExit_Click);
            // 
            // btnAllUpdate
            // 
            this.btnAllUpdate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAllUpdate.Image = global::TVSScales.Properties.Resources.Save;
            this.btnAllUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllUpdate.Location = new System.Drawing.Point(209, 225);
            this.btnAllUpdate.Name = "btnAllUpdate";
            this.btnAllUpdate.Size = new System.Drawing.Size(130, 35);
            this.btnAllUpdate.TabIndex = 2;
            this.btnAllUpdate.Text = "Cập nhật   [ F4 ]";
            this.btnAllUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllUpdate.UseVisualStyleBackColor = true;
            this.btnAllUpdate.Click += new System.EventHandler(this.btnAllUpdate_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.TxtStartNumber);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TxtMaxNumber);
            this.tabPage1.Controls.Add(this.cbbStopBits);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbbDataBits);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cbbParity);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbbBaudRate);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbbPortName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 180);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cấu hình cổng COM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(222, 134);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Số ký tự đầu :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtStartNumber
            // 
            this.TxtStartNumber.Location = new System.Drawing.Point(314, 134);
            this.TxtStartNumber.Name = "TxtStartNumber";
            this.TxtStartNumber.Size = new System.Drawing.Size(87, 21);
            this.TxtStartNumber.TabIndex = 24;
            this.TxtStartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtStartNumber.Leave += new System.EventHandler(this.txtLeave);
            this.TxtStartNumber.Enter += new System.EventHandler(this.txtEnter);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(31, 134);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Số ký tự Max :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtMaxNumber
            // 
            this.TxtMaxNumber.Location = new System.Drawing.Point(123, 134);
            this.TxtMaxNumber.Name = "TxtMaxNumber";
            this.TxtMaxNumber.Size = new System.Drawing.Size(87, 21);
            this.TxtMaxNumber.TabIndex = 22;
            this.TxtMaxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMaxNumber.Leave += new System.EventHandler(this.txtLeave);
            this.TxtMaxNumber.Enter += new System.EventHandler(this.txtEnter);
            // 
            // cbbStopBits
            // 
            this.cbbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStopBits.FormattingEnabled = true;
            this.cbbStopBits.Location = new System.Drawing.Point(314, 104);
            this.cbbStopBits.Name = "cbbStopBits";
            this.cbbStopBits.Size = new System.Drawing.Size(87, 23);
            this.cbbStopBits.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(254, 107);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Dừng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbDataBits
            // 
            this.cbbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDataBits.FormattingEnabled = true;
            this.cbbDataBits.Location = new System.Drawing.Point(314, 66);
            this.cbbDataBits.Name = "cbbDataBits";
            this.cbbDataBits.Size = new System.Drawing.Size(87, 23);
            this.cbbDataBits.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(254, 69);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Dữ liệu :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbParity
            // 
            this.cbbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbParity.FormattingEnabled = true;
            this.cbbParity.Location = new System.Drawing.Point(123, 101);
            this.cbbParity.Name = "cbbParity";
            this.cbbParity.Size = new System.Drawing.Size(87, 23);
            this.cbbParity.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(45, 101);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Chẵn lẻ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbBaudRate
            // 
            this.cbbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBaudRate.FormattingEnabled = true;
            this.cbbBaudRate.Location = new System.Drawing.Point(123, 63);
            this.cbbBaudRate.Name = "cbbBaudRate";
            this.cbbBaudRate.Size = new System.Drawing.Size(87, 23);
            this.cbbBaudRate.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(63, 66);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tần số :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbPortName
            // 
            this.cbbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPortName.FormattingEnabled = true;
            this.cbbPortName.Location = new System.Drawing.Point(123, 25);
            this.cbbPortName.Name = "cbbPortName";
            this.cbbPortName.Size = new System.Drawing.Size(87, 23);
            this.cbbPortName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(63, 28);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cổng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabCodeID
            // 
            this.tabCodeID.Controls.Add(this.tabPage3);
            this.tabCodeID.Controls.Add(this.tabPage1);
            this.tabCodeID.Controls.Add(this.tabPage2);
            this.tabCodeID.Location = new System.Drawing.Point(11, 11);
            this.tabCodeID.Name = "tabCodeID";
            this.tabCodeID.SelectedIndex = 0;
            this.tabCodeID.Size = new System.Drawing.Size(464, 208);
            this.tabCodeID.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbbRepType2);
            this.tabPage3.Controls.Add(this.cbbPrintBillDefault);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.cbbPrintBill88);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.txtCount);
            this.tabPage3.Controls.Add(this.chkAutobackup);
            this.tabPage3.Controls.Add(this.cbbRepType);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.cbbUnit);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.chkRepPrintView);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(456, 180);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cấu hình chung";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbbPrintBillDefault
            // 
            this.cbbPrintBillDefault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPrintBillDefault.FormattingEnabled = true;
            this.cbbPrintBillDefault.Location = new System.Drawing.Point(188, 116);
            this.cbbPrintBillDefault.Name = "cbbPrintBillDefault";
            this.cbbPrintBillDefault.Size = new System.Drawing.Size(250, 23);
            this.cbbPrintBillDefault.TabIndex = 99;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(32, 120);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label17.Size = new System.Drawing.Size(153, 15);
            this.label17.TabIndex = 98;
            this.label17.Text = "Thiết lập máy in mặc định :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbPrintBill88
            // 
            this.cbbPrintBill88.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPrintBill88.FormattingEnabled = true;
            this.cbbPrintBill88.Location = new System.Drawing.Point(188, 85);
            this.cbbPrintBill88.Name = "cbbPrintBill88";
            this.cbbPrintBill88.Size = new System.Drawing.Size(250, 23);
            this.cbbPrintBill88.TabIndex = 97;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(46, 88);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label16.Size = new System.Drawing.Size(139, 15);
            this.label16.TabIndex = 96;
            this.label16.Text = "Thiết lập máy in khổ 88 :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label15.Location = new System.Drawing.Point(315, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 15);
            this.label15.TabIndex = 94;
            this.label15.Text = "Số file lưu : ";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(392, 147);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(46, 21);
            this.txtCount.TabIndex = 93;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkAutobackup
            // 
            this.chkAutobackup.AutoSize = true;
            this.chkAutobackup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutobackup.Location = new System.Drawing.Point(32, 149);
            this.chkAutobackup.Name = "chkAutobackup";
            this.chkAutobackup.Size = new System.Drawing.Size(199, 19);
            this.chkAutobackup.TabIndex = 92;
            this.chkAutobackup.Text = "Tự động sao lưu khi khởi động";
            this.chkAutobackup.UseVisualStyleBackColor = true;
            // 
            // cbbRepType
            // 
            this.cbbRepType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRepType.FormattingEnabled = true;
            this.cbbRepType.Location = new System.Drawing.Point(188, 53);
            this.cbbRepType.Name = "cbbRepType";
            this.cbbRepType.Size = new System.Drawing.Size(120, 23);
            this.cbbRepType.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(86, 56);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "Khổ phiếu cân :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbUnit
            // 
            this.cbbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUnit.FormattingEnabled = true;
            this.cbbUnit.Location = new System.Drawing.Point(392, 20);
            this.cbbUnit.Name = "cbbUnit";
            this.cbbUnit.Size = new System.Drawing.Size(46, 23);
            this.cbbUnit.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(306, 22);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(82, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "Đơn vị cân :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkRepPrintView
            // 
            this.chkRepPrintView.AutoSize = true;
            this.chkRepPrintView.Location = new System.Drawing.Point(188, 23);
            this.chkRepPrintView.Name = "chkRepPrintView";
            this.chkRepPrintView.Size = new System.Drawing.Size(115, 19);
            this.chkRepPrintView.TabIndex = 8;
            this.chkRepPrintView.Text = "Xem trước khi In";
            this.chkRepPrintView.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(103, 21);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(82, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "In phiếu :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.TxtServerPath);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.camera2Combo);
            this.tabPage2.Controls.Add(this.camera1Combo);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(456, 180);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cấu hình Camera";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 110);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(118, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Thư mục lưu ảnh :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtServerPath
            // 
            this.TxtServerPath.Location = new System.Drawing.Point(127, 110);
            this.TxtServerPath.Name = "TxtServerPath";
            this.TxtServerPath.Size = new System.Drawing.Size(307, 21);
            this.TxtServerPath.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(42, 69);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Camera 02 :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(42, 30);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Camera 01 :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // camera2Combo
            // 
            this.camera2Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camera2Combo.FormattingEnabled = true;
            this.camera2Combo.Location = new System.Drawing.Point(127, 69);
            this.camera2Combo.Name = "camera2Combo";
            this.camera2Combo.Size = new System.Drawing.Size(307, 23);
            this.camera2Combo.TabIndex = 5;
            // 
            // camera1Combo
            // 
            this.camera1Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camera1Combo.FormattingEnabled = true;
            this.camera1Combo.Location = new System.Drawing.Point(127, 30);
            this.camera1Combo.Name = "camera1Combo";
            this.camera1Combo.Size = new System.Drawing.Size(307, 23);
            this.camera1Combo.TabIndex = 4;
            // 
            // cbbRepType2
            // 
            this.cbbRepType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRepType2.FormattingEnabled = true;
            this.cbbRepType2.Location = new System.Drawing.Point(318, 53);
            this.cbbRepType2.Name = "cbbRepType2";
            this.cbbRepType2.Size = new System.Drawing.Size(120, 23);
            this.cbbRepType2.TabIndex = 100;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAllExit;
            this.ClientSize = new System.Drawing.Size(484, 272);
            this.ControlBox = false;
            this.Controls.Add(this.btnAllUpdate);
            this.Controls.Add(this.btnAllExit);
            this.Controls.Add(this.tabCodeID);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 311);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 311);
            this.Name = "frmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " .: Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfig_KeyDown);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabCodeID.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllExit;
        private System.Windows.Forms.Button btnAllUpdate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbbPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabCodeID;
        private System.Windows.Forms.ComboBox cbbStopBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbDataBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbParity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtMaxNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtStartNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtServerPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox camera2Combo;
        private System.Windows.Forms.ComboBox camera1Combo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkRepPrintView;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbbUnit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbRepType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbbPrintBillDefault;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbbPrintBill88;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.CheckBox chkAutobackup;
        private System.Windows.Forms.ComboBox cbbRepType2;

    }
}