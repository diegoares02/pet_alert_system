using System;
using System.Collections.Generic;
using System.Text;

namespace pet_system_alarm_library.Models
{
    public enum PetColor
    {
        Black,
        White,
        Brown,
        Gold
    }
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public PetColor Color { get; set; }
        public string Details { get; set; }
    }
}
