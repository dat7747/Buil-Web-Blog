using System.Collections.Generic;
using Web_Blog.Models; 

namespace Web_Blog.Models
{
    public class LamborghiniViewModel
    {
        public IEnumerable<Lamborghini> LamborghiniList { get; set; }
        public IEnumerable<LoaiLamborghini> Brands { get; set; }
    }

}