using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore.Model
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateAt { get; set; } = new DateTime();
        public DateTime UpdateAt { get; set; } = new DateTime();
    }
}
