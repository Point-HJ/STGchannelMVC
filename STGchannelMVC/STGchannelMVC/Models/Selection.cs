//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STGchannelMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Selection
    {
        public int BookID { get; set; }
        public Nullable<long> ISBN { get; set; }
        public string Author { get; set; }
        public string BookName { get; set; }
        public string Publisher { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Season { get; set; }
        public string Language { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
