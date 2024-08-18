using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Blog.Models
{
    public class LoaiBMW
    {
        [Key]
        public int LoaiID  { get; set; }

        public string TenLoai  { get; set; } // Tên của loại Audi

        public ICollection<BMW> BMWList { get; set; } // Danh sách Audi thuộc loại này
    }

}