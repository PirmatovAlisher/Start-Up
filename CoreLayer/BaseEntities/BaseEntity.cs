using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.BaseEntities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }

        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual DateTime? UpdatedDate { get; set; }

        public virtual byte[] RowVersion { get; set; } = null!;
    }
}
