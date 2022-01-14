using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Model
{
    public class Item : Base
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
