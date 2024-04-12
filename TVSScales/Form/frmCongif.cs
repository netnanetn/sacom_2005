using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

namespace TVSMain
{
    public partial class frmConfig : Form
    {
        #region method Declare ...
        private clsConfigXML objCfig = new clsConfigXML();   
        
        #endregion

        #region Method frmConfig
        public frmConfig()
        {
            InitializeComponent();          
        }
        #endregion

        #region Method GetConfigPublic
        private void GetConfigPublic()
        {
            try
            {
                if (objCfig.GetKey("RepPrintView") != "0") chkRepPrintView.Checked = true;
                else chkRepPrintView.Checked = false;
                cbbRepType.Items.Add(new TVSSys.ItemCombobox("Bill88", "Bill88"));
                cbbRepType.Items.Add(new TVSSys.ItemCombobox("Bill88Logo", "Bill88Logo"));
                cbbRepType.Items.Add(new TVSSys.ItemCombobox("Bill65", "Bill65"));
                cbbRepType.Items.Add(new TVSSys.ItemCombobox("Bill65Logo", "Bill65Logo"));
                cbbRepType.Items.Add(new TVSSys.ItemCombobox("Bill47", "Bill47"));
                cbbRepType.Items.Add(new TVSSys.ItemCombobox("Bill47Logo", "Bill47Logo"));


                cbbRepType2.Items.Add(new TVSSys.ItemCombobox("Bill88", "Bill88"));
                cbbRepType2.Items.Add(new TVSSys.ItemCombobox("Bill88Logo", "Bill88Logo"));
                cbbRepType2.Items.Add(new TVSSys.ItemCombobox("Bill65", "Bill65"));
                cbbRepType2.Items.Add(new TVSSys.ItemCombobox("Bill65Logo", "Bill65Logo"));
                cbbRepType2.Items.Add(new TVSSys.ItemCombobox("Bill47", "Bill47"));
                cbbRepType2.Items.Add(new TVSSys.ItemCombobox("Bill47Logo", "Bill47Logo"));
                cbbRepType2.Items.Add(new TVSSys.ItemCombobox("", ""));

                cbbUnit.Items.Add(new TVSSys.ItemCombobox("Kg", "Kg"));
                cbbUnit.Items.Add(new TVSSys.ItemCombobox("g", "g"));
                TVSSys.clsPublic objP = new TVSSys.clsPublic();
                objP.SelectValueCombobox(cbbRepType, objCfig.GetKey("RepType"));
                objP.SelectValueCombobox(cbbRepType2, objCfig.GetKey("RepType2"));
                objP.SelectValueCombobox(cbbUnit, objCfig.GetKey("Unit"));




                foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cbbPrintBill88.Items.Add(new TVSSys.ItemCombobox(strPrinter, strPrinter));
                    cbbPrintBillDefault.Items.Add(new TVSSys.ItemCombobox(strPrinter, strPrinter));
                }
                try
                {

                    objP.SelectValueCombobox(cbbPrintBill88, objCfig.GetKey("SetPrintBill88"));
                }
                catch { }
                try
                {

                    objP.SelectValueCombobox(cbbPrintBillDefault, objCfig.GetKey("SetPrintBillDefault"));
                }
                catch { }

                bool schkAutoBackUp = false;
                try
                {
                    schkAutoBackUp = bool.Parse(objCfig.GetKey("Autobackup"));
                }
                catch { }
                this.chkAutobackup.Checked = schkAutoBackUp;
                int sBackupCount = 0;
                try
                {
                    sBackupCount = int.Parse(objCfig.GetKey("BackupCount"));
                }
                catch { }
                this.txtCount.Text = sBackupCount.ToString();
            }
            catch { }            
        }
        #endregion


        #region Method GetConfig
        private void GetConfig()
        {
            try
            {
                cbbPortName.Items.Add(new TVSSys.ItemCombobox("COM1", "COM1"));
                cbbPortName.Items.Add(new TVSSys.ItemCombobox("COM2", "COM2"));
                cbbPortName.Items.Add(new TVSSys.ItemCombobox("COM3", "COM3"));
                cbbPortName.Items.Add(new TVSSys.ItemCombobox("COM4", "COM4"));
                cbbPortName.Items.Add(new TVSSys.ItemCombobox("COM5", "COM5"));
                cbbPortName.Items.Add(new TVSSys.ItemCombobox("COM6", "COM6"));
                cbbPortName.Items.Add(new TVSSys.ItemCombobox("COM7", "COM7"));
                cbbPortName.Items.Add(new TVSSys.ItemCombobox("COM8", "COM8"));

                cbbBaudRate.Items.Add(new TVSSys.ItemCombobox("1200", "1200"));
                cbbBaudRate.Items.Add(new TVSSys.ItemCombobox("2400", "2400"));
                cbbBaudRate.Items.Add(new TVSSys.ItemCombobox("4800", "4800"));
                cbbBaudRate.Items.Add(new TVSSys.ItemCombobox("9600", "9600"));

                cbbParity.Items.Add(new TVSSys.ItemCombobox("E", "E"));
                cbbParity.Items.Add(new TVSSys.ItemCombobox("O", "O"));
                cbbParity.Items.Add(new TVSSys.ItemCombobox("N", "N"));

                cbbDataBits.Items.Add(new TVSSys.ItemCombobox("8", "8"));
                cbbDataBits.Items.Add(new TVSSys.ItemCombobox("7", "7"));
                cbbDataBits.Items.Add(new TVSSys.ItemCombobox("6", "6"));
                cbbDataBits.Items.Add(new TVSSys.ItemCombobox("5", "5"));

                cbbStopBits.Items.Add(new TVSSys.ItemCombobox("1", "1"));
                cbbStopBits.Items.Add(new TVSSys.ItemCombobox("1.5", "1.5"));
                cbbStopBits.Items.Add(new TVSSys.ItemCombobox("2", "2"));

                TVSSys.clsPublic objP = new TVSSys.clsPublic();

                objP.SelectValueCombobox(cbbPortName, objCfig.GetKey("PortName"));
                objP.SelectValueCombobox(cbbBaudRate, objCfig.GetKey("BaudRate"));
                objP.SelectValueCombobox(cbbParity, objCfig.GetKey("Parity"));
                objP.SelectValueCombobox(cbbDataBits, objCfig.GetKey("DataBits"));
                objP.SelectValueCombobox(cbbStopBits, objCfig.GetKey("StopBits"));
                this.TxtMaxNumber.Text = objCfig.GetKey("MaxNumber");
                this.TxtStartNumber.Text = objCfig.GetKey("StartNumber");
            }
            catch
            {
            }
        }
        #endregion

        #region Method frmConfig_Load
        private void frmConfig_Load(object sender, EventArgs e)
        {
            this.GetConfigPublic(); 
            this.GetConfig();
            this.GetConfigCamera(); 
        }
        #endregion

        #region method frmConfig_KeyDown
        private void frmConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6) this.btnAllUpdate.PerformClick();
            if (e.KeyCode == Keys.Escape) this.Close();
        } 
        #endregion

        #region method txtEnter
        private void txtEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tmp = (System.Windows.Forms.TextBox)sender;
            tmp.BackColor = TVSSys.GlobalModule.objColorEnter;
        }
        #endregion

        #region method txtLeave
        private void txtLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tmp = (System.Windows.Forms.TextBox)sender;
            tmp.BackColor = TVSSys.GlobalModule.objColorLeave;
        }
        #endregion


        #region method SetConfigPublic
        private void SetConfigPublic()
        {
            try
            {
                if (this.chkRepPrintView.Checked) objCfig.UpdateKey("RepPrintView", "1");
                else objCfig.UpdateKey("RepPrintView", "0");
                TVSSys.ItemCombobox objItype = (TVSSys.ItemCombobox)cbbRepType.SelectedItem;
                objCfig.UpdateKey("RepType", objItype.Value);

                TVSSys.ItemCombobox objItype2 = (TVSSys.ItemCombobox)cbbRepType2.SelectedItem;
                objCfig.UpdateKey("RepType2", objItype2.Value);

                TVSSys.ItemCombobox objIt = (TVSSys.ItemCombobox)cbbUnit.SelectedItem;
                objCfig.UpdateKey("Unit", objIt.Value);

                objCfig.UpdateKey("SetPrintBill88", this.cbbPrintBill88.SelectedItem.ToString());
                objCfig.UpdateKey("SetPrintBillDefault", this.cbbPrintBillDefault.SelectedItem.ToString());
                objCfig.UpdateKey("Autobackup", chkAutobackup.Checked.ToString());
                objCfig.UpdateKey("BackupCount", txtCount.Text);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật dữ liệu!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion        

        #region method SetConfig
        private void SetConfig()
        {
            try
            {
                TVSSys.ItemCombobox objItem = (TVSSys.ItemCombobox)cbbPortName.SelectedItem;
                objCfig.UpdateKey("PortName", objItem.Value);
                objItem = (TVSSys.ItemCombobox)cbbBaudRate.SelectedItem;
                objCfig.UpdateKey("BaudRate", objItem.Value);
                objItem = (TVSSys.ItemCombobox)cbbParity.SelectedItem;
                objCfig.UpdateKey("Parity", objItem.Value);
                objItem = (TVSSys.ItemCombobox)cbbDataBits.SelectedItem;
                objCfig.UpdateKey("DataBits", objItem.Value);
                objItem = (TVSSys.ItemCombobox)cbbStopBits.SelectedItem;
                objCfig.UpdateKey("StopBits", objItem.Value);
                int sMax = int.Parse(this.TxtMaxNumber.Text.Trim());
                int sStart = int.Parse(this.TxtStartNumber.Text.Trim());
                objCfig.UpdateKey("MaxNumber", sMax.ToString());
                objCfig.UpdateKey("StartNumber", sStart.ToString());
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
            this.SetConfigPublic();
            this.SetConfig();
            this.SetConfigCamera(); 
        }
        #endregion


        #region Method TabCamera
        private void GetConfigCamera()
        {
            try
            {
                this.TxtServerPath.Text = objCfig.GetKey("ServerPath");
                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count > 0)
                {
                    for (int i = 1, n = videoDevices.Count; i <= n; i++)
                    {
                        string cameraName = i + " : " + videoDevices[i - 1].Name;
                        camera1Combo.Items.Add(cameraName);
                        camera2Combo.Items.Add(cameraName);
                    }
                    camera1Combo.SelectedIndex = int.Parse(objCfig.GetKey("CameraIndex0"));
                    camera2Combo.SelectedIndex = int.Parse(objCfig.GetKey("CameraIndex1"));
                }
            }
            catch {}
        }
        private void SetConfigCamera()
        {
            try
            {
                objCfig.UpdateKey("ServerPath", this.TxtServerPath.Text);
                objCfig.UpdateKey("CameraIndex0", camera1Combo.SelectedIndex.ToString());
                objCfig.UpdateKey("CameraIndex1", camera2Combo.SelectedIndex.ToString());
                MessageBox.Show("Thông số mới đã được ghi nhận trên hệ thống!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật dữ liệu!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}