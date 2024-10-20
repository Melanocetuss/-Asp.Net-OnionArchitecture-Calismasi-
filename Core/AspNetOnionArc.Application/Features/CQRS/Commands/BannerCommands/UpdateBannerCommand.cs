using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Commands.BannerCommands
{
    public class UpdateBannerCommand
    {
        public int BannerID { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
