using System.Collections.Generic;
using Web_Blog.Models; 
namespace Web_Blog.Models
{
    public class FerrariViewModel
    {
        public IEnumerable<Ferrari> FerrariList { get; set; }
        public IEnumerable<LoaiFerrari> Brands { get; set; }
    }
}
