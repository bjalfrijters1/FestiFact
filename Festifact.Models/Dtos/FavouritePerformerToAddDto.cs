﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models.Dtos
{
    public class FavouritePerformerToAddDto
    {
        public int UserId { get; set; }
        public int PerformerId { get; set; }
    }
}
