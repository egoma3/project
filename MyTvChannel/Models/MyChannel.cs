using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTvChannel.Models
{
    public class MyChannel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set;}

        [Required]
        public string imageUrl { get; set; }

        public DateTime? DateDeleted { get; set; }

        public virtual List<MyShows> myShows { get; set; }


    }

}