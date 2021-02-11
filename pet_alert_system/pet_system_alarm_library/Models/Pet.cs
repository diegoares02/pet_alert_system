using System.Collections.Generic;

namespace pet_system_alarm_library.Models
{
    public enum PetColor
    {
        Black,
        White,
        Brown,
        Gold
    }
    public enum PetType
    {
        Cat,
        Dog
    }
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public PetType PetType { get; set; }
        public PetColor PetColor { get; set; }
        public string Details { get; set; }
        public string Breed { get; set; }
        public string PetPhoto { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<PetLocation> PetLocations { get; set; }
        public ICollection<Vaccine> Vaccines { get; set; }
    }
}
