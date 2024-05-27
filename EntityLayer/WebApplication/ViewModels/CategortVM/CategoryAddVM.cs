using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.CategortVM
{
    public class CategoryAddVM
    {
        public string Name { get; set; } = string.Empty;

        public List<PortfolioListVM> Portfolios { get; set; } = null!;
    }
}
