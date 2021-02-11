using System;

namespace pet_system_alarm_library.Models
{
    public class Person
    {
        public int Id { get; set; }
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
