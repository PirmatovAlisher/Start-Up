using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.ContactVM
{
    public class ContactUpdateVM
    {
        public int Id { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public byte[] RowVersion { get; set; } = null!;


        public string Location { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Call { get; set; } = string.Empty;

        public string Map { get; set; } = string.Empty;
    }
}
