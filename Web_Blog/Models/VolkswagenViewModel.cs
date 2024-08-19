using System.Collections.Generic;
using Web_Blog.Models; 

namespace Web_Blog.Models
{
    public class VolkswagenViewModel
    {
        public IEnumerable<Volkswagen> VolkswagenList { get; set; }
        public IEnumerable<LoaiVolkswagen> Brands { get; set; }
    }
}