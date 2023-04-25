using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAppo_StevenVR.Models
{
    public  class Service
    {
        public Service()
        {
            
        }
        public int ServiceId { get; set; }
        public string ServiceDescription { get; set; } = null!;
        public int ServiceTimeSpan { get; set; }
        public decimal ServiceEstimatedCost { get; set; }
        public bool? Active { get; set; }


    }
}
