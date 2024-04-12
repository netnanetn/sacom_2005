using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using C1.Win.C1TrueDBGrid;

namespace TVSMain
{
    public partial class frmDir : Form
    {


        #region method Declare ...
        public string UserName = "";
        public string sTabTable = "KHÁCH HÀNG";
        private string sTab = "TblKhachhang";
        private string sTabID = "", sTabName = "";
        private DataTable objdata = new DataTable();

        public bool sEdit = false;
        public bool sSelect = false;
        public string sSelectValue1 = "", sSelectValue2 = "", sSelectValue3="";
        #endregion

        public frmDir()
        {
            InitializeComponent();
        }

        #region Mothod FromCode
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.c1TrueDBGrid1.AllowAddNew = true;
            this.c1TrueDBGrid1.AllowUpdate = true;
            this.c1TrueDBGrid1.MoveLast();
            this.c1TrueDBGrid1.Row = this.c1TrueDBGrid1.Row + 1;
            this.c1TrueDBGrid1.Select();
            this.c1TrueDBGrid1.Columns[sTabName].Value = "Cập nhật dữ liệu";
            this.c1TrueDBGrid1.AllowAddNew = false;
            this.Set_ModeButton("Update");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (objdata.GetChanges() == null) return;
                TVSSys.Connection objCon = new TVSSys.Connection();
                SqlConnection Con = new SqlConnection(objCon.strConnectionString);
                Con.Open();
                SqlCommand cmd = new SqlCommand("Select * from " + sTab, Con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(objdata.GetChanges());
                objdata.AcceptChanges();
                this.Set_ModeButton("Load");
                this.sEdit = true;  
            }
            catch { }
        }

        private void c1TrueDBGrid1_Error(object sender, C1.Win.C1TrueDBGrid.ErrorEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Lỗi kiểu dữ liệu", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Set_DBGrid(string sTab)
        {
            try
            {

                sTabID = "ID" + sTab.Substring(3) ;
                sTabName = "Name" + sTab.Substring(3);
                c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
                c1TrueDBGrid1.Splits[0].DisplayColumns[sTabName].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                c1TrueDBGrid1.Splits[0].DisplayColumns[sTabName].HeadingStyle.WrapText = true;  
                c1TrueDBGrid1.Columns[sTabName].Caption = sTabTable.ToUpper();

                this.Text = "THÔNG TIN " + sTabTable.ToUpper();

                try
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns["Code" + sTab.Substring(3)].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                    c1TrueDBGrid1.Splits[0].DisplayColumns["Code" + sTab.Substring(3)].HeadingStyle.WrapText = true;
                    c1TrueDBGrid1.Columns["Code" + sTab.Substring(3)].Caption = "GIÁ TRỊ";
                }
                catch { }
                if (sTab == "TabRobin")
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns["CodeRep" + sTab.Substring(3)].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                    c1TrueDBGrid1.Splits[0].DisplayColumns["CodeRep" + sTab.Substring(3)].HeadingStyle.WrapText = true;
                    c1TrueDBGrid1.Columns["CodeRep" + sTab.Substring(3)].Caption = "GIÁ TRỊ SỐ PHIẾU";
                }
            }
            catch
            {
            }
        }
        private void Set_sTabTable(string sTabTable)
        {
            try
            {
                switch (sTabTable)
                {
                    case "KÍCH THƯỚC": { sTab = "TabSize"; break; }
                    case "TÊN SẢN PHẨM": { sTab = "TabType"; break; }
                    case "KHỐI LƯỢNG BOBIN": { sTab = "TabRobin"; break; }
                    case "MÁY SẢN XUẤT": { sTab = "TabMachine"; break; }
                    case "DÂY CHUYỀN": { sTab = "TabLine"; break; }
                    case "CẤP NHIỆT ĐỘ": { sTab = "TabTemperature"; break; }
                    case "TIÊU CHUẨN": { sTab = "TabStandard"; break; }
                    case "BỀ RỘNG": { sTab = "TabSize0"; break; }
                    case "BỀ DÀY": { sTab = "TabSize1"; break; }
                    case "BÁN KÍNH GÓC": { sTab = "TabSize2"; break; }
                    case "ĐƠN VỊ": { sTab = "TabUnit"; break; }
                }
            }
            catch { }
        }
        private void Set_ModeButton(string sMode)
        {
            try
            {
                switch (sMode)
                {
                    case "Load":
                        {
                            this.c1TrueDBGrid1.AllowUpdate = false;
                            this.btnEdit.Enabled = true;
                            this.btnDelete.Enabled = true;
                            this.btnUpdate.Enabled = false;
                            this.btnCancel.Enabled = false;
                            break;
                        }
                    case "Update":
                        {
                            this.btnEdit.Enabled = false;
                            this.btnDelete.Enabled = false;
                            this.btnUpdate.Enabled = true;
                            this.btnCancel.Enabled = true;
                            break;
                        }
                }
            }
            catch
            {
            }
        }
        private void frmDir_Load(object sender, EventArgs e)
        {
            Set_sTabTable(sTabTable);
            TVSSys.Connection objCon = new TVSSys.Connection();
            objdata = objCon.EXESelect("Select * from " + sTab);
            BindingSource bindsrc = new BindingSource();
            bindsrc.DataSource = objdata;
            bNagGrid.BindingSource = bindsrc;
            c1TrueDBGrid1.DataSource = bindsrc;
            Set_DBGrid(sTab);
            this.Set_ModeButton("Load");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                TVSSys.Connection objCon = new TVSSys.Connection();
                objdata = new DataTable();
                objdata = objCon.EXESelect("Select * from " + sTab);
                BindingSource bindsrc = new BindingSource();
                bindsrc.DataSource = objdata;
                bNagGrid.BindingSource = bindsrc;
                c1TrueDBGrid1.DataSource = bindsrc;
                Set_DBGrid(sTab);
                this.Set_ModeButton("Load");
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa thông tin này ?...", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            TVSSys.Connection objCon = new TVSSys.Connection();
            if (objCon.EXEUpdate("Delete from " + sTab + "  Where " + sTabID + "=" + c1TrueDBGrid1.Columns[sTabID].CellValue(c1TrueDBGrid1.Row)))
            {
                MessageBox.Show("Xóa thành công!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                objCon = new TVSSys.Connection();
                objdata = objCon.EXESelect("Select * from " + sTab);
                BindingSource bindsrc = new BindingSource();
                bindsrc.DataSource = objdata;
                bNagGrid.BindingSource = bindsrc;
                c1TrueDBGrid1.DataSource = bindsrc;
                Set_DBGrid(sTab);
            }
            else MessageBox.Show("Lỗi, xóa không thành công!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.c1TrueDBGrid1.AllowUpdate = true;
            this.Set_ModeButton("Update");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDir_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        if (btnUpdate.Enabled)
                        {
                            this.btnCancel.Focus();
                            this.btnCancel.PerformClick();
                        }
                        else
                        {
                            this.sSelect = false;  
                            this.Close();
                        }
                        break;
                    }
                case Keys.F4:
                    {
                        this.btnAddNew.Focus();
                        this.btnAddNew.PerformClick();
                        break;
                    }
                case Keys.F5:
                    {
                        this.btnEdit.Focus();
                        this.btnEdit.PerformClick();
                        break;
                    }
                case Keys.F6:
                    {
                        this.btnUpdate.Focus();
                        this.btnUpdate.PerformClick();
                        break;
                    }
                case Keys.F8:
                    {
                        this.btnDelete.Focus();
                        this.btnDelete.PerformClick();
                        break;
                    }
            }

        }

        private void c1TrueDBGrid1_DoubleClick(object sender, EventArgs e)
        {

            if ((sSelect) & (!this.btnUpdate.Enabled))
            {
                try
                {
                    sSelectValue1 = c1TrueDBGrid1.Columns[sTabName].CellValue(c1TrueDBGrid1.Row).ToString();
                }
                catch { }
                this.Close();
            }
        }

        private void c1TrueDBGrid1_RowColChange(object sender, RowColChangeEventArgs e)
        {
            if (sSelect)
            {
                try
                {
                    sSelectValue1 = c1TrueDBGrid1.Columns[sTabName].CellValue(c1TrueDBGrid1.Row).ToString();
                }
                catch { }
            }
        }

        private void c1TrueDBGrid1_FilterChange(object sender, EventArgs e)
        {
            try
            {
                string sWhere = "";
                foreach (C1.Win.C1TrueDBGrid.C1DataColumn dc in this.c1TrueDBGrid1.Columns)
                {
                    if (dc.FilterText.Length > 0)
                    {
                        if (sWhere != "") sWhere += " AND ";
                        if (dc.DataType.ToString() != "System.String") sWhere += dc.DataField + "=" + dc.FilterText;
                        else sWhere +=dc.DataField + " LIKE '%" + dc.FilterText + "%'";
                    }
                }
                this.objdata.DefaultView.RowFilter = sWhere;
            }
            catch { return; }
        } 
        #endregion

        private void c1TrueDBGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            { 
                if ((sSelect) & (!this.btnUpdate.Enabled))
                {
                    try
                    {
                        sSelectValue1 = c1TrueDBGrid1.Columns[sTabName].CellValue(c1TrueDBGrid1.Row).ToString();
                    }
                    catch { }
                    this.Close();
                }
            }
        }
    }
}