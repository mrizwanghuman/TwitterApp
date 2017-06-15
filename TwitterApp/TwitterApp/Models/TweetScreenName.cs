using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterApp.Models
{
    public class TweetScreenName
    {
        [Required(ErrorMessage = "This field is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Only numbers allowed")]
        public string TweetsUserNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string SearchByUser { get; set; }
      
    }

}