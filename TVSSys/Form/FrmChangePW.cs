using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TVSSys
{
    public partial class FrmChangePW : Form
    {
        public string StrUsername = "";
        private TVSSys.Connection objFun = new TVSSys.Connection();
         
        public FrmChangePW()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Cryptography objMD5 = new Cryptography(); 
            if (txtPWOld.Text.Trim()== string.Empty)
            {
                MessageBox.Show("Hãy nhập mật khẩu cũ!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPWOld.Focus();
                return;
            }
            if (txtPWNew.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy nhập mật khẩu mới!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPWNew.Focus();
                return;
            }
            clsPublic clsP = new clsPublic();
            int sPasslen = clsP.Get_ConfigInfo("PassWordLenght");
            if (this.txtPWNew.Text.Trim().Length < sPasslen)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất " + sPasslen.ToString() + " ký tự.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPWNew.Focus();
                return;
            }
            if (txtPWRepeat.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy nhắc lại mật khẩu!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPWRepeat.Focus();
                return;
            }
            if (txtPWRepeat.Text.Trim() != txtPWNew.Text.Trim())
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPWRepeat.Text = "";
                txtPWRepeat.Focus();
                return;
            }
           
          
            SqlConnection cn = new SqlConnection(objFun.strConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM TabUser WHERE USERName = @Username AND Pass = @Pass", cn);
            cmd.Parameters.AddWithValue("@Username", StrUsername);
            cmd.Parameters.AddWithValue("@Pass", objMD5.CryptographyMD5(txtPWOld.Text));
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                SqlConnection cn1 = new SqlConnection(objFun.strConnectionString);
                SqlCommand cmd1 = new SqlCommand("UPDATE TabUser SET Pass=@PassWord WHERE (UserName=@UserName)", cn1);
                cmd1.Parameters.AddWithValue("@UserName", StrUsername);
                cmd1.Parameters.AddWithValue("@PassWord", objMD5.CryptographyMD5(txtPWNew.Text));
                cn1.Open();
                cmd1.ExecuteNonQuery();
                cn1.Close();
                cn1.Dispose();
                MessageBox.Show("Mật khẩu đã được thay đổi", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPWOld.Text = string.Empty;
                txtPWOld.Focus();
            }
            dr.Close();
            dr.Dispose();
            cn.Close();
            cn.Dispose();
        }

        #region cmdExit_Click
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region txtPWOld_KeyPress
        private void txtPWOld_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPWNew.Focus();
            }
        } 
        #endregion

        #region txtPWNew_KeyPress
        private void txtPWNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPWRepeat.Focus();
            }
        } 
        #endregion
        
        #region txtPWRepeat_KeyPress
        private void txtPWRepeat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSave.PerformClick();
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