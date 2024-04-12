using System;
using System.Collections;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TVSSys
{
    public class Regis
    {
        #region method Declare ...
        private TVSSys.Connection objFunc = new TVSSys.Connection(); 
        private string strConnection = "";
        private TVS_LICENSE.TVSHR lice = new TVS_LICENSE.TVSHR(); 
        #endregion

        #region method Regis
        public Regis()
        {
            this.strConnection = this.objFunc.strConnectionString;
        } 
        #endregion

        #region method CheckForRes
        public bool CheckForRes()
        {
            bool Res = false;
            string CDKey = this.GetCDKey(InsertInfo("Win32_Processor"));
            if (CDKey.ToUpper() == this.GetSerial().ToUpper())
            {
                Res = true;
            } return Res;
        } 
        #endregion        

        #region method GetCDKey
        public string GetCDKey(string Source)
        {
            string Result = "";
            Result = lice.GetCDKey(Source); 
            // Code Old
            //string[] A1 = { "A", "L", "O", "F", "U", "U", "A", "N", "G", "P", "L", "K", "J", "H", "G", "F", "D", "S", "A", "Z", "X", "C", "V", "B", "N", "M" };
            //string[] A2 = { "T", "V", "S", "H", "R", "U", "A", "N", "G", "P", "O", "H", "L", "K", "N", "A", "S", "D", "F", "C", "V", "Z", "X", "M", "J", "B" };
            //if (Source != "")
            //{
            //    Result = this.CryptographyMD5(Source);
            //    char[] A = Result.ToCharArray(0, Result.Trim().Length);
            //    Result = "";
            //    for (int j = 0; j < 20; j++)
            //    {
            //        if (j % 2 == 1)
            //        {
            //            Result += A1[int.Parse(A[j].ToString())];
            //        }
            //        else
            //        {
            //            Result += A2[int.Parse(A[j].ToString())];
            //        }
            //    }
            //}
            // END Code Old
            return Result;
        } 
        #endregion

        #region method GetSerial
        public string GetSerial()
        {
            clsConfigXML objXML = new clsConfigXML();
            return  objXML.GetKey("License");
        }       
        #endregion

        #region method InsertInfo
        public string InsertInfo(string Key)
        {
            string ProcessorID = "";

            ProcessorID = lice.InsertInfo(Key);
            // Code Old
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + Key);

            //try
            //{
            //    foreach (ManagementObject share in searcher.Get())
            //    {
            //        foreach (PropertyData PC in share.Properties)
            //        {
            //            if (PC.Name.ToUpper() == "PROCESSORID")
            //            {
            //                if (PC.Value != null && PC.Value.ToString() != "")
            //                {
 
            //                    switch (PC.Value.GetType().ToString())
            //                    {
            //                        case "System.String[]":
            //                            string[] str = (string[])PC.Value;

            //                            string str2 = "";
            //                            foreach (string st in str)
            //                                str2 += st + " ";

            //                            ProcessorID = str2;

            //                            break;
            //                        case "System.UInt16[]":
            //                            ushort[] shortData = (ushort[])PC.Value;


            //                            string tstr2 = "";
            //                            foreach (ushort st in shortData)
            //                                tstr2 += st.ToString() + " ";

            //                            ProcessorID = tstr2;

            //                            break;

            //                        default:
            //                            ProcessorID = PC.Value.ToString();
            //                            break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}         
            //catch (Exception exp)
            //{
            //    MessageBox.Show("can't get data because of the followeing error \n" + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            // END Code Old

            return ProcessorID;
        }
        #endregion

        #region Method CryptographyMD5
        public string CryptographyMD5(string source)
        {
            string result = "";
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider objMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(source);
                byte[] bytHash = objMD5.ComputeHash(buffer);
                foreach (byte a in bytHash)
                {
                    result += int.Parse(a.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
                }
            }
            catch
            {
            }
            return result;
        }
        #endregion
    }
}
