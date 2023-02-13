using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLiSinhVien_HashTable
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            QuanLiSinhVien quanLiSinhVien = new QuanLiSinhVien();
            Console.WriteLine("===============================================================");
            Console.WriteLine("|                                                             |");
            Console.WriteLine("|            CHƯƠNG TRÌNH QUẢN LÍ SINH VIÊN                   |");
            Console.WriteLine("|                                                             |");
            Console.WriteLine("|      - Danh sách các chức năng:                             |");
            Console.WriteLine("|                                                             |");
            Console.WriteLine("|      1. Nhập thông tin sinh viên                            |");
            Console.WriteLine("|      2. Xem thông tin sinh viên                             |");
            Console.WriteLine("|      3. Xóa thông tin sinh viên theo id                     |");
            Console.WriteLine("|      4. Tìm sinh viên theo id                               |");
            Console.WriteLine("|      5. Tìm sinh viên có điểm trung bình lớn nhất           |");
            Console.WriteLine("|                                                             |");
            Console.WriteLine("|                                                             |");
            Console.WriteLine("===============================================================");
            Console.Write("Chọn chức năng bạn muốn thực hiện: ");
            int chucnang = int.Parse(Console.ReadLine());
            string turn;
            do
            {
                switch (chucnang)
                {
                    case 1: // Chức năng nhập thông tin sinh viên
                        Console.WriteLine();
                        Console.Write("Nhập số lượng sinh viên: ");
                        int soSV = int.Parse(Console.ReadLine());
                        for (int i = 1; i <= soSV; i++)
                        {
                            Console.WriteLine("Thông tin sinh viên số " + i);
                            quanLiSinhVien.NhapThongTinSinhVien(i);
                            Console.WriteLine();
                        }
                        break;
                    case 2: // Chức năng xem thông tin sinh viên
                        Console.WriteLine();
                        if (quanLiSinhVien.SoLuongSinhVien() > 0)
                        {
                            quanLiSinhVien.HienThiThongTinSinhVien();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Danh sách không có sinh viên");
                        }
                        break;
                    case 3: // Chức năng xóa thông tin của 1 sinh viên theo id
                        Console.WriteLine();
                        if (quanLiSinhVien.SoLuongSinhVien() > 0)
                        {
                            int idDelete;
                            do
                            {
                                Console.Write("Nhập id cần xóa: ");
                                idDelete = int.Parse(Console.ReadLine());
                                if (idDelete < 0)
                                {
                                    Console.WriteLine("ID không được là số âm");
                                }
                            } while (idDelete < 0);
                            if (quanLiSinhVien.XoaThongTinSinhVien(idDelete) == true)
                            {
                                Console.WriteLine("Đã xóa thành công");
                            }
                            else
                            {
                                Console.WriteLine("Không có id để xóa");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Danh sách không có sinh viên");
                        }
                        ; break;
                    case 4: // Chức năng tìm kiếm sinh viên theo id
                        Console.WriteLine();
                        if (quanLiSinhVien.SoLuongSinhVien() > 0)
                        {
                            int id;
                            do
                            {
                                Console.Write("Nhập id cần tìm kiếm: ");
                                id = int.Parse(Console.ReadLine());
                                if (id < 0)
                                {
                                    Console.WriteLine("ID không được là số âm");
                                }
                            } while (id < 0);
                            Dictionary<int, SinhVien> DSearch = new Dictionary<int, SinhVien>();
                            DSearch = quanLiSinhVien.TimKiemThongTinSinhVien(id);
                            quanLiSinhVien.HienThiThongTinSinhVien(DSearch);
                        }
                        else
                        {
                            Console.WriteLine("Không có sinh viên trong danh sách");
                        }
                        break;
                    case 5: // Chức năng hiển thị thông tin của sinh viên có điểm trung bình lớn nhất trong danh sách
                        Console.WriteLine();
                        if (quanLiSinhVien.SoLuongSinhVien() > 0)
                        {
                            quanLiSinhVien.TimDiemLonNhat();
                        }
                        else
                        {
                            Console.WriteLine("Không có sinh viên trong danh sách");
                        }
                        break;
                    case 6: // Xóa toàn bộ danh sách sinh viên
                        Console.WriteLine();
                        if(quanLiSinhVien.SoLuongSinhVien() > 0)
                        {
                            quanLiSinhVien.XoaDanhSachSinhVien();

                        }
                        else
                        {
                            Console.WriteLine("Không có sinh viên trong danh sách để xóa");
                        }
                        break;
                    default:
                        Console.WriteLine("Không có chức năng mà bạn muốn. Xin hãy nhập lại. ");
                        break;
                }
                do
                {
                    Console.WriteLine();
                    Console.Write("Bạn có muốn tiếp tục không ? (Chọn c: có; Chọn k: không)   ");
                    turn = Console.ReadLine();
                } while (turn != "c" && turn != "C" && turn != "k" && turn != "K");
                if (turn == "c" || turn == "C") // Nếu chọn c hoặc C thì tiếp tục chương trình
                {
                    Console.Write("Chọn chức năng bạn muốn thực hiện: ");
                }
                if (turn == "k" || turn == "K") // Nếu chọn k hay K sẽ kết thúc chương trình
                {
                    break;
                }
                chucnang = int.Parse(Console.ReadLine());
            } while (turn != "k" || turn != "K");
        }
    }
}