using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Results.BannerResults
{
    public class GetBannerQueryResult
    {
        public int BannerID { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
