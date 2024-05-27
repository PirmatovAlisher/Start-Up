using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.CategortVM
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public string Name { get; set; } = string.Empty;

        public List<PortfolioUpdateVM> Portfolios { get; set; } = null!;
    }
}
