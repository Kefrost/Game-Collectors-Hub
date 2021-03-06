﻿// ReSharper disable VirtualMemberCallInConstructor
namespace GameCollectorsHub.Data.Models
{
    using System;
    using System.Collections.Generic;

    using GameCollectorsHub.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Ratings = new HashSet<Rating>();
            this.Comments = new HashSet<Comment>();
            this.UserGamesCollection = new HashSet<UserGameCollection>();
            this.UserConsolesCollection = new HashSet<UserConsoleCollection>();
            this.UserAmiibosCollection = new HashSet<UserAmiiboCollection>();
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

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<UserGameCollection> UserGamesCollection { get; set; }

        public virtual ICollection<UserConsoleCollection> UserConsolesCollection { get; set; }

        public virtual ICollection<UserAmiiboCollection> UserAmiibosCollection { get; set; }
    }
}
