using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Model
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
