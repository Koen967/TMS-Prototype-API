//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestApplication.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            this.Drivers = new HashSet<Driver>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string accountNumber { get; set; }
        public string VATNumber { get; set; }
        public int locationId { get; set; }

        [JsonIgnore]
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
