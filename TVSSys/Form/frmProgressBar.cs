using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace TVSSys
{
    public partial class frmProgressBar : Form
    {
        #region method Declare ...
        private dataBase objDataBase=new dataBase(); 
        public string sServerName="",sUserName="",sPassWord="",sDataName="",sType="1";
        public string sFileName = "";
        public bool sOk = false; 
        #endregion
        public frmProgressBar()
        {
            InitializeComponent();
        }



        private void frm_Load(object sender, EventArgs e)
        {
            try
            {
                sOk = false; 
                backgroundWorker1.RunWorkerAsync();
            }
            catch { }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                objDataBase.createDatabase(sServerName, sUserName, sPassWord, sDataName, sType);
                int iProgressPercentage = 50;
                backgroundWorker1.ReportProgress(iProgressPercentage);
                objDataBase.runScripFile(sServerName, sUserName, sPassWord, sDataName, sFileName, sType);
            }
            catch
            {
                return;
            }
        }

        

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum) sOk = true; 
            this.Close(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar2.Value == progressBar2.Maximum) progressBar2.Value = 0;
            progressBar2.Value += 1;  
        }
    }
}