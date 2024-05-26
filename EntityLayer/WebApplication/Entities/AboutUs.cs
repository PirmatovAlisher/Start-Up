using CoreLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.Entities
{
    public class AboutUs : BaseEntity
    {
        public string Header { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Clients {  get; set; } = string.Empty;

        public string Projects { get; set; } = string.Empty;

        public string HoursOfSupport { get; set; } = string.Empty;  

        public string HardWorkers {  get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;

        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; } = null!;
    }
}
