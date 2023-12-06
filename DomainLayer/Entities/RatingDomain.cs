﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class RatingDomain
    {
        public int Id { get; set; } // Auto-generated by the database
        public string UserId { get; set; } // ID of the user who created the rating
        public int MovieId { get; set; } // ID of the movie the rating is related to
        public double Rating { get; set; }
    }
}
