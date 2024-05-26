using CoreLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.Entities
{
    public class Contact : BaseEntity
    {
        public string Location { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Call { get; set; } = string.Empty;

        public string Map { get; set; } = string.Empty;
    }

}
