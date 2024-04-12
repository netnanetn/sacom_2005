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
    public partial class FrmGroup : Form
    {

       #region Declare variable to use
	    public string strConnectionString;
        public int GID;
        private TVSSys.Connection objFunc = new TVSSys.Connection();
         
        public bool Action = false;
        #endregion;

       #region Method FrmGroup
        public FrmGroup()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
                
        } 
        #endregion

       #region Method txtGName_KeyPress
        private void txtGName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtNote.Focus();
            }
        } 
        #endregion


       #region Method tSBAdd_Click
        private void tSBAdd_Click(object sender, EventArgs e)
        {
            this.txtGName.Text = "";
            this.txtNote.Text = "";            
            this.GID = 0;
            this.txtGName.Focus();
        } 
        #endregion

       #region Method tSBSave_Click
       private void tSBSave_Click(object sender, EventArgs e)
        {
            if (this.txtGName.Text == "")
            {
                MessageBox.Show("Các trường có dấu * cần nhập thông tin.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SqlConnection SqlCon = new SqlConnection(this.strConnectionString);
            SqlCon.Open();
            SqlCommand Cmd = new SqlCommand("ActionOnTabGroup", SqlCon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@GID", SqlDbType.Int);
            Cmd.Parameters.Add("@GName", SqlDbType.NVarChar);
            Cmd.Parameters.Add("@GDes", SqlDbType.NVarChar);
            Cmd.Parameters.Add("@GPer", SqlDbType.VarChar);
            Cmd.Parameters.Add("@GStatus", SqlDbType.SmallInt);

            Cmd.Parameters["@GID"].Value = this.GID;
            Cmd.Parameters["@GName"].Value = this.txtGName.Text;
            Cmd.Parameters["@GDes"].Value = this.txtNote.Text;
            Cmd.Parameters["@GPer"].Value = "";     
            if (this.ckBSActive.Checked) Cmd.Parameters["@GStatus"].Value = 1;
            else Cmd.Parameters["@GStatus"].Value = 0;
            Cmd.ExecuteNonQuery();
            this.Action = true;
            this.Close();
        } 
        #endregion

       #region method GetInformation
        private void GetInformation()
        {
            SqlConnection SqlCon = new SqlConnection(objFunc.strConnectionString);
            SqlCon.Open();
            SqlCommand Cmd = SqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM [TabGroup] WHERE [GID] = " + this.GID.ToString();            
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                this.txtGName.Text  = Rd["GName"].ToString();
                this.txtNote.Text   = Rd["GDes"].ToString();                
                if (Rd["GStatus"].ToString() == "1")
                {
                    this.ckBSActive.Checked = true;
                }
                else
                {
                    this.ckBSActive.Checked = false;
                }
            }
            Rd.Close();
            Rd.Dispose();
            SqlCon.Close();
            SqlCon.Dispose();
        }
        #endregion

       #region Method FrmGroup_Load
        private void FrmGroup_Load(object sender, EventArgs e)
        {
            this.strConnectionString = this.objFunc.strConnectionString;   
            this.GetInformation();
        } 
        #endregion

       #region Method tSBClose_Click
        private void tSBClose_Click(object sender, EventArgs e)
        {
            this.Action = false;
            this.Close();
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