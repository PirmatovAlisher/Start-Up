using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.TeamVM
{
	public class TeamAddVM
	{
		public string FullName { get; set; } = string.Empty;

		public string Title { get; set; } = string.Empty;

		public string FileName { get; set; } = string.Empty;

		public string FileType { get; set; } = string.Empty;

		public string? Twitter { get; set; }

		public string? LinkedId { get; set; }

		public string? Facebook { get; set; }

		public string? Instagram { get; set; }

		public IFormFile Photo { get; set; } = null!;
	}
}
