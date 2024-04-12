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
    public partial class frmProgressBarBK : Form
    {
        #region method Declare ...
        private dataBase objDataBase=new dataBase();
        private TVSSys.clsConfigXML objCfig = new TVSSys.clsConfigXML();  
        public bool sOk = false;
        #endregion
        public frmProgressBarBK()
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

        #region method DeleteBackupFile
        private void DeleteBackupFile()
        {
            try
            {
                int sBkCount = 30;
                try
                {
                    sBkCount = int.Parse(objCfig.GetKey("BackupCount"));
                }
                catch { }
                if ((sBkCount > 1000) || (sBkCount < 5))
                {
                    sBkCount = 5;
                }
                string sPath = AppDomain.CurrentDomain.BaseDirectory + "DataBackup";  

                DataTable objTable = new DataTable();
                DataColumn colAdd = new DataColumn("Name");
                colAdd.DataType = System.Type.GetType("System.String");
                objTable.Columns.Add(colAdd);
                DirectoryInfo di = new DirectoryInfo(sPath);
                FileInfo[] rgFiles = di.GetFiles("*.bak");
                //FileInfo[] rgFiles = di.GetFiles();
                foreach (FileInfo fi in rgFiles)
                {
                    DataRow dr = objTable.NewRow();
                    dr[0] = fi.Name.ToString();
                    objTable.Rows.Add(dr);
                }

                DataView objV = objTable.DefaultView;
                objV.Sort = "Name";
                DataTable sDt = objV.ToTable();

                if (sDt.Rows.Count > sBkCount)
                {
                    for (int i = 0; i < sDt.Rows.Count - sBkCount; i++)
                    {
                        System.IO.File.Delete(sPath +"\\" + sDt.Rows[i][0].ToString());
                    }
                }
            }
            catch { }
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                objDataBase.BackUpDatabase(objCfig.GetKey("ServerName"), objCfig.GetKey("UserID"), objCfig.GetKey("PassWord"), objCfig.GetKey("DataBase"), objCfig.GetKey("AccountType"));
                DeleteBackupFile();
            }
            catch { }
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