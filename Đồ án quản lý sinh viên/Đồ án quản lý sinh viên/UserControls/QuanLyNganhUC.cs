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
            Nganh nganh = new Nganh();

            nganh.MsNganh = txtMaNganh.Text;
            nganh.TenNganh = txtTenNganh.Text;

            CSDL_Nganh.Add(nganh);
            MessageBox.Show("Thêm Ngành thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            hienThiLenListViewNganh();
        }
    }
}
