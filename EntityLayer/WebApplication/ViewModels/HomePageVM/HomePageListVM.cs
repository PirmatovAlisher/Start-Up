using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.HomePageVM
{
    public class HomePageListVM
    {

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public string Header { get; set; } = string.Empty;

        //public string Description { get; set; } = string.Empty;

        public string VideoLink { get; set; } = string.Empty;
    }
}
