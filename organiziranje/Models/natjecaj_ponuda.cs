//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace organiziranje.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class natjecaj_ponuda
    {
        public int id { get; set; }
        public int broj_osoblja { get; set; }
        public decimal iznos { get; set; }
        public int natjecaj_id { get; set; }
        public string dobitna_ponuda { get; set; }
    
        public virtual natjecaj natjecaj { get; set; }
    }
}
