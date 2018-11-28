using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace Đồ_án_quản_lý_sinh_viên
{

    public partial class Form1 : Form
    {
        LinkedList<SinhVien> CSDL_SV = new LinkedList<SinhVien>();
        LinkedList<LopHoc> CSDL_Lop = new LinkedList<LopHoc>();
        LinkedList<Nganh> CSDL_Nganh = new LinkedList<Nganh>();


        public Form1()
        {
            InitializeComponent();
            gioiThieuUC1.BringToFront();
            labelTitle.Text = "Giới thiệu";
            duLieuGia();
        }

        private void duLieuGia()
        {
            Nganh nganhCntt = new Nganh();
            nganhCntt.MsNganh = "CNTT_CLC";
            nganhCntt.TenNganh = "Công nghệ thông tin";

            LopHoc lopCNTTCL1 = new LopHoc();
            lopCNTTCL1.MsLopHoc = "1711_CNTT";
            lopCNTTCL1.TenLopHoc = "Chất lượng cao CL1";
            lopCNTTCL1.NganhChuQuan = nganhCntt;

            SinhVien sv2 = new SinhVien();
            sv2.MSSV = 1711;
            sv2.TenSV = "Nguyễn Văn Tuấn";
            sv2.GioiTinh = true;
            sv2.LopChuQuan = lopCNTTCL1;

            nganhCntt.DsLop.Add(lopCNTTCL1);

            CSDL_Lop.Add(lopCNTTCL1);
            CSDL_Nganh.Add(nganhCntt);

            lopCNTTCL1.DsSVLop.Add(sv2);
            CSDL_SV.Add(sv2);

            //SinhVien sv1 = new SinhVien();
            //sv1.MSSV = 1711;
            //sv1.TenSV = "Nguyễn Văn Nam";
            //sv1.GioiTinh = true;
            //sv1.LopChuQuan = lopCNTTCL1;
            ////SinhVien sv2 = new SinhVien(1718, "Trần Thị Tèo");
            //CSDL_SV.InsertFirst(sv1);
            ////CSDL_SV.InsertFirst(sv2);

            Nganh CoKhi = new Nganh();
            CoKhi.MsNganh = "CoKhiCLC";
            CoKhi.TenNganh = "Cơ khí";
            

            LopHoc lopCoKhi1 = new LopHoc();
            lopCoKhi1.MsLopHoc = "abc";
            lopCoKhi1.TenLopHoc = "Lớp Cơ khí CLC1";
            lopCoKhi1.NganhChuQuan = CoKhi;

            SinhVien sv1 = new SinhVien();
            sv1.MSSV = 1712;
            sv1.TenSV = "Nguyễn Văn Nam";
            sv1.GioiTinh = true;
            sv1.LopChuQuan = lopCoKhi1;

            CoKhi.DsLop.Add(lopCoKhi1);
            CSDL_Nganh.Add(CoKhi);
            lopCoKhi1.DsSVLop.Add(sv1);
            CSDL_Lop.Add(lopCoKhi1);
            CSDL_SV.Add(sv1);
        }

        private void btnGioiThieu_Click(object sender, EventArgs e)
        {
            panelClick.Height = btnGioiThieu.Height;
            panelClick.Top = btnGioiThieu.Top;
            gioiThieuUC1.BringToFront();
            labelTitle.Text = "Giới thiệu";
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            DialogResult flag = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(flag == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btQLSV_Click(object sender, EventArgs e)
        {
            panelClick.Height = btQLSV.Height;
            panelClick.Top = btQLSV.Top;
            quanLySinhVienUC1.BringToFront();
            labelTitle.Text = "Quản lý sinh viên";
            quanLySinhVienUC1.layDuLieu(CSDL_SV, CSDL_Lop, CSDL_Nganh);
        }
        private void btnQLLopHoc_Click(object sender, EventArgs e)
        {
            panelClick.Height = btnQLLopHoc.Height;
            panelClick.Top = btnQLLopHoc.Top;
            quanLyLopHocUC1.BringToFront();
            labelTitle.Text = "Quản lý lớp học";
            quanLyLopHocUC1.layDuLieu(CSDL_Lop, CSDL_Nganh);
        }

        private void btnQLNganh_Click(object sender, EventArgs e)
        {
            panelClick.Height = btnQLNganh.Height;
            panelClick.Top = btnQLNganh.Top;
            quanLyNganhUC1.BringToFront();
            labelTitle.Text = "Quản lý ngành";
            quanLyNganhUC1.layDuLieu(CSDL_Nganh);
        }

        private void btnTimKiemSV_Click(object sender, EventArgs e)
        {
            panelClick.Height = btnTimKiemSV.Height;
            panelClick.Top = btnTimKiemSV.Top;
            timKiemSinhVienUC1.BringToFront();
            labelTitle.Text = "Tìm Kiếm Sinh Viên";
            timKiemSinhVienUC1.layDuLieu(CSDL_SV);
        }
        private void quanLySinhVienUC1_Load(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            dialog.ShowDialog();

            filePath = dialog.FileName;


            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    // đặt tên người tạo file
                    p.Workbook.Properties.Author = "Phần mềm quản lý sinh viên";

                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = "Thông kê sinh viên";

                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add("Quản lý Sinh Viên");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Quản lý sinh viên";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "MSSV",
                                                "Họ tên",
                                                "Giới tính",
                                                "Ngày sinh",
                                                "Điểm toán",
                                                "Điểm lý",
                                                "Điểm hóa",
                                                "Điểm TB",
                                                "Lớp",
                                                "Ngành"
                };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = "QUẢN LÝ SINH VIÊN";
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    // font size
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 25;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    //tạo các header từ column header đã tạo từ bên trên

                    ws.Column(2).Width = 30;
                    ws.Column(3).Width = 10;
                    ws.Column(4).Width = 15;
                    ws.Column(5).Width = 15;
                    ws.Column(6).Width = 15;
                    ws.Column(7).Width = 15;
                    ws.Column(8).Width = 15;
                    ws.Column(9).Width = 30;
                    ws.Column(10).Width = 40;

                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);


                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;
                        cell.Value = item;
                        colIndex++;
                    }

                    LinkedList<SinhVien>.Node nodeSV = CSDL_SV.pHead;
                    while (nodeSV != null)
                    {
                        colIndex = 1;
                        rowIndex++;
                        ws.Cells[rowIndex, colIndex++].Value = nodeSV.data.MSSV;
                        ws.Cells[rowIndex, colIndex++].Value = nodeSV.data.TenSV;
                        string gioiTinh = nodeSV.data.GioiTinh == true ? "Nam" : "Nữ";
                        ws.Cells[rowIndex, colIndex++].Value = gioiTinh;
                        //Định dạng ngày tháng bằng cách sử dụng fr-FR
                        IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
                        ws.Cells[rowIndex, colIndex++].Value = nodeSV.data.NgSinh.GetDateTimeFormats(culture)[0];
                        ws.Cells[rowIndex, colIndex++].Value = nodeSV.data.DiemToan;
                        ws.Cells[rowIndex, colIndex++].Value = nodeSV.data.DiemLy;
                        ws.Cells[rowIndex, colIndex++].Value = nodeSV.data.DiemHoa;
                        ws.Cells[rowIndex, colIndex++].Value = nodeSV.data.diemTrungBinh();
                        ws.Cells[rowIndex, colIndex++].Value = nodeSV.data.LopChuQuan.TenLopHoc;
                        ws.Cells[rowIndex, colIndex++].Value = nodeSV.data.LopChuQuan.NganhChuQuan.TenNganh;
                        nodeSV = nodeSV.pNext;
                    }



                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                MessageBox.Show("Xuất excel thành công!");
            }
            catch (Exception EE)
            {
                MessageBox.Show("Có lỗi khi lưu file!");
            }
        }
    }
}
