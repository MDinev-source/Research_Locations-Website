﻿namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Discussions;

    public class District : BaseDeletableModel<string>
    {
        public District()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DistrictViews = new HashSet<DistrictView>();
            this.UserDistricts = new HashSet<UserDistrict>();
            this.DistrictLikes = new HashSet<DistrictLike>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int Raiting { get; set; }

        [Required]
        public string CityId { get; set; }

        public City City { get; set; }

        public virtual ICollection<DistrictView> DistrictViews { get; set; }

        public virtual ICollection<UserDistrict> UserDistricts { get; set; }

        public virtual ICollection<DistrictLike> DistrictLikes { get; set; }
    }
}
