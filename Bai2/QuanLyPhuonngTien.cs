using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai2
{
    public class QuanLyPhuongTien
    {
        private List<PhuongTien> danhSach = new List<PhuongTien>();

        public void AddPhuongTien(PhuongTien pt)
        {
            danhSach.Add(pt);
        }

        public void DisplayAll()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach phuong tien dang trong.");
                return;
            }

            foreach (var pt in danhSach)
            {
                Console.WriteLine(pt.GetInfo());
            }
        }

        public PhuongTien FindMaxGiaLanBanh()
        {
            if (danhSach.Count == 0) return null;
            return danhSach.OrderByDescending(pt => pt.TinhGiaLanBanh()).FirstOrDefault();
        }

        public List<PhuongTien> SearchByName(string keyword)
        {
            return danhSach.Where(pt => pt.TenHang.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}