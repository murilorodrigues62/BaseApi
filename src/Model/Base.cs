using System;

namespace BaseApi.Model
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
