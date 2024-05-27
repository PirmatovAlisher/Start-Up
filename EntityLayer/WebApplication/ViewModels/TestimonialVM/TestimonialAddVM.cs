using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.TestimonialVM
{
    public class TestimonialAddVM
    {
        public string Comment { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;
    }
}
