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
    public partial class rptBill65 : DataDynamics.ActiveReports.ActiveReport3
    {        
        #region Declare variable to use
        private TVSSys.clsPublic objcP = new TVSSys.clsPublic();  
        public static string sIDScales = "";
        TVSSys.Connection objCon = new TVSSys.Connection();
        #endregion

        #region method rptBill65
        public rptBill65()
        {
            InitializeComponent();

            this.DataSource = Get_Data(sIDScales);
             
        } 
        #endregion

        private DataTable Get_Data(string IDScales)
        {
            try
            {
                string sSQL = " Select * from TabScales Where ID=" + IDScales;
                return objCon.EXESelect(sSQL);
            }
            catch
            {
                return null;
            }
        }     

    }


}
