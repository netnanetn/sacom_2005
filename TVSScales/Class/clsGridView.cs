using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using C1.Win.C1TrueDBGrid;  
namespace TVSMain
{
    public class clsGridView
    {       
        #region method Declare ...
        #endregion
        
        #region method clsGridView
        public clsGridView()
        {
           
        } 
        #endregion

        #region method Set_GridViewDir
        public void Set_GridViewKhachhang(C1TrueDBGrid sDBGridView)
        {
            try
            {
                sDBGridView.Splits[0].DisplayColumns[0].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["bChon"].Visible = false;
                for (int i = 1; i < sDBGridView.Columns.Count; i++)
                {
                    sDBGridView.Splits[0].DisplayColumns[i].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                }
                sDBGridView.Splits[0].DisplayColumns["TenKhachhang"].Width = 300;
                sDBGridView.Splits[0].DisplayColumns["Diachi"].Width = 300;
                sDBGridView.Splits[0].DisplayColumns["Dienthoai"].Width = 90;
                sDBGridView.Splits[0].DisplayColumns["IDLoaihang"].Width = 150;
                sDBGridView.Columns["TenKhachhang"].Caption = "Tên khách hàng";
                sDBGridView.Columns["Diachi"].Caption = "Địa chỉ";
                sDBGridView.Columns["Dienthoai"].Caption = "Địa bàn";
                sDBGridView.Columns["IDLoaihang"].Caption = "Loại hàng";
                sDBGridView.Columns["Xe"].Caption = "Xe chở";
                CreateControlTrueDBDropdown(sDBGridView, "IDLoaihang", "TenLoaihang", "TblLoaihang");
            }
            catch
            {
            }
        }

        public void Set_GridViewLoaihang(C1TrueDBGrid sDBGridView)
        {
            try
            {
                sDBGridView.Splits[0].DisplayColumns[0].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["bSan"].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["Macdinh"].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["TenLoaihang"].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Columns["TenLoaihang"].Caption = "Tên loại hàng";
            }
            catch
            {
            }
        }
        
        public void Set_GridViewXeCho(C1TrueDBGrid sDBGridView)
        {
            try
            {
                sDBGridView.Splits[0].DisplayColumns[0].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["bChonXe"].Visible = false;
                for (int i = 1; i < sDBGridView.Columns.Count; i++)
                {
                    sDBGridView.Splits[0].DisplayColumns[i].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                }
                sDBGridView.Splits[0].DisplayColumns["Xe"].Width = 90;
                sDBGridView.Splits[0].DisplayColumns["HotenLaiXe"].Width = 300;

                sDBGridView.Columns["Xe"].Caption = "Biển số xe";
                sDBGridView.Columns["HotenLaiXe"].Caption = "Họ và tên lái xe";
                sDBGridView.Columns["KhoiluongXe"].Caption = "Tải trọng của xe (Kg)";
                sDBGridView.Columns["KhoiluongXe"].NumberFormat = "#,##0";
            }
            catch
            {
            }
        }
        #endregion


        #region mothod Set_GridViewScales
        public void Set_GridViewScales(C1TrueDBGrid sDBGridView, string sUnitFormat, string sUnitText)
        {
            try
            {
                sDBGridView.Splits[0].DisplayColumns[0].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["FileName"].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["FileName1"].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["TemperatureCode"].Visible = false;  
                for (int i = 1; i < sDBGridView.Columns.Count; i++)
                {
                    sDBGridView.Splits[0].DisplayColumns[i].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                    sDBGridView.Splits[0].DisplayColumns[i].HeadingStyle.WrapText = true;
                }

                sDBGridView.Columns["Rep"].Caption = "Số phiếu";
                sDBGridView.Columns["ScalesDate"].Caption = "Ngày cân";
                sDBGridView.Columns["Type"].Caption = "Tên sản phẩm";
                sDBGridView.Columns["Size"].Caption = "Kích thước";
                sDBGridView.Columns["Robin"].Caption = "Trọng lượng bobin";
                sDBGridView.Columns["Machine"].Caption = "Máy sản xuất";
                sDBGridView.Columns["Line"].Caption = "Dây chuyền";
                sDBGridView.Columns["Standard"].Caption = "Tiêu chuẩn";
                sDBGridView.Columns["Temperature"].Caption = "Cấp nhiệt độ";
                sDBGridView.Columns["Value0"].Caption = "Tổng trọng lượng" + sUnitText;
                sDBGridView.Columns["Value1"].Caption = "Trọng lượng tịnh" + sUnitText;
                sDBGridView.Columns["Printed"].Caption = "Đã In hóa đơn";
                sDBGridView.Columns["Fullname"].Caption = "Người cập nhật";
                sDBGridView.Columns["Technology"].Caption = "Phiếu công nghệ";
                sDBGridView.Columns["Note"].Caption = "Ghi chú";
                sDBGridView.Splits[0].DisplayColumns["Rep"].Width = 250;
                sDBGridView.Splits[0].DisplayColumns["ScalesDate"].Width = 130;
                sDBGridView.Splits[0].DisplayColumns["Fullname"].Width = 150;

                sDBGridView.Splits[0].DisplayColumns["Value0"].HeadingStyle.ForeColor = System.Drawing.Color.Red;
                sDBGridView.Splits[0].DisplayColumns["Value0"].Style.ForeColor = System.Drawing.Color.Red;
                sDBGridView.Splits[0].DisplayColumns["Value1"].HeadingStyle.ForeColor = System.Drawing.Color.Blue;
                sDBGridView.Splits[0].DisplayColumns["Value1"].Style.ForeColor = System.Drawing.Color.Blue;

                sDBGridView.Columns["ScalesDate"].NumberFormat = "dd/MM/yyyy HH:mm:ss";
                sDBGridView.Columns["Value0"].NumberFormat = sUnitFormat;
                sDBGridView.Columns["Value1"].NumberFormat = sUnitFormat;
                sDBGridView.Splits[0].DisplayColumns["ScalesDate"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Size"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Type"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Robin"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Machine"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Line"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Standard"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Temperature"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                try
                {
                    sDBGridView.Splits[0].DisplayColumns["RobinName"].Visible = false;
                }
                catch { }
            }
            catch
            {
            }
        }

        public void Set_GridViewScales1(C1TrueDBGrid sDBGridView, string sUnitFormat, string sUnitText)
        {
            try
            {
                sDBGridView.Splits[0].DisplayColumns[0].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["FileName"].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["FileName1"].Visible = false;
                sDBGridView.Splits[0].DisplayColumns["TemperatureCode"].Visible = false;
                for (int i = 1; i < sDBGridView.Columns.Count; i++)
                {
                    sDBGridView.Splits[0].DisplayColumns[i].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                    sDBGridView.Splits[0].DisplayColumns[i].HeadingStyle.WrapText = true;
                }

                sDBGridView.Columns["Rep"].Caption = "Số phiếu";
                sDBGridView.Columns["ScalesDate"].Caption = "Ngày cân";
                sDBGridView.Columns["Type"].Caption = "Tên sản phẩm";
                sDBGridView.Columns["Size0"].Caption = "Bề rộng";
                sDBGridView.Columns["Size1"].Caption = "Bề dày";
                sDBGridView.Columns["Size2"].Caption = "Bán kính góc";
                sDBGridView.Columns["Size3"].Caption = "Tiết diện";
                sDBGridView.Columns["Robin"].Caption = "Trọng lượng Bobin";
                sDBGridView.Columns["Machine"].Caption = "Máy sản xuất";
                sDBGridView.Columns["Line"].Caption = "Dây chuyền";
                sDBGridView.Columns["Standard"].Caption = "Tiêu chuẩn";
                sDBGridView.Columns["Temperature"].Caption = "Cấp nhiệt độ";
                sDBGridView.Columns["Value0"].Caption = "Tổng trọng lượng" + sUnitText;
                sDBGridView.Columns["Value1"].Caption = "Trọng lượng tịnh" + sUnitText;
                sDBGridView.Columns["Printed"].Caption = "Đã In hóa đơn";
                sDBGridView.Columns["Fullname"].Caption = "Người cập nhật";
                sDBGridView.Columns["Technology"].Caption = "Phiếu công nghệ";
                sDBGridView.Columns["Note"].Caption = "Ghi chú";

                sDBGridView.Splits[0].DisplayColumns["Rep"].Width = 250;
                sDBGridView.Splits[0].DisplayColumns["ScalesDate"].Width = 130;
                sDBGridView.Splits[0].DisplayColumns["Fullname"].Width = 150;

                sDBGridView.Splits[0].DisplayColumns["Value0"].HeadingStyle.ForeColor = System.Drawing.Color.Red;
                sDBGridView.Splits[0].DisplayColumns["Value0"].Style.ForeColor = System.Drawing.Color.Red;
                sDBGridView.Splits[0].DisplayColumns["Value1"].HeadingStyle.ForeColor = System.Drawing.Color.Blue;
                sDBGridView.Splits[0].DisplayColumns["Value1"].Style.ForeColor = System.Drawing.Color.Blue;

                sDBGridView.Columns["ScalesDate"].NumberFormat = "dd/MM/yyyy HH:mm:ss";
                sDBGridView.Columns["Value0"].NumberFormat = sUnitFormat;
                sDBGridView.Columns["Value1"].NumberFormat = sUnitFormat;
                sDBGridView.Splits[0].DisplayColumns["ScalesDate"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Size0"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Size1"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Size2"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Size3"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Type"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Robin"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Machine"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Line"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Standard"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                sDBGridView.Splits[0].DisplayColumns["Temperature"].Style.HorizontalAlignment = AlignHorzEnum.Center;
             //   sDBGridView.Columns["Size3"].NumberFormat = "##0.0";
                try
                {
                    sDBGridView.Columns["Size"].Caption = "Kích thước";
                    sDBGridView.Splits[0].DisplayColumns["Size"].Style.HorizontalAlignment = AlignHorzEnum.Center;
                    sDBGridView.Columns["NameScalesGroup"].Caption = "Loại sản phẩm";
                }
                catch { }
                try
                {
                    sDBGridView.Splits[0].DisplayColumns["RobinName"].Visible = false;
                }
                catch { }
            }
            catch
            {
            }
        } 
        #endregion

        #region method CreateControlTrueDBDropdown
        private void CreateControlTrueDBDropdown(C1TrueDBGrid sDBGridView, string sFieldID, string sFieldName, string sTable)
        {
            C1TrueDBDropdown objControl = new C1TrueDBDropdown();
            sDBGridView.FindForm().Controls.Add(objControl);
            objControl.ColumnHeaders = false;
            objControl.Height = 120;
            objControl.RowHeight = 22;
            objControl.Style.VerticalAlignment = AlignVertEnum.Center;
            objControl.Style.HorizontalAlignment = AlignHorzEnum.Far;
            objControl.Cursor = Cursors.Hand;
            objControl.Width = sDBGridView.Splits[0].DisplayColumns[sFieldID].Width;
            objControl.ExtendRightColumn = true;
            try
            {
                TVSSys.Connection objCon = new TVSSys.Connection();
                objControl.DataSource = objCon.EXESelect("Select " + sFieldID + ", " + sFieldName + " from " + sTable + " order by " + sFieldName);
                sDBGridView.Columns[sFieldID].DropDown = objControl;
                sDBGridView.Splits[0].DisplayColumns[sFieldID].Style.HorizontalAlignment = AlignHorzEnum.Justify;
                objControl.DataField = sFieldID;
                objControl.ListField = sFieldName;
                sDBGridView.Columns[sFieldID].ValueItems.Translate = true;
                objControl.ValueTranslate = true;
                objControl.DisplayColumns[0].Visible = false;
                sDBGridView.Splits[0].DisplayColumns[sFieldID].FilterButton = true;
            }
            catch
            {
            }
        }
        #endregion
    }
}
 