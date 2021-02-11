using System;
using System.Collections.Generic;
using System.Text;

namespace pet_system_alarm_library.Models
{
    public class PetLocation
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }

        public DateTime LocationDate
        {
            get { return DateTime.Now; }
        }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
