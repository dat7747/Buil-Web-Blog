using System.Collections.Generic;
using Web_Blog.Models; 

namespace Web_Blog.Models
{
    public class BentleyViewModel
    {
        public IEnumerable<Bentley> BentleyList { get; set; }
        public IEnumerable<LoaiBentley> Brands { get; set; }
    }

}