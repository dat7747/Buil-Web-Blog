using System.Collections.Generic;
using Web_Blog.Models; 
namespace Web_Blog.Models
{
    public class HondaViewModel
    {
        public IEnumerable<Honda> HondaList { get; set; }
        public IEnumerable<LoaiHonda> Brands { get; set; }
    }
}
