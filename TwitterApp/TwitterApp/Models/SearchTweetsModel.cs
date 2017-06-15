using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterApp.Models
{
    public class SearchTweetsModel
    {
        [Required(ErrorMessage ="This field is required")]
        [Range(0, int.MaxValue, ErrorMessage ="Only numbers allowed")]
        public string TweetsSearchNumber { get; set; }
        [Required(ErrorMessage = "This field is required")]       
        public string SearchByText { get; set; }
       
    }
}