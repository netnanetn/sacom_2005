using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;    

namespace TVSSys
{
    public partial class FrmConnectData : Form
    {
        #region method Declare ...
        private TVSSys.Connection objFunc = new TVSSys.Connection();
        private TVSSys.clsConfigXML objCfig = new clsConfigXML();
        private TVSSys.dataBase objDataBase = new TVSSys.dataBase();
        private bool sOption = false; 
        #endregion

        #region method FrmConnectData
        public FrmConnectData()
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
            try
            {
                this.Height = 220; 
                this.txtServerName.Text = objCfig.GetKey("ServerName");
                this.txtDataName.Text = objCfig.GetKey("DataBase");
                this.txtUserName.Text = objCfig.GetKey("UserID");
                this.txtPassWord.Text = objCfig.GetKey("PassWord");

                cboType.Items.Add(new TVSSys.ItemCombobox("Tài khoản máy", "0"));
                cboType.Items.Add(new TVSSys.ItemCombobox("Tài khoản máy - Attach", "1"));
                cboType.Items.Add(new TVSSys.ItemCombobox("Tài khoản CSDL", "2"));

                if ((objCfig.GetKey("AccountType")) == "2")
                {
                    this.txtUserName.Enabled = true;
                    this.txtPassWord.Enabled = true;
                }
                else
                {
                    this.txtUserName.Enabled = false;
                    this.txtPassWord.Enabled = false;
                }

                cboType.SelectedIndex = int.Parse(objCfig.GetKey("AccountType"));
                if ((objCfig.GetKey("InStall")) == "0")
                {
                    DateTime dt = DateTime.Now;
                    this.txtDataName.Text = this.txtDataName.Text + dt.Month.ToString("00") + dt.Day.ToString("00");    
                    if (!objDataBase.CheckConnect(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), cboType.SelectedIndex.ToString())) return;
                    if (objDataBase.CheckDatabase(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), this.txtDataName.Text.ToString(), cboType.SelectedIndex.ToString())) return;
                    try
                    {
                        frmProgressBar frmbar = new frmProgressBar();
                        frmbar.sServerName = this.txtServerName.Text;
                        frmbar.sUserName = this.txtUserName.Text;
                        frmbar.sPassWord = this.txtPassWord.Text;
                        frmbar.sDataName = this.txtDataName.Text;
                        frmbar.sType = cboType.SelectedIndex.ToString();
                        frmbar.sFileName = "TVSDATAFULL.sql"; 
                        frmbar.ShowDialog();
                    }
                    catch 
                    {
                    }
                    if (!objDataBase.CheckDatabase(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), this.txtDataName.Text.ToString(), cboType.SelectedIndex.ToString())) return;
                    this.UpdateConnection();
                    this.Close();
                }
            }
            catch { }
        } 
        #endregion

        #region method cmdUpdate_Click
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;   
            try
            {
                if (!objDataBase.CheckConnect(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi kết nối với máy chủ", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!objDataBase.CheckDatabase(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), this.txtDataName.Text.ToString(), cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return;
                }
                this.UpdateConnection();
                MessageBox.Show("Cập nhật thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            catch
            {
                MessageBox.Show("Lỗi, Cập nhật không thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
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
            tmp.BackColor = GlobalModule.objColorLeave;
        }
        #endregion

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!objDataBase.CheckConnect(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), cboType.SelectedIndex.ToString()))
            {
                MessageBox.Show("Lỗi kết nối với máy chủ", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    MessageBox.Show("Kết nối với máy chủ thành công.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string StrConnString = "Server = '" + this.txtServerName.Text.Trim() + "'; Initial Catalog = master; Integrated Security=True;";
                    SqlConnection SqlCon = new SqlConnection(StrConnString);
                    SqlCon.Open();
                    string sqlQuery = "SELECT NAME,STATE_DESC FROM sys.databases ORDER BY NAME";
                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlQuery, SqlCon);
                    DataSet ds = new DataSet();
                    sqlDA.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 4)
                    {
                        txtDataName.Items.Clear();  
                        for (int i = 4; i < dt.Rows.Count; i++)
                        {
                            txtDataName.Items.Add(new TVSSys.ItemCombobox(dt.Rows[i][0].ToString(), dt.Rows[i][0].ToString()));
                        }
                    }
                    SqlCon.Close();
                }
                catch { }
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex ==0)
            {
                this.txtUserName.Enabled = false;
                this.txtPassWord.Enabled = false;
            }
            else
            {
                this.txtUserName.Enabled = true;
                this.txtPassWord.Enabled = true;
            }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            try
            {
                sOption = !sOption;
                if (sOption)
                {
                    btnOption.Text = "  Thu nhỏ";
                    this.btnOption.Image = global::TVSSys.Properties.Resources.Option1;
                    this.Height = 315; 
                }
                else
                {
                    btnOption.Text = "  Mở rộng";
                    this.btnOption.Image = global::TVSSys.Properties.Resources.Option0;
                    this.Height = 220;
                }
            }
            catch
            {

            }

        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!objDataBase.CheckConnect(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi kết nối với máy chủ", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn khởi tạo cơ sở dữ liệu tự động không?\n\nViệc khởi tạo này sẽ xoá cơ sở dữ liệu đang có", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        frmProgressBar frmbar = new frmProgressBar();
                        frmbar.sServerName = this.txtServerName.Text;
                        frmbar.sUserName = this.txtUserName.Text;
                        frmbar.sPassWord = this.txtPassWord.Text;
                        frmbar.sDataName = this.txtDataName.Text;
                        frmbar.sType = cboType.SelectedIndex.ToString();
                        frmbar.sFileName = "TVSDATA.sql";
                        frmbar.ShowDialog();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi, Khởi tạo Cơ sở dữ liệu không thành công...", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }
                if (!objDataBase.CheckDatabase(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), this.txtDataName.Text.ToString(), cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.UpdateConnection();
                MessageBox.Show("Khởi tạo thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi, Khởi tạo không thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAttachDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!objDataBase.CheckConnect(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi kết nối với máy chủ", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn Đính kèm Cơ sở dữ liệu?", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (!objDataBase.AttachDatabase(this.txtServerName.Text, this.txtUserName.Text, this.txtPassWord.Text, this.txtDataName.Text, cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi, Đính kèm Cơ sở dữ liệu không thành công...", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else MessageBox.Show("Đính kèm thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objCfig.UpdateKey("ServerName", txtServerName.Text);
                objCfig.UpdateKey("DataBase", txtDataName.Text);
                objCfig.UpdateKey("UserID", txtUserName.Text);
                objCfig.UpdateKey("PassWord", txtPassWord.Text);
                objCfig.UpdateKey("AccountType", cboType.SelectedIndex.ToString());
                Connection.strConnection = "";
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnBackUpDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!objDataBase.CheckConnect(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi kết nối với máy chủ", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn Sao Lưu Cơ sở dữ liệu?", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (!objDataBase.BackUpDatabase(this.txtServerName.Text, this.txtUserName.Text, this.txtPassWord.Text, this.txtDataName.Text, cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi, Sao Lưu Cơ sở dữ liệu không thành công...", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else MessageBox.Show("Sao Lưu thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnRestoreDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!objDataBase.CheckConnect(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi kết nối với máy chủ", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn Khôi phục Cơ sở dữ liệu?\r\nBạn nên Sao Lưu dữ liệu trước khi khôi phục...", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (!objDataBase.RestoreDatabaseMaster(this.txtServerName.Text, this.txtUserName.Text, this.txtPassWord.Text, this.txtDataName.Text, cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi, Khôi phục Cơ sở dữ liệu không thành công...", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else MessageBox.Show("Khôi phục thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.UpdateConnection();
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!objDataBase.CheckConnect(this.txtServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), cboType.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Lỗi kết nối với máy chủ", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn Cập nhật Cơ sở dữ liệu,", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        objDataBase.runScripFile(this.txtServerName.Text, this.txtUserName.Text, this.txtPassWord.Text, this.txtDataName.Text, "TVSDataUpdate.sql", cboType.SelectedIndex.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi, Cập nhật Cơ sở dữ liệu không thành công...", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                MessageBox.Show("Cập nhật thành công", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #region method UpdateKey
        private bool UpdateConnection()
        {
            try
            {
                objCfig.UpdateKey("ServerName", txtServerName.Text);
                objCfig.UpdateKey("DataBase", txtDataName.Text);
                objCfig.UpdateKey("UserID", txtUserName.Text);
                objCfig.UpdateKey("PassWord", txtPassWord.Text);
                objCfig.UpdateKey("AccountType", cboType.SelectedIndex.ToString());
                objCfig.UpdateKey("InStall", "1");
                Connection.strConnection = "";
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}