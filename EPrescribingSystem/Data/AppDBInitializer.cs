using EPrescribingSystem.Migrations;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EprescribingDBContext>();

                context.Database.EnsureCreated();

                //seed given data
                if (!context.MedicalPractices.Any())
                {
                    context.MedicalPractices.AddRange(new List<MedicalPractice>()
                    {
                        new MedicalPractice()
                        {
                            PracticeNumber = "565611",
                            Name = "Medicross",
                            Address1 = "59 Parliament Street",
                            Address2 = "Central",
                            ContactNum = "0826561544",
                            EmailAddress = "medicross@gmail.com",
                            SuburbID = 8
                        },
                        new MedicalPractice()
                        {
                           PracticeNumber = "265612",
                            Name = "Health Meds",
                            Address1 = "17 Nobbs Road",
                            Address2 = "Humewood",
                            ContactNum = "0826569999",
                            EmailAddress = "healthmeds@gmail.com",
                            SuburbID = 7
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Cities.Any())
                {
                    context.Cities.AddRange(new List<City>()
                    {
                        new City()
                        {
                            Name = "Gqeberha",
                            Abbreviation = "GQ"
                        },
                        new City()
                        {
                            Name = "Johannesburg",
                            Abbreviation = "JHB"
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Suburbs.Any())
                {
                    context.Suburbs.AddRange(new List<Suburb>()
                    {
                        new Suburb()
                        {
                            Name = "Summerstrand",
                            PostalCode = "6001",
                            CityID = 1
                        },
                       new Suburb()
                        {
                            Name = "Humewood",
                            PostalCode = "6001",
                            CityID = 1
                        },
                       new Suburb()
                        {
                            Name = "Walmer",
                            PostalCode = "6070",
                            CityID = 1
                        },
                    });
                    context.SaveChanges();
                }
                //if (!context.Pharmacies.Any())
                //{
                //    context.Pharmacies.AddRange(new List<Pharmacy>()
                //    {
                //        new Pharmacy()
                //        {
                //            LicenseNumber = "P-335611",
                //            Name = "Rink Pharmacy",
                //            Address1 = "4 Rink Street",
                //            SuburbID = 1,
                //            ContactNumber = "0414671544",
                //            EmailAddress = "rinkpharm@gmail.com"
                //        },
                //        new Pharmacy()
                //        {
                //            LicenseNumber = "P-735610",
                //            Name = "Njoli Pharmacy",
                //            Address1 = "Njoli & Meke Street",
                //            SuburbID = 1,
                //            ContactNumber = "0414671236",
                //            EmailAddress = "njoli@pharm.com"
                //        },
                //    });
                //    context.SaveChanges();
                //}
            }
        }
    }
}
