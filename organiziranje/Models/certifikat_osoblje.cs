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
    
    public partial class certifikat_osoblje
    {
        public int id { get; set; }
        public int certifikat_id { get; set; }
        public int osoblje_id { get; set; }
    
        public virtual certifikat certifikat { get; set; }
        public virtual osoblje osoblje { get; set; }
    }
}
