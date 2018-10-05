using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Đồ_án_quản_lý_sinh_viên
{
    public partial class Form1 : Form
    {
        LinkedList<SinhVien> CSDL_SV = new LinkedList<SinhVien>();
        LinkedList<Nganh> CSDL_Nganh = new LinkedList<Nganh>();
        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmQuanLySV frmquanLySV = new frmQuanLySV();
            frmquanLySV.layDuLieu(CSDL_SV, CSDL_Nganh);
            frmquanLySV.ShowDialog();
        }

        private void btnQLyLopHoc_Click(object sender, EventArgs e)
        {
            frmQuanLyLopHoc frmquanLyLopHoc = new frmQuanLyLopHoc();
            frmquanLyLopHoc.layDuLieu(CSDL_SV, CSDL_Nganh);
            frmquanLyLopHoc.ShowDialog();
        }

        private void duLieuGia()
        {
            Nganh nganhCntt = new Nganh()
            {
                maSoNganh = "1711-CLC",
                tenNganh = "Công nghệ thông tin"
            };
            CSDL_Nganh.InsertFirst(nganhCntt);

            Nganh nganhCoKhi = new Nganh()
            {
                maSoNganh = "1725",
                tenNganh = "Cơ Khí"
            };
            CSDL_Nganh.InsertFirst(nganhCoKhi);

            LopHoc lopCnnt1 = new LopHoc()
            {
                maSoLopHoc = "CLC-CNTT-CL1",
                tenLopHoc = "Chat luong cao 1",
                nganhChuQuan = nganhCntt
            };
            nganhCntt.dsLop.InsertFirst(lopCnnt1);

            LopHoc lopCoKhi1 = new LopHoc()
            {
                maSoLopHoc = "CO-KHI_CL1",
                tenLopHoc = "Co Khi Chat luong cao 1",
                nganhChuQuan = nganhCoKhi
            };
            nganhCoKhi.dsLop.InsertFirst(lopCoKhi1);

            SinhVien sv1 = new SinhVien()
            {
                mssv = 1711,
                tenSV = "Nguyên Văn Nam",
                gioiTinh = true,
                lopChuQuan = lopCnnt1
            };
            CSDL_SV.InsertFirst(sv1);

            SinhVien sv2 = new SinhVien()
            {
                mssv = 1715,
                tenSV = "Nguyen thi Nam",
                gioiTinh = false,
                lopChuQuan = lopCnnt1
            };
            CSDL_SV.InsertFirst(sv2);

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
                    ws.Column(4).Width = 30;
                    ws.Column(5).Width = 40;
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

                    LinkedList<SinhVien>.Node ptempSV = CSDL_SV.pHead;
                    while (ptempSV != null)
                    {
                        colIndex = 1;
                        rowIndex++;
                        ws.Cells[rowIndex, colIndex++].Value = ptempSV.data.mssv;
                        ws.Cells[rowIndex, colIndex++].Value = ptempSV.data.tenSV;
                        string gioiTinh = ptempSV.data.gioiTinh == true ? "Nam" : "Nữ";
                        ws.Cells[rowIndex, colIndex++].Value = gioiTinh;
                        ws.Cells[rowIndex, colIndex++].Value = ptempSV.data.lopChuQuan.tenLopHoc;
                        ws.Cells[rowIndex, colIndex++].Value = ptempSV.data.lopChuQuan.nganhChuQuan.tenNganh;
                        ptempSV = ptempSV.pNext;
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

        private void btnSearchSV_Click(object sender, EventArgs e)
        {

            frmSearchSV frmSearch = new frmSearchSV();
            frmSearch.layDuLieu(CSDL_SV, CSDL_Nganh);
            frmSearch.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            duLieuGia();
        }
    }
}
