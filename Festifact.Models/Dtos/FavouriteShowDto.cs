﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models.Dtos
{
    public class FavouriteShowDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShowId { get; set; }
    }
}
