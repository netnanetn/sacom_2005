using System;
using System.Data;
using System.Text;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;   

namespace TVSSys
{
    public class dataBase
    {
        #region method CheckConnect
        public bool CheckConnect()
        {
            try
            {
                clsConfigXML objCfig = new clsConfigXML();
                string serverName = "", UserID = "", Pass = "", sType = "0";
                serverName = objCfig.GetKey("ServerName");
                UserID = objCfig.GetKey("UserID");
                Pass = objCfig.GetKey("PassWord");
                sType = objCfig.GetKey("AccountType");
                ServerConnection objSc;
                if (sType == "1") objSc = new ServerConnection(serverName, UserID, Pass);
                else objSc = new ServerConnection(serverName);
                objSc.Connect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CheckConnect(string serverName, string UserID, string Pass, string sType)
        {
            try
            {
                ServerConnection objSc;
                if (sType == "1") objSc = new ServerConnection(serverName, UserID, Pass);
                else objSc = new ServerConnection(serverName);
                objSc.Connect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region method CheckDatabase
        public bool CheckDatabase()
        {
            try
            {
                Connection objCon=new Connection();
                DataTable dt = objCon.EXESelect("SELECT count(*) FROM [TabUser]");
                if (dt != null) return true;
                else return false; 
            }
            catch
            {
                return false;
            }
        }
        public bool CheckDatabase(string serverName, string UserID, string Pass, string dataBase, string sType)
        {
            try
            {
                string StrConnection = "";
                if (sType == "1") StrConnection = "Server = '" + serverName + "'; Initial Catalog = '" + dataBase + "'; user id = '" + UserID + "'; pwd = '" + Pass + "'";
                else StrConnection = "Server = '" + serverName + "'; Initial Catalog = '" + dataBase + "'; Integrated Security=SSPI;";
                SqlConnection SqlCon = new SqlConnection(StrConnection);
                SqlCon.Open();
                SqlCommand Cmd = SqlCon.CreateCommand();
                Cmd.CommandText = "SELECT count(*) FROM [TabUser]";
                SqlDataReader Rd = Cmd.ExecuteReader();
                Rd.Close();
                Rd.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region method createDatabase
        public void createDatabase(string serverName, string uid, string pwd, string dataBase, string sType)
        {
            SQLDMO.SQLServer gSQLServerDMO = new SQLDMO.SQLServer();
            SQLDMO.Database nDatabase = new SQLDMO.Database();
            SQLDMO.DBFile nDBFileData = new SQLDMO.DBFile();
            SQLDMO.LogFile nLogFile = new SQLDMO.LogFile();
            
            try
            {
                string scriptPath = Application.StartupPath;

                //scriptPath = scriptPath.Substring(0, scriptPath.LastIndexOf("bin"));
                //scriptPath += "Data\\";
                scriptPath += "\\Data\\";

                if (sType == "1") gSQLServerDMO.Connect(serverName, uid, pwd);
                else
                {
                    gSQLServerDMO.LoginSecure = true;
                    gSQLServerDMO.Connect(serverName, null, null);
                }
                nDatabase.Name = dataBase;
                nDBFileData.Name = dataBase;
                nDBFileData.PhysicalName = scriptPath + dataBase + "_Data.mdf"; 
                nDBFileData.PrimaryFile = true;
                nDBFileData.Size = 2;
                nDBFileData.FileGrowthType = SQLDMO.SQLDMO_GROWTH_TYPE.SQLDMOGrowth_MB;
                nDBFileData.FileGrowth = 1;
                nDatabase.FileGroups.Item("PRIMARY").DBFiles.Add(nDBFileData);
                nLogFile.Name = dataBase + "Log";
                nLogFile.PhysicalName = scriptPath + dataBase + "_Log.ldf";
                nLogFile.Size = 2;
                nDatabase.TransactionLog.LogFiles.Add(nLogFile);

                gSQLServerDMO.Databases.Add(nDatabase);
                gSQLServerDMO.DisConnect();
            }
            catch 
            {
                return;
            }
            finally
            {

            }
        }
        #endregion

        #region method runScripFile
        public void runScripFile(string serverName, string uid, string pwd, string dataBase, string scriptFile, string sType)
        {
            string scriptPath = Application.StartupPath;

            //scriptPath = scriptPath.Substring(0, scriptPath.LastIndexOf("bin"));
            //scriptPath += "Data\\" + scriptFile;
            scriptPath += "\\Data\\" + scriptFile;

            string sqlConnectionString = "";
            if (sType == "1") sqlConnectionString = "Server = '" + serverName + "'; Initial Catalog = '" + dataBase + "'; user id = '" + uid + "'; pwd = '" + pwd + "'";
            else sqlConnectionString = "Server = '" + serverName + "'; Initial Catalog = '" + dataBase + "'; Integrated Security=SSPI;";
            
            FileInfo file = new FileInfo(scriptPath);
            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(conn));
            server.ConnectionContext.ExecuteNonQuery(script);
        }
        #endregion                

        #region method BackUpDatabase
        public bool  BackUpDatabase(string serverName, string uid, string pwd, string dataBase,  string sType)
        {
            try
            {
                DateTime dtn = DateTime.Now;
                string scriptPath = Application.StartupPath + "\\DataBackup";

                DirectoryInfo sDir = new DirectoryInfo(scriptPath);
                if (!sDir.Exists) sDir.Create(); 
                scriptPath += "\\";

                string sqlConnectionString = "";
                if (sType == "1") sqlConnectionString = "Server = '" + serverName + "'; Initial Catalog = '" + dataBase + "'; user id = '" + uid + "'; pwd = '" + pwd + "'";
                else sqlConnectionString = "Server = '" + serverName + "'; Initial Catalog = '" + dataBase + "'; Integrated Security=SSPI;";
                SqlConnection conn = new SqlConnection(sqlConnectionString);
                conn.Open();
                try
                {
                    SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT FILE_NAME(1)", conn);
                    DataSet ds = new DataSet();
                    sqlDA.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0) scriptPath += dt.Rows[0][0].ToString();  
                    conn.Close();
                }
                catch { }

                scriptPath +=dtn.ToString("yyyyMMdd") + ".bak";
                FileInfo f = new FileInfo(scriptPath);
                if (f.Exists) f.Delete();

                conn.Open();
                SqlParameter[] sParam = new SqlParameter[] {
                    new SqlParameter("Name", dataBase),
                    new SqlParameter("Path", scriptPath)};
                SqlCommand command = new SqlCommand("ActionOnTabDBBackup", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sParam);
                try
                {
                    int result = command.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch { return false; }
        }
        #endregion

        #region method RestoreDatabase
        public bool RestoreDatabase(string serverName, string uid, string pwd, string dataBase, string sType)
        {
                OpenFileDialog sOpenBk = new OpenFileDialog();
                sOpenBk.Title = "Chọn thư mục lưu Cơ sở dữ liệu";
                sOpenBk.Filter = "bak|*.Bak";
                sOpenBk.ShowDialog();
                if ((sOpenBk.FileName != "") && (sOpenBk.FileName.Length>12))
                {
                    string sNameFile = sOpenBk.FileName.ToString();
                    for (int i = 1; i < sNameFile.Length; i++)
                    {
                        sNameFile = sNameFile.Substring(sNameFile.IndexOf("\\") + 1);
                    }
                    sNameFile = sNameFile.Substring(0, sNameFile.Length - 12);
                    string scriptPath = Application.StartupPath;
                    scriptPath += "\\Data\\";
                    string sqlConnectionString = "";
                    if (sType == "1") sqlConnectionString = "Server = '" + serverName + "'; Initial Catalog = " + sNameFile + "; user id = '" + uid + "'; pwd = '" + pwd + "'";
                    else sqlConnectionString = "Server = '" + serverName + "'; Initial Catalog = " + sNameFile + "; Integrated Security=SSPI;";
                    SqlConnection SqlCon = new SqlConnection(sqlConnectionString);
                    SqlCon.Open();
                    SqlParameter[] sParam = new SqlParameter[] {
                    new SqlParameter("databaseOldName", sNameFile),
                    new SqlParameter("databaseOldLogName", sNameFile + "Log"),
                    new SqlParameter("databaseNewName", dataBase),
                    new SqlParameter("databasePath", sOpenBk.FileName),
                    new SqlParameter("databaseNewDataPath", scriptPath + dataBase+ "_Data.mdf"),
                    new SqlParameter("databaseNewLogPath", scriptPath + dataBase + "_Log.ldf")};
                    SqlCommand command = new SqlCommand("ActionOnTabDBRestore", SqlCon);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(sParam);
                    //command.CommandTimeout = 100;
                    try
                    {
                        int result = command.ExecuteNonQuery();
                        SqlCon.Close();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                   
                }
                else return false;
        }


        public bool RestoreDatabaseMaster(string serverName, string uid, string pwd, string dataBase, string sType)
        {
            SQLDMO.Restore oRestore = new SQLDMO.RestoreClass();
            SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
            try
            {
                OpenFileDialog sOpenBk = new OpenFileDialog();
                sOpenBk.Title = "Chọn thư mục lưu Cơ sở dữ liệu";
                sOpenBk.Filter = "bak|*.Bak";
                sOpenBk.ShowDialog();
                if (sOpenBk.FileName != "")
                {
                    string sqlConnectionString = "";
                    if (sType == "1") sqlConnectionString = "Server = '" + serverName + "'; Initial Catalog = master; user id = '" + uid + "'; pwd = '" + pwd + "'";
                    else sqlConnectionString = "Server = '" + serverName + "'; Initial Catalog = master; Integrated Security=SSPI;";

                    SqlConnection SqlCon = new SqlConnection(sqlConnectionString);
                    SqlCon.Open();
                    SqlCommand Cmd = SqlCon.CreateCommand();
                    Cmd.CommandText = "declare @vcdbname varchar(50) Set @vcdbname ='" + dataBase + "' set nocount on declare Users cursor for select spid from master..sysprocesses where db_name(dbid) = @vcdbname declare @spid int, @str varchar(255) open users fetch next from users into @spid while @@fetch_status <> -1 begin if @@fetch_status = 0 begin set @str = 'kill ' + convert(varchar, @spid) exec (@str) end fetch next from users into @spid end deallocate users ";
                    Cmd.ExecuteNonQuery();
                    SqlCon.Close();
                    SqlCon.Dispose();
                    SQLDMO._SQLServer srv = new SQLDMO.SQLServerClass();
                    srv.LoginSecure = false;
                    if (sType == "1")
                    {
                        srv.LoginSecure = true;
                        srv.Connect(serverName, null, null);
                    }
                    else srv.Connect(serverName, uid, pwd);
                    SQLDMO.Restore res = new SQLDMO.RestoreClass();
                    res.Devices = res.Files;
                    res.Files = sOpenBk.FileName;
                    res.Database = dataBase;
                    res.ReplaceDatabase = true;
                    res.SQLRestore(srv);

                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                oSQLServer.DisConnect();
            }

        }

        #endregion

        #region method AttachDatabase
        public bool AttachDatabase(string serverName, string uid, string pwd, string dataBase, string sType)
        {
            try
            {
                OpenFileDialog sOpenBk = new OpenFileDialog();
                sOpenBk.Title = "Chọn thư mục lưu Cơ sở dữ liệu";
                sOpenBk.Filter = "mdf|*.Mdf";
                sOpenBk.ShowDialog();
                if (sOpenBk.FileName != "")
                {
                    SQLDMO.Restore oRestore = new SQLDMO.RestoreClass();
                    SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
                    oSQLServer.LoginSecure = false;
                    if (sType == "1")
                    {
                        oSQLServer.LoginSecure = true;
                        oSQLServer.Connect(serverName, null, null);
                    }
                    else oSQLServer.Connect(serverName, uid, pwd);
                    oSQLServer.AttachDB(dataBase, sOpenBk.FileName);
                    return true;
                }
                else return false; 
            }
            catch { return false; }
        }
        #endregion
    }
} 
