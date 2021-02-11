using System.Collections.Generic;

namespace pet_system_alarm_library.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Schedule { get; set; }
        public string Address { get; set; }
        public ICollection<Vaccine> Vaccines { get; set; }
    }
}
