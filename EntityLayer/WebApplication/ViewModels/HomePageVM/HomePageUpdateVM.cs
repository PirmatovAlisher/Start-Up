using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.HomePageVM
{
    public class HomePageUpdateVM
    {
        public int Id { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public string Header { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string VideoLink { get; set; } = string.Empty;
    }
}
