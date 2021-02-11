using System;
using System.Collections.Generic;
using System.Text;

namespace pet_system_alarm_library.Models
{
    public enum VaccineType
    {
        //Both
        Rabies,
        //Dogs
        Distemper,
        Adenovirus,
        Parvovirus,
        Parainfluenza,
        Bordetella,
        Leptospirosis,
        LymeDisease,
        Cornavirus,
        Giardia,
        CaninaInfluenza,
        //Cats
        FPL,
        FVR,
        FCV
    }
    public class Vaccine
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public DateTime VaccineDate
        {
            get { return DateTime.Now; }
        }
        public string Dose { get; set; }
        public string Description { get; set; }
        public int PetId { get; set; }
        public VaccineType VaccineType { get; set; }
        public Pet Pet { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
