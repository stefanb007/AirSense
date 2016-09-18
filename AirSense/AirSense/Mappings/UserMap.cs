using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using AirSense.Models;

namespace Test1.Models
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");

            Id(x => x.Id);

            Map(x => x.Salt)
                .Column("Salt")
                .Not.Nullable();

            Map(x => x.HashedPass)
                .Column("HashedPass")
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .Not.Nullable();

            Map(x => x.Surname)
                .Column("Surname")
                .Not.Nullable();

            Map(x => x.Username)
                .Column("Username")
                .Not.Nullable();

            Map(x => x.Email)
                .Column("Email")
                .Not.Nullable();

            Map(x => x.Age)
                .Column("Age")
                .Not.Nullable();

            Map(x => x.Sex)
                .Column("Sex")
                .Not.Nullable();

            Map(x => x.Weight)
                .Column("Weight")
                .Nullable();

            Map(x => x.Height)
                .Column("Height")
                .Nullable();

            Map(x => x.BMI)
                .Column("BMI")
                .Nullable();

            Map(x => x.FitLevel)
                .Column("FitLevel")
                .Nullable();

            Map(x => x.Goal)
                .Column("Goal")
                .Nullable();

            Map(x => x.RoleId)
                .Column("RoleId")
                .Not.Nullable();
        }
    }
}