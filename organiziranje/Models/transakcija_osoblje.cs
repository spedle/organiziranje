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
    
    public partial class transakcija_osoblje
    {
        public transakcija_osoblje()
        {
            this.natjecaj_transakcija_osoblje = new HashSet<natjecaj_transakcija_osoblje>();
            this.posao_transakcija_osoblje = new HashSet<posao_transakcija_osoblje>();
        }
    
        public int id { get; set; }
        public System.DateTime datum { get; set; }
        public decimal prihod { get; set; }
        public decimal trosak { get; set; }
        public int osoblje_id { get; set; }
    
        public virtual ICollection<natjecaj_transakcija_osoblje> natjecaj_transakcija_osoblje { get; set; }
        public virtual osoblje osoblje { get; set; }
        public virtual ICollection<posao_transakcija_osoblje> posao_transakcija_osoblje { get; set; }
    }
}
