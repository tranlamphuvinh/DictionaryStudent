using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien_HashTable
{
    public class QuanLiSinhVien
    {
        Dictionary<int, SinhVien> DSinhVien = null;

        public QuanLiSinhVien()
        {
            DSinhVien = new Dictionary<int, SinhVien>();
        }

        public int SoLuongSinhVien()
        {
            int count = 0;
            if(DSinhVien != null)
            {
                count = DSinhVien.Count; // Phương thức Count sẽ trả về số key/value mà DSinhVien đang giữ 
            }
            return count;
        }
        public void NhapThongTinSinhVien(int id)
        {
            SinhVien sv = new SinhVien();
            Console.Write("Nhập tên sinh viên: ");
            sv.name = Console.ReadLine();
            do
            {
                Console.Write("Nhập tuổi của sinh viên: ");
                sv.age = int.Parse(Console.ReadLine());
                if (sv.age < 17)
                {
                    Console.WriteLine("Tuổi chưa hợp lệ !");
                }
            } while (sv.age < 17); // Nhập điểm từ 17 tuổi trở lên sẽ nhập thông tin tiếp theo
            Console.Write("Nhập giới tính (Nam hoặc nữ): ");
            sv.gender = Console.ReadLine();
            do
            {
                Console.Write("Nhập điểm trung bình: ");
                sv.score = float.Parse(Console.ReadLine());
                if (sv.score < 0 || sv.score > 10)
                {
                    Console.WriteLine("Điểm chưa hợp lệ !");
                }
            } while (sv.score < 0 || sv.score > 10); // Nhập điểm trong khoảng từ 0 - 10 sẽ thoát khỏi vòng lặp
            DSinhVien.Add(id, sv); // Thêm id cho key, thông tin sinh viên trong sv cho value của id trong Dictionary DSinhVien
        }
        public void HienThiThongTinSinhVien()
        {
            Console.WriteLine("ID     Tên         Tuổi     Giới tính        Điểm trung bình");
            foreach (KeyValuePair<int, SinhVien> item in DSinhVien) // Tạo item thuộc KeyValuePair để truy cập tới key và value của DSinhVien
            {
                Console.WriteLine(item.Key + "     " + item.Value.name + "           " + item.Value.age + "        " + item.Value.gender + "              " + item.Value.score);
            }
        }
        public void HienThiThongTinSinhVien(int id, SinhVien sv)
        {
            Console.WriteLine("ID     Tên         Tuổi     Giới tính        Điểm trung bình");
            Console.WriteLine(id + "     " + sv.name + "           " + sv.age + "        " + sv.gender + "              " + sv.score);

        }

        public void HienThiThongTinSinhVien(Dictionary<int, SinhVien> DSinhVien)
        {
            Console.WriteLine("ID     Tên         Tuổi     Giới tính        Điểm trung bình");
            foreach (KeyValuePair<int, SinhVien> item in DSinhVien) // Tạo item thuộc KeyValuePair để truy cập tới key và value của DSinhVien
            {
                Console.WriteLine(item.Key + "     " + item.Value.name + "           " + item.Value.age + "        " + item.Value.gender + "              " + item.Value.score);
            }
        }
        public Dictionary<int, SinhVien> TimKiemThongTinSinhVien(int id)
        {
            Dictionary<int, SinhVien> DSearch = new Dictionary<int, SinhVien>(); // Tạo một Dictionary khác để giữ kết quả cần tìm kiếm
            SinhVien sv = new SinhVien();
            if (DSinhVien != null && DSinhVien.Count > 0)
            {
                foreach (KeyValuePair<int, SinhVien> item in DSinhVien) // Tạo item thuộc KeyValuePair để truy cập tới key và value của DSinhVien
                {
                    if (item.Key == id)
                    {
                        sv.name = item.Value.name;
                        sv.age = item.Value.age;
                        sv.gender = item.Value.gender;
                        sv.score = item.Value.score;
                        DSearch.Add(id, sv); // Thêm id cho key và thông tin của sinh viên trong sv cho
                                             // value của Dictionary sẽ trả kết quả tìm kiếm
                    }

                }
            }
            return DSearch;
        }

        public bool XoaThongTinSinhVien(int id)
        {
            bool isDeleted = false;
            foreach (KeyValuePair<int, SinhVien> item in DSinhVien) // Tạo item thuộc KeyValuePair để truy cập tới key và value của DSinhVien
            {
                if (item.Key == id)
                {
                    DSinhVien.Remove(id);
                }
                isDeleted = true;
            }
            return isDeleted; // Thông báo kết quả đã xóa hay chưa
        }
        public void TimDiemLonNhat()
        {
            SinhVien result = null;
            SinhVien sv = new SinhVien();
            double MaxScore = 0;
            int id = 0;
            foreach(KeyValuePair<int, SinhVien> item in DSinhVien) // Tạo item thuộc KeyValuePair để truy cập tới key và value của DSinhVien
            {
                if(MaxScore < item.Value.score)
                {
                    MaxScore = item.Value.score;
                    id = item.Key;
                    sv.name = item.Value.name;
                    sv.age = item.Value.age;
                    sv.gender = item.Value.gender;
                    sv.score = item.Value.score;
                }
            }
            result = sv;
            HienThiThongTinSinhVien(id, sv);
        }
        public void XoaDanhSachSinhVien()
        {
            DSinhVien.Clear(); // Xóa hết dữ liệu trong DSinhVien
        }
    }
}
