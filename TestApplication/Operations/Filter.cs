using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Operations
{
    public class Filter
    {
        public string PropertyName { get; set; }
        public Operator Operator { get; set; }
        public Object Value { get; set; }
    }
}