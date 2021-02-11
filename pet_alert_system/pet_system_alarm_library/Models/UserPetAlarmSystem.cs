using System;
using System.Collections.Generic;
using System.Text;

namespace pet_system_alarm_library.Models
{
    public class UserPetAlarmSystem
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
