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
    public partial class QuanLyLopHocUC : UserControl
    {
        private LinkedList<LopHoc> CSDL_Lop;
        private LinkedList<Nganh> CSDL_Nganh;
        public QuanLyLopHocUC()
        {
            InitializeComponent();
        }

        internal void layDuLieu(LinkedList<LopHoc> CSDL_Lop, LinkedList<Nganh> CSDL_Nganh)
        {
            this.CSDL_Lop = CSDL_Lop;
            this.CSDL_Nganh = CSDL_Nganh;
            hienThiLenTreeViewNganh();
            hienThiComBoBox();
            cboNganh.Text = "    -------------------------------- Lựa chọn Ngành --------------------------------";
            lvThongTinLop.Items.Clear();
        }

        private void hienThiLenTreeViewNganh()
        {
            trvNganh.Nodes.Clear();
            LinkedList<Nganh>.Node nodeNganh = CSDL_Nganh.pHead;
            while (nodeNganh != null)
            {
                trvNganh.Nodes.Add(nodeNganh.data.TenNganh);
                nodeNganh = nodeNganh.pNext;
            }
        }

        private void trvNganh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node != null)
            {
                hienThiListViewThongTinSV(e.Node.Text);
            }
        }

        private void hienThiListViewThongTinSV(string tenNganh)
        {
            lvThongTinLop.Items.Clear();
            LinkedList<Nganh>.Node nodeNganh = CSDL_Nganh.pHead;
            while (nodeNganh.data.TenNganh != tenNganh)
            {
                nodeNganh = nodeNganh.pNext;
            }

            LinkedList<LopHoc>.Node nodeLop = nodeNganh.data.DsLop.pHead;
            while (nodeLop != null)
            {
                ListViewItem lviSV = new ListViewItem(nodeLop.data.MsLopHoc);
                lviSV.SubItems.Add(nodeLop.data.TenLopHoc);
                lviSV.SubItems.Add(nodeLop.data.DsSVLop.count.ToString());
                lvThongTinLop.Items.Add(lviSV);
                nodeLop = nodeLop.pNext;
            }
        }

        private void hienThiComBoBox()
        {
            cboNganh.Items.Clear();
            LinkedList<Nganh>.Node nodeNganh = CSDL_Nganh.pHead;
            while (nodeNganh != null)
            {
                cboNganh.Items.Add(nodeNganh.data.TenNganh);
                nodeNganh = nodeNganh.pNext;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (xuLyLuu())
            {
                MessageBox.Show("Lưu Thành Công!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiListViewThongTinSV(cboNganh.SelectedItem.ToString());
                xuLyClear();
            }
        }

        private bool xuLyLuu()
        {
            //Validation
            string contentValidation = "";
            Validation validation = new Validation();
            contentValidation += validation.kiemTraComboBox("Ngành", cboNganh);
            contentValidation += validation.kiemTraRong("Mã lớp", txtMaLop);
            //Xử lý MSSV trùng
            if (contentValidation == "")
            {
                LinkedList<LopHoc>.Node nodeLopHoc = CSDL_Lop.pHead;
                while (nodeLopHoc != null)
                {
                    if (nodeLopHoc.data.MsLopHoc == txtMaLop.Text)
                    {
                        contentValidation += "Mã Lớp đã tồn tại\n";
                        break;
                    }
                    nodeLopHoc = nodeLopHoc.pNext;
                }
            }
            contentValidation += validation.kiemTraChuoi("Tên Lớp", txtTenLop);

            if (contentValidation != "")
            {
                MessageBox.Show(contentValidation, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Bắt đầu lấy giá trị và lưu
            LopHoc lop = new LopHoc();

            LinkedList<Nganh>.Node nodeNganh = CSDL_Nganh.pHead;

            string chonNganh = Convert.ToString(this.cboNganh.SelectedItem);
            while (chonNganh != nodeNganh.data.TenNganh)
            {
                nodeNganh = nodeNganh.pNext;
            }
            lop.NganhChuQuan = nodeNganh.data;
            lop.MsLopHoc = txtMaLop.Text;
            lop.TenLopHoc = txtTenLop.Text;

            CSDL_Lop.Add(lop);
            nodeNganh.data.DsLop.Add(lop);

            return true;
        }
        private void xuLyXoa(string maLopHocDel)
        {
            LinkedList<Nganh>.Node nodeNganh = CSDL_Nganh.pHead;
            LinkedList<LopHoc>.Node nodeLop = CSDL_Lop.pHead;

            string tenNganh = "";

            while (nodeLop != null)
            {
                if (nodeLop.data.MsLopHoc == maLopHocDel)
                {
                    tenNganh = nodeLop.data.NganhChuQuan.TenNganh;
                    CSDL_Lop.Remove(nodeLop);
                    break;
                }
                nodeLop = nodeLop.pNext;
            }

            while (nodeNganh != null)
            {
                if (nodeNganh.data.TenNganh == tenNganh)
                {
                    LinkedList<LopHoc>.Node nodeDsLop = nodeNganh.data.DsLop.pHead;
                    while (nodeDsLop != null)
                    {
                        if (nodeDsLop.data.MsLopHoc == maLopHocDel)
                        {
                            nodeNganh.data.DsLop.Remove(nodeDsLop);
                            break;
                        }
                        nodeDsLop = nodeDsLop.pNext;
                    }
                    break;
                }
                nodeNganh = nodeNganh.pNext;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenNganh = trvNganh.SelectedNode.Text;
            if (lvThongTinLop.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lvThongTinLop.SelectedItems.Count; i++)
                {
                    xuLyXoa(lvThongTinLop.SelectedItems[i].SubItems[0].Text);   
                }
                hienThiListViewThongTinSV(tenNganh);
                MessageBox.Show("Xóa Thành Công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void QuanLyLopHocUC_Load(object sender, EventArgs e)
        {
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyXoa(txtMaLop.Text);
            if (xuLyLuu())
            {
                MessageBox.Show("Sửa Thành Công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiListViewThongTinSV(cboNganh.SelectedItem.ToString());
                xuLyClear();
            }
        }
        // Khi Double Click
        private void lvThongTinLop_DoubleClick(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = true;

            var index = lvThongTinLop.FocusedItem.Index;

            var lopHoc = lvThongTinLop.Items[index];

            txtMaLop.Text = lopHoc.SubItems[0].Text;
            txtTenLop.Text = lopHoc.SubItems[1].Text;
            txtMaLop.Enabled = false;
            cboNganh.Text = trvNganh.SelectedNode.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            xuLyClear();
        }

        private void xuLyClear()
        {
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = false;

            cboNganh.Text = "    -------------------------------- Lựa chọn Ngành --------------------------------";
            txtMaLop.Text = "";
            txtMaLop.Enabled = true;
            txtTenLop.Text = "";
        }

        private void cboNganh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
