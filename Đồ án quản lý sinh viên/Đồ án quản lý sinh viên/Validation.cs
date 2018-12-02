using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Đồ_án_quản_lý_sinh_viên
{
    public class Validation
    {
        public string kiemTraRong(string name, TextBox txt)
        {
            if (txt.Text == "")
            {
                return name + " KHÔNG được để trống\n";
            }
            return "";
        }

        public string kiemTraSo(string name, TextBox txt)
        {
            string content = kiemTraRong(name, txt);
            if (content != "")
                return content;
            Regex regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(txt.Text))
            {
                return name + " phải là SỐ\n";
            }
            return "";
        }


        public string kiemTraChuoi(string name, TextBox txt)
        {
            string content = kiemTraRong(name, txt);
            if (content != "")
                return content;
            Regex regex = new Regex(@"\d+");
            if (!regex.IsMatch(txt.Text))
            {
                return "";
            }
            return name + " phải là CHUỖI\n";
        }

        public string kiemTraRadio(RadioButton a, RadioButton b)
        {
            if(a.Checked == false && b.Checked == false)
            {
                return "Hãy chọn Giới tính\n";
            }
            return "";
        }
        
        public string kiemTraDate(TextBox ngaySinh, TextBox thangSinh, TextBox namSinh)
        {
            string content = "";
            content += kiemTraRong("Ngày sinh", ngaySinh);
            content += kiemTraRong("Tháng sinh", thangSinh);
            content += kiemTraRong("Năm sinh", namSinh);
            if (content != "")
                return content;

            if (Int32.Parse(thangSinh.Text) < 1 || Int32.Parse(thangSinh.Text) > 12)
                return "Tháng sinh không hợp lệ\n";
            if (Int32.Parse(namSinh.Text) > DateTime.Now.Year)
                return "Năm sinh không hợp lệ\n";

            int[] soNgay = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if(Int32.Parse(thangSinh.Text) == 2 && Int32.Parse(ngaySinh.Text) == 29 && (Int32.Parse(namSinh.Text) % 400 == 0 || 
                           (Int32.Parse(namSinh.Text) % 4 ==0 && Int32.Parse(namSinh.Text) % 100 != 0)))
            {
                return "";
            }

            if(Int32.Parse(ngaySinh.Text) < 1 || 
               Int32.Parse(ngaySinh.Text) > soNgay[Int32.Parse(thangSinh.Text)])
            {
                return "Ngày không hợp lệ\n";
            }

            return "";
        }

        public string kiemTraComboBox(string name, ComboBox cbo)
        {
            if(cbo.SelectedIndex == -1)
            {
                return "Hãy chọn " + name + "\n";
            }
            return "";
        }

        public string kiemTraDiem(string name, TextBox txt)
        {
            string content = kiemTraRong(name, txt);
            if (content != "")
                return content;

            if (Int32.Parse(txt.Text) < 0 || Int32.Parse(txt.Text) > 10)
            {
                return name + " không hợp lệ\n";
            }
            return "";
        }

        public bool kiemTraTrung(TextBox txt, string txtSearch)
        {
            if(txt.Text == txtSearch)
            {
                return false;
            }
            return true;
        }
    }
}
