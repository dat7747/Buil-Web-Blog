using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Web_Blog.Models
{
    public class LoaiPoscher
    {
        [Key]
        public int LoaiID { get; set; }
        public string TenLoai { get; set; }
        
        public ICollection<Poscher> Poschers { get; set; } // Thêm thuộc tính điều hướng nếu có
    }
}
