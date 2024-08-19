using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Web_Blog.Models
{
    public class LoaiVolkswagen
    {
        [Key]
        public int LoaiID { get; set; }

        public string TenLoai { get; set; } // Tên của loại Volkswagen

        public ICollection<Volkswagen> VolkswagenList { get; set; } // Danh sách Volkswagen thuộc loại này
    }
}
