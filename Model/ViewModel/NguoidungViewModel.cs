using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class NguoidungViewModel
    {
        public int ID_Nguoidung { get; set; }

        public string Taikhoan { get; set; }

        public string Ten_ND { get; set; }

        public int? Tuoi { get; set; }

        public string Gioitinh { get; set; }

        public decimal? Chieucao { get; set; }

        public decimal? Cannang { get; set; }

        public string Email { get; set; }

        public decimal? CaloriesTrongngay { get; set; }

        public string TenMuctieu { get; set; }

        public string Loai { get; set; }
        
    }
}
