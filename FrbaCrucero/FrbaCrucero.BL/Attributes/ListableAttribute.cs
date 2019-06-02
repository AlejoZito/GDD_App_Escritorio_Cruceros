using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.Attributes
{
    [System.AttributeUsage( System.AttributeTargets.Property,
                            AllowMultiple = true)]  // multiuse attribute   
    public class ListableAttribute : Attribute
    {
        public string Description;

        public ListableAttribute(string description)
        {
            Description = description;
        }
    }
}
