using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Blog.Models
{
    public class LoaiHonda
    {
        [Key]
        public int LoaiID { get; set; }

        public string TenLoai { get; set; } // Tên của loại Honda

        public ICollection<Honda> HondaList { get; set; } // Danh sách Honda thuộc loại này
    }

}