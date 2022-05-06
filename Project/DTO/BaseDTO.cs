using System;

namespace Project.DTO
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
