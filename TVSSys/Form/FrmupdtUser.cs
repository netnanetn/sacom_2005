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
    public partial class FrmupdtUser : Form
    {
        #region Method Declare variable to be use
        private TVSSys.Connection objFunc = new TVSSys.Connection();
        private TVSSys.GlobalModule objGlb = new TVSSys.GlobalModule(); 
        private string strConnectionString = "";
        private string OldName = "";
        public bool Action,objCheck;
        #endregion

        #region Method FrmupdtUser
        public FrmupdtUser()
        {            
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
            this.strConnectionString = this.objFunc.strConnectionString;
            this.loadGroupIntoListView();
            this.GetInformation();
        }
        #endregion

        #region Method loadGroupIntoListView
        private void loadGroupIntoListView()
        {
            SqlConnection SqlCon = new SqlConnection(objFunc.strConnectionString);
            SqlCon.Open();
            SqlCommand Cmd = SqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM [TabGroup] ORDER BY [GID]";
            SqlDataReader Rd = Cmd.ExecuteReader();
            int i = 0;
            while (Rd.Read())
            {
                this.lsvGroup.Items.Add(Rd["GID"].ToString());
                this.lsvGroup.Items[i].SubItems.Add(Rd["GName"].ToString());
                this.lsvGroup.Items[i].SubItems.Add(Rd["GPer"].ToString());
                i++;
            }
            Rd.Close();
            SqlCon.Close();
            SqlCon.Dispose();
        }
        #endregion

        #region Method checkGroup
        private void checkGroup()
        {
            SqlConnection SqlCon = new SqlConnection(objFunc.strConnectionString);
            SqlCon.Open();
            SqlCommand Cmd = SqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM [TabUser] WHERE [UserName] = '" + this.txtUserName.Text + "'";
            SqlDataReader Rd = Cmd.ExecuteReader();
            string strGPer = "";
            while (Rd.Read())
            {
                strGPer = Rd["Group"].ToString();
                for (int i = 0; i < this.lsvGroup.Items.Count; i++)
                {
                    this.lsvGroup.Items[i].Checked = false;
                }
                for (int i = 0; i < this.lsvGroup.Items.Count; i++)
                {
                    if (strGPer.Contains("\"" + this.lsvGroup.Items[i].SubItems[0].Text + "\""))
                    {
                        this.lsvGroup.Items[i].Checked = true;
                    }
                }
            }
            Rd.Close();
            Rd.Dispose();
            SqlCon.Close();
            SqlCon.Dispose();
        }
        #endregion  

        #region Method txtUserName_KeyPress
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtFullName.Focus();
            }
        }
        #endregion

        #region Method txtFullName_KeyPress
        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPass.Focus();
            }
        }
        #endregion

        #region Method txtPass_KeyPress
        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPassCofirm.Focus();
            }
        }
        #endregion

        #region Method txtPassCofirm_KeyPress
        private void txtPassCofirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtNote.Focus();
            }
        }
        #endregion
    
        #region Method txtNote_KeyPress
        private void txtNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.ckBSActive.Focus();
            }
        }
        #endregion

        #region Method tSBAdd_Click
        private void tSBAdd_Click(object sender, EventArgs e)
        {
            objCheck = false;
            this.txtUserName.Text = "";
            this.txtUserName.Focus();
            txtPass.Enabled = true;
            txtPassCofirm.Enabled = true;
        }
        #endregion

        #region Method tSBSave_Click
        private void tSBSave_Click(object sender, EventArgs e)
        {
            //if (objCheck)
            //{
            //    if (this.txtUserName.Text == "" || this.txtFullName.Text == "")
            //    {
            //        MessageBox.Show("Các trường có dấu * cần nhập thông tin.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            //else
            //{
            if (this.txtUserName.Text == "" || this.txtFullName.Text == "")
            {
                MessageBox.Show("Các trường có dấu * cần nhập thông tin.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!objCheck)
            {
                if (this.txtPass.Text == "")
                {
                    MessageBox.Show("Các trường có dấu * cần nhập thông tin.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                clsPublic clsP = new clsPublic();
                int sPasslen = clsP.Get_ConfigInfo("PassWordLenght");
                if (this.txtPass.Text.Trim().Length < sPasslen)
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất " + sPasslen.ToString() + " ký tự.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.Focus();
                    return;
                }
                if (this.txtPass.Text != this.txtPassCofirm.Text)
                {
                    MessageBox.Show("Mật khẩu không đúng.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassCofirm.Focus();
                    return;
                }
            }
            Cryptography objMD5 = new Cryptography(); 
            SqlConnection SqlCon = new SqlConnection(this.strConnectionString);
            SqlCon.Open();
            SqlCommand Cmd = new SqlCommand("ActionOnTabUser", SqlCon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@UserName",SqlDbType.VarChar);
            Cmd.Parameters.Add("@FullName", SqlDbType.NVarChar);
            Cmd.Parameters.Add("@Pass", SqlDbType.VarChar);
            Cmd.Parameters.Add("@Create", SqlDbType.DateTime);
            Cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
            Cmd.Parameters.Add("@Group", SqlDbType.VarChar);
            Cmd.Parameters.Add("@oldUserName", SqlDbType.VarChar);
            Cmd.Parameters.Add("@NoChangePass", SqlDbType.SmallInt);
            Cmd.Parameters.Add("@Per", SqlDbType.VarChar);

            Cmd.Parameters["@UserName"].Value   = this.txtUserName.Text;
            Cmd.Parameters["@FullName"].Value   = this.txtFullName.Text;
            Cmd.Parameters["@Pass"].Value = objMD5.CryptographyMD5(this.txtPass.Text);
            Cmd.Parameters["@Create"].Value     = DateTime.Now;
            if (this.ckBSActive.Checked)
            {
                Cmd.Parameters["@Status"].Value = 1;
            }
            else
            {
                Cmd.Parameters["@Status"].Value = 0;
            }
            string strGroup = "";
            string strPer = "";
            for (int i = 0; i < this.lsvGroup.Items.Count; i++)
            {
                if (this.lsvGroup.Items[i].Checked)
                {
                    strGroup += "\"" + this.lsvGroup.Items[i].SubItems[0].Text + "\",";
                    strPer += this.lsvGroup.Items[i].SubItems[2].Text + ",";
                }
            }
            if (strGroup != "") strGroup = strGroup.Remove(strGroup.Length - 1);
            if (strPer != "") strPer = strPer.Remove(strPer.Length - 1);
            Cmd.Parameters["@Group"].Value = strGroup;
            Cmd.Parameters["@oldUserName"].Value = this.OldName;
            if (this.txtPass.Text != "") Cmd.Parameters["@NoChangePass"].Value = 0;
            else Cmd.Parameters["@NoChangePass"].Value = 1;
            Cmd.Parameters["@Per"].Value = strPer;
            try
            {
                Cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi, không thể cập nhật thông tin.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Action = true;
            SqlCon.Close();
            SqlCon.Dispose();
            this.Close();
        }
        #endregion

        #region Method tSBClose_Click
        private void tSBClose_Click(object sender, EventArgs e)
        {
            this.Action = false;
            this.Close();
        }
        #endregion

        #region method GetInformation
        private void GetInformation()
        {
            SqlConnection SqlCon = new SqlConnection(this.strConnectionString);
            SqlCon.Open();
            SqlCommand Cmd = SqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM [TabUser] WHERE [UserName] = '"+this.txtUserName.Text+"'";
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                this.OldName = Rd["UserName"].ToString();
                this.txtFullName.Text   = Rd["FullName"].ToString();
                //this.txtPass.Enabled  = false;
                //this.txtPassCofirm.Enabled = false;
                if (Rd["Status"].ToString() == "1")
                {
                    this.ckBSActive.Checked = true;
                }
                else
                {
                    this.ckBSActive.Checked = false;
                }
                objCheck = true;

            }
            Rd.Close();
            Rd.Dispose();
            SqlCon.Close();
            SqlCon.Dispose();
        }
        #endregion

        #region Method FrmupdtUser_Load
        private void FrmupdtUser_Load(object sender, EventArgs e)
        {
            this.GetInformation();
            this.checkGroup();
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