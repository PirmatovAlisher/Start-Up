using EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using Microsoft.AspNetCore.Http;

namespace EntityLayer.WebApplication.ViewModels.AboutVM
{
    public class AboutAddVM
    {

        public string Header { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Clients { get; set; }

        public int Projects { get; set; }

        public int HoursOfSupport { get; set; }

        public int HardWorkers { get; set; }

        public string FileName { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;


		public IFormFile Photo { get; set; } = null!;



		public int SocialMediaId { get; set; }
        public SocialMediaAddVM SocialMedia { get; set; } = null!;
    }
}
