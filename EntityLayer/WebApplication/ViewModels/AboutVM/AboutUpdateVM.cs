using EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using Microsoft.AspNetCore.Http;

namespace EntityLayer.WebApplication.ViewModels.AboutVM
{
    public class AboutUpdateVM
    {
        public int Id { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public byte[] RowVersion { get; set; } = null!;




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
        public SocialMediaUpdateVM SocialMedia { get; set; } = null!;
    }
}
