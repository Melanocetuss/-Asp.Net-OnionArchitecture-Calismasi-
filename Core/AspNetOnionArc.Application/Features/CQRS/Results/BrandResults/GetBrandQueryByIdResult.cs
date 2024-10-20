﻿using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandQueryByIdResult
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
    }
}