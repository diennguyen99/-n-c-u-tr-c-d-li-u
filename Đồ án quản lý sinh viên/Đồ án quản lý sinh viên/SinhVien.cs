using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_quản_lý_sinh_viên
{
    class SinhVien
    {
        public int mssv { get; set; }
        public string tenSV { get; set; }
        public bool gioiTinh { get; set; }
        public LopHoc lopChuQuan { get; set; }
    }
}
