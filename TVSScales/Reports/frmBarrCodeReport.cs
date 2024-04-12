using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using C1.Win.C1TrueDBGrid;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Excel_12 = Microsoft.Office.Interop.Excel;



namespace TVSReports
{
    public partial class frmBarrCodeReport : Form
    {
        #region method Declare ...
        public string UserName = "",FullName="";
        public string sTab = "";
        private System.Data.DataTable objdata = new System.Data.DataTable();
        private System.Data.DataTable objdataBarCode = new System.Data.DataTable();
        private string sUnitText = " (Kg)", sUnitFormat = "#,##0.000", sUnit = "1", sRepType="Bill88";
        private string sBarrCode="";
        private int Count = 0;
        
        #endregion

        public frmBarrCodeReport()
        {
            InitializeComponent();
        }

        private void c1TrueDBGrid1_Error(object sender, C1.Win.C1TrueDBGrid.ErrorEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Lỗi kiểu dữ liệu", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                ltvReport.Items.Clear();
                ltvReport.Items.Add("rpt0", "Báo cáo thống kê", 0);
                ltvReport.Items.Add("rpt1", "In chi tiết", 1);
                ltvReport.Items.Add("rpt2", "Xuất Excel", 2);


                TVSMain.clsConfigXML objCfig = new TVSMain.clsConfigXML();
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
                sRepType = objCfig.GetKey("RepType");
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            } 
        }

        private void c1TrueDBGrid1_FilterChange(object sender, EventArgs e)
        {
            this.Set_RowFilter();
        }
        
        #region method RowFilter
        private void Set_RowFilter()
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
        #endregion


        private System.Data.DataTable Get_DataView(C1TrueDBGrid sDBGrid)
        {
            try
            {
                BindingSource bs = (BindingSource)sDBGrid.DataSource;
                System.Data.DataTable dt = (System.Data.DataTable)bs.DataSource;
                System.Data.DataTable objdt = new System.Data.DataTable();
                objdt = dt.Copy();
                objdt.Rows.Clear();
                for (int sRow = 0; sRow < sDBGrid.RowCount; sRow++)
                {
                    DataRow dr = objdt.NewRow();
                    for (int i = 0; i < sDBGrid.Columns.Count; ++i)
                    {
                        if (c1TrueDBGrid1.Columns[i].CellText(sRow) != "")
                        {
                            dr[i] = c1TrueDBGrid1.Columns[i].CellText(sRow);
                        }
                    }
                    objdt.Rows.Add(dr);
                }
                objdt.Columns.Remove("FileName");
                objdt.Columns.Remove("FileName1");  
                return objdt;
            }
            catch
            {
                return null;
            }
        }


        #region ExportExcel
        private void ExportExcelDataView()
        {
            try
            {
                System.Data.DataTable objdt = Get_DataView(c1TrueDBGrid1);
                objdt.Columns.Remove("ID");
                objdt.Columns.Remove("ScalesDate");
                objdt.Columns.Remove("Size0");
                objdt.Columns.Remove("Size1");
                objdt.Columns.Remove("Size2");
                objdt.Columns.Remove("Size3");
                objdt.Columns.Remove("Machine");
                objdt.Columns.Remove("Line");
                objdt.Columns.Remove("Standard");
                objdt.Columns.Remove("Temperature");
                objdt.Columns.Remove("TemperatureCode");
                objdt.Columns.Remove("NameScalesGroup");
                objdt.Columns.Remove("Printed");

                if (objdt.Rows.Count == 0) return;
                Cursor.Current = Cursors.WaitCursor;

                ApplicationClass excel = new ApplicationClass();
                excel.Application.Workbooks.Add(true);

                Excel_12.Application oExcel_12 = null;                //Excel_12 Application
                Excel_12.Workbook oBook = null;                       // Excel_12 Workbook
                Excel_12.Sheets oSheetsColl = null;                   // Excel_12 Worksheets collection
                //Excel_12.Worksheet oSheet = null;                     // Excel_12 Worksheet
                //Excel_12.Range oRange = null;                         // Cell or Range in worksheet
                Object oMissing = System.Reflection.Missing.Value;
                oExcel_12 = new Excel_12.Application();

                // Make Excel_12 invisible to the user.
                oExcel_12.Visible = false;

                // Set the UserControl property so Excel_12 won't shut down.
                oExcel_12.UserControl = false;

                // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
                // Add a workbook.
                oBook = oExcel_12.Workbooks.Add(oMissing);
                // Get worksheets collection
                oSheetsColl = oExcel_12.Worksheets;
                FillSheetByQuery(oSheetsColl, objdt);
                // oBook.Password="123456";
                string sPathFile = AppDomain.CurrentDomain.BaseDirectory.ToString() + "TVSExcel.xls";
                try
                {
                    System.IO.FileInfo fr = new System.IO.FileInfo(sPathFile);
                    fr.Delete();
                }
                catch { }
                oBook.SaveCopyAs(sPathFile);
                // Release the variables.
                oBook.Close(false, oMissing, oMissing);
                oBook = null;

                oExcel_12.Quit();
                oExcel_12 = null;

                // Collect garbage.
                GC.Collect();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Kết xuất dữ liệu thành công.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(sPathFile);
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Lỗi, Kết xuất dữ liệu không thành công.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region method FillSheetByQuery
        private void FillSheetByQuery(Excel_12.Sheets oSheetsColl, System.Data.DataTable ds)
        {
            if (ds.Rows.Count > 0)
            {
                Excel_12.Worksheet oSheet = null;
                Excel_12.Range oRange = null;
                Excel_12.Range xlEntireColumn = null;
                oSheet = (Excel_12.Worksheet)oSheetsColl.get_Item("Sheet1");
                // Xuat tieu de

                int sRowHeader = 1;

                oRange = (Excel_12.Range)oSheet.Cells[sRowHeader, 1];
                oRange.Value2 = "PHIẾU NHẬP KHO";
                oRange.HorizontalAlignment = 3;
                oRange.VerticalAlignment = 3;
                oRange.Font.Size = 15;
                oRange.Font.Bold = true;
                oRange.get_Range("A1", "I1").Merge(false);


                sRowHeader = 2;
                string sDescription = "";
                oRange = (Excel_12.Range)oSheet.Cells[sRowHeader, 1];
                oRange.Value2 = sDescription;
                oRange.HorizontalAlignment = 3;
                oRange.VerticalAlignment = 3;
                oRange.Font.Size = 13;
                oRange.Font.Bold = true;
                oRange.get_Range("A1", "I1").Merge(false);

                for (int j = 0; j < ds.Columns.Count; j++)
                {
                    oRange = (Excel_12.Range)oSheet.Cells[sRowHeader + 1, j + 1];
                    oRange.Value2 = c1TrueDBGrid1.Columns[ds.Columns[j].ColumnName].Caption;
                    oRange.Font.Bold = true;
                }
                // Xuat du lieu

                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Columns.Count; j++)
                    {
                        oRange = (Excel_12.Range)oSheet.Cells[i + sRowHeader + 2, j + 1];
                        oRange.Value2 = ds.Rows[i][j];
                        xlEntireColumn = oRange.EntireColumn;
                        xlEntireColumn.AutoFit();
                    }
                }
            }
        }
        #endregion 
        #endregion

        private void ltvReport_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string sDescription = "";
                string strReport = ltvReport.SelectedItems[0].ImageIndex.ToString();

                if (strReport != "2")
                {
                    TVSReports.frmReportViewer objReport = new TVSReports.frmReportViewer();
                    objReport.WindowState = FormWindowState.Maximized;
                    switch (strReport)
                    {
                        case "0":
                            {
                                objReport.srptType = "List";
                                objReport.srptTable = Get_DataView(c1TrueDBGrid1);
                                objReport.srptFullName=this.UserName; 
                                break;
                            }
                        case "3":
                            {
                                #region Total
                                if (c1TrueDBGrid1.RowCount == 0) break;
                                string sSQLRep = "";
                                for (int i = 0; i < c1TrueDBGrid1.RowCount; i++)
                                {
                                    sSQLRep += "'" + c1TrueDBGrid1.Columns["SoPhieu"].CellValue(i).ToString() + "',";
                                }
                                if (sSQLRep.Length > 0) sSQLRep = sSQLRep.Remove(sSQLRep.Length - 1);
                                TVSSys.Connection objCon = new TVSSys.Connection();
                                string sSQL = "select convert(nvarchar(10),NgayCan,103) as NgayCan,TenLoaihang, sum(Khoiluong1) as Khoiluong1, sum(Khoiluong2) as Khoiluong2,sum(KhoiluongTong) as KhoiluongTong,sum(TapchatTheoKg) as TapchatTheoKg, sum(KhoiluongHang) as KhoiluongHang" +
                                            " from TblCan" +
                                            " left join TblLoaihang on TblLoaihang.IdLoaihang=TblCan.IdLoaihang" +
                                            " Where SoPhieu In (" + sSQLRep + ")" +
                                            " Group by convert(nvarchar(10),NgayCan,103) ,TenLoaihang " +
                                            " Order by convert(nvarchar(10),NgayCan,103),TenLoaihang ";
                                objReport.srptTable = objCon.EXESelect(sSQL);
                                objReport.srptType = "ListTotal";
                                break;
                                #endregion
                            }
                        case "1":
                            {
                                TVSSys.Connection objCon = new TVSSys.Connection();
                                objCon.EXEUpdate("Update TblCan Set Printed=1 where Id=" + c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString());
                                objReport.srptType = sRepType;
                                objReport.sIDScales = c1TrueDBGrid1.Columns["ID"].CellValue(c1TrueDBGrid1.Row).ToString();
                                break;
                            }


                    }
                    objReport.srptTitleDescription1 = this.TxtDescription.Text;
                    objReport.ShowDialog();
                }
                else
                {
                    ExportExcelDataView();
                }
            }
            catch
            {
            }
            Cursor.Current = Cursors.Default;
        }

        

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                string sWhereSeach = " where Rep In ('";
                sBarrCode += this.txtBarcode.Text+",";
                string sBarrCodeCopy = sBarrCode;
                this.txtBarcode.Text = "";  
                for (int i = 0; i <= Count; i++)
                    if (i == 0)
                    {
                        sWhereSeach += sBarrCodeCopy.Split(',')[i] + "'";
                    }
                    else
                        sWhereSeach += ",'" + sBarrCodeCopy.Split(',')[i] + "'";
                sWhereSeach += " )";
                Count++;
                string sSQL = " Select TabScales.Id as ID,Rep,Technology,ScalesDate" +
                         ",Size,Size0,Size1,Size2,round(Size3,3) as Size3,Type,Machine,Line,Standard,Temperature,TemperatureCode" +
                         ",(Value0 * cast(" + sUnit + " as int)) as Value0,Robin,(Value1 * cast(" + sUnit + " as int)) as Value1 " +
                         " ,NameScalesGroup,FileName,FileName1,Printed,Fullname,(case when (isnull(Note,'')='') then '-' else Note end ) as Note" +
                         " from TabScales " +
                         " left join TabUser on TabUser.Username=TabScales.IdNguoican" +
                         " left join TabScalesGroup on TabScalesGroup.IDScalesGroup=TabScales.IDScalesGroup" +
                        " " + sWhereSeach +
                        " order by TabScales.Id desc";

                TVSSys.Connection objCon = new TVSSys.Connection();
                objdata = objCon.EXESelect(sSQL);
                BindingSource bindsrc = new BindingSource();
                bindsrc.DataSource = objdata;
                bNagGrid.BindingSource = bindsrc;
                c1TrueDBGrid1.DataSource = bindsrc;
                TVSMain.clsGridView objGv = new TVSMain.clsGridView();
                objGv.Set_GridViewScales1(c1TrueDBGrid1, sUnitFormat, sUnitText);
                
            }
        }



    }
}