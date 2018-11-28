using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_quản_lý_sinh_viên
{
    public class LopHoc
    {
        private string msLopHoc;
        private string tenLopHoc;
        private Nganh nganhChuQuan;
        private LinkedList<SinhVien> dsSVLop;

        public LopHoc()
        {
            this.dsSVLop = new LinkedList<SinhVien>();
        }

        public string MsLopHoc
        {
            get { return msLopHoc; }
            set { msLopHoc = value; }
        }

        public string TenLopHoc
        {
            get { return tenLopHoc; }
            set { tenLopHoc = value; }
        }

        public Nganh NganhChuQuan
        {
            get { return nganhChuQuan; }
            set { nganhChuQuan = value; }
        }

        internal LinkedList<SinhVien> DsSVLop
        {
            get { return dsSVLop; }
            set { dsSVLop = value; }
        }
    }
}
