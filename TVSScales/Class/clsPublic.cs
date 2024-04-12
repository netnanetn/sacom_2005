using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using C1.Win.C1TrueDBGrid;
using Microsoft.VisualBasic;
using System.IO;

namespace TVSMain
{
    public class clsPublic
    {       
        #region method Declare ...
        #endregion


        #region method clsPublic
        public clsPublic()
        {
           
        } 
        #endregion

        public DateTime GetServerDateTime()
        {
            try
            {
                TVSSys.Connection objCon = new TVSSys.Connection();
                DataTable dt = objCon.EXESelect("Select getdate()");
                return DateTime.Parse(dt.Rows[0][0].ToString());
            }
            catch { return DateTime.Now; }  
        }

        #region method TotalItem
        public int Get_TotalItem()
        {
            int sResult = 0;
            TVSSys.Connection  objCon = new TVSSys.Connection();
            sResult += objCon.Get_EXESelectInt("Select count(*) from TabScales");
            return sResult;
        }
        #endregion

        #region method Images

        #region method Load_StringImage
        public string Load_StringImage(string sCadre,  string sContent)
        {
            byte[] bImageFile;
            string sFileAttach = sCadre + ".ttt";
            string strAttach = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + sFileAttach;
            if (!File.Exists(strAttach))
            {
                bImageFile = Convert.FromBase64String(sContent);
                File.WriteAllBytes(strAttach, bImageFile);
            }
            return strAttach;
        }
        #endregion

        #region method UpLoad_StringImage
        public string UpLoad_StringImage(string strFile)
        {
            byte[] bImageFile;
            string strImageFile="";
            bImageFile = File.ReadAllBytes(strFile);
            strImageFile = Convert.ToBase64String(bImageFile);
            return strImageFile;
        }
        #endregion

        #region method Delete_StringImage
        public void Delete_StringImage(string sCadre)
        {
            try
            {
                string sFileAttach = sCadre + ".ttt";
                string strAttach = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + sFileAttach;
                File.Delete(strAttach);
            }
            catch { }
        }
        #endregion

        #endregion


        public void SetSessionImage()
        {
            DateTime DateSever = GetServerDateTime();
            int i = -10;
            DateTime DateOld = DateAndTime.DateAdd(DateInterval.Day, i, DateSever);
            TVSSys.Connection objCon = new TVSSys.Connection();
            objCon.EXEUpdate("Update TabScales Set FileName='',FileName1='' where convert(nvarchar(10),ScalesDate,102)<'" + DateOld.ToString("yyyy.MM.dd") + "'");

            string sDateOld = DateOld.ToString("yyyyMMdd");
            string sLastName = "";
            clsConfigXML objCfig = new clsConfigXML();
            DirectoryInfo di = new DirectoryInfo(objCfig.GetKey("ServerPath"));
            //FileInfo[] rgFiles = di.GetFiles("*.bmp");
            FileInfo[] rgFiles = di.GetFiles();
            foreach (FileInfo fi in rgFiles)
            {
                sLastName = fi.Name.ToString().Substring(0, 8);
                try
                {
                    if (int.Parse(sLastName) <= int.Parse(sDateOld)) fi.Delete();
                }
                catch { }
            }
        }


        public bool Check_CDKey(string sKey)
        {
            try
            {
                string sListKey = "" +
                                ",UUQNAUNHQUNIIAIPAAIP" + // chuyển sang may mới.  UUQUIPNUAUIAIUPUNUAU
                                ",UUQUIPNUAUIAIUPUNUAU" + // 24/02/2016
                                ",UANNAHUIPUQAUNQUUUIQ" + // 05/03/2016
                                "";

                return sListKey.Contains(sKey);
            }
            catch { return false; }
        }

    }
}
 