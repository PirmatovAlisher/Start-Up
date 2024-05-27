using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CategortVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.PortfolioVM
{
    public class PortfolioListVM
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }


        public string Title { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public CategoryListVM Category { get; set; } = null!;
    }
}
