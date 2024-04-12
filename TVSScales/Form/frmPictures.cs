using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TVSMain
{
    public partial class frmPictures : Form
    {
        #region method Declare ...
        public  bool sPerEdit = false; 
        public string sRep = "";
        private string sFile1 = "", sFile2 = "";
        #endregion

        #region Method frmPictures
        public frmPictures()
        {
            InitializeComponent();          
        }
        #endregion


        #region Method frm_Load
        private void frm_Load(object sender, EventArgs e)
        {
            this.GetImage_Load();
            if (this.sPerEdit) this.btnDelete.Enabled = true;
            else this.btnDelete.Enabled = false;
        }
        #endregion

        #region method frm_KeyDown
        private void frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        } 
        #endregion

        #region Method GetImage_Load
        private void GetImage_Load()
        {
            try
            {
                TVSSys.Connection objCon = new TVSSys.Connection();
                DataTable dt = objCon.EXESelect("Select FileName,FileName1 from TabScales where Rep=N'" + sRep + "'");
                if (dt.Rows.Count > 0)
                {
                    sFile1 = dt.Rows[0][0].ToString();
                    sFile2 = dt.Rows[0][1].ToString();
                }
                if (sFile1 != "")
                {
                    try { this.ptbIn.Image = System.Drawing.Image.FromFile(sFile1); }
                    catch { }
                }
                if (sFile2 != "")
                {
                    try { this.ptbIn1.Image = System.Drawing.Image.FromFile(sFile2); }
                    catch { }
                }
            }
            catch { }
        }
        #endregion

        private void btnAllExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (sFile1 != "")
                {
                    try
                    {
                        ptbIn.Image.Dispose();
                        System.IO.File.Delete(sFile1);
                    }
                    catch { }
                }
                if (sFile2 != "")
                {
                     try
                    {
                    ptbIn1.Image.Dispose();
                    System.IO.File.Delete(sFile2);
                     }
                    catch { }
                }

                TVSSys.Connection objCon = new TVSSys.Connection();
                if (objCon.EXEUpdate("Update TabScales Set FileName='',FileName1='' where Rep='" + sRep + "'"))
                {
                    MessageBox.Show("Xóa thành công!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi, Xóa không thành công!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch 
            {
                MessageBox.Show("Lỗi, Xóa không thành công!", "TVS - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}