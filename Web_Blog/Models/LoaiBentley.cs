using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Blog.Models
{
public class LoaiBentley
    {
        [Key]
        public int LoaiID { get; set; }

        public string TenLoai { get; set; } // Tên của loại Bentley

        public ICollection<Bentley> BentleyList { get; set; } // Danh sách Bentley thuộc loại này
    }

}