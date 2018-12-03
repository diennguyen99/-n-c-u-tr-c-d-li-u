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
    public partial class QuanLyNganhUC : UserControl
    {
        private LinkedList<Nganh> CSDL_Nganh;
        public QuanLyNganhUC()
        {
            InitializeComponent();
        }

        internal void layDuLieu(LinkedList<Nganh> CSDL_Nganh)
        {
            this.CSDL_Nganh = CSDL_Nganh;
            hienThiLenListViewNganh();
        }

        private void hienThiLenListViewNganh()
        {
            lvThongTinNganh.Items.Clear();

            LinkedList<Nganh>.Node nodeNganh = CSDL_Nganh.pHead;
            while(nodeNganh != null)
            {
                ListViewItem lviItemNganh = new ListViewItem(nodeNganh.data.MsNganh);
                lviItemNganh.SubItems.Add(nodeNganh.data.TenNganh);
                lviItemNganh.SubItems.Add(nodeNganh.data.DsLop.count.ToString());
                lvThongTinNganh.Items.Add(lviItemNganh);
                nodeNganh = nodeNganh.pNext;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (xuLyLuu())
            {
                MessageBox.Show("Thêm Ngành thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiLenListViewNganh();
            }
        }

        private bool xuLyLuu()
        {
            //Validation
            string contentValidation = "";
            Validation validation = new Validation();
            contentValidation += validation.kiemTraRong("Mã ngành", txtMaNganh);
            //Xử lý MSSV trùng
            if (contentValidation == "")
            {
                if (CSDL_Nganh.Search(txtMaNganh.Text) != null)
                {
                    contentValidation += "Mã Ngành đã tồn tại\n";
                }
            }
            contentValidation += validation.kiemTraChuoi("Tên ngành", txtTenNganh);

            if (contentValidation != "")
            {
                MessageBox.Show(contentValidation, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Bắt đâu lấy dữ liệu xử lý lưu
            Nganh nganh = new Nganh();

            nganh.MsNganh = txtMaNganh.Text;
            nganh.TenNganh = txtTenNganh.Text;

            CSDL_Nganh.Add(nganh, nganh.MsNganh);
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvThongTinNganh.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lvThongTinNganh.SelectedItems.Count; i++)
                {
                    xuLyXoa(lvThongTinNganh.SelectedItems[i].SubItems[0].Text);
                }
                MessageBox.Show("Xóa Thành Công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiLenListViewNganh();
            }
        }

        private void xuLyXoa(string maNganhDel)
        {
            CSDL_Nganh.Remove(maNganhDel);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyXoa(txtMaNganh.Text);

            if (xuLyLuu())
            {
                MessageBox.Show("Sửa Ngành thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            hienThiLenListViewNganh();
        }

        private void lvThongTinNganh_DoubleClick(object sender, EventArgs e)
        {
            btnLuu.Visible = false;
            btnXoa.Visible = false;
            btnSua.Visible = true;

            var index = lvThongTinNganh.FocusedItem.Index;
            var nganh = lvThongTinNganh.Items[index];

            txtMaNganh.Text = nganh.SubItems[0].Text;
            txtMaNganh.Enabled = false;
            txtTenNganh.Text = nganh.SubItems[1].Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            xuLyClear();
        }

        private void xuLyClear()
        {
            btnLuu.Visible = true;
            btnXoa.Visible = true;
            btnSua.Visible = false;

            txtMaNganh.Text = "";
            txtMaNganh.Enabled = true;
            txtTenNganh.Text = "";
        }
    }
}
