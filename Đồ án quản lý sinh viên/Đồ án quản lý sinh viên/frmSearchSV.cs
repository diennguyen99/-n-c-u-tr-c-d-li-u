using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_quản_lý_sinh_viên
{
    public partial class frmSearchSV : Form
    {

        private LinkedList<SinhVien> CSDL_SV;
        private LinkedList<Nganh> CSDL_Nganh;
        public frmSearchSV()
        {
            InitializeComponent();
        }

        internal void layDuLieu(LinkedList<SinhVien> cSDL_SV, LinkedList<Nganh> cSDL_Nganh)
        {
            CSDL_SV = cSDL_SV;
            CSDL_Nganh = cSDL_Nganh;
        }

        private void frmSearchSV_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int mssvSearch = Convert.ToInt32(txtSearch.Text);
            LinkedList<SinhVien>.Node ptempSV = CSDL_SV.pHead;
            LinkedList<SinhVien>.Node svDelete = new LinkedList<SinhVien>.Node();
            //SinhVien svDelete = new SinhVien();
            while (ptempSV != null)
            {
                if (ptempSV.data.mssv == mssvSearch)
                {
                    svDelete = ptempSV;
                    break;
                }
                ptempSV = ptempSV.pNext;
            }
            if (ptempSV != null)
                hienThiThongTinSVLenListView(ptempSV);
            else
                MessageBox.Show("MSSV KHÔNG tồn tại!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void hienThiThongTinSVLenListView(LinkedList<SinhVien>.Node ptempSV)
        {
            ListViewItem lviSV = new ListViewItem(Convert.ToString(ptempSV.data.mssv));
            lviSV.SubItems.Add(ptempSV.data.tenSV);
            string gioiTinh = ptempSV.data.gioiTinh == true ? "Nam" : "Nữ";
            lviSV.SubItems.Add(gioiTinh);
            lviSV.SubItems.Add(ptempSV.data.lopChuQuan.tenLopHoc);
            lviSV.SubItems.Add(ptempSV.data.lopChuQuan.nganhChuQuan.tenNganh);
            lvThongTinSV.Items.Add(lviSV);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult click = MessageBox.Show("Bạn có muốn thoát phần mềm?", "Thoát",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (click == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
