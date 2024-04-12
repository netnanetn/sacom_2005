using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data.SqlClient;
using System.Data;

namespace TVSReports
{
    public partial class rptList : DataDynamics.ActiveReports.ActiveReport3
    {        
        #region Declare variable to use
        private TVSSys.clsPublic objcP = new TVSSys.clsPublic();
        private clsReports objcR = new clsReports();
        public static string srptFullName = "";
        public static string srptTitle = "";
        public static string srptTitleDescription = "";
        public static string srptTitleDescription1 = "";
        public static DataTable srptTable;
        #endregion

        #region method rptList
        public rptList()
        {
            InitializeComponent();
            this.LblCompany.Text = this.objcP.getCompanyInfor("ComName");
            this.LblManager.Text = this.objcP.getCompanyInfor("ComManager");
            this.LblAddress.Text = this.objcP.getCompanyInfor("ComAddress");
            this.LblPhone.Text = this.objcP.getCompanyInfor("ComPhone");
            if (srptTitle != "") this.LblTitle.Text = srptTitle;
            if (srptTitleDescription != "") this.LblTitleDescription.Text = srptTitleDescription;
            if (srptTitleDescription1 != "") this.LblTitleDescription1.Text = srptTitleDescription1;
            if (srptFullName != "") this.label7.Text = srptFullName;
            this.label11.Text = "Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.ToString("MM") + " năm " + DateTime.Now.ToString("yyyy");
            try
            {
                picture1.Image = Image.FromFile("Images\\Logo.jpg");
            }
            catch { }
            this.DataSource = srptTable;
        } 
        #endregion

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            objcR.MakeSameHeight(this.detail);  
        }


    }


}
