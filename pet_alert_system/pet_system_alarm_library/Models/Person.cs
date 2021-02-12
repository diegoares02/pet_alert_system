using System;
using System.Collections.Generic;

namespace pet_system_alarm_library.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DateBirth { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
