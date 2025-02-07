﻿namespace ExploreCities.Data.Models
{
    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Location;

    public class UserCity : BaseDeletableModel<string>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string CityId { get; set; }

        public City City { get; set; }
    }
}
