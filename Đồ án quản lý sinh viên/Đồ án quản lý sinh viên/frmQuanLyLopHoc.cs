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
    public partial class frmQuanLyLopHoc : Form
    {

        private LinkedList<SinhVien> CSDL_SV;
        private LinkedList<Nganh> CSDL_Nganh;
        public frmQuanLyLopHoc()
        {
            InitializeComponent();
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

        internal void layDuLieu(LinkedList<SinhVien> cSDL_SV, LinkedList<Nganh> cSDL_Nganh)
        {
            CSDL_SV = cSDL_SV;
            CSDL_Nganh = cSDL_Nganh;
        }

        private void hienThiLenTreeViewNganh()
        {
            trvNganh.Nodes.Clear();
            LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
            LinkedList<LopHoc>.Node ptempLopHoc = ptempNganh.data.dsLop.pHead;
            while (ptempNganh != null)
            {
                TreeNode nodeNganh = new TreeNode(ptempNganh.data.tenNganh);
                trvNganh.Nodes.Add(nodeNganh);
                ptempNganh = ptempNganh.pNext;
            }
        }

        private void trvNganh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {  
                LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
                    
                while (ptempNganh != null)
                {
                    //while (ptempLopHoc != null)
                    //{
                    //    if (ptempLopHoc.data.tenLopHoc == e.Node.Text)
                    //    {
                    //        hienThiThongTinSV(ptempLopHoc.data.tenLopHoc);
                    //    }
                    //    ptempLopHoc = ptempLopHoc.pNext;
                    //}
                    if (ptempNganh.data.tenNganh == e.Node.Text)
                    {
                        hienThiThongTinSV(ptempNganh.data.tenNganh);
                    }
                    ptempNganh = ptempNganh.pNext;
                }
            }
            
        }
        private void hienThiThongTinSV(string tenNganh)
        {
            lvLopHoc.Items.Clear();
            LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
            
            while (ptempNganh != null)
            {
                if (ptempNganh.data.tenNganh == tenNganh)
                {
                    LinkedList<LopHoc>.Node ptempLopHoc = ptempNganh.data.dsLop.pHead;
                    while (ptempLopHoc != null)
                    {
                        ListViewItem lvLop = new ListViewItem(ptempLopHoc.data.maSoLopHoc);
                        lvLop.SubItems.Add(ptempLopHoc.data.tenLopHoc);
                        lvLopHoc.Items.Add(lvLop);
                        ptempLopHoc = ptempLopHoc.pNext;
                    }
                }
                ptempNganh = ptempNganh.pNext;
            }
        }

        private void hienThiLenComboBox()
        {
            cboNganh.Items.Clear();
            LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
            while (ptempNganh != null)
            {
                cboNganh.Items.Add(ptempNganh.data.tenNganh);
                ptempNganh = ptempNganh.pNext;
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //CHECK ERROR
            string flag = "";
            Validate checkError = new Validate();
            flag += checkError.checkComboBox("Ngành", cboNganh);
            flag += checkError.checkStringNumber("Mã Lớp Học", txtMaLopHoc.Text);
            flag += checkError.checkString("Tên Lớp Học", txtTenLopHoc.Text);

            if (flag != "")
            {
                MessageBox.Show(flag, "Error Validate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //KHOI TAO DU LIEU LỚP HỌC
            LopHoc lop = new LopHoc();

            lop.maSoLopHoc = txtMaLopHoc.Text;
            lop.tenLopHoc = txtTenLopHoc.Text;

            LinkedList<Nganh>.Node ptempNganh = CSDL_Nganh.pHead;
            while (ptempNganh != null)
            {
                if (ptempNganh.data.tenNganh == this.cboNganh.GetItemText(this.cboNganh.SelectedItem))
                {
                    lop.nganhChuQuan = ptempNganh.data;
                    ptempNganh.data.dsLop.InsertFirst(lop);
                    ptempNganh.pNext = null;
                }
                ptempNganh = ptempNganh.pNext;
            }

            //XU LY THANH CONG
            MessageBox.Show("Thêm lớp học THÀNH CÔNG", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            cboNganh.SelectedIndex = -1;
            txtMaLopHoc.Text = "";
            txtTenLopHoc.Text = "";
            cboNganh.Text = "     -------------------------Lựa chọn ngành-------------------------";
        }
        private void frmQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            hienThiLenTreeViewNganh();
            hienThiLenComboBox();
        }
    }
}
