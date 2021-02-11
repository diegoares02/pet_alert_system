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
                new Person(){ Name="Administrator",Lastname="Administrator",DateBirth=Convert.ToDateTime("02/10/2021"),Address="Remote location",Email="administrator@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Camila",Lastname="Smith",DateBirth=Convert.ToDateTime("05/03/1983"),Address="Ilac Centre, Henry Street, Dublin 1 ",Email="camila.smith@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Emily",Lastname="Marinkovic",DateBirth=Convert.ToDateTime("02/09/1988"),Address="Autoaddress, 4 Inns Court, Winetavern Street, Dublin 8, D08 XY01",Email="emily.marinkovic@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Luciana",Lastname="Arismendi",DateBirth=Convert.ToDateTime("08/01/1989"),Address="5 Inns Court, Winetavern Street, Dublin 8, D08 XY00",Email="luciana.arismaendi@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Sandra",Lastname="Blanco",DateBirth=Convert.ToDateTime("16/03/1985"),Address="New Company Ltd, D08 XY00",Email="sandra.blanco@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Patrick",Lastname="Lemark",DateBirth=Convert.ToDateTime("01/08/1992"),Address="Silver Birches",Email="patrick.lemark@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Pablo",Lastname="Johnson",DateBirth=Convert.ToDateTime("10/09/1997"),Address="Silver birches, Meath",Email="pablo.johnson@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Julian",Lastname="Raducu",DateBirth=Convert.ToDateTime("04/08/1989"),Address="Chancery, Turlough, Castlebar, Co. Mayo",Email="julian.raducu@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Ignacio",Lastname="Gates",DateBirth=Convert.ToDateTime("10/02/1992"),Address="Silver Birches, Millfarm, Dunboyne, Co. Meath",Email="Ignacio.gates@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Julie",Lastname="Williams",DateBirth=Convert.ToDateTime("06/12/1982"),Address="Cavalry House, Clancy Quay, Islandbridge, Dublin 8",Email="julie.williams@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Joel",Lastname="Amador",DateBirth=Convert.ToDateTime("02/11/1990"),Address="Autoaddress, 4 Inns Court, Winetavern Street, Dublin 8",Email="joel.amador@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Fatima",Lastname="Suarez",DateBirth=Convert.ToDateTime("05/12/1986"),Address="8 Silver Birches, Dunboyne, Meath",Email="fatima.suarez@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Sophie",Lastname="Sherif",DateBirth=Convert.ToDateTime("02/06/1990"),Address="Autoaddress, 4 Inns Court, Winetavern Street, Dublin 8, D08 XY00",Email="sophie.sherif@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Dario",Lastname="Thompson",DateBirth=Convert.ToDateTime("03/05/1993"),Address="5 Inns Court, Winetavern Street, Dublin 8, D0B XY00",Email="dario.thompson@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Luis",Lastname="Simpson",DateBirth=Convert.ToDateTime("02/07/1996"),Address="NewCo at Debenhams, Henry Street, Dublin 1 D01 A3T6",Email="luis.simpson@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Erick",Lastname="Stradivarius",DateBirth=Convert.ToDateTime("03/04/1982"),Address="Pavilion, The University of Dublin Trinity College, Dublin 2",Email="erick.stradivarius@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="John",Lastname="Lee",DateBirth=Convert.ToDateTime("04/10/1991"),Address="Middle Earth, Winetavern Street, Dublin 8",Email="john.lee@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()},
                new Person(){ Name="Julio",Lastname="Iglesias",DateBirth=Convert.ToDateTime("05/09/1981"),Address="NewCo at Debenhams, Henry Street, Dublin 1 D01 A2T6",Email="jilio.iglesias@gmail.com", IdNumber=new Random().Next(0, 1000000) + "-S", PhoneNumber = new Random().Next(0, 65788118).ToString()}
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
                users.Add(new UserPetAlarmSystem() { Username = item.Email, Password = EncryptDecrypt.EncryptString(item.Name), PersonId = cont });
                cont++;
            }
            users.ForEach(item => context.UserPetAlarmSystems.Add(item));
            context.SaveChanges();


        }
    }
}
