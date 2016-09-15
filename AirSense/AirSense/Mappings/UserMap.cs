using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using AirSense.Models;

namespace Test1.Models
{
    public class UserMap : ClassMap<UserViewModel>
    {
        public UserMap()
        {
            Table("Korisnici");

            Id(x => x.Id);

            Map(x => x.Salt)
                .Not.Nullable();
            Map(x => x.HashedPass)
                .Not.Nullable();
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Username); 
            Map(x => x.Email);
            Map(x => x.Age);
            Map(x => x.Sex);
            Map(x => x.Weight);
            Map(x => x.Height);
            Map(x => x.BMI);
            Map(x => x.FitLevel);
            Map(x => x.Goal);
            Map(x => x.RoleId);
        }
    }
}