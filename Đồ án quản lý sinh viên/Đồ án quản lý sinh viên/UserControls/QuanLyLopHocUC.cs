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
            lvThongTinSV.Items.Clear();
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
            lvThongTinSV.Items.Clear();
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
                lvThongTinSV.Items.Add(lviSV);
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

            cboNganh.SelectedIndex = -1;
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            hienThiListViewThongTinSV(chonNganh);
        }

        private void QuanLyLopHocUC_Load(object sender, EventArgs e)
        {
        }
    }
}
