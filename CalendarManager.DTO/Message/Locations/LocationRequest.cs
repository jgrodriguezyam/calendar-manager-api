﻿namespace CalendarManager.DTO.Message.Locations
{
    public class LocationRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public int Type { get; set; }
        public int UserId { get; set; }
    }
}