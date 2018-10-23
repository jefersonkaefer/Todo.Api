using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Interfaces;

namespace Todo.Domain.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
    }
}
