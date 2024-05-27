using EntityLayer.WebApplication.ViewModels.SocialMediaVM;

namespace EntityLayer.WebApplication.ViewModels.AboutVM
{
    public class AboutListVM
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

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

        public int SocialMediaId { get; set; }
        public SocialMediaListVM SocialMedia { get; set; } = null!;
    }
}
