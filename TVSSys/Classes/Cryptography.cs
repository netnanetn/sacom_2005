using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using Microsoft.SqlServer.Management.Common;    
   

namespace TVSSys
{
    public class Cryptography
    {       
        #region Method CryptographyMD5
        public string CryptographyMD5(string source)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider objMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(source);
            byte[] bytHash = objMD5.ComputeHash(buffer);
            string result = "";
            foreach (byte a in bytHash)
            {
                result += int.Parse(a.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
            }
            //result = EncodeMD5(result);
            return result;
        }
        #endregion

        #region Method EncodeMD5
        private string EncodeMD5(string source)
        {
            string sSourcre = EncodeString(source);
            return sSourcre;
        }
        #endregion

        #region EncodeChar
        private static readonly string[] EncodeChar = new string[]   
        {   
            "%aoeudiy&#",   
            "0",   
            "1",   
            "2",   
            "3",   
            "4",   
            "5",   
            "6",   
            "7",   
            "8",   
            "9"
        };
        #endregion

        #region EncodeString
        private string EncodeString(string tmpstr)
        {
            try
            {
                string str = tmpstr;
                for (int i = 1; i < EncodeChar.Length; i++)
                {
                    for (int j = 0; j < EncodeChar[i].Length; j++)
                        str = str.Replace(EncodeChar[i][j], EncodeChar[0][i - 1]);
                }
                return str;
            }
            catch
            {
                return "";
            }
        }
        #endregion
        
    }

}
