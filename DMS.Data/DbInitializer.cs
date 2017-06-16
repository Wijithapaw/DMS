using DMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            //Comment out this section once the initial phase of development is done
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //Uncomment this section once the initial phase of development is done
            //context.Database.Migrate();

            if (context.Admins.Any())
                return;

            var admins = new Admin[]
              {
                    new Admin{ FirstName = "Super", LastName = "Admin", Birthday = new DateTime(1985,8,1), Active=true, Email="superadmin.dms@yopmail.com"},
                    new Admin{ FirstName = "Wijitha", LastName = "Wijenayake", Birthday = new DateTime(1985,8,1), Active=true, Email="wijitha.dms@yopmail.om" },
                    new Admin{ FirstName = "Jagath", LastName = "Sampath", Birthday = new DateTime(1985,8,1), Active=true, Email="jagath.dms@yopmail.com" }
              };

            context.Admins.AddRange(admins);
            context.SaveChanges();

            var donors = new Donor[]
                {
                    new Donor { FirstName = "Zaman", LastName = "Kumara", Birthday = new DateTime(1985,8,1), Active=true, Email="saman.dms@yopmail.com"},
                    new Donor { FirstName = "Widura", LastName = "Wijenayake", Birthday = new DateTime(1990,8,1), Active=true, Email="widura.dms@yopmail.com"},
                    new Donor { FirstName = "Kapila", LastName = "Senarath", Birthday = new DateTime(1975,5,1), Active=true, Email="kapila.dms@yopmail.com"}
                };

            context.Donors.AddRange(donors);
            context.SaveChanges();

            var donees = new Donee[]
                {
                    new Donee{ FirstName = "Dinith", LastName = "Atapattu", Birthday = new DateTime(1992,8,1), Active=true, Email="dinith.dms@yopmail.com" },
                    new Donee{ FirstName = "Wishwa", LastName = "Atapattu", Birthday = new DateTime(1995,8,1), Active=true, Email="wishawa.dms@yopmail.com" },
                    new Donee{ FirstName = "Ranjith", LastName = "Gamage", Birthday = new DateTime(1992,8,5), Active=true, Email="ranjith.dms@yopmail.com" }
                };

            context.Donees.AddRange(donees);
            context.SaveChanges();

            var projectCategories = new ProjectCategory[]
               {
                    new ProjectCategory { ShortDescription = "Educational", Description="Scholarship for educational purpose"},
                    new ProjectCategory { ShortDescription = "Self Employment", Description="Financial aid for develop self-employment"},
                    new ProjectCategory { ShortDescription = "Other", Description="Other financial aid"}
               };

            context.ProjectCategories.AddRange(projectCategories);
            context.SaveChanges();

            var projects = new Project[]
                {
                    new Project { Description="Scholorship to University student", ProjectCategoryId=1, EndDateUtc= new DateTime(2019,1,5), StartDateUtc = new DateTime(2017, 4, 1), Title="Scholarhip to Saman"},
                    new Project { Description="Scholorship to A/L student", ProjectCategoryId=1, EndDateUtc= new DateTime(2018,1,5), StartDateUtc = new DateTime(2017,7, 1), Title="Schorship to Madura"},
                    new Project { Description="Scholorship to O/L student", ProjectCategoryId=1, EndDateUtc= new DateTime(2017,12,31), StartDateUtc = new DateTime(2017, 4, 1), Title="Scholarhip to Kasun"}
                };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}
