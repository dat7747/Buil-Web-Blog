using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Blog.Models
{
    public class LoaiAudi
    {
        [Key]
        public int LoaiAudiID { get; set; }

        public string Ten { get; set; } // Tên của loại Audi

        public ICollection<Audi> AudiList { get; set; } // Danh sách Audi thuộc loại này
    }

}