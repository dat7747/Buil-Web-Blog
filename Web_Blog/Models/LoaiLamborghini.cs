using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Web_Blog.Models
{
    public class LoaiLamborghini
    {
        [Key]
        public int LoaiID { get; set; }

        public string TenLoai { get; set; } // Tên của loại Lamborghini

        public ICollection<Lamborghini> LamborghiniList { get; set; } // Danh sách Lamborghini thuộc loại này
    }
}
