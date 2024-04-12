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
    public partial class FrmRootCompany : Form
    {
        #region method Declare ...
        private TVSSys.Connection objFunc = new TVSSys.Connection();
        
        #endregion

        #region method FrmCompany
        public FrmRootCompany()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
        } 
        #endregion

        #region method cmdClose_Click
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region method FrmCompany_Load
        private void FrmCompany_Load(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(this.objFunc.strConnectionString);
            sqlCon.Open();
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT TOP 1 * FROM [TabCompany] WHERE [ComID] = 'COM01'";
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txtComName.Text    = rd["ComName"].ToString();
                this.txtComAddress.Text = rd["ComAddress"].ToString();
                this.txtComManager.Text = rd["ComManager"].ToString();
                this.txtComPhone.Text   = rd["ComPhone"].ToString();
                this.txtComFax.Text     = rd["ComFax"].ToString();
                this.txtComTax.Text     = rd["ComTax"].ToString();
                this.txtComEmail.Text   = rd["ComEmail"].ToString();
                this.txtComWebsite.Text = rd["ComWebsite"].ToString();
            }
            rd.Close();
            rd.Dispose();
            sqlCon.Close();
            sqlCon.Dispose();
        } 
        #endregion

        #region method cmdUpdate_Click
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(objFunc.strConnectionString);
                SqlCommand cmd = new SqlCommand("ActionOnTabCompany", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ComID", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ComName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ComManager", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ComAddress", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ComPhone", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ComFax", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ComEmail", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ComTax", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ComWebsite", SqlDbType.NVarChar);

                cmd.Parameters["@ComID"].Value = "COM01";
                cmd.Parameters["@ComName"].Value = this.txtComName.Text;
                cmd.Parameters["@ComManager"].Value = this.txtComManager.Text;
                cmd.Parameters["@ComAddress"].Value = this.txtComAddress.Text;
                cmd.Parameters["@ComPhone"].Value = this.txtComPhone.Text;
                cmd.Parameters["@ComFax"].Value = this.txtComFax.Text;
                cmd.Parameters["@ComEmail"].Value = this.txtComEmail.Text;
                cmd.Parameters["@ComTax"].Value = this.txtComTax.Text;
                cmd.Parameters["@ComWebsite"].Value = this.txtComWebsite.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cn.Dispose();
                MessageBox.Show("Cập nhật thông tin thành công!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Lỗi, không thể cập nhật!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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