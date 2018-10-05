using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_quản_lý_sinh_viên
{
    public class Nganh
    {
        public string maSoNganh { get; set; }
        public string tenNganh { get; set; }

        public LinkedList<LopHoc> dsLop { get; set; }

        public Nganh()
        {
            dsLop = new LinkedList<LopHoc>();
        }
    }
}
