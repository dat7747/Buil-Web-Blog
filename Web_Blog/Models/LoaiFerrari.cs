using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Blog.Models
{
    public class LoaiFerrari
    {
        [Key]
        public int LoaiID { get; set; }

        public string TenLoai { get; set; } // Tên của loại Ferrari

        public ICollection<Ferrari> FerrariList { get; set; } // Danh sách Ferrari thuộc loại này
    }
}
