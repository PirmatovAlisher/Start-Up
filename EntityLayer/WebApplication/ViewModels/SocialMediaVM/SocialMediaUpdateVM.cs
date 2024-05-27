﻿using EntityLayer.WebApplication.ViewModels.AboutVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.SocialMediaVM
{
    public class SocialMediaUpdateVM
    {
        public int Id { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public byte[] RowVersion { get; set; } = null!;


        public string? Twitter { get; set; }

        public string? LinkedId { get; set; }

        public string? Facebook { get; set; }

        public string? Instagram { get; set; }


        public AboutUpdateVM About { get; set; } = null!;
    }
}
