//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MMTPracticalTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class city_table
    {
        public int cityid { get; set; }
        public string cityname { get; set; }
        public Nullable<int> sid { get; set; }
    
        public virtual state_table state_table { get; set; }
    }
}
