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
    
    public partial class skladiste
    {
        public skladiste()
        {
            this.skladiste_opreme = new HashSet<skladiste_opreme>();
        }
    
        public int id { get; set; }
        public string naziv { get; set; }
        public string adresa { get; set; }
    
        public virtual ICollection<skladiste_opreme> skladiste_opreme { get; set; }
    }
}
