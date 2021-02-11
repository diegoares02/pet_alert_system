using pet_system_alarm_library.Models;
using pet_system_alarm_library.utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pet_system_alarm_api.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(PetAlarmSystemContext context)
        {
            context.Database.EnsureCreated();

            if (context.People.Any())
            {
                return;
            }
            var people = new List<Person>
            {
                new Person(){ Name="Administrator",Lastname="Administrator",DateBirth="02/10/2021",Address="Remote location",Email="administrator@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Camila",Lastname="Smith",DateBirth="05/03/1983",Address="Ilac Centre, Henry Street, Dublin 1 ",Email="camila.smith@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Emily",Lastname="Marinkovic",DateBirth="02/09/1988",Address="Autoaddress, 4 Inns Court, Winetavern Street, Dublin 8, D08 XY01",Email="emily.marinkovic@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Luciana",Lastname="Arismendi",DateBirth="08/01/1989",Address="5 Inns Court, Winetavern Street, Dublin 8, D08 XY00",Email="luciana.arismaendi@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Sandra",Lastname="Blanco",DateBirth="06/03/1985",Address="New Company Ltd, D08 XY00",Email="sandra.blanco@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Patrick",Lastname="Lemark",DateBirth="01/08/1992",Address="Silver Birches",Email="patrick.lemark@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Pablo",Lastname="Johnson",DateBirth="10/09/1997",Address="Silver birches, Meath",Email="pablo.johnson@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Julian",Lastname="Raducu",DateBirth="04/08/1989",Address="Chancery, Turlough, Castlebar, Co. Mayo",Email="julian.raducu@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Ignacio",Lastname="Gates",DateBirth="10/02/1992",Address="Silver Birches, Millfarm, Dunboyne, Co. Meath",Email="Ignacio.gates@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Julie",Lastname="Williams",DateBirth="06/12/1982",Address="Cavalry House, Clancy Quay, Islandbridge, Dublin 8",Email="julie.williams@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Joel",Lastname="Amador",DateBirth="02/11/1990",Address="Autoaddress, 4 Inns Court, Winetavern Street, Dublin 8",Email="joel.amador@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Fatima",Lastname="Suarez",DateBirth="05/12/1986",Address="8 Silver Birches, Dunboyne, Meath",Email="fatima.suarez@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Sophie",Lastname="Sherif",DateBirth="02/06/1990",Address="Autoaddress, 4 Inns Court, Winetavern Street, Dublin 8, D08 XY00",Email="sophie.sherif@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Dario",Lastname="Thompson",DateBirth="03/05/1993",Address="5 Inns Court, Winetavern Street, Dublin 8, D0B XY00",Email="dario.thompson@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Luis",Lastname="Simpson",DateBirth="02/07/1996",Address="NewCo at Debenhams, Henry Street, Dublin 1 D01 A3T6",Email="luis.simpson@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Erick",Lastname="Stradivarius",DateBirth="03/04/1982",Address="Pavilion, The University of Dublin Trinity College, Dublin 2",Email="erick.stradivarius@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="John",Lastname="Lee",DateBirth="04/10/1991",Address="Middle Earth, Winetavern Street, Dublin 8",Email="john.lee@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Julio",Lastname="Iglesias",DateBirth="05/09/1981",Address="NewCo at Debenhams, Henry Street, Dublin 1 D01 A2T6",Email="jilio.iglesias@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()}
            };

            foreach (var item in people)
            {
                context.People.Add(item);
            }
            context.SaveChanges();

            var users = new List<UserPetAlarmSystem>();
            int cont = 1;
            foreach (var item in people)
            {
                users.Add(new UserPetAlarmSystem() { Username = item.Email, Password = EncryptDecrypt.EncryptString(item.Name.ToLower()), PersonId = cont });
                cont++;
            }
            users.ForEach(item => context.UserPetAlarmSystems.Add(item));
            context.SaveChanges();

            var hospitals = new List<Hospital>()
            {
                new Hospital(){ Name="Pet Angels", Address="777 Brockton Avenue, Abington MA 2351", Email="customer.service@petangels.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Rescue", Address="30 Memorial Drive, Avon MA 2322", Email="customer.service@petrescue.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Help", Address="250 Hartford Avenue, Bellingham MA 2019", Email="customer.service@pethelp.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Hub", Address="700 Oak Street, Brockton MA 2301", Email="customer.service@pethub.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Dream", Address="66-4 Parkhurst Rd, Chelmsford MA 1824", Email="customer.service@petdream.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Sky", Address="591 Memorial Dr, Chicopee MA 1020", Email="customer.service@petsky.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Cloud", Address="55 Brooksby Village Way, Danvers MA 1923", Email="customer.service@petcloud.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Helmet", Address="137 Teaticket Hwy, East Falmouth MA 2536", Email="customer.service@pethelmet.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Warrior", Address="42 Fairhaven Commons Way, Fairhaven MA 2719", Email="customer.service@petwarrior.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Doctors", Address="374 William S Canning Blvd, Fall River MA 2721", Email="customer.service@petdoctors.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Scy", Address="121 Worcester Rd, Framingham MA 1701", Email="customer.service@petscy.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Crazy", Address="677 Timpany Blvd, Gardner MA 1440", Email="customer.service@petcrazy.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" },
                new Hospital(){ Name="Pet Style", Address="337 Russell St, Hadley MA 1035", Email="customer.service@petstyle.com", PhoneNumber = new Random().Next(0, 65788118).ToString(), Schedule ="08:00 - 12:00 | 14:00 - 18:00" }
            };
            hospitals.ForEach(item => context.Hospitals.Add(item));
            context.SaveChanges();
            var pets = new List<Pet>()
            {
                new Pet(){ Name="Firulais", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=2},
                new Pet(){ Name="Berni", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "Bernard", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/thumb/6/64/Hummel_Vedor_vd_Robandahoeve.jpg/1200px-Hummel_Vedor_vd_Robandahoeve.jpg",PersonId=2},
                new Pet(){ Name="Jassy", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/e/e4/Shiloh_Shepherd_Dog_Outdoors.jpg",PersonId=3},
                new Pet(){ Name="Steven", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "Schnauzer", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/c/cf/%D0%A6%D0%B2%D0%B5%D1%80%D0%B3%D1%88%D0%BD%D0%B0%D1%83%D1%86%D0%B5%D1%80_%D0%BE%D0%BA%D1%80%D0%B0%D1%81_%D1%87%D0%B5%D1%80%D0%BD%D1%8B%D0%B9_%D1%81_%D1%81%D0%B5%D1%80%D0%B5%D0%B1%D1%80%D0%BE%D0%BC.JPG",PersonId=3},
                new Pet(){ Name="Minocha", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=3},
                new Pet(){ Name="Kyra", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=3},
                new Pet(){ Name="Roomie", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=4},
                new Pet(){ Name="Soch", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=5},
                new Pet(){ Name="Lassy", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=6},
                new Pet(){ Name="Troncha", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=6},
                new Pet(){ Name="Perla", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=6},
                new Pet(){ Name="Gasper", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=6},
                new Pet(){ Name="Tila", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=7},
                new Pet(){ Name="Plumb", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=8},
                new Pet(){ Name="Loca", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=9},
                new Pet(){ Name="Rasty", Age=new Random().Next(0, 15), Length = 60.5, Height = 50, PetColor = PetColor.Brown, Weight = 15, PetType = PetType.Dog, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/d/d0/German_Shepherd_-_DSC_0346_%2810096362833%29.jpg",PersonId=10},
                new Pet(){ Name="Michi", Age=new Random().Next(0, 15), Length = 30, Height = 15, PetColor = PetColor.White, Weight = 5, PetType = PetType.Cat, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/e/e3/Domestic_White_and_Gray_Cat.JPG",PersonId=10},
                new Pet(){ Name="Firulais", Age=new Random().Next(0, 15), Length = 28, Height = 16, PetColor = PetColor.Black, Weight = 5, PetType = PetType.Cat, Breed = "German Sherphed", Details = "White cheest", PetPhoto="https://upload.wikimedia.org/wikipedia/commons/9/9e/Domestic_cat.jpg",PersonId=3}
            };
            pets.ForEach(item => context.Pets.Add(item));
            context.SaveChanges();

            var vaccines = new List<Vaccine>()
            {
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=1, Dose="1 per week", PetId = 1, VaccineType = VaccineType.CaninaInfluenza,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=2, Dose="1 per week", PetId = 2, VaccineType = VaccineType.Parvovirus,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=3, Dose="1 per week", PetId = 3, VaccineType = VaccineType.CaninaInfluenza,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=4, Dose="1 per week", PetId = 4, VaccineType = VaccineType.Leptospirosis,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=5, Dose="1 per month", PetId = 5, VaccineType = VaccineType.Rabies,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=6, Dose="1 per week", PetId = 6, VaccineType = VaccineType.Rabies,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=1, Dose="1 per week", PetId = 7, VaccineType = VaccineType.Rabies,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=2, Dose="1 per week", PetId = 8, VaccineType = VaccineType.Rabies,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=3, Dose="1 per week", PetId = 9, VaccineType = VaccineType.Bordetella,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=4, Dose="1 per week", PetId = 10, VaccineType = VaccineType.Distemper,Description="It has been applied by doctor"},
                new Vaccine(){ Code ="C" + new Random().Next(0, 6589444) + "D", HospitalId=1, Dose="1 per week", PetId = 1, VaccineType = VaccineType.Adenovirus,Description="It has been applied by doctor"},
            };
            vaccines.ForEach(item => context.Vaccines.Add(item));
            context.SaveChanges();

            var petLocations = new List<PetLocation>()
            {
                new PetLocation(){ PetId=1, Latitude= 51.50853, Longitude =-0.12514 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=1, Latitude= 51.50860, Longitude =-0.12524 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=1, Latitude= 51.51853, Longitude =-0.12534 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=1, Latitude= 51.50953, Longitude =-0.12544 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=1, Latitude= 51.50853, Longitude =-0.12554 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=1, Latitude= 51.50453, Longitude =-0.12564 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=1, Latitude= 51.50353, Longitude =-0.12574 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=1, Latitude= 51.50653, Longitude =-0.12584 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=2, Latitude= 51.51553, Longitude =-0.12614 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=2, Latitude= 51.51533, Longitude =-0.12624 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=2, Latitude= 51.51543, Longitude =-0.12634 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=2, Latitude= 51.51553, Longitude =-0.12644 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=2, Latitude= 51.51563, Longitude =-0.12654 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=2, Latitude= 51.51573, Longitude =-0.12664 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=2, Latitude= 51.51583, Longitude =-0.12674 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=2, Latitude= 51.51593, Longitude =-0.12684 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=3, Latitude= 51.52813, Longitude =-0.12814 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=3, Latitude= 51.52823, Longitude =-0.12824 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=3, Latitude= 51.52833, Longitude =-0.12834 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=3, Latitude= 51.52843, Longitude =-0.12844 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=3, Latitude= 51.52853, Longitude =-0.12854 , Speed=new Random().Next(0, 8) },
                new PetLocation(){ PetId=3, Latitude= 51.52863, Longitude =-0.12864 , Speed=new Random().Next(0, 8) }
            };
            petLocations.ForEach(item => context.PetLocations.Add(item));
            context.SaveChanges();
        }
    }
}
