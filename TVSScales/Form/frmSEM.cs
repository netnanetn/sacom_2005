using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using C1.Win.C1TrueDBGrid;
using System.IO.Ports;
using System.IO;

using AForge.Video;
using AForge.Video.DirectShow;

namespace TVSMain
{
    public partial class frmSEM : Form
    {


        #region method Declare ...
        public string UserName = "",Permission = "";
        private bool sPerEdit=false; 
        public string sTabTable = "", tmpValue1 = "", tmpValue2 = "";
        private DataTable objdata = new DataTable();
        private string sRepIndex = "";
        private clsConfigXML objCfig = new clsConfigXML();
        private string sUnitText = " (Kg)", sUnitFormat = "#,##0.000", sUnit = "1";
        private string sIDScales = "0";
        private TVSSys.Connection objCon = new TVSSys.Connection();
        public static string sStation = "";
        #endregion

        #region method Declare PortCom ...

        string bufferSUM = "";
        int count = 0, check1 = 0, sMax = 0, sStart=0;
        double sMaxValue = 1;
        string buffer1 = "", buffer2 = "", buffer3 = "", bufferkq1 = "";
        public static int int1, j;
        char char2;
        private delegate void SetTextDeleg(string text);
        #endregion

        #region method Declare Video ...

        FilterInfoCollection videoDevices;

        private string sFileNameIn="", sFileNameIn1="";
        #endregion

        #region Mothod FormCode
        public frmSEM()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            
            this.dtpDate.Value = DateTime.Now;
            this.TxtRep.Text = "AUTO";  
            //this.cbbSize.Text = "";
            //this.cbbRobin.Text = "";
            //this.cbbType.Text = "";
            //this.cbbMachine.Text = "";
            //this.cbbLine.Text = "";
            //this.cbbStandard.Text = "";
            //this.cbbTemperature.Text = ""; 
            this.cbbRobin.Focus();
            this.btnPrint.Enabled = false;
            this.btnEdit.Enabled = false;   
            this.btnDelete.Enabled = false;
            this.btnUpdate.Enabled = true;
            chkInfo.Checked = true;
            sIDScales = "0";
            this.c1TrueDBGrid1.Enabled = false;   
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            chkInfo.Checked = false;
            this.btnPrint.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnUpdate.Enabled = true;
            this.Load_Detail(); 
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.cbbSize.Text == "")
            {
                MessageBox.Show("Lỗi, Bạn chưa chọn kích thước đường kính.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbbSize.Focus(); 
                return;
            }
            if (this.cbbRobin.Text == "")
            {
                MessageBox.Show("Lỗi, Bạn chưa cập nhật khối lượng Robin.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbbRobin.Focus();
                return;
            }
            
            if (this.cbbType.Text == "")
            {
                MessageBox.Show("Lỗi, Bạn chưa cập nhật loại vật liệu cần cân.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbbType.Focus();
                return;
            }
            if (this.cbbMachine.Text == "")
            {
                MessageBox.Show("Lỗi, Bạn chưa cập nhật máy sản xuất.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbbMachine.Focus();
                return;
            }
            if (this.cbbLine.Text == "")
            {
                MessageBox.Show("Lỗi, Bạn chưa cập nhật Dây chuyền sản xuất.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbbLine.Focus();
                return;
            }
            if (this.cbbStandard.Text == "")
            {
                MessageBox.Show("Lỗi, Bạn chưa cập nhật tiêu chuẩn.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbbStandard.Focus();
                return;
            }

            if (this.cbbTemperature.Text == "")
            {
                MessageBox.Show("Lỗi, Bạn chưa cập nhật Cấp nhiệt độ.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbbTemperature.Focus();
                return;
            }
            if (double.Parse(this.TxtTotal.Text) <=0)
            {
                MessageBox.Show("Lỗi, Khối lượng cân không hợp lệ.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (objCon.Get_EXESelectInt("Select count(Id) from TabScales Where Technology=N'" + TxtTechnology.Text.Trim() + "'") > 0)
            {
                MessageBox.Show("Lỗi, Phiếu công nghệ này đã được sử dụng.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TxtTechnology.Focus();  
                return;
            }
            if (!TxtTechnology.Text.Trim().Contains(cbbLine.Text.Trim()))
            {
                MessageBox.Show("Lỗi, Phiếu công nghệ này không phù hợp với dây chuyền.!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TxtTechnology.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có đồng ý khối lượng hàng: " + this.TxtTotal.Text + sUnitText + "?", "TVS - Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;


            if (chkInfo.Checked) this.Set_Video(0); 
            this.SaveData();
        }

        private void c1TrueDBGrid1_Error(object sender, C1.Win.C1TrueDBGrid.ErrorEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Lỗi kiểu dữ liệu", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmScales_Load(object sender, EventArgs e)
        {
            SetPermission();

            clsConfigXML objCfig = new clsConfigXML();
            sStation = objCfig.GetKey("Station");
            if (objCfig.GetKey("Unit") != "Kg")
            {
                sUnitText = " (g)";
                sUnitFormat = "#,##0";
                sUnit = "1000";
            }
            else
            {
                sUnit = "1";
                sUnitText = " (Kg)";
                sUnitFormat = "#,##0.000";
            }

            TVSSys.clsPublic objcP = new TVSSys.clsPublic();
            objcP.LoadComboBox("SELECT * FROM TabSize ORDER BY NameSize", cbbSize, "IDSize", "NameSize");
            objcP.LoadComboBox("SELECT * FROM TabType ORDER BY NameType", cbbType, "IDType", "NameType");
            objcP.LoadComboBox("SELECT * FROM TabRobin ORDER BY NameRobin", cbbRobin, "IDRobin", "NameRobin");
            objcP.LoadComboBox("SELECT * FROM TabMachine ORDER BY NameMachine", cbbMachine, "IDMachine", "NameMachine");
            objcP.LoadComboBox("SELECT * FROM TabLine ORDER BY NameLine", cbbLine, "IDLine", "NameLine");
            objcP.LoadComboBox("SELECT * FROM TabStandard ORDER BY NameStandard", cbbStandard, "IDStandard", "NameStandard");
            objcP.LoadComboBox("SELECT * FROM TabTemperature ORDER BY NameTemperature", cbbTemperature, "IDTemperature", "NameTemperature");
            this.Load_List();

            this.Get_PortComParams(this.serialPort1);
            this.Get_Video();

            if (sPerEdit) this.btnDelete.Enabled = true;
            else this.btnDelete.Enabled = false;
            this.cbbRobin.Focus();  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.TxtRep.Text != "AUTO")
            {
                if (!sPerEdit)
                {
                    MessageBox.Show(" Bạn không có quyền xóa hóa đơn này ?", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (objCon.EXEUpdate("Delete from TabScales Where Rep='" + this.TxtRep.Text + "'"))
                {
                    MessageBox.Show(" Xóa thành công.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_List();
                    this.btnAddNew.PerformClick();  
                }
                else MessageBox.Show(" Lỗi, xóa không thành công.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Lỗi. Hóa đơn chưa được cập nhật ?", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void TxtReturn_TextChanged(object sender, EventArgs e)
        {
            double sTotal = 0, sValue0 = 0, sValue1 = 0;
            try
            {
                sValue0 = double.Parse(objCon.Get_EXESelect("Select CodeRobin from TabRoBin Where IDRobin=" + cbbRobin.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                sValue1 = double.Parse(this.TxtReturn.Text.Trim());
            }
            catch { }
            sTotal = sValue1 - sValue0;
            this.TxtTotal.Text = sTotal.ToString(sUnitFormat);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Load_List();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();  
            }
            catch { }
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
                            try
                            {
                                serialPort1.Close();
                            }
                            catch { }
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
                case Keys.F8:
                    {
                        this.btnDelete.Focus();
                        this.btnDelete.PerformClick();
                        break;
                    }
                case Keys.F6:
                    {
                        this.btnUpdate.Focus();
                        this.btnUpdate.PerformClick();
                        break;
                    }
            }

        }

        private void frmScales_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.StopCameras();
            try
            {
                serialPort1.Close();
            }
            catch { }
        }

        #region method txtTextBox
        private void txtEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tmp = (System.Windows.Forms.TextBox)sender;
            tmp.BackColor = TVSSys.GlobalModule.objColorEnter;
        }
        private void txtLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tmp = (System.Windows.Forms.TextBox)sender;
            tmp.BackColor = TVSSys.GlobalModule.objColorLeave;
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                System.Windows.Forms.TextBox tmp = (System.Windows.Forms.TextBox)sender;
                if (tmp.Name == "TxtNote") this.btnUpdate.Focus();
                else SendKeys.Send("{TAB}");
            }
        }

        private void txtDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void txtDigit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox tmp = (System.Windows.Forms.TextBox)sender;
                tmp.Text = double.Parse(tmp.Text).ToString("#,##0");
                tmp.SelectionStart = tmp.Text.Length;
            }
            catch { }
        }
        #endregion


        private void Load_List()
        {
            try
            {
                this.c1TrueDBGrid1.Enabled = true;   
                string sWhere = "";
                sWhere = " DatePart(Day,TabScales.ScalesDate)=" + dtpDate.Value.Day + " and DatePart(Month,TabScales.ScalesDate)=" + dtpDate.Value.Month + " and DatePart(year,TabScales.ScalesDate)=" + dtpDate.Value.Year;
                if (sWhere != "") sWhere = " Where  " + sWhere + " AND IDScalesGroup=0";
                string sSQL = " Select TabScales.Id as ID,Rep,ScalesDate" +
                        " ,Size,Type,Machine,Line,Standard,Temperature,TemperatureCode" +
                        ",(Value0 * cast(" + sUnit + " as int)) as Value0,Robin,RobinName,(Value1 * cast(" + sUnit + " as int)) as Value1 " +
                        " ,FileName,FileName1,Printed,Fullname,Technology,Note" +
                        " from TabScales " +
                        " left join TabUser on TabUser.Username=TabScales.IdNguoican" +
                        " " + sWhere+
                        " and Station='" + sStation + "' order by TabScales.Id desc";

                objdata = objCon.EXESelect(sSQL);
                BindingSource bindsrc = new BindingSource();
                bindsrc.DataSource = objdata;
                bNagGrid.BindingSource = bindsrc;
                c1TrueDBGrid1.DataSource = bindsrc;
                clsGridView objGv = new clsGridView();
                objGv.Set_GridViewScales(this.c1TrueDBGrid1, sUnitFormat,sUnitText);
                Load_Detail();

                this.btnEdit.Enabled = true;
                this.btnDelete.Enabled = true;
                this.btnPrint.Enabled = true;
                this.btnUpdate.Enabled = false;  
            }
            catch { }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
           // if (this.TxtRep.Text != "AUTO") 
                
                this.Load_List();
        }

        private void c1TrueDBGrid1_RowColChange(object sender, RowColChangeEventArgs e)
        {
            if (e.LastRow != c1TrueDBGrid1.Row) Load_Detail();
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
                        if (dc.DataType.Name == "String") sWhere += dc.DataField + " LIKE '%" + dc.FilterText + "%'";
                        else sWhere += dc.DataField + " = '" + dc.FilterText + "'";
                    }
                }
                this.objdata.DefaultView.RowFilter = sWhere;
            }
            catch { return; }
        }

        private void c1TrueDBGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (sFileNameIn != "")
                {
                    frmPictures objfrm = new frmPictures();
                    objfrm.sPerEdit = this.sPerEdit;  
                    objfrm.sRep = this.TxtRep.Text.Trim();
                    objfrm.ShowDialog();
                }
            }
            catch { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                objCon.EXEUpdate("Update TabScales Set Printed=1 where Id=" + c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString());
                clsConfigXML objCfig = new clsConfigXML();
                string sRepType= objCfig.GetKey("RepType");
                if (objCfig.GetKey("RepPrintView") == "0")
                {
                    #region SetPrint
                    if ((sRepType != "Bill88") && (sRepType != "Bill88Logo"))
                        TVSReports.frmReportViewer.Set_DefaultPrinter("SetPrintBillDefault");
                    else
                        TVSReports.frmReportViewer.Set_DefaultPrinter("SetPrintBill88");
                    #endregion

                    
                    DataDynamics.ActiveReports.ActiveReport3 report = new DataDynamics.ActiveReports.ActiveReport3();
                    switch (sRepType)
                    {
                        case "Bill88":
                            {
                                TVSReports.rptBill88.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                report = new TVSReports.rptBill88();
                                break; 
                            }
                        case "Bill65":
                            {
                                TVSReports.rptBill65.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                report = new TVSReports.rptBill65();
                                break; 
                            }
                        case "Bill47":
                            {
                                TVSReports.rptBill47.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                report = new TVSReports.rptBill47();
                                break;
                            }
                        case "Bill88Logo":
                            {
                                TVSReports.rptBill88Logo.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                report = new TVSReports.rptBill88Logo();
                                break;
                            }
                        case "Bill65Logo":
                            {
                                TVSReports.rptBill65Logo.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                report = new TVSReports.rptBill65Logo();
                                break;
                            }
                        case "Bill47Logo":
                            {
                                TVSReports.rptBill47Logo.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                report = new TVSReports.rptBill47Logo();
                                break;
                            }
                    }
                    report.Run();
                    report.Document.Print(false, true);
                }
                else
                {
                    TVSReports.frmReportViewer objReport = new TVSReports.frmReportViewer();
                    objReport.WindowState = FormWindowState.Maximized;
                    objReport.srptType = sRepType;
                    objReport.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                    objReport.ShowDialog();
                }

                #region sRepType2
                string sRepType2 = objCfig.GetKey("RepType2");
                if (sRepType2 != "")
                {
                    
                    System.Threading.Thread.Sleep(1000);

                    if (objCfig.GetKey("RepPrintView") == "0")
                    {
                        #region SetPrint
                        if ((sRepType2 != "Bill88") && (sRepType2 != "Bill88Logo"))
                            TVSReports.frmReportViewer.Set_DefaultPrinter("SetPrintBillDefault");
                        else
                        {
                            TVSReports.frmReportViewer.Set_DefaultPrinter("SetPrintBill88");
                        }
                        #endregion


                        DataDynamics.ActiveReports.ActiveReport3 report = new DataDynamics.ActiveReports.ActiveReport3();
                        switch (sRepType2)
                        {
                            case "Bill88":
                                {
                                    TVSReports.rptBill88.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                    report = new TVSReports.rptBill88();
                                    break;
                                }
                            case "Bill65":
                                {
                                    TVSReports.rptBill65.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                    report = new TVSReports.rptBill65();
                                    break;
                                }
                            case "Bill47":
                                {
                                    TVSReports.rptBill47.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                    report = new TVSReports.rptBill47();
                                    break;
                                }
                            case "Bill88Logo":
                                {
                                    TVSReports.rptBill88Logo.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                    report = new TVSReports.rptBill88Logo();
                                    break;
                                }
                            case "Bill65Logo":
                                {
                                    TVSReports.rptBill65Logo.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                    report = new TVSReports.rptBill65Logo();
                                    break;
                                }
                            case "Bill47Logo":
                                {
                                    TVSReports.rptBill47Logo.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                    report = new TVSReports.rptBill47Logo();
                                    break;
                                }
                        }
                        report.Run();
                        report.Document.Print(false, true);
                    }
                    else
                    {
                        TVSReports.frmReportViewer objReport = new TVSReports.frmReportViewer();
                        objReport.WindowState = FormWindowState.Maximized;
                        objReport.srptType = sRepType2;
                        objReport.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                        objReport.ShowDialog();
                    }
                }
                #endregion

                // this.Load_List();
               // this.btnAddNew.PerformClick();  
            }
            catch { }
        }

        #region method SaveData
        private void SaveData()
        {
            try
            {
                sRepIndex = this.TxtRep.Text;
                double sValue0 = 0, sValue1 = 0;
                try
                {
                    if (chkInfo.Checked) sValue0 = double.Parse(this.TxtReturn.Text.Trim());
                    else sValue0 = double.Parse(c1TrueDBGrid1.Columns["Value0"].CellValue(c1TrueDBGrid1.Row).ToString());
                }
                catch { }
                try
                {
                    if (chkInfo.Checked)  sValue1 = double.Parse(this.TxtTotal.Text.Trim());
                    else sValue1 = double.Parse(c1TrueDBGrid1.Columns["Value1"].CellValue(c1TrueDBGrid1.Row).ToString());
                }
                catch { }
                // Don vi chuan trong SQL la Kg
                sValue0 = sValue0 / float.Parse(sUnit);
                sValue1 = sValue1 / float.Parse(sUnit); 
                SqlConnection Con = new SqlConnection(objCon.strConnectionString);
                Con.Open();
                SqlCommand cmd = new SqlCommand("ActionOnTabScales", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Rep", SqlDbType.NVarChar, 50);
                cmd.Parameters["@Rep"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@ScalesDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@IDSize", SqlDbType.Int);
                cmd.Parameters.Add("@Size", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@Size0", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@Size1", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@IDSize2", SqlDbType.Int);
                cmd.Parameters.Add("@Size2", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@Size3", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@IDRobin", SqlDbType.Int);
                cmd.Parameters.Add("@Robin", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@IDType", SqlDbType.Int);
                cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@Line", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@IDStandard", SqlDbType.Int);
                cmd.Parameters.Add("@Standard", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@IDTemperature", SqlDbType.Int);
                cmd.Parameters.Add("@Temperature", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@Value0", SqlDbType.Float);
                cmd.Parameters.Add("@Value1", SqlDbType.Float);
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar, 300);
                cmd.Parameters.Add("@FileName1", SqlDbType.NVarChar, 300);
                cmd.Parameters.Add("@IdNguoican", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@IDScalesGroup", SqlDbType.Int);
                cmd.Parameters.Add("@Technology", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar, 300);
                cmd.Parameters.Add("@Act", SqlDbType.Int);
                cmd.Parameters.Add("@Station", SqlDbType.NVarChar, 250);
                //=====================================================
                cmd.Parameters["@Rep"].Value = this.TxtRep.Text.Trim();
                cmd.Parameters["@ScalesDate"].Value = this.dtpDate.Value;
                cmd.Parameters["@IDSize"].Value = this.cbbSize.SelectedValue.ToString();
                cmd.Parameters["@Size"].Value = this.cbbSize.Text.Trim();
                cmd.Parameters["@Size0"].Value = "";
                cmd.Parameters["@Size1"].Value = "";
                cmd.Parameters["@IDSize2"].Value = "0";
                cmd.Parameters["@Size2"].Value = "";
                cmd.Parameters["@Size3"].Value = "";
                cmd.Parameters["@IDRobin"].Value = this.cbbRobin.SelectedValue.ToString();
                cmd.Parameters["@Robin"].Value = this.cbbRobin.Text.Trim();
                cmd.Parameters["@IDType"].Value = this.cbbType.SelectedValue.ToString();  
                cmd.Parameters["@Type"].Value = cbbType.Text;
                cmd.Parameters["@Machine"].Value = this.cbbMachine.Text;
                cmd.Parameters["@Line"].Value = this.cbbLine.Text;
                cmd.Parameters["@IDStandard"].Value = this.cbbStandard.SelectedValue.ToString();  
                cmd.Parameters["@Standard"].Value = this.cbbStandard.Text;
                cmd.Parameters["@IDTemperature"].Value = this.cbbTemperature.SelectedValue.ToString();  
                cmd.Parameters["@Temperature"].Value = this.cbbTemperature.Text;
                cmd.Parameters["@Value0"].Value = sValue0;
                cmd.Parameters["@Value1"].Value = sValue1;
                cmd.Parameters["@FileName"].Value = this.sFileNameIn;
                cmd.Parameters["@FileName1"].Value = this.sFileNameIn1;
                cmd.Parameters["@IdNguoican"].Value = this.UserName;
                cmd.Parameters["@IDScalesGroup"].Value = 0;
                cmd.Parameters["@Technology"].Value = TxtTechnology.Text;
                cmd.Parameters["@Note"].Value = TxtNote.Text;
                cmd.Parameters["@Act"].Value = sIDScales;
                cmd.Parameters["@Station"].Value = sStation;
                cmd.ExecuteNonQuery();
                if (this.TxtRep.Text == "AUTO") this.TxtRep.Text = cmd.Parameters["@Rep"].Value.ToString();
                Con.Close();
                Con.Dispose();
                MessageBox.Show("Cập nhật thành công!" + this.cbbSize.Text.Trim(), "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Load_List();
                if (sRepIndex != "AUTO")
                {
                    for (int i = 0; i < c1TrueDBGrid1.RowCount; i++)
                    {
                        if (c1TrueDBGrid1.Columns["Rep"].CellValue(i).ToString() == sRepIndex)
                        {
                            c1TrueDBGrid1.Row = i;
                            c1TrueDBGrid1.Select();
                            break;
                        }
                    }
                }
                this.btnPrint.Enabled = true;   
                this.btnPrint.Focus();  
            }
            catch 
            {
                MessageBox.Show("Lỗi, cập nhật không thành công!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              
        } 
        #endregion

        #region method Combobox_Key
        private void Combobox_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox tmp = (System.Windows.Forms.ComboBox)sender;
            tmp.BackColor = TVSSys.GlobalModule.objColorEnter;
        }

        private void Combobox_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox tmp = (System.Windows.Forms.ComboBox)sender;
            tmp.BackColor = TVSSys.GlobalModule.objColorLeave;
        }
        private void Combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.F2)
            {
                System.Windows.Forms.ComboBox tmp = (System.Windows.Forms.ComboBox)sender;
                frmDir objfrm = new frmDir();
                switch (tmp.Name.Substring(3).ToUpper())
                {
                    case "SIZE": { objfrm.sTabTable = "KÍCH THƯỚC"; break; }
                    case "ROBIN": { objfrm.sTabTable = "KHỐI LƯỢNG BOBIN"; break; }
                    case "TYPE": { objfrm.sTabTable = "TÊN SẢN PHẨM"; break; }
                    case "MACHINE": { objfrm.sTabTable = "MÁY SẢN XUẤT"; break; }
                    case "LINE": { objfrm.sTabTable = "DÂY CHUYỀN"; break; }
                    case "STANDARD": { objfrm.sTabTable = "TIÊU CHUẨN"; break; }
                    case "TEMPERATURE": { objfrm.sTabTable = "CẤP NHIỆT ĐỘ"; break; }
                }
                objfrm.sSelect = true;
                objfrm.ShowDialog();
                if (objfrm.sEdit)
                {
                    TVSSys.clsPublic objcP = new TVSSys.clsPublic();
                    switch (tmp.Name.Substring(3).ToUpper())
                    {
                        case "SIZE": { objcP.LoadComboBox("SELECT * FROM TabSize ORDER BY NameSize", cbbSize, "IDSize", "NameSize"); break; }
                        case "ROBIN": { objcP.LoadComboBox("SELECT * FROM TabRobin ORDER BY NameRobin", cbbRobin, "IDRobin", "NameRobin"); break; }
                        case "TYPE": { objcP.LoadComboBox("SELECT * FROM TabType ORDER BY NameType", cbbType, "IDType", "NameType"); break; }
                        case "MACHINE": { objcP.LoadComboBox("SELECT * FROM TabMachine ORDER BY NameMachine", cbbMachine, "IDMachine", "NameMachine"); break; }
                        case "LINE": { objcP.LoadComboBox("SELECT * FROM TabLine ORDER BY NameLine", cbbLine, "IDLine", "NameLine"); break; }
                        case "STANDARD": { objcP.LoadComboBox("SELECT * FROM TabStandard ORDER BY NameStandard", cbbStandard, "IDStandard", "NameStandard"); break; }
                        case "TEMPERATURE": { objcP.LoadComboBox("SELECT * FROM TabTemperature ORDER BY NameTemperature", cbbTemperature, "IDTemperature", "NameTemperature"); break; }
                    }
                }
                if (objfrm.sSelect) tmp.Text = objfrm.sSelectValue1;
            }
        }
        #endregion

        private void Load_Detail()
        {
            try
            {
                this.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.TxtRep.Text = c1TrueDBGrid1.Columns["Rep"].CellValue(c1TrueDBGrid1.Row).ToString();
                DateTime dt = DateTime.Parse(c1TrueDBGrid1.Columns["ScalesDate"].CellValue(c1TrueDBGrid1.Row).ToString());
                this.cbbSize.Text = c1TrueDBGrid1.Columns["Size"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.cbbType.Text = c1TrueDBGrid1.Columns["Type"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.cbbRobin.Text = c1TrueDBGrid1.Columns["RobinName"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.cbbMachine.Text = c1TrueDBGrid1.Columns["Machine"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.cbbLine.Text = c1TrueDBGrid1.Columns["Line"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.cbbStandard.Text = c1TrueDBGrid1.Columns["Standard"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.cbbTemperature.Text = c1TrueDBGrid1.Columns["Temperature"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.TxtTotal.Text = double.Parse(c1TrueDBGrid1.Columns["Value1"].CellValue(c1TrueDBGrid1.Row).ToString()).ToString(sUnitFormat);
                this.sFileNameIn = c1TrueDBGrid1.Columns["FileName"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.sFileNameIn1 = c1TrueDBGrid1.Columns["FileName1"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.TxtTechnology.Text = c1TrueDBGrid1.Columns["Technology"].CellValue(c1TrueDBGrid1.Row).ToString();
                this.TxtNote.Text = c1TrueDBGrid1.Columns["Note"].CellValue(c1TrueDBGrid1.Row).ToString();
            }
            catch { }
        }

        #endregion

        #region Mothod PortCom
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
               // Lay du lieu theo kieu String
            //string data = serialPort1.ReadLine();
            //this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });




                ////  Lay du lieu theo kieu Byte
            while (serialPort1.BytesToRead > 0)
            {
                int1 = serialPort1.ReadByte();
                char2 = Convert.ToChar(int1);

                //   MessageBox.Show(char2 + "OK" + int1.ToString() );  

                if (char2 == (char)13)
                //if (char2 == ')')
                {
                    count = 0;
                    buffer1 = string.Copy("");
                    buffer2 = string.Copy("");
                    buffer3 = string.Copy("");
                    bufferSUM = string.Copy("");
                    check1 = 1;
                }
                if (check1 == 1)
                {
                    count++;
                    buffer1 = Convert.ToString(char2);
                    buffer3 = String.Concat(buffer2, buffer1);
                    buffer2 = String.Copy(buffer3);
                    bufferSUM = String.Copy(buffer3);
                }
            }
            //bufferkq1 = bufferSUM.Remove(0, 3);
            bufferkq1 = bufferSUM;
            if (bufferSUM.Length > sStart + sMax)
            {
                bufferkq1 = bufferSUM.Remove(0, sStart);
                this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { bufferkq1 });
            }

  
        }

        double sTempValue = 0;
        private void si_DataReceived(string data)
        {
            try
            {
                sTempValue = double.Parse(data.Trim().Replace(" ", "0"));
                if (sTempValue.ToString().Length > sMax) sTempValue = sTempValue / sMaxValue;
                TxtReturn.Text = sTempValue.ToString();
            }
            catch { }
        }

        private void Get_PortComParams(SerialPort sPort)
        {
            try
            {
                clsConfigXML objCfig = new clsConfigXML();
                sPort.PortName = objCfig.GetKey("PortName");
                sPort.BaudRate = int.Parse(objCfig.GetKey("BaudRate"));
                sPort.DataBits = int.Parse(objCfig.GetKey("DataBits"));
                switch (objCfig.GetKey("Parity"))
                {
                    case "N": { sPort.Parity = System.IO.Ports.Parity.None; break; }
                    case "O": { sPort.Parity = System.IO.Ports.Parity.Odd; break; }
                    case "E": { sPort.Parity = System.IO.Ports.Parity.Even; break; }
                }
                switch (objCfig.GetKey("StopBits"))
                {
                    case "1": { sPort.StopBits = System.IO.Ports.StopBits.One; break; }
                    case "1.5": { sPort.StopBits = System.IO.Ports.StopBits.OnePointFive; break; }
                    case "2": { sPort.StopBits = System.IO.Ports.StopBits.Two; break; }
                }
                try
                {
                    sMax = int.Parse(objCfig.GetKey("MaxNumber"));
                    sStart = int.Parse(objCfig.GetKey("StartNumber"));
                }
                catch { }

                sStart += 1;

                if (objCfig.GetKey("Unit") != "Kg") sMax = sMax - 3;
                if (sMax != 0)
                {
                    for (int i = 0; i < sMax; i++)
                        sMaxValue = sMaxValue * 10;
                }
                else sMaxValue = 1;
                sPort.Open();
            }
            catch { }
        }


        #endregion


        #region Mothod Video
        private void Get_Video()
        {

            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                this.StartCameras();
            }
            catch { }
        }

        private void Set_Video(int sInOut)
        {
            try
            {
                string sFileName = "";
                string sFileName1 = "";
                try
                {
                    clsConfigXML objCfig = new clsConfigXML();
                    sFileName = objCfig.GetKey("ServerPath");
                }
                catch
                {
                    sFileName = Application.StartupPath + "\\Pictures";
                }
                sFileName1 = sFileName + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfffA") + ".Bmp";
                sFileName += "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".Bmp";

                while (!CheckImage(sFileName))
                {
                    try
                    {
                        imgVideo1.Image.Save(sFileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    catch { System.Threading.Thread.Sleep(30); }
                }
                while (!CheckImage(sFileName1))
                {
                    try
                    {
                        imgVideo2.Image.Save(sFileName1, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    catch { System.Threading.Thread.Sleep(30); }
                }
                if (sInOut == 0)
                {
                    sFileNameIn = sFileName;
                    sFileNameIn1 = sFileName1;
                }
            }
            catch { }
        }


        private void StartCameras()
        {
            int sCamare0 = 0, sCamare1 = 0;
            clsConfigXML objCfig = new clsConfigXML();
            try
            {
            sCamare0 = int.Parse(objCfig.GetKey("CameraIndex0"));
            sCamare1 = int.Parse(objCfig.GetKey("CameraIndex1"));
            }
            catch { }
            try
            {
                VideoCaptureDevice videoSource1 = new VideoCaptureDevice(videoDevices[sCamare0].MonikerString);
                videoSource1.DesiredFrameRate = 25;
                videoSourcePlayer1.VideoSource = videoSource1;
                videoSourcePlayer1.Start();
            }
            catch { }

            try
            {
                if (sCamare1 != sCamare0)
                {
                    System.Threading.Thread.Sleep(500);

                    VideoCaptureDevice videoSource2 = new VideoCaptureDevice(videoDevices[sCamare1].MonikerString);
                    videoSource2.DesiredFrameRate = 25;

                    videoSourcePlayer2.VideoSource = videoSource2;
                    videoSourcePlayer2.Start();
                }
            }
            catch { }

            timer.Start();
        }

        private void StopCameras()
        {

            timer.Stop();

            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer2.SignalToStop();

            videoSourcePlayer1.WaitForStop();
            videoSourcePlayer2.WaitForStop();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                IVideoSource videoSource1 = videoSourcePlayer1.VideoSource;
                IVideoSource videoSource2 = videoSourcePlayer2.VideoSource;
            }
            catch { }
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                this.imgVideo1.Image = image;
            }
            catch { }
        }

        private void videoSourcePlayer2_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                this.imgVideo2.Image = image;
            }
            catch { }
        }

        private string GetTextFromImage(string getFileName)
        {
            string extractedText = "";
            //try
            //{
            //MODI.Document doc = new MODI.Document();
            //doc.Create(getFileName);
            //doc.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH, true, true);
            //MODI.Image img = (MODI.Image)doc.Images[0];
            //MODI.Layout layout = img.Layout;
            //for (int i = 0; i < layout.Words.Count; i++)
            //{
            //    MODI.Word word = (MODI.Word)layout.Words[i];

            //    if (extractedText.Length > 0)
            //    {
            //        extractedText += " ";
            //    }
            //    extractedText += word.Text;
            //}
            return extractedText;
            //}
            //catch
            //{
            //    return extractedText;
            //}
        }



        private bool CheckImage(string sfileName)
        {
            string sPath = objCfig.GetKey("ServerPath");
            DirectoryInfo di = new DirectoryInfo(sPath);
            FileInfo[] rgFiles = di.GetFiles();
            foreach (FileInfo fi in rgFiles)
            {
                if (sfileName == sPath + "\\" + fi.Name.ToString()) return true;
            }
            return false; 
        }

        #endregion


        #region Method SetPermission
        private void SetPermission()
        {
            TVSSys.Connection objCon = new TVSSys.Connection();
            this.Permission = objCon.GetSysPerUser(this.UserName);
            if (this.Permission.Contains("303"))
            {
                this.sPerEdit = true;
                this.chkInfo.Enabled = true;  
            }
        }
        #endregion

        private void label14_Click(object sender, EventArgs e)
        {

        }

        }
}