using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Blog.Models
{
    public class LoaiMercedes
    {
        [Key]
        public int LoaiID { get; set; }

        public string TenLoai { get; set; }

        public ICollection<Mercedes> MercedesList { get; set; } // Danh sách Mercedes thuộc loại này
    }
}
