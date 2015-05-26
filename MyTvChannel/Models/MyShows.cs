using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTvChannel.Models
{
    public class MyShows
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Range(1.50, 2.00 )]
        public double Price { get; set; }

        [Required]
        public string imageUrl { get; set; }

        public DateTime? DateDeleted { get; set; }

        //One to many with MyChannel
        public int MyChannelId { get; set; }

        public virtual MyChannel MyChannel { get; set; }
    } 
}