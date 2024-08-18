using System.Collections.Generic;
using Web_Blog.Models; 

namespace Web_Blog.Models
{
    public class AudiViewModel
    {
        public List<Audi> AudiList { get; set; }
        public List<LoaiAudi> Brands { get; set; }
    }

}