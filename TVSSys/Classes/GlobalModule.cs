using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace TVSSys
{
    public class GlobalModule
    {       
        #region method Declare ...

        public static System.Drawing.Color objColorEnter = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(235)))), ((int)(((byte)(25)))));
        public static System.Drawing.Color objColorLeave = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        public static int sMainLeft = 0, sMainTop = 0;

        #endregion

        #region method GlobalModule
        public GlobalModule()
        {
            try
            {

            }
            catch { }
        } 
        #endregion

    }
}
