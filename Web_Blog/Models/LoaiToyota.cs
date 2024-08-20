using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Web_Blog.Models
{
    public class LoaiToyota
    {
        [Key]
        public int LoaiID { get; set; }

        public string TenLoai { get; set; } // Tên của loại Toyota

        public ICollection<Toyota> ToyotaList { get; set; } // Danh sách Toyota thuộc loại này
    }
}
