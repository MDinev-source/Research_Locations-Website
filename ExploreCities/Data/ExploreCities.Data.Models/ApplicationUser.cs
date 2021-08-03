﻿// ReSharper disable VirtualMemberCallInConstructor
namespace ExploreCities.Data.Models
{
    using System;
    using System.Collections.Generic;

    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Discussions;
    using ExploreCities.Data.Models.Location;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.UserCities = new HashSet<UserCity>();
            this.UserDistricts = new HashSet<UserDistrict>();
            this.UserDiscussions = new HashSet<UserDiscussion>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        // My properties
        public virtual ICollection<UserCity> UserCities { get; set; }

        public virtual ICollection<UserDistrict> UserDistricts { get; set; }

        public virtual ICollection<UserDiscussion> UserDiscussions { get; set; }
    }
}
