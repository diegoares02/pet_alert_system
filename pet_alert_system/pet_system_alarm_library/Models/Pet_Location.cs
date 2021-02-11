using System;
using System.Collections.Generic;
using System.Text;

namespace pet_system_alarm_library.Models
{
    public class Pet_Location
    {
        public int Id { get; set; }
        public int IdPet { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public double Speed { get; set; }
        private DateTime locationDate;

        public DateTime LocationDate
        {
            get { return DateTime.Now; }
            set { locationDate = value; }
        }

    }
}
