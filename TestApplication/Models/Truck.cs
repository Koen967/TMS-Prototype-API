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

    public partial class Truck
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Truck()
        {
            this.TruckContainers = new HashSet<TruckContainer>();
            this.TruckDrivers = new HashSet<TruckDriver>();
            this.TruckLocations = new HashSet<TruckLocation>();
        }
    
        public int id { get; set; }
        public int number { get; set; }
        public string brand { get; set; }
        public string licencePlate { get; set; }
        public string chassis { get; set; }
        public bool rental { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<TruckContainer> TruckContainers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<TruckDriver> TruckDrivers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<TruckLocation> TruckLocations { get; set; }
    }
}
