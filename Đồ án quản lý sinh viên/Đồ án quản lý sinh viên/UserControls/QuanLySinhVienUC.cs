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
    public partial class QuanLySinhVienUC : UserControl
    {

        private LinkedList<SinhVien> CSDL_SV;
        private LinkedList<LopHoc> CSDL_Lop;
        private LinkedList<Nganh> CSDL_Nganh;
        public QuanLySinhVienUC()
        {
            InitializeComponent();
        }

        internal void layDuLieu(LinkedList<SinhVien> CSDL_SV,
                                LinkedList<LopHoc> CSDL_Lop,
                                LinkedList<Nganh> CSDL_Nganh
                                )
        {
            this.CSDL_SV = CSDL_SV;
            this.CSDL_Lop = CSDL_Lop;
            this.CSDL_Nganh = CSDL_Nganh;
            hienThiLenComboBoxNganh();
            hienThiDuLieuLenListView();
            cboNganh.Text = "     ---------------------- Lựa chọn Ngành ---------------------";
            cboLop.Text = "     ----------------------- Lựa chọn Lớp -----------------------";
        }

        private void hienThiLenComboBoxNganh()
        {
            cboNganh.Items.Clear();
            LinkedList<Nganh>.Node nodeNganh = CSDL_Nganh.pHead;
            while (nodeNganh != null)
            {
                cboNganh.Items.Add(nodeNganh.data.TenNganh);
                nodeNganh = nodeNganh.pNext;
            }
        }

        //Khi da chon Nganh
        private void cbNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNganh.SelectedIndex == -1) return;
            cboLop.SelectedIndex = -1;
            cboLop.Items.Clear();
            cboLop.Text = "     ----------------------- Lựa chọn Lớp -----------------------";
            string nganh = this.cboNganh.GetItemText(this.cboNganh.SelectedItem);
            hienThiLenComboBoxLopHoc(nganh);
        }

        private void hienThiLenComboBoxLopHoc(string tenNganh)
        {
            cboLop.Items.Clear();
            LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
            while (ptempNganh != null)
            {
                LinkedList<LopHoc>.Node ptempLopHoc = ptempNganh.data.DsLop.pHead;
                while (ptempLopHoc != null)
                {
                    if (ptempNganh.data.TenNganh == tenNganh)
                    {
                        cboLop.Items.Add(ptempLopHoc.data.TenLopHoc);
                    }
                    ptempLopHoc = ptempLopHoc.pNext;
                }
                ptempNganh = ptempNganh.pNext;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        { 
            SinhVien sv = new SinhVien();
            LinkedList<Nganh>.Node nodeNganh = CSDL_Nganh.pHead;

            sv.MSSV = Convert.ToInt32(txtMSSV.Text);
            sv.TenSV = txtTenSV.Text;
            bool gioiTinh = radNam.Checked ? true : false;
            sv.GioiTinh = gioiTinh;
            sv.NgSinh = new DateTime(Convert.ToInt32(txtNamSinh.Text),
                                     Convert.ToInt32(txtThangSinh.Text),
                                     Convert.ToInt32(txtNgaySinh.Text));

            string nganh = this.cboNganh.GetItemText(this.cboNganh.SelectedItem);
            while (nodeNganh != null)
            {
                if(nodeNganh.data.TenNganh == nganh)
                {
                    break;
                }
                nodeNganh = nodeNganh.pNext;
            }

            LinkedList<LopHoc>.Node nodeLop = nodeNganh.data.DsLop.pHead;
            string lop = this.cboLop.GetItemText(this.cboLop.SelectedItem);

            while (nodeLop != null)
            {
                if (nodeLop.data.TenLopHoc == lop)
                {
                    sv.LopChuQuan = nodeLop.data;
                    nodeLop.data.DsSVLop.Add(sv);
                    break;
                }
                nodeLop = nodeLop.pNext;
            }

            sv.DiemToan = Convert.ToDouble(txtDiemToan.Text);
            sv.DiemLy = Convert.ToDouble(txtDiemLy.Text);
            sv.DiemHoa = Convert.ToDouble(txtDiemHoa.Text);

            CSDL_SV.Add(sv);
            hienThiDuLieuLenListView();
        }

        private void hienThiDuLieuLenListView()
        {
            lvThongTinSV.Items.Clear();
            LinkedList<SinhVien>.Node nodeSV = CSDL_SV.pHead;

            while (nodeSV != null)
            {
                ListViewItem lviSV = new ListViewItem(Convert.ToString(nodeSV.data.MSSV));
                lviSV.SubItems.Add(nodeSV.data.TenSV);

                string gioiTinh = nodeSV.data.GioiTinh == true ? "Nam" : "Nữ";
                lviSV.SubItems.Add(gioiTinh);
                lviSV.SubItems.Add(nodeSV.data.NgSinh.ToString("dd/MM/yyyy"));

                lviSV.SubItems.Add(nodeSV.data.LopChuQuan.NganhChuQuan.TenNganh);
                lviSV.SubItems.Add(nodeSV.data.LopChuQuan.TenLopHoc);
                lviSV.SubItems.Add(Convert.ToString(Math.Round(nodeSV.data.diemTrungBinh(), 3)));

                lvThongTinSV.Items.Add(lviSV);
                nodeSV = nodeSV.pNext;
            }
        }
        private void QuanLySinhVienUC_Load(object sender, EventArgs e)
        {
        }
        //Khi click vao list view
        private void lvThongTinSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvThongTinSV.SelectedItems.Count > 0)
            {
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.Red;
                btnXoa.ForeColor = Color.White;
            }
            else
            {
                btnXoa.Enabled = false;
                btnXoa.BackColor = Color.Red;
                btnXoa.ForeColor = Color.Red;
                lvThongTinSV.FullRowSelect = true;
            }
        }

        // Khi click XOA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvThongTinSV.SelectedItems.Count > 0)
            {
                ListViewItem lvChonSV = lvThongTinSV.SelectedItems[0];
                int mssDel = Convert.ToInt32(lvChonSV.SubItems[0].Text);
               
                LinkedList<SinhVien>.Node nodeSV = CSDL_SV.pHead;
                //Dua vao mssv tim node sinh vien can xoa
                while (nodeSV!=null)
                {
                    if(nodeSV.data.MSSV == mssDel)
                    {
                        //Hoi co muon XOA khong?
                        DialogResult chonXoa = MessageBox.Show("Bạn có chắc muốn xóa sinh viên " + nodeSV.data.TenSV,
                                                                "Xóa",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question);
                        // Neu Chon XOA thi xu ly
                        if(chonXoa == DialogResult.Yes)
                        {
                            
                            CSDL_SV.Remove(nodeSV);
                            MessageBox.Show("Xóa thanh công!", "Xóa",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        //Dung khong duyet nua
                        break; 
                    }
                    nodeSV = nodeSV.pNext;
                }


                //Xoa SV trong danh sach lop
                LinkedList<LopHoc>.Node nodeLopHoc = CSDL_Lop.pHead;
                
                while(nodeLopHoc != null)
                {
                    if (nodeLopHoc.data.MsLopHoc == nodeSV.data.LopChuQuan.MsLopHoc)
                    {
                        LinkedList<SinhVien>.Node nodeSvLop = nodeLopHoc.data.DsSVLop.pHead;
                        while (nodeSvLop != null)
                        {
                            if (nodeSvLop.data.MSSV == nodeSV.data.MSSV)
                            {
                                nodeLopHoc.data.DsSVLop.Remove(nodeSvLop);
                                break;
                            }
                            nodeSvLop = nodeSvLop.pNext;
                        }
                        break;
                    }
                    nodeLopHoc = nodeLopHoc.pNext;
                }
                hienThiDuLieuLenListView();
            }
        }

        private void QuanLySinhVienUC_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnXoa.BackColor = Color.Gray;
            //lvThongTinSV.SelectedItems[0].Selected = false;
        }
    }
}
