using System;
using System.Collections.Generic;
using System.Text;

namespace pet_system_alarm_library.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        private DateTime vaccineDate;

        public DateTime VaccineDate
        {
            get { return DateTime.Now; }
        }
        public string Dose { get; set; }
        public string Description { get; set; }
    }
}
