using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTvChannel.Models
{
    public class MyChannelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string imageUrl { get; set; }
        public DateTime? DateDeleted { get; set; }
        public List<MyShows> myShows { get; set; }
    }
}