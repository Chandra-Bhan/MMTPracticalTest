

namespace MMTPracticalTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class mmt_table
    {
        public int id { get; set; }
        [Display(Name ="Name")]
        [Required(ErrorMessage ="Name is Required")]
        public string name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage ="Email is Invalid")]
        public string email { get; set; }
        [Display(Name = "Phone No")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string phoneno { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required")]
        public string city { get; set; }       
        public bool agree { get; set; }
        [Required(ErrorMessage = "State is Required")]
        public int stateid { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public int cityid { get; set; }
    }
}
