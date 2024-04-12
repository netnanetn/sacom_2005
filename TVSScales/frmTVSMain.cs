using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace TVSMain
{
    public partial class TVSMain : Form
    {
        #region method Decleration
        public string UserName = "", FullName = "",Permission = "";
        #endregion

        public TVSMain()
        {
            InitializeComponent();
        }

        private void CloseAllform()
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
            }
            catch { }
        }

        #region method System
        #region method tvsLogin_Click
        private void tvsLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Hệ thống sẽ thoát khỏi phiên làm việc hiện tại\r\n\r\nBạn có thực sự muốn đổi phiên làm việc không?", "TVS - Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.CloseAllform();
                    TVSSys.frmLogin objLogin = new TVSSys.frmLogin();
                    objLogin.ShowDialog();
                    if (objLogin.OK)
                    {
                        this.UserName = objLogin.UserName;
                        this.FullName = objLogin.FullName;
                        clsPublic objP = new clsPublic();
                        lblName.Text = objLogin.FullName + "   [" + objP.GetServerDateTime().ToString("dd/MM/yyyy HH:mm:ss") + "]";
                        this.SetPermission();
                    }
                }
            }
            catch { }
        }
        #endregion

        #region method tvsChangePass_Click
        private void tvsChangePass_Click(object sender, EventArgs e)
        {
            TVSSys.FrmChangePW objOD = new TVSSys.FrmChangePW();
            objOD.StrUsername = this.UserName;
            objOD.ShowDialog();
        }
        #endregion

        #region method tvsAccount_Click
        private void tvsAccount_Click(object sender, EventArgs e)
        {
            try
            {
                this.CloseAllform();
                TVSSys.frmPerGroup objfrm = new TVSSys.frmPerGroup();
                objfrm.MdiParent = this;
                objfrm.UserName = this.UserName;
                objfrm.Show();
                objfrm.WindowState = FormWindowState.Maximized;
            }
            catch { }

        }
        #endregion

        #region method tvsOnwer_Click
        private void tvsOnwer_Click(object sender, EventArgs e)
        {
            TVSSys.FrmRootCompany objRC = new TVSSys.FrmRootCompany();
            objRC.ShowDialog();
        }
        #endregion

        #region method tvsExit_Click
        private void tvsExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình này không?\r\n\r\nBấm YES để thoát, bấm NO để tiếp tục sủ dụng chương trình", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CloseAllform();
                Application.Exit();
            }
        }
        #endregion

        private void MnuConfig_Click(object sender, EventArgs e)
        {
            try
            {
                CloseAllform();
                frmConfig objRC = new frmConfig();
                objRC.ShowDialog();
                //clsPublic objP = new clsPublic();
                //TVSSys.clsConfigXML objCfig = new TVSSys.clsConfigXML();
                //if (objCfig.GetKey("MenuLeft") != "True") this.toolStrip1.Visible = false;
                //else this.toolStrip1.Visible = true;
            }
            catch { }
        }

        #region method tvsConfig_Click
        private void tvsConfig_Click(object sender, EventArgs e)
        {
            CloseAllform();
            TVSSys.FrmConnectData objRC = new TVSSys.FrmConnectData();
            objRC.ShowDialog();
        }
        #endregion

        #endregion

        #region method Help

        private void MnuHotlineSupport_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("ymsgr:sendim?tvs_jsc");
            }
            catch { }
        }

        
        private void MnuTeamViewer_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("TVQS.exe");
            }
            catch { }
        }

        private void MnuIntroduction_Click(object sender, EventArgs e)
        {
            TVSSys.frmIntro objAbout = new TVSSys.frmIntro();
            objAbout.ShowDialog();
        }

        private void tsMnuRegister_Click(object sender, EventArgs e)
        {
            try
            {
                TVSSys.FrmRegister objRes = new TVSSys.FrmRegister();
                objRes.ShowDialog();
            }
            catch
            {
            }
        }
        #endregion

        private void frmTVSMain_Load(object sender, EventArgs e)
        {
            try
            {
                TVSSys.clsPublic clsP = new TVSSys.clsPublic();
                sslCompany.Text = " .:: " + clsP.getCompanyInfor("ComName").ToUpper() + " ::. ";
                clsPublic objP = new clsPublic();
                lblName.Text = this.FullName + "   [" + objP.GetServerDateTime().ToString("dd/MM/yyyy HH:mm:ss") + "]";
                SetPermission();

                objP.SetSessionImage();  
                

            }
            catch { }
        }

        private void frmTVSMain_Resize(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            TVSSys.GlobalModule.sMainTop = this.Top;
            TVSSys.GlobalModule.sMainLeft = this.Left;
            //this.CloseAllform(); 
        }

        private void TVSMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.CloseAllform();
                clsConfigXML objCfig = new clsConfigXML();
                serialPort1.PortName = objCfig.GetKey("PortName");
                serialPort1.Close();
            }
            catch { }
        }

        #region Method SetPermission
        private void SetPermission()
        {
            TVSSys.Connection objCon = new TVSSys.Connection();
            this.Permission = objCon.GetSysPerUser(this.UserName);

            // Menu He thong
            if (this.Permission.Contains("101")) this.MnuChangePass.Enabled = true;
            else this.MnuChangePass.Enabled = false;
            if (this.Permission.Contains("102")) this.MnuAccount.Enabled = true;
            else this.MnuAccount.Enabled = false;
            if (this.Permission.Contains("103")) this.MnuOnwer.Enabled = true;
            else this.MnuOnwer.Enabled = false;
            if (this.Permission.Contains("104")) this.MnuConfig.Enabled = true;
            else this.MnuConfig.Enabled = false;
            if (this.Permission.Contains("105")) this.MnuConfigDataBase.Enabled = true;
            else this.MnuConfigDataBase.Enabled = false;

            // Khai bao
            if (this.Permission.Contains("201")) this.MnuDir0.Enabled = true;
            else this.MnuDir0.Enabled = false;
            if (this.Permission.Contains("202")) this.MnuDir1.Enabled = true;
            else this.MnuDir1.Enabled = false;
            if (this.Permission.Contains("203")) this.MnuDir2.Enabled = true;
            else this.MnuDir2.Enabled = false;
            if (this.Permission.Contains("204")) this.MnuDir3.Enabled = true;
            else this.MnuDir3.Enabled = false;
            if (this.Permission.Contains("205")) this.MnuDir4.Enabled = true;
            else this.MnuDir4.Enabled = false;
            if (this.Permission.Contains("206")) this.MnuDir5.Enabled = true;
            else this.MnuDir5.Enabled = false;
            if (this.Permission.Contains("207")) this.MnuDir6.Enabled = true;
            else this.MnuDir6.Enabled = false;
            if (this.Permission.Contains("208")) this.MnuDir7.Enabled = true;
            else this.MnuDir7.Enabled = false;
            if (this.Permission.Contains("209")) this.MnuDir8.Enabled = true;
            else this.MnuDir8.Enabled = false;
            if (this.Permission.Contains("210")) this.MnuDir9.Enabled = true;
            else this.MnuDir9.Enabled = false;

            // Menu Cân điện tử
            if (this.Permission.Contains("301")) this.MnuScalesSys.Enabled = true;
            else this.MnuScalesSys.Enabled = false;
            if (this.Permission.Contains("302")) this.MnuScalesSys1.Enabled = true;
            else this.MnuScalesSys1.Enabled = false;
            if (this.Permission.Contains("303")) this.MnuReport.Enabled = true;
            else this.MnuReport.Enabled = false;
        }
        #endregion

        #region method Dir
        private void MnuDir_Click(object sender, EventArgs e)
        {
            this.CloseAllform();
            frmDir objfrm = new frmDir();
            objfrm.MdiParent = this;
            objfrm.UserName = this.UserName;
            objfrm.sTabTable = sender.ToString().ToUpper();
            objfrm.Show();
            objfrm.WindowState = FormWindowState.Maximized;

        }
        #endregion

        #region  Scales
        private void MnuScales_Click(object sender, EventArgs e)
        {
            try
            {
                this.CloseAllform();
                frmSEM objfrm = new frmSEM();
                objfrm.WindowState = FormWindowState.Maximized;
                objfrm.MdiParent = this;
                objfrm.UserName = this.UserName;
                objfrm.Show();
            }
            catch { }
        }

        private void MnuScalesSys1_Click(object sender, EventArgs e)
        {
            try
            {
                this.CloseAllform();
                frmSEM1 objfrm = new frmSEM1();
                objfrm.WindowState = FormWindowState.Maximized;
                objfrm.MdiParent = this;
                objfrm.UserName = this.UserName;
                objfrm.Show();
            }
            catch { }
        }
        #endregion

        #region Report
        private void MnuReport_Click(object sender, EventArgs e)
        {
            this.CloseAllform();
            TVSReports.frmSearch objfrm = new TVSReports.frmSearch();
            objfrm.MdiParent = this;
            objfrm.UserName = this.FullName;
            objfrm.Show();
            objfrm.WindowState = FormWindowState.Maximized;
        } 
        

        private void MnuReport0_Click(object sender, EventArgs e)
        {
            this.CloseAllform();
            TVSReports.frmBarrCodeReport objfrm = new TVSReports.frmBarrCodeReport();
            objfrm.MdiParent = this;
            objfrm.UserName = this.FullName;
            objfrm.Show();
            objfrm.WindowState = FormWindowState.Maximized;
        }
        #endregion

    }
}
