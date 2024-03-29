using System;

namespace Windows_Backend.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Creation { get; set; }
    }
}