using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Blog.Models
{
    public class Bentley
    {
        [Key]
        public int BentleyID { get; set; }

        public string Ten { get; set; } // Tên xe

        public double? CongSuatDienToiDa { get; set; } // Công suất điện tối đa

        public double? TangToc { get; set; } // Tăng tốc từ 0 - 100 km/h

        public double? MoMenXoanToiDa { get; set; } // Mô-men xoắn tối đa

        public double? TocDoToiDa { get; set; } // Tốc độ tối đa

        public string Image { get; set; } // Tên tệp hình ảnh

        [NotMapped]
        public bool ImageExists { get; set; } // Để kiểm tra sự tồn tại của ảnh

        public decimal? Gia { get; set; } // Giá xe

        public int LoaiID { get; set; } // Khóa ngoại tới LoaiBentley

        public LoaiBentley LoaiBentley { get; set; } // Điều hướng tới LoaiBentley
    }
}