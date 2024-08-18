using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Blog.Models
{
    public class BMW
    {
        [Key]
        public int BMWID { get; set; }

        public string Ten { get; set; }

        public double? CongSuatDienToiDa { get; set; } // Công suất điện tối đa

        public double? TangToc { get; set; } // Tăng tốc từ 0 - 100 km/h

        public double? MoMenXoanToiDa { get; set; } // Mô-men xoắn tối đa

        public double? TocDoToiDa { get; set; } // Tốc độ tối đa

        public string Image { get; set; }

        [NotMapped]
        public bool ImageExists { get; set; }

        public decimal? Gia { get; set; } // Giá
        public int LoaiID { get; set; } // Khóa ngoại tới LoaiAudi
        public LoaiBMW LoaiBMW{ get; set; } // Điều hướng tới LoaiAudi
    }
}