using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TVSSys
{
    public partial class frmLogin : Form
    {
        #region Method declare variable to use
        private TVSSys.Connection objCon = new TVSSys.Connection();
        private TVSSys.GlobalModule objGlb = new TVSSys.GlobalModule();
        private DateTime sDateLogin;
        public string UserName, FullName, Password, UserNameLogOff;
        public bool OK = false;
        #endregion

        #region method frmLogin
        public frmLogin()
        {
            InitializeComponent();
        } 
        #endregion

        #region method cmdClose_Click
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion               

        #region method cmdLogin_Click
        private void cmdLogin_Click(object sender, EventArgs e)
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            string shortDateFormat, sLongDate;
            shortDateFormat = "dd/MM/yyyy";
            sLongDate = "dd/MM/yyyy";
            rkey.SetValue("sShortDate", shortDateFormat);
            rkey.SetValue("sLongDate", sLongDate);
            rkey.Close();
            
            this.lblMsg.Text = "";
            if (this.txtUserName.Text.Trim() == "" || this.txtPassWord.Text.Trim() == "")
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "        Bạn phải nhập vào đầy đủ thông tin!";
                if (this.txtUserName.Text == "")
                {
                    this.txtUserName.Focus();
                }
                else
                {
                    this.txtPassWord.Focus();
                }
                return;
            }
            bool Found = false;
            int sLogin = 0;
            int sStatus = 0;
            try
            {
                Cryptography objMD5 = new Cryptography(); 
                SqlConnection SqlCon = new SqlConnection(objCon.strConnectionString);
                SqlCon.Open();
                SqlCommand Cmd = SqlCon.CreateCommand();
                Cmd.CommandText = "SELECT FullName,UserName,Pass,Status,Login,getdate()AS DateLogin FROM [TabUser] WHERE [UserName] = '" + this.txtUserName.Text.Replace("or", "").Replace("--", "").Replace("'", "") + "'";
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read() && !Found)
                {
                    if (objMD5.CryptographyMD5(this.txtPassWord.Text.Trim()) == Rd["Pass"].ToString())
                    {
                        this.FullName = Rd["FullName"].ToString();
                        this.UserName = Rd["UserName"].ToString();
                        sStatus = int.Parse(Rd["Status"].ToString());
                        sLogin = int.Parse(Rd["Login"].ToString());
                        sDateLogin =DateTime.Parse(Rd["DateLogin"].ToString()); 
                        Found = true;
                    }
                }
                Rd.Close();
                Rd.Dispose();
                SqlCon.Close();
                SqlCon.Dispose();
            }
            catch
            {
                //
            }

            if (!Found)
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "        Thông tin đăng nhập không hợp lệ!";
                return;
            }
            else
            {
                if (sStatus == 0)
                {
                    this.lblMsg.Visible = true;
                    this.lblMsg.Text = "        Tài khoản này đang bị khoá!";
                    this.txtUserName.Focus();
                    return;
                }
                long elapsedTicks = DateTime.Now.Ticks - sDateLogin.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

                if (Math.Abs(elapsedSpan.TotalMinutes)>3)
                {
                    this.lblMsg.Visible = true;
                    this.lblMsg.Text = "       Thời gian không hợp lệ với máy chủ!. " + sDateLogin.ToString() ;
                    return;
                }

                //if ((sLogin != 0) && (UserNameLogOff != this.UserName) && (this.UserName != "admin")) 
                //{
                //    this.lblMsg.Visible = true;
                //    this.txtUserName.Focus();
                //    this.lblMsg.Text = "        Tài khoản đang được sử dụng!";
                //    return; 
                //}

                objCon.SetUpdateLogin(this.txtUserName.Text.Trim(), 1);    
                this.Password = this.txtPassWord.Text.Trim();
                this.OK = true;
                this.ChangeSystemDateTimeFormat();
                clsConfigXML objConfig = new clsConfigXML();
                objConfig.UpdateKey("UserName",this.txtUserName.Text); 
                this.Close();
            }
        } 
        #endregion

        #region method ChangeSystemDateTimeFormat
        private void ChangeSystemDateTimeFormat()
        {

            try
            {

                //Get Data From Text Boxes

                string ShortDateFormat = "dd/MM/yyyy";

                string LongTimeFormat = "hh:mm:ss tt";
                string ShortTimeFormat = "hh:mm tt";

                //string Currency = txtCurrency.Text.Trim();

                //Registry Logic

                //Open Sub key

                RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);


                ///Set Values

                if (rkey.GetValue("sShortTime").ToString() != ShortTimeFormat) rkey.SetValue("sShortTime", ShortTimeFormat);

                if (rkey.GetValue("sTimeFormat").ToString() != LongTimeFormat) rkey.SetValue("sTimeFormat", LongTimeFormat);

                if (rkey.GetValue("sShortDate").ToString() != ShortDateFormat) rkey.SetValue("sShortDate", ShortDateFormat);

                //rkey.SetValue("sCurrency", Currency);

                //Close the Registry

                rkey.Close();
            }
            catch
            {
            }


        } 
        #endregion

        #region Method txtPassword_KeyPress
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && this.txtPassWord.Text != "")
            {
                if (this.txtUserName.Text != "" && this.txtPassWord.Text != "")
                {
                    this.cmdLogin.PerformClick();
                }
                else if (this.txtUserName.Text == "")
                {
                    this.txtUserName.Focus();
                }
            }
        }
        #endregion
         
        #region method frmLogin_Load
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                clsConfigXML objConfig = new clsConfigXML();
                UserNameLogOff = objConfig.GetKey("UserName");
                this.txtUserName.Text = UserNameLogOff;
                this.txtPassWord.Focus();
                //this.txtPassWord.Text = "123";
                //this.cmdLogin.PerformClick();
               this.label5.Visible = false;   
            }
            catch { }
        } 
        #endregion

        #region method txtUserName_KeyPress
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPassWord.Focus();
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

    }
}