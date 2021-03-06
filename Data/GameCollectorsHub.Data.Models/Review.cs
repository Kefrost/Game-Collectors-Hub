﻿namespace GameCollectorsHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using GameCollectorsHub.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public Review()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int GameId { get; set; }

        public Game Game { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1, 10)]
        public int RatingScore { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
