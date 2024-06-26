using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Collections;
using System.Xml;

namespace TVSSys
{
    public partial class FrmRegister : Form
    {
        #region method Declare ...
        XmlDocument xmlDoc = new XmlDocument();
        public bool Reg = false; 
        #endregion

        #region method FrmRegister
        public FrmRegister()
        {
            InitializeComponent();
        } 
        #endregion

        #region method FrmRegister_Load
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            try
            {
                Regis objRes = new Regis();
                this.TxtRegister.Text = objRes.InsertInfo("Win32_Processor");
                string CDKey = objRes.GetCDKey(this.TxtRegister.Text.Trim());
                if (CDKey.ToUpper() == objRes.GetSerial().ToUpper())
                {
                    Reg = true;
                    this.TxtRegister.Visible = false;
                    this.label1.Visible = false;
                    this.lblInformation.Text = "Sản phẩm đã được cấp giấy phép sử dụng";
                    this.lblInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));    
                    this.lblTitle.Text = "Bạn đã đăng ký sử dụng sản phẩm với\r\nCông ty cổ phần phần mềm Trung Việt\r\nĐể được hỗ trợ kỹ thuật, vui lòng liên hệ thông tin dưới đây";
                    this.label4.Text = "";
                    this.TxtCDKey1.Visible = false;
                    this.TxtCDKey2.Visible = false;
                    this.TxtCDKey3.Visible = false;
                    this.TxtCDKey4.Visible = false;
                    this.lblCDKey.Visible = false;
                    this.lblSpace1.Visible = false;
                    this.lblSpace2.Visible = false;
                    this.lblSpace3.Visible = false;
                    this.CmdRegister.Enabled = false;
                }
                else
                {
                    Reg = false;
                    this.CmdRegister.Enabled = true;
                    this.lblTitle.Text = "Bạn đang sử dụng phiên bản dùng thử\r\nĐể sử dụng bản chính thức, vui lòng liên hệ với nhà cung cấp\nHãy gửi mã số đăng ký ở trên để được cung cấp một CD Key hợp lệ";
                    this.TxtCDKey1.Visible = true;
                    this.TxtCDKey2.Visible = true;
                    this.TxtCDKey3.Visible = true;
                    this.TxtCDKey4.Visible = true;
                    this.lblCDKey.Visible = true;
                    this.lblSpace1.Visible = true;
                    this.lblSpace2.Visible = true;
                    this.lblSpace3.Visible = true;
                }
            }
            catch
            {
                //
            }
        } 
        #endregion

        #region Method CryptographyMD5
        public string CryptographyMD5(string source)
        {
            string result = "";
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider objMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(source);
                byte[] bytHash = objMD5.ComputeHash(buffer);
                foreach (byte a in bytHash)
                {
                    result += int.Parse(a.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
                }
            }
            catch
            {
            }
            return result;
        }
        #endregion

        #region method CmdRegister_Click
        private void CmdRegister_Click(object sender, EventArgs e)
        {
            Regis objRes = new Regis();
            string tmpValue = this.TxtCDKey1.Text.Trim() + this.TxtCDKey2.Text.Trim() + this.TxtCDKey3.Text.Trim() + this.TxtCDKey4.Text.Trim();
            if (tmpValue == objRes.GetCDKey(this.TxtRegister.Text.Trim()))
            {
                clsConfigXML objXML = new clsConfigXML();
                objXML.UpdateKey("License", tmpValue); 
                Reg = true;
                MessageBox.Show("Bạn đã đăng ký sử dụng phần mềm thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Reg = false;
                MessageBox.Show("Mã số đăng ký không hợp lệ.\n\nKiểm tra lại hoặc liên hệ nhà cung cấp để được trợ giúp!", "TVS - Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } 
        #endregion

        #region method CmdExit_Click
        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

 
        #region method FrmRegister_KeyDown
        private void FrmRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        } 
        #endregion
    }

    #region Class HardDrive
    class HardDrive
    {
        private string model = null;
        private string type = null;
        private string serialNo = null;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; }
        }
    }
    #endregion
}