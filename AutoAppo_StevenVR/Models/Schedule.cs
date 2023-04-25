using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAppo_StevenVR.Models
{
    public class Schedule
    {
        public Schedule()
        {
            
        }
        public int ScheduleId { get; set; }
        public DateTime ScheduleDateStart { get; set; }
        public DateTime ScheduleDateEnd { get; set; }
        public int InitialTime { get; set; }
        public int FinalTime { get; set; }
        public string? Notes { get; set; }
        public bool? PromoDay { get; set; }
        public bool? Active { get; set; }

    }
}
