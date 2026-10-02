using System;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLyPhuongTien ql = new QuanLyPhuongTien();

            Console.WriteLine("================ CHẠY KỊCH BẢN KIỂM THỬ (TEST CASES) ================\n");

            // --- TC01: Kiểm tra Validation Năm sản xuất ---
            Console.WriteLine("[TC01] Kiểm tra Validation Năm sản xuất (1850):");
            try
            {
                Oto invalidOto = new Oto("OT999", "VinFast", 1850, 500000000m, 5, 1.4);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"-> Thành công bắt ngoại lệ: {ex.Message}\n");
            }

            try
            {
                // --- TC02 & TC03: Khởi tạo dữ liệu chuẩn cho TC02 và TC03 ---
                // TC02: Ô tô 5 chỗ, giá gốc 1,000,000,000 VNĐ -> Giá lăn bánh kỳ vọng: 1,420,000,000 VNĐ
                Oto oto5Cho = new Oto("OT001", "Toyota", 2023, 1000000000m, 5, 1.5);

                // TC03: Xe máy 150cc, giá gốc 50,000,000 VNĐ -> Giá lăn bánh kỳ vọng: 51,000,000 VNĐ
                XeMay xeMay150cc = new XeMay("XM001", "Honda", 2024, 50000000m, 150);

                // --- TC04: Kiểm tra Đa hình List<PhuongTien> ---
                ql.AddPhuongTien(oto5Cho);
                ql.AddPhuongTien(xeMay150cc);

                Console.WriteLine("[TC04] Kiểm tra Đa hình qua List<PhuongTien> (DisplayAll):");
                ql.DisplayAll();
                Console.WriteLine();

                // Kiểm tra chi tiết giá lăn bánh của riêng TC02 và TC03
                Console.WriteLine($"[TC02 kết quả thực tế] Giá lăn bánh Ô tô 5 chỗ: {oto5Cho.TinhGiaLanBanh():N0} VNĐ");
                Console.WriteLine($"[TC03 kết quả thực tế] Giá lăn bánh Xe máy 150cc: {xeMay150cc.TinhGiaLanBanh():N0} VNĐ\n");

                // --- TC05: Kiểm tra Tìm Giá Lăn Bánh Max ---
                Console.WriteLine("[TC05] Kiểm tra Tìm phương tiện có Giá Lăn Bánh Max:");
                var maxPt = ql.FindMaxGiaLanBanh();
                if (maxPt != null)
                {
                    Console.WriteLine($"-> Phương tiện cao nhất: {maxPt.GetInfo()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi không mong muốn: {ex.Message}");
            }

            Console.WriteLine("\n================ HOÀN TẤT KIỂM THỬ ================");
        }
    }
}