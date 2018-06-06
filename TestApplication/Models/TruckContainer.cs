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

    public partial class TruckContainer
    {
        public int id { get; set; }
        public int truckId { get; set; }
        public int containerId { get; set; }
        public System.DateTime coupleDate { get; set; }
        public Nullable<System.DateTime> decoupleDate { get; set; }

        [JsonIgnore]
        public virtual Container Container { get; set; }
        [JsonIgnore]
        public virtual Truck Truck { get; set; }
    }
}