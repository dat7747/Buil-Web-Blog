using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Blog.Models
{
    public class Mercedes
    {
        [Key]
        public int MercedesID { get; set; }

        public string Ten { get; set; }

        public double? TangToc { get; set; } // Tăng tốc

        public double? CongSuat { get; set; } // Công suất

        public double? MucTieuThuNhienLieu { get; set; } // Mức tiêu thụ nhiên liệu

        public double? ChuTrinhDoThiCoBan { get; set; } // Chu trình đô thị cơ bản

        public double? ChuTrinhDoThiPhu { get; set; } // Chu trình đô thị phụ

        public double? TocDoCaoNhat { get; set; } // Tốc độ cao nhất

        public string Image { get; set; }

        [NotMapped]
        public bool ImageExists { get; set; }

        public int LoaiID { get; set; } // Khóa ngoại tới LoaiMercedes
        public LoaiMercedes LoaiMercedes { get; set; } // Điều hướng tới LoaiMercedes
    }
}
