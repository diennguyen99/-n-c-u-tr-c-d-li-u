using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_quản_lý_sinh_viên
{
    public class SinhVien
    {
        private int mssv;
        private string tenSV;
        private bool gioiTinh;
        private DateTime ngaySinh;
        private LopHoc lopChuQuan;

        private double diemToan;
        private double diemLy;
        private double diemHoa;

        public int MSSV{
            get { return mssv; }
            set { mssv = value; }
        }

        public string TenSV
        {
            get { return tenSV; }
            set { tenSV = value; }
        }

        public bool GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public DateTime NgSinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public LopHoc LopChuQuan
        {
            get { return lopChuQuan; }
            set { lopChuQuan = value; }
        }

        public double DiemToan
        {
            get { return diemToan; }
            set { diemToan = value; }
        }
        public double DiemLy
        {
            get { return diemLy; }
            set { diemLy = value; }
        }
        public double DiemHoa
        {
            get { return diemHoa; }
            set { diemHoa = value; }
        }

        public double diemTrungBinh()
        {
            return ((DiemToan + DiemLy + DiemHoa) / 3);
        }
    }
}
