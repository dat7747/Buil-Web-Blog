using System.Collections.Generic;
using Web_Blog.Models; 

namespace Web_Blog.Models
{
    public class MercedesViewModel
    {
        public List<Mercedes> MercedesList { get; set; }
        public List<LoaiMercedes> Brands { get; set; }
    }
}