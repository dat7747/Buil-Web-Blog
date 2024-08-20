using System.Collections.Generic;
using Web_Blog.Models; 

namespace Web_Blog.Models
{
    public class ToyotaViewModel
    {
        public IEnumerable<Toyota> ToyotaList { get; set; }
        public IEnumerable<LoaiToyota> Brands { get; set; }
    }
}