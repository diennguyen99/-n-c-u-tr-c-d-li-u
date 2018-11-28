using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_quản_lý_sinh_viên.UserControls
{
    public partial class TimKiemSinhVienUC : UserControl
    {
        private LinkedList<SinhVien> CSDL_SV;
        public TimKiemSinhVienUC()
        {
            InitializeComponent();
        }

        internal void layDuLieu(LinkedList<SinhVien> CSDL_SV)
        {
            this.CSDL_SV = CSDL_SV;
            hienThiListViewThongTinSV("");
        }

        private void hienThiListViewThongTinSV(string mssv)
        {
            lvThongTinSV.Items.Clear();
            LinkedList<SinhVien>.Node nodeSV = CSDL_SV.pHead;
            while (nodeSV != null)
            {
                if(nodeSV.data.MSSV.ToString().Contains(mssv) || mssv == null)
                {
                    ListViewItem lviItemSV = new ListViewItem(nodeSV.data.MSSV.ToString());
                    lviItemSV.SubItems.Add(nodeSV.data.TenSV);
                    string gioiTinh = nodeSV.data.GioiTinh == true ? "Nam" : "Nữ";
                    lviItemSV.SubItems.Add(gioiTinh);
                    lviItemSV.SubItems.Add(nodeSV.data.DiemToan.ToString());
                    lviItemSV.SubItems.Add(nodeSV.data.DiemLy.ToString());
                    lviItemSV.SubItems.Add(nodeSV.data.DiemHoa.ToString());
                    lviItemSV.SubItems.Add(nodeSV.data.LopChuQuan.TenLopHoc);
                    lviItemSV.SubItems.Add(nodeSV.data.LopChuQuan.NganhChuQuan.TenNganh);
                    lvThongTinSV.Items.Add(lviItemSV);
                }
                nodeSV = nodeSV.pNext;
            }
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            string mssv = txtTimKiem.Text;
            hienThiListViewThongTinSV(mssv);
        }
    }
}
