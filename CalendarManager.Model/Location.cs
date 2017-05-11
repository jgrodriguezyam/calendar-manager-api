using System;
using System.Collections.Generic;
using CalendarManager.Model.Base;
using CalendarManager.Model.Enums;

namespace CalendarManager.Model
{
    public class Location : EntityBase, IDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public ELocationType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<SharedLocation> SharedLocations { get; set; }

        public bool IsActive { get; set; }
    }
}