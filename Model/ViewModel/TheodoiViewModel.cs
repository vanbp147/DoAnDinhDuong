using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class TheodoiViewModel
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

        public int ID_theodoi { get; set; }

        public DateTime? Ngaythang { get; set; }

        public decimal? Fat_ba { get; set; }

        public decimal? Protein_ba { get; set; }

        public decimal? Carb_ba { get; set; }

        public decimal? Total_calos { get; set; }

        public int ID_sobuatrongngay { get; set; }

        public string Ten_bua { get; set; }
    }
}
