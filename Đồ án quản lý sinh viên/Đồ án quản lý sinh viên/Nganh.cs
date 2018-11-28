using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_quản_lý_sinh_viên
{
    public class Nganh
    {
        private string msNganh;
        private string tenNganh;
        private LinkedList<LopHoc> dsLop;

        public Nganh()
        {
            this.dsLop = new LinkedList<LopHoc>();
        }
        public string MsNganh
        {
            get { return msNganh; }
            set { msNganh = value; }
        }

        public string TenNganh
        {
            get { return tenNganh; }
            set { tenNganh = value; }
        }

        internal LinkedList<LopHoc> DsLop
        {
            get { return dsLop; }
            set { dsLop = value; }
        }
    }
}
