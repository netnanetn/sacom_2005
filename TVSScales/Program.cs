using System;
using System.Net;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO; 

namespace TVSMain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        // </summary>
        [STAThread]
        static void Main()
        {
            TVSSys.dataBase objdb = new TVSSys.dataBase();       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string instanceName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            Process[] processes = Process.GetProcessesByName(instanceName);  
            if(processes.Length>1)
            {
                MessageBox.Show("Chương trình đang được sử dụng", "Thông báo - Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return; 
            }

            //if (!objdb.CheckConnect())
            //{
            //    TVSSys.FrmConnectData frmCon = new TVSSys.FrmConnectData();
            //    frmCon.ShowDialog();
            //}
            //if (!objdb.CheckDatabase())
            //{
            //    TVSSys.FrmConnectData frmCon = new TVSSys.FrmConnectData();
            //    frmCon.ShowDialog();
            //}
            //if (objdb.CheckDatabase())
            if (1==1)
            {
                TVSSys.Regis objRes = new TVSSys.Regis();



                string strRegister = "4CGBBR58DF6F68V";
                //string strRegister = objRes.InsertInfo("Win32_Processor"); 
                string CDKey = objRes.GetCDKey(strRegister.Trim());
                clsPublic clsPub = new clsPublic();
                int totalItem = clsPub.Get_TotalItem();
                if (((CDKey.ToUpper() == objRes.GetSerial().ToUpper() && clsPub.Check_CDKey(CDKey.ToUpper()))) || (totalItem < 100))
                {
                    TVSSys.frmLogin objLogin = new TVSSys.frmLogin();
                    objLogin.ShowDialog();
                    if (objLogin.OK)
                    {
                        TVSMain objfrm = new TVSMain();
                        objfrm.UserName = objLogin.UserName;
                        objfrm.FullName = objLogin.FullName;
                        objfrm.ShowDialog();
                    }
                }
                else
                {
                    try
                    {
                        TVSSys.FrmRegister objResDx = new TVSSys.FrmRegister();
                        objResDx.ShowDialog();
                    }
                    catch
                    {
                    }
                }  
            } 
        }
    }
}