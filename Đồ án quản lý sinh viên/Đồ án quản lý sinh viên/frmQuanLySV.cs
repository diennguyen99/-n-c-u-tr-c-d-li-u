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
    
    public partial class frmQuanLySV : Form
    {

        private LinkedList<SinhVien> CSDL_SV;
        private LinkedList<Nganh> CSDL_Nganh;
        public frmQuanLySV()
        {
            InitializeComponent();
        }

        internal void layDuLieu(LinkedList<SinhVien> cSDL_SV, LinkedList<Nganh> cSDL_Nganh)
        {
            CSDL_SV = cSDL_SV;
            CSDL_Nganh = cSDL_Nganh;
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

        private void hienThiLenTreeViewNganh()
        {
            trvNganh.Nodes.Clear();
            LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
            while (ptempNganh != null)
            {
                TreeNode nodeNganh = new TreeNode(ptempNganh.data.tenNganh);
                trvNganh.Nodes.Add(nodeNganh);
                LinkedList<LopHoc>.Node ptempLopHoc = ptempNganh.data.dsLop.pHead;
                while (ptempLopHoc != null)
                {
                    TreeNode nodeLopHoc = new TreeNode(ptempLopHoc.data.tenLopHoc);
                    nodeNganh.Nodes.Add(nodeLopHoc);
                    ptempLopHoc = ptempLopHoc.pNext;
                }
                ptempNganh = ptempNganh.pNext;
            }
            trvNganh.ExpandAll();
        }
        private void trvNganh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Level == 1)
                {
                    LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
                    
                    while (ptempNganh != null)
                    {
                        LinkedList<LopHoc>.Node ptempLopHoc = ptempNganh.data.dsLop.pHead;
                        while (ptempLopHoc != null)
                        {
                            if(ptempLopHoc.data.tenLopHoc == e.Node.Text)
                            {
                                hienThiThongTinSV(ptempLopHoc.data.tenLopHoc);
                            }
                            ptempLopHoc = ptempLopHoc.pNext;
                        }
                        ptempNganh = ptempNganh.pNext;
                    }
                }
            }
        }

        private void hienThiThongTinSV(string tenLopHoc)
        {
            lvThongTinSV.Items.Clear();

            LinkedList<SinhVien>.Node ptempSV = CSDL_SV.pHead;

            while (ptempSV != null)
            {
                if(ptempSV.data.lopChuQuan.tenLopHoc == tenLopHoc)
                {
                    ListViewItem lviSV = new ListViewItem(Convert.ToString(ptempSV.data.mssv));
                    lviSV.SubItems.Add(ptempSV.data.tenSV);
                    string gioiTinh = ptempSV.data.gioiTinh == true ? "Nam" : "Nữ";
                    lviSV.SubItems.Add(gioiTinh);
                    lviSV.SubItems.Add(ptempSV.data.lopChuQuan.tenLopHoc);
                    lviSV.SubItems.Add(ptempSV.data.lopChuQuan.nganhChuQuan.tenNganh);
                    lvThongTinSV.Items.Add(lviSV);
                }
                ptempSV = ptempSV.pNext;
            }   
        }

        private void hienThiLenComboBoxNganh()
        {
            cboNganh.Items.Clear();
            LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
           
            while (ptempNganh != null)
            {
                cboNganh.Items.Add(ptempNganh.data.tenNganh);
                ptempNganh = ptempNganh.pNext;
            }
        }

        private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNganh.SelectedIndex == -1) return;
            cboLop.SelectedIndex = -1;
            cboLop.Items.Clear();
            cboLop.Text = "     ----------------------------Lựa chọn lớp--------------------------";
            string nganh = this.cboNganh.GetItemText(this.cboNganh.SelectedItem);
            hienThiLenComboBoxLopHoc(nganh);
        }
        private void hienThiLenComboBoxLopHoc(string tenNganh)
        {
            cboLop.Items.Clear();
            LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
            while (ptempNganh != null)
            {
                LinkedList<LopHoc>.Node ptempLopHoc = ptempNganh.data.dsLop.pHead;
                while (ptempLopHoc != null)
                {
                    if (ptempNganh.data.tenNganh == tenNganh)
                    {
                        cboLop.Items.Add(ptempLopHoc.data.tenLopHoc);
                    }
                    ptempLopHoc = ptempLopHoc.pNext;
                }
                ptempNganh = ptempNganh.pNext;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {


            //KHOI TAO DU LIEU SINH VIEN
            SinhVien sv = new SinhVien();

            //CHECK LỖI
            string flag="";
            Validate checkError = new Validate();
            flag += checkError.checkNumber("MSSV", txtMSSV.Text);
            flag += checkError.checkSame(CSDL_SV, Convert.ToInt32(txtMSSV.Text), "MSSV");

            flag += checkError.checkString("Tên SV", txtTenSV.Text);

            flag += checkError.checkRadioBtn(radNam, radNu);
            flag += checkError.checkComboBox("Nganh", cboNganh);
            flag += checkError.checkComboBox("Lop hoc", cboLop);

            if (flag != "")
            {

                MessageBox.Show(flag,"Error Validate",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //LƯU SINH VIEN
            sv.mssv = Convert.ToInt32(txtMSSV.Text);
            sv.tenSV = txtTenSV.Text;
            bool gioiTinh = radNam.AutoCheck ? true : false;
            sv.gioiTinh = gioiTinh;

            LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
            while (ptempNganh != null)
            {
                if (ptempNganh.data.tenNganh == this.cboNganh.GetItemText(this.cboNganh.SelectedItem))
                {
                    LinkedList<LopHoc>.Node ptempLopHoc = ptempNganh.data.dsLop.pHead;
                    while (ptempLopHoc != null)
                    {
                        if(ptempLopHoc.data.tenLopHoc == this.cboLop.GetItemText(this.cboLop.SelectedItem))
                        {
                            sv.lopChuQuan = ptempLopHoc.data;
                        }
                        ptempLopHoc = ptempLopHoc.pNext;
                    }
                }
                ptempNganh = ptempNganh.pNext;
            }
            CSDL_SV.InsertFirst(sv);

            //XU LY THANH CONG
            MessageBox.Show("Thêm sinh viên THÀNH CÔNG", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtMSSV.Text = "";
            txtTenSV.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            cboNganh.SelectedIndex = -1;
            cboLop.SelectedIndex = -1;
            cboNganh.Text = "     -------------------------Lựa chọn ngành-------------------------";
            cboLop.Items.Clear();
            cboLop.Text = "     ----------------------------Lựa chọn lớp--------------------------";
        }

        private void lvThongTinSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvThongTinSV.SelectedItems.Count > 0)
            {
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                ListViewItem lvItem = lvThongTinSV.SelectedItems[0];
                txtMSSV.Text = lvItem.SubItems[0].Text;
                txtMSSV.Enabled = false;
                txtTenSV.Text = lvItem.SubItems[1].Text;
                string gioiTinh = lvItem.SubItems[2].Text;
                if (gioiTinh == "Nam")
                    radNam.Checked = true;
                else
                    radNu.Checked = true;
                cboNganh.Text = lvItem.SubItems[4].Text;
                cboLop.Text = lvItem.SubItems[3].Text;

                int mssvSearch = Convert.ToInt32(txtMSSV.Text);
                LinkedList<SinhVien>.Node ptempSV = CSDL_SV.pHead;
                SinhVien svSearch = new SinhVien();
                while (ptempSV != null)
                {
                    if(ptempSV.data.mssv == mssvSearch)
                    {
                        svSearch = ptempSV.data;
                        break;
                    }
                    ptempSV = ptempSV.pNext;
                }
            }
        }

       
        // CLICK XÓA SINH VIÊN 
        private void btnXoa_Click(object sender, EventArgs e)
        {
            xoaSV();
        }

        //PHƯƠNG THƯC XÓA SINH VIÊN
        private void xoaSV()
        {
            int mssvSearch = Convert.ToInt32(txtMSSV.Text);
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
            //XÓA SINH VIÊN
            CSDL_SV.Remove(ptempSV);
            MessageBox.Show("Xóa sinh viên " + ptempSV.data.tenSV +
                            " Thành Công!", "Thành công");
            
        }


        private void frmQuanLySV_Load(object sender, EventArgs e)
        {
            hienThiLenTreeViewNganh();
            hienThiLenComboBoxNganh();
            cboNganh.Text = "     -------------------------Lựa chọn ngành-------------------------";
            cboLop.Text = "     ----------------------------Lựa chọn lớp--------------------------";
        }

    }
}
