using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TVSSys
{
    public partial class frmPerGroup : Form
    {
        #region method Declare ...
        private TVSSys.Connection objCon = new TVSSys.Connection();
        private TVSSys.GlobalModule objGbl = new TVSSys.GlobalModule(); 
        private  string  sTabKey="";
        public string UserName="";
        #endregion

        #region method frmPerGroup
        public frmPerGroup()
        {
            InitializeComponent();

        } 
        #endregion

        #region method frmPer_Load
        private void frmPer_Load(object sender, EventArgs e)
        {
            Load_Account();
            LoadTreeViewPerGroup(this.tvWPerGroup); 
        }
        #endregion

        #region method Load_Account
        private void Load_Account()
        {
            tvwUser.Nodes.Clear();
            TreeNode objTno;
            objTno = new TreeNode();
            objTno.Text = "Nhóm Người dùng";
            objTno.Tag = "G";
            objTno.SelectedImageIndex = 0; 
            objTno.ImageIndex = 0;
            tvwUser.Nodes.Add(objTno);
            LoadTreeView("Select GID as ID,GName as Name,1 as LogIn from TabGroup", objTno, 0, "G");

            objTno = new TreeNode();
            objTno.Text = "Người dùng";
            objTno.Tag = "U";
            objTno.SelectedImageIndex = 1;
            objTno.ImageIndex = 1; 
            tvwUser.Nodes.Add(objTno);
            LoadTreeView("Select UserName as ID,FullName as Name,LogIn from TabUser where UserName<>'alofun'", objTno, 1, "U");
            tvwUser.ExpandAll();  
        }
        #endregion

        #region LoadTreeView
        private void LoadTreeView(string sSQL, TreeNode sTreeNode, int sImage, string sTab)
        {
            TreeNode objTno;
            SqlConnection cn = new SqlConnection(objCon.strConnectionString);
            cn.Open();
            SqlCommand Cmd = new SqlCommand(sSQL, cn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            try
            {
                while (Rd.Read())
                {
                    objTno = new TreeNode();
                    if (sTab=="U") objTno.Text = Rd["ID"].ToString() + " [ " + Rd["Name"].ToString() + " ] ";
                    else objTno.Text = Rd["Name"].ToString();
                    objTno.Tag =sTab +  Rd["ID"].ToString();
                    if (Rd["LogIn"].ToString()!="0")
                    {
                        objTno.SelectedImageIndex = sImage;
                        objTno.ImageIndex = sImage;
                    }
                    else
                    {
                        objTno.SelectedImageIndex = 2;
                        objTno.ImageIndex = 2;
                    }
                    sTreeNode.Nodes.Add(objTno);
                }
            }
            catch
            {

            }
            finally
            {
                Rd.Close();
                Rd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        private void LoadTreeView(string IdGroup, TreeNode sTreeNode)
        {
            try
            {
                TreeNode objTno;
                Connection objCon = new Connection();
                DataTable dt = objCon.EXESelect("Select PerID,PerName from TabPer Where IdGroup=" + int.Parse(IdGroup));
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objTno = new TreeNode();
                        objTno.Text = dt.Rows[i][1].ToString();
                        objTno.Tag = dt.Rows[i][0].ToString();
                        sTreeNode.Nodes.Add(objTno);
                    }
                }
            }
            catch { }
        }
        private void LoadTreeViewPerGroup(TreeView sTreeView)
        {
            try
            {
                TreeNode objTno;
                Connection objCon = new Connection();
                DataTable dt = objCon.EXESelect("Select * from TabPerGroup");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objTno = new TreeNode();
                        objTno.Text = dt.Rows[i][1].ToString();
                        sTreeView.Nodes.Add(objTno);
                        this.LoadTreeView(dt.Rows[i][0].ToString(), objTno);
                    }
                    sTreeView.ExpandAll();
                }
            }
            catch { }
        }
        #endregion

        #region Method checkPermission
        private void checkPermission(string sID)
        {
            string sSQL = "";
            if (sID.Length == 1) return; 
            if (sID.Substring(0, 1) == "G") sSQL = "SELECT GPer as Per FROM [TabGroup] WHERE [GID] = " + sID.Substring(1);
            else sSQL = "SELECT Per FROM [TabUser] WHERE [UserName] = '" + sID.Substring(1) + "'";
            objCon = new Connection(); 
            string strGPer = objCon.Get_EXESelect(sSQL); 
            TreeNode objTno = new TreeNode();
            for (int i = 0; i < tvWPerGroup.Nodes.Count; i++)
            {
                objTno = tvWPerGroup.Nodes[i]; 
                for (int j = 0; j < objTno.Nodes.Count; j++)
                {
                    if (strGPer.Contains("\"" + objTno.Nodes[j].Tag.ToString() + "\"")) objTno.Nodes[j].Checked = true;
                    else objTno.Nodes[j].Checked = false;
                }
            
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


        private void tvwUser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.LblName.Text = tvwUser.SelectedNode.Text.ToString(); 
            sTabKey = tvwUser.SelectedNode.Tag.ToString();
            this.checkPermission(sTabKey); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sTabKey.Length == 1) return;
            string stPer = "";
            TreeNode objTno = new TreeNode();
            for (int i = 0; i < tvWPerGroup.Nodes.Count; i++)
            {
                objTno = tvWPerGroup.Nodes[i];
                for (int j = 0; j < objTno.Nodes.Count; j++)
                {
                    if (objTno.Nodes[j].Checked) stPer += "\"" + objTno.Nodes[j].Tag.ToString() + "\",";
                }

            }
            if (stPer != "") stPer = stPer.Remove(stPer.Length - 1);
            try
            {
                string sSQL = "";
                if (sTabKey.Substring(0, 1) == "G") sSQL = "UPDATE [TabGroup] SET [GPer] = '" + stPer + "' WHERE [GID] =" + sTabKey.Substring(1);
                else sSQL = sSQL = "UPDATE [TabUser] SET [Per] = '" + stPer + "' WHERE [UserName] ='" + sTabKey.Substring(1) + "'";
                objCon = new Connection();
                if (objCon.EXEUpdate(sSQL)) MessageBox.Show("Cập nhật thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Lỗi, Cập nhật thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
            catch { }
        }


        private void tSBClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();    
        }

        private void tvwUser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if ((sTabKey.Substring(0, 1) == "U") && (sTabKey.Length > 1))
                    {
                        tsmtStatus.Visible = true;
                        tsmtStep.Visible = true;
                    }
                    else
                    {
                        tsmtStatus.Visible = false;
                        tsmtStep.Visible = false;
                    }
                }
                catch { }
                this.cMSTreeview.Left = e.X;
                this.cMSTreeview.Top = e.Y;
                this.cMSTreeview.Show(MousePosition); 
            }
        }

        private void tsmtAdd_Click(object sender, EventArgs e)
        {
            if (sTabKey=="") return; 
            if (sTabKey.Substring(0, 1) == "G")
            {
                FrmGroup objGp = new FrmGroup();
                objGp.GID = 0;
                objGp.ShowDialog();
                if (objGp.Action) Load_Account();
            }
            else
            {
                FrmupdtUser objUU = new FrmupdtUser();
                objUU.txtUserName.Text = "";
                objUU.ShowDialog();
                if (objUU.Action) Load_Account();
            }
        }

        private void tsmtEdit_Click(object sender, EventArgs e)
        {
            if (sTabKey == "") return;
            if (sTabKey.Substring(0, 1) == "G")
            {
                FrmGroup objGp = new FrmGroup();
                objGp.GID = int.Parse(sTabKey.Substring(1)) ;
                objGp.ShowDialog();
                if (objGp.Action) Load_Account();
            }
            else
            {
                FrmupdtUser objUU = new FrmupdtUser();
                objUU.txtUserName.Text = sTabKey.Substring(1);
                objUU.ShowDialog();
                if (objUU.Action) Load_Account();
            }
        }

        private void tsmtDelete_Click(object sender, EventArgs e)
        {
            if (sTabKey == "") return;
            if (sTabKey.Substring(0, 1) == "G")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá nhóm này không?", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection SqlCon = new SqlConnection(objCon.strConnectionString);
                    SqlCon.Open();
                    SqlCommand Cmd = SqlCon.CreateCommand();
                    Cmd.CommandText = "DELETE FROM [TabGroup] WHERE [GID] = " + sTabKey.Substring(1);
                    Cmd.ExecuteNonQuery();
                    SqlCon.Close();
                    SqlCon.Dispose();
                    Load_Account();
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này không?", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CheckUser(sTabKey.Substring(1)) || CheckEmpExitstInRep(sTabKey.Substring(1)))
                    {
                        MessageBox.Show("Tài khoản này đang sử dụng, không thể xoá!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return; 
                    }
                    SqlConnection SqlCon = new SqlConnection(objCon.strConnectionString);
                    SqlCon.Open();
                    SqlCommand Cmd = SqlCon.CreateCommand();
                    Cmd.CommandText = "DELETE FROM [TabUser] WHERE [UserName] = '" + sTabKey.Substring(1) + "'";
                    Cmd.ExecuteNonQuery();
                    SqlCon.Close();
                    SqlCon.Dispose();
                    Load_Account();
                }
            }
        }

        #region method CheckAccount
        private bool CheckUser(string sUserName)
        {
            try 
            {
            string sqlQuery = "SELECT Login FROM [TabUser] WHERE [UserName] = '" + sUserName + "'";
            string strValue = "0";
            SqlConnection sqlCon = new SqlConnection(objCon.strConnectionString);
            sqlCon.Open();
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandText = sqlQuery;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                strValue = rd["Login"].ToString();
            }
            rd.Close();
            rd.Dispose();
            sqlCon.Close();
            sqlCon.Dispose();
            if (strValue != "0") return true;
            else return false ;
            }
            catch { return false; }
        }
        #endregion

        #region Method CheckEmpExitstInRep
        public bool CheckEmpExitstInRep(string tmpAutoID)
        {
            bool  tmp = false;
            SqlConnection SqlCon = new SqlConnection(objCon.strConnectionString);
            SqlCon.Open();
            try
            {

                SqlCommand Cmd = SqlCon.CreateCommand();

                Cmd.CommandText = "select  RepID from TabRepList WHERE [EmpID]='" + tmpAutoID + "'  union select  RetailID from TabRetailsList WHERE [EmpID]='" + tmpAutoID + "'  union select  RetailTransactionID from TabRetailTransaction WHERE [SellBy]='" + tmpAutoID + "'  union select  EPVoucherId from TabEPaymentVoucher  WHERE [EntryBy]='" + tmpAutoID + "'  union select  IPVoucherId from TabIPaymentVoucher   WHERE [EntryBy]='" + tmpAutoID + "'";
                SqlDataReader Rd = Cmd.ExecuteReader();
                if (Rd.HasRows)
                {
                    tmp = true;
                }
                Rd.Close();
                Rd.Dispose();
                SqlCon.Close();
                SqlCon.Dispose();
                return tmp; 
            }
            catch
            {
                return tmp; 
            }
        }
        #endregion

        private void tvWPerGroup_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode objTno = new TreeNode();
                objTno = e.Node;
                for (int i = 0; i < objTno.Nodes.Count; i++)
                {
                    objTno.Nodes[i].Checked = e.Node.Checked;
                }
            }
            catch { } 
        }

        private void tsmtStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (sTabKey == "") return;
                if (sTabKey.Substring(0, 1) == "U")
                {
                    objCon.SetUpdateLogin(sTabKey.Substring(1), 0);
                    Load_Account();
                }
            }
            catch { }
        }
    }
}