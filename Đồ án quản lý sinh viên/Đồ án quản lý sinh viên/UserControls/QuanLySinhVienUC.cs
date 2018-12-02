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

            if (xuLyLuu())
            {
                MessageBox.Show("Lưu Thành công!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiDuLieuLenListView();
                xuLyClear();
            }
        }
        // Xử lý Lưu
        private bool xuLyLuu()
        {
            //Validation
            string contentValidation = "";
            Validation validation = new Validation();
            contentValidation += validation.kiemTraSo("MSSV", txtMSSV);
            //Xử lý MSSV trùng
            if(contentValidation == "")
            {
                LinkedList<SinhVien>.Node nodeSV = CSDL_SV.pHead;
                while (nodeSV != null)
                {
                    if(nodeSV.data.MSSV == Int32.Parse(txtMSSV.Text))
                    {
                        contentValidation += "MSSV đã tồn tại\n";
                        break;
                    }
                    nodeSV = nodeSV.pNext;
                }
            }
            contentValidation += validation.kiemTraChuoi("Tên SV", txtTenSV);
            contentValidation += validation.kiemTraRadio(radNam, radNu);
            contentValidation += validation.kiemTraDate(txtNgaySinh, txtThangSinh, txtNamSinh);
            contentValidation += validation.kiemTraComboBox("Ngành", cboNganh);
            contentValidation += validation.kiemTraComboBox("Lớp", cboLop);
            contentValidation += validation.kiemTraDiem("Điểm Toán", txtDiemToan);
            contentValidation += validation.kiemTraDiem("Điểm Lý", txtDiemLy);
            contentValidation += validation.kiemTraDiem("Điểm Hóa", txtDiemHoa);
            if (contentValidation != "")
            {
                MessageBox.Show(contentValidation, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


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
                if (nodeNganh.data.TenNganh == nganh)
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
            return true;
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
                lviSV.SubItems.Add(nodeSV.data.DiemHoa.ToString());
                lviSV.SubItems.Add(nodeSV.data.DiemLy.ToString());
                lviSV.SubItems.Add(nodeSV.data.DiemHoa.ToString());
                lviSV.SubItems.Add(Convert.ToString(Math.Round(nodeSV.data.diemTrungBinh(), 3)));
                lviSV.SubItems.Add(nodeSV.data.LopChuQuan.TenLopHoc);
                lviSV.SubItems.Add(nodeSV.data.LopChuQuan.NganhChuQuan.TenNganh);
                
                lvThongTinSV.Items.Add(lviSV);
                nodeSV = nodeSV.pNext;
            }
        }
        // Khi click XOA
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (lvThongTinSV.SelectedItems.Count > 0)
            {
                //Hoi co muon XOA khong?
                DialogResult chonXoa = MessageBox.Show("Bạn có chắc muốn xóa ?",
                                                                "Xóa",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question);

                // Neu Chon XOA thi xu ly
                if (chonXoa == DialogResult.Yes)
                {
                    for (int i = 0; i < lvThongTinSV.SelectedItems.Count; i++)
                    {
                        ListViewItem item = lvThongTinSV.SelectedItems[i];
                        xuLyXoa(Convert.ToInt32(item.SubItems[0].Text));
                    }
                    MessageBox.Show("Xóa thanh công!", "Xóa",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    btnXoa.Enabled = false;
                    btnXoa.BackColor = Color.Gray;
                }
                else
                {
                    return;
                }
            }
            hienThiDuLieuLenListView();
        }
        //Xử lý thao tác xóa
        private void xuLyXoa(int mssDel) {
            if (lvThongTinSV.SelectedItems.Count > 0)
            {
                LinkedList<SinhVien>.Node nodeSV = CSDL_SV.pHead;
                //Dua vao mssv tim node sinh vien can xoa
                while (nodeSV != null)
                {
                    if (nodeSV.data.MSSV == mssDel)
                    {
                       
                        CSDL_SV.Remove(nodeSV);
                        //Dung khong duyet nua
                        break;
                    }
                    nodeSV = nodeSV.pNext;
                }


                //Xoa SV trong danh sach lop
                LinkedList<LopHoc>.Node nodeLopHoc = CSDL_Lop.pHead;

                while (nodeLopHoc != null)
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
            }
        }

        //Khi Click Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyXoa(Int32.Parse(txtMSSV.Text));
            if (xuLyLuu())
            {
                MessageBox.Show("Sửa Thành Công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiDuLieuLenListView();
                xuLyClear();
            }
        }

        // Khi double click vao item list view thì đổ dữ liệu lên
        private void lvThongTinSV_DoubleClick(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = true;

            var index = lvThongTinSV.FocusedItem.Index;

            var sv = lvThongTinSV.Items[index];

            txtMSSV.Text = sv.SubItems[0].Text;
            txtTenSV.Text = sv.SubItems[1].Text;
            if(sv.SubItems[2].Text == "Nam")
            {
                radNam.Checked = true;
            }else
            {
                radNu.Checked = true;
            }

            //Cat chuoi thanh ngay thang nam sinh
            var date = sv.SubItems[3].Text.Split('/');
            
            txtNgaySinh.Text = date[0];
            txtThangSinh.Text = date[1];
            txtNamSinh.Text = date[2];

            txtDiemToan.Text = sv.SubItems[4].Text;
            txtDiemLy.Text = sv.SubItems[5].Text;
            txtDiemHoa.Text = sv.SubItems[6].Text;

            cboNganh.Text = sv.SubItems[9].Text;
            cboLop.Text = sv.SubItems[8].Text;

            txtMSSV.Enabled = false;
        }
        //Click Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            xuLyClear();
        }

        private void xuLyClear()
        {
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = false;

            txtMSSV.Enabled = true;
            txtMSSV.Text = "";
            txtTenSV.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            txtNgaySinh.Text = "";
            txtThangSinh.Text = "";
            txtNamSinh.Text = "";
            cboNganh.Text = "     ---------------------- Lựa chọn Ngành ---------------------";
            cboLop.Text = "     ----------------------- Lựa chọn Lớp -----------------------";
            txtDiemToan.Text = "";
            txtDiemLy.Text = "";
            txtDiemHoa.Text = "";
        }

        private void cboNganh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboLop_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }

   
}
