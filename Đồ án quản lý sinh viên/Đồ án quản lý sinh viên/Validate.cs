using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Đồ_án_quản_lý_sinh_viên
{
    public class Validate
    {
        
        public string checkEmpty( string name,string content)
        {
            if (content == "")
            {
                string text = name + " không được để trống \n";
                return text;
            }
            return "";
        }

        internal string checkSame(LinkedList<SinhVien> CSDL_SV, int mssv, string name)
        {
            LinkedList<SinhVien>.Node ptempSv = CSDL_SV.pHead;
            while (ptempSv != null)
            {
                if(ptempSv.data.mssv == mssv)
                {
                    return name + " " + mssv + " " + " đã tồn tại \n";
                }
                ptempSv = ptempSv.pNext;
            }
            return "";
        }

        public string checkComboBox(string name, ComboBox a)
        {
            if (a.SelectedIndex == -1)
            {
                string text = ("Hãy chọn " + name + "\n");
                return text;
            }
            return "";
        }

        public string checkRadioBtn(RadioButton radA, RadioButton radB){
            if (radA.Checked == false && radB.Checked == false)
            {
                string text = "Hãy chọn giới tính " + radA.Text + " hoặc " + radB.Text + "\n";
                return text;
            }
            return "";
        }

        public string checkNumber(string name, string content)
        {
            string text = checkEmpty(name, content);
            if (text == "")
            {
                byte[] ASCIIValues = Encoding.ASCII.GetBytes(content);
                foreach (byte b in ASCIIValues)
                {
                    if (b < 48 || b > 57)
                    {
                        text = name + " phải là số \n";
                        return text;
                    }
                }
            }
            return text;
        }

        public string checkString(string name, string content)
        {
            string text = checkEmpty(name, content);
            if (text == "")
            {
                byte[] ASCIIValues = Encoding.ASCII.GetBytes(content);
                foreach (byte b in ASCIIValues)
                {
                    if (b > 47  && b < 58)
                    {
                        text += name + " phải là 1 chuỗi ký tự \n";
                        return text;
                    }
                }
            }
            return text;
        }

        public string checkStringNumber(string name, string content)
        {
            string text = checkEmpty(name, content);
            if (text == "")
                text += checkString(name, content);
            else
                return name + " không được rỗng \n";
            if (text != "")
            {
                text = "";
                text += checkNumber(name, content);
            }
            else
                return name + " phải chứa cả chữ và số \n";

            if (text == "")
                return name + " phải chứa cả chữ và số \n";
            return "";
        }
    }
}
