using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TVSSys
{
    public partial class FrmConfig : Form
    {
        #region method Declare ...
        private TVSSys.clsConfigXML objCfig = new TVSSys.clsConfigXML();   
        private TVSSys.GlobalModule objGlb = new TVSSys.GlobalModule();
        #endregion

        #region Method FrmConfig
        public FrmConfig()
        {
            InitializeComponent();          
        }
        #endregion

        #region Method GetConfig
        private void GetConfig()
        {
            try
            {
                if (objCfig.GetKey("MenuLeft") == "True") chkShowMenuLeft.Checked = true;
                else chkShowMenuLeft.Checked = false;

                for (int i = 1; i < 31; i++)
                {
                    cbbBirthdayExt.Items.Add(new TVSSys.ItemCombobox(i.ToString() + " Ngày", i.ToString()));
                    cbbContractExpiresExt.Items.Add(new TVSSys.ItemCombobox(i.ToString() + " Ngày", i.ToString()));
                }
                if (objCfig.GetKey("Birthday") == "True") chkShowBirthday.Checked = true;
                else chkShowBirthday.Checked = false;
                cbbBirthdayExt.SelectedIndex = int.Parse(objCfig.GetKey("BirthdayExt"));

                if (objCfig.GetKey("ContractExpires") == "True") chkContractExpires.Checked = true;
                else chkContractExpires.Checked = false;
                cbbContractExpiresExt.SelectedIndex = int.Parse(objCfig.GetKey("ContractExpiresExt"));

                this.txtFolderAttach.Text = objCfig.GetKey("SourcePath"); 
                this.TxtSourcePath.Text = objCfig.GetKey("SourceTimeSheet");
                 
            }
            catch
            {
            }            
        }
        #endregion

        #region Method FrmCongif_Load
        private void FrmCongif_Load(object sender, EventArgs e)
        {
            this.GetConfig();
        }
        #endregion

        #region method FrmCongif_KeyDown
        private void FrmCongif_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        } 
        #endregion

        #region method txtEnter
        private void txtEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tmp = (System.Windows.Forms.TextBox)sender;
            tmp.BackColor = GlobalModule.objColorEnter;
        }
        #endregion

        #region method txtLeave
        private void txtLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tmp = (System.Windows.Forms.TextBox)sender;
            tmp.BackColor = GlobalModule.objColorLeave;
        }
        #endregion


        #region method Cauhinhchung
        private void UpdateMenuLeft()
        {
            try
            {
                objCfig.UpdateKey("MenuLeft", this.chkShowMenuLeft.Checked.ToString());

                objCfig.UpdateKey("Birthday", this.chkShowBirthday.Checked.ToString());
                objCfig.UpdateKey("BirthdayExt", this.cbbBirthdayExt.SelectedIndex.ToString() );

                objCfig.UpdateKey("ContractExpires", this.chkContractExpires.Checked.ToString());
                objCfig.UpdateKey("ContractExpiresExt", this.cbbContractExpiresExt.SelectedIndex.ToString());

                objCfig.UpdateKey("SourcePath", this.txtFolderAttach.Text);
                objCfig.UpdateKey("SourceTimeSheet", this.TxtSourcePath.Text);

                MessageBox.Show("Thông số mới đã được ghi nhận trên hệ thống!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật dữ liệu!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnAllExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region method btnAllUpdate
        private void btnAllUpdate_Click(object sender, EventArgs e)
        {
            UpdateMenuLeft();
        }
        #endregion

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.ShowReadOnly = true;
                openFileDialog1.Title = "Chọn file cần cập nhật...";
                openFileDialog1.Filter = "MDB|*.Mdb";
                openFileDialog1.ShowDialog();
                TxtSourcePath.Text = openFileDialog1.FileName;
            }
            catch { }
        }

    }
}