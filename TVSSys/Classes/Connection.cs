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
    public class Connection
    {       
        #region method Declare ...
        public string strConnectionString = "";
        public static string strConnection = "";
        private TVSSys.clsConfigXML objCfig = new clsConfigXML();
        private SqlConnection conn;
        private string strPer = "";
        #endregion

        #region method Connection
        public Connection()
        {
            try
            {
                strConnectionString = GetStrConnectionString();
            }
            catch { }
        } 

        public string GetStrConnectionString()
        {
            if (strConnection == "")
            {
                string serverName = "", UserID = "", Pass = "", dataBase = "", StrConnectionString = "", sType = "0",DBAttachfile="";
                serverName = objCfig.GetKey("ServerName");
                UserID = objCfig.GetKey("UserID");
                Pass = objCfig.GetKey("PassWord");
                dataBase = objCfig.GetKey("DataBase");
                sType = objCfig.GetKey("AccountType");

                DBAttachfile = Application.StartupPath + "\\Data\\" + objCfig.GetKey("DBAttachfile");

                switch (sType)
                {
                    case "0":
                        {
                            StrConnectionString = "Server = " + serverName + "; Initial Catalog = " + dataBase + "; Integrated Security=SSPI;";
                            break; 
                        }
                    case "1":
                        { 
                            StrConnectionString = "Server=" + serverName + "; Initial Catalog=" + dataBase + "; User Id=" + UserID + "; pwd=" + Pass + ";";
                            break; 
                        }
                    case "2":
                        {
                            StrConnectionString = "Data Source=" + serverName + ";AttachDbFilename=" + DBAttachfile + ";Integrated Security=True;User Instance=True";
                            break; 
                        }
                }
                strConnection = StrConnectionString;
                strConnectionString = StrConnectionString;
                return StrConnectionString;
            }
            else return strConnection;
        }

        public DataTable EXESelect(string strSQL)
        {          
            conn = new SqlConnection(strConnectionString);
            conn.Open(); 
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable EXESelect(string Storedname, SqlParameter[] Parmeterarray)
        {
            conn = new SqlConnection(strConnectionString);
            conn.Open(); 
            DataTable dt = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand(Storedname, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(Parmeterarray);
                //command.CommandTimeout = 100;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch 
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public SqlDataAdapter EXEAdapter(string Storedname, SqlParameter[] Parmeterarray)
        {
            conn = new SqlConnection(strConnectionString);
            conn.Open(); 
            try
            {
                SqlCommand command = new SqlCommand(Storedname, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(Parmeterarray);
                //command.CommandTimeout = 100;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                return sqlDA;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool EXEUpdate(string strSQL)
        {
            conn = new SqlConnection(strConnectionString);
            conn.Open(); 
            SqlCommand sqlCmd = conn.CreateCommand();
            sqlCmd.CommandText = strSQL;
            sqlCmd.CommandType = CommandType.Text;
            //sqlCmd.CommandTimeout = 100;
            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool EXEUpdate(string Storedname, SqlParameter[] Parmeterarray)
        {
            conn = new SqlConnection(strConnectionString);
            conn.Open(); 
            SqlCommand command = new SqlCommand(Storedname, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(Parmeterarray);
            //command.CommandTimeout = 1000;
            try
            {
                int result = command.ExecuteNonQuery();
                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool EXEUpdateTimeout(string Storedname, SqlParameter[] Parmeterarray)
        {
            conn = new SqlConnection(strConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(Storedname, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(Parmeterarray);
            command.CommandTimeout = 350;
            try
            {
                int result = command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public string Get_EXESelect(string strSQL)
        {
            conn = new SqlConnection(strConnectionString);
            conn.Open(); 
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString(); 
                else return "";
            }
            catch
            {
                return "";
            }
            finally
            {
                conn.Close();
            }
        }

        public int Get_EXESelectInt(string strSQL)
        {
            conn = new SqlConnection(strConnectionString);
            conn.Open(); 
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0) return int.Parse(dt.Rows[0][0].ToString());
                else return 0;
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        #region method SetUpdateLogin
        public void SetUpdateLogin(string sAccount, int sLogin)
        {
            this.EXEUpdate("UPDATE [TabUser] SET [Login] =" + sLogin + ", [LogOff]=[LogOff]+1 Where UserName='" + sAccount + "'");
        }
        #endregion

        #region Method GetSysPer
        public string GetSysPerUser(string UserName)
        {
            string StrPer = "";
            DataTable dt = this.EXESelect("SELECT [Per] FROM [TabUser] WHERE [UserName] = '" + UserName + "'");
            if (dt.Rows.Count > 0) StrPer = dt.Rows[0][0].ToString();
            if (StrPer != "") StrPer = "IN(" + StrPer.Remove(StrPer.Length - 1, 1).Replace("\"", "") + ")";
            return StrPer;
        }
        public void SetPermissionUser(string UserName, string sIndex, Button sbtnButton)
        {
            strPer = GetSysPerUser(UserName);
            if (this.strPer.Contains(sIndex)) sbtnButton.Enabled = true;
            else sbtnButton.Enabled = false;
        }
        public void SetPermissionUser(string UserName, string sIndex, Button sbtnAdd, Button sbtnEdit, Button sbtnDelete)
        {
            strPer = GetSysPerUser(UserName);
            if (this.strPer.Contains(sIndex))
            {
                sbtnAdd.Enabled = true;
                sbtnEdit.Enabled = true;
                sbtnDelete.Enabled = true;
            }
            else
            {
                sbtnAdd.Enabled = false;
                sbtnEdit.Enabled = false;
                sbtnDelete.Enabled = false;
            }
        }
        public bool CheckPermissionUser(string UserName, string UserNameOld, string sIndex)
        {
            if (UserName == UserNameOld) return true;
            int sIndexNext = int.Parse(sIndex) + 3;
            strPer = GetSysPerUser(UserName);
            if (this.strPer.Contains(sIndexNext.ToString())) return true;
            else return false;
        }
        #endregion



    }

}
