using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace TVSReports
{
    public partial class frmReportViewer : Form
    {
        #region method Declare ...
        public string srptType = "";
        public string srptTitle = "";
        public string srptFullName= "";
        public string srptTitleDescription = "";
        public string srptTitleDescription1 = "";
        public DataTable srptTable;
        private DataDynamics.ActiveReports.ActiveReport3 report = null;
        private DataDynamics.ActiveReports.ActiveReport3 subreport = null;
        private string[] sTitleDescription;
        public string sIDScales = "";
        TVSSys.clsPublic objP = new TVSSys.clsPublic();


        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);

        #endregion

        #region method frmReportViewer
        public frmReportViewer()
        {
            InitializeComponent();
        } 
        #endregion

        #region method frmReportViewer_Load
        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                #region SetPrint
                if ((srptType != "Bill88") && (srptType != "Bill88Logo"))
                    Set_DefaultPrinter("SetPrintBillDefault");                
                else                
                    Set_DefaultPrinter("SetPrintBill88");
                #endregion

                switch (srptType)
                {
                    case "Bill88":
                        {
                            
                            TVSReports.rptBill88.sIDScales = this.sIDScales; 
                            report = new TVSReports.rptBill88();
                            break;
                        }
                    

                    case "Bill65":
                        {
                            TVSReports.rptBill65.sIDScales = this.sIDScales;
                            report = new TVSReports.rptBill65();
                            break;
                        }
                    case "Bill47":
                        {
                            TVSReports.rptBill47.sIDScales = this.sIDScales;
                            report = new TVSReports.rptBill47();
                            break;
                        }

                    case "Bill88Logo":
                        {
                            TVSReports.rptBill88Logo.sIDScales = this.sIDScales;
                            report = new TVSReports.rptBill88Logo();
                            break;
                        }

                    case "Bill65Logo":
                        {
                            TVSReports.rptBill65Logo.sIDScales = this.sIDScales;
                            report = new TVSReports.rptBill65Logo();
                            break;
                        }
                    case "Bill47Logo":
                        {
                            TVSReports.rptBill47Logo.sIDScales = this.sIDScales;
                            report = new TVSReports.rptBill47Logo();
                            break;
                        }
                    case "List":
                        {
                            TVSReports.rptList.srptTable = this.srptTable;
                            TVSReports.rptList.srptTitle = this.srptTitle; 
                            TVSReports.rptList.srptTitleDescription = this.srptTitleDescription;
                            TVSReports.rptList.srptTitleDescription1 = this.srptTitleDescription1;
                            TVSReports.rptList.srptFullName = this.srptFullName;
                            report = new TVSReports.rptList();
                            break;
                        }
                }
                viewer1.Document = report.Document;
                report.Run();
            }
            catch { }
            Cursor.Current = Cursors.Default;
        } 
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string sPathFile = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\EXCEL\\" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xls";
                try
                {
                    System.IO.FileInfo fr = new System.IO.FileInfo(sPathFile);
                    fr.Delete();
                }
                catch { }
                DataDynamics.ActiveReports.Export.Xls.XlsExport x = new DataDynamics.ActiveReports.Export.Xls.XlsExport();
                x.FileFormat = DataDynamics.ActiveReports.Export.Xls.FileFormat.Xls97Plus;
                x.MinRowHeight = 0;
                x.UseCellMerging = true;
                x.Export(viewer1.Document, sPathFile);
                MessageBox.Show("Kết xuất dữ liệu thành công.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(sPathFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Kết xuất dữ liệu không thành công." + System.Environment.NewLine +ex.ToString()  , "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReportViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.Return) viewer1.Document.Print();   
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string sPathFile = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\PDF\\" + DateTime.Now.ToString("yyyyMMddHHmm") + ".pdf";
                try
                {
                    System.IO.FileInfo fr = new System.IO.FileInfo(sPathFile);
                    fr.Delete();
                }
                catch { }
                DataDynamics.ActiveReports.Export.Pdf.PdfExport p = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
                p.NeverEmbedFonts = "Aria";
                p.Export(viewer1.Document, sPathFile);
                MessageBox.Show("Kết xuất dữ liệu thành công.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(sPathFile);
            }
            catch
            {
                MessageBox.Show("Lỗi, Kết xuất dữ liệu không thành công.", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void document_EndPrint(object  sender ,PrintEventArgs e )
        {
            
        }

        #region DefaultPrinter
        public static string Get_DefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                {
                    return printer;
                }
            }
            return string.Empty;
        }

        public static bool Set_DefaultPrinter(string sTypePrinter)
        {
            TVSMain.clsConfigXML objConfig = new TVSMain.clsConfigXML();
            string sName = objConfig.GetKey(sTypePrinter);
            if (sName != Get_DefaultPrinter())
            {
                //MessageBox.Show("1: " + sName); 
                SetDefaultPrinter(sName);
                //MessageBox.Show("2: " + sName);  
            }
            return false;
        }

        #endregion
    }
}