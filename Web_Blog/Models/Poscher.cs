using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Blog.Models
{
    public class Poscher
    {
        public int PoscherID { get; set; }
        public string Ten { get; set; }
        public double CongSuat { get; set; }
        public double? MoMenXoanCucDai { get; set; }
        public double? TangToc { get; set; }
        public double? TocDoToiDa { get; set; }
        public double? MucTieuThuKetHop { get; set; }
        public double? LuongKhiThaiCO2 { get; set; }
        public decimal GiaTieuChuan { get; set; }
        public double? ChieuDai { get; set; }
        public double? ChieuRong { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public bool ImageExists { get; set; }

        public int LoaiID { get; set; } // Khóa ngoại tới LoaiPoscher
        public LoaiPoscher LoaiPoscher { get; set; } // Điều hướng tới LoaiPoscher
    }
}
