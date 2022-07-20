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
            //using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<EprescribingDBContext>();

            //    context.Database.EnsureCreated();

            //    //seed given fighters
            //    if (!context.MedicalPractices.Any())
            //    {
            //        context.MedicalPractices.AddRange(new List<MedicalPractice>()
            //        {
            //            new MedicalPractice()
            //            {
            //                PracticeNumber = "565611",
            //                Name = "Medicross",
            //                Address1 = "59 Parliament Street",
            //                Address2 = "Central",
            //                ContactNum = "0826561544",
            //                EmailAddress = "medicross@gmail.com"
            //            },
            //            new MedicalPractice()
            //            {
            //               PracticeNumber = "265612",
            //                Name = "Health Meds",
            //                Address1 = "17 Nobbs Road",
            //                Address2 = "Humewood",
            //                ContactNum = "0826569999",
            //                EmailAddress = "healthmeds@gmail.com"
            //            },
            //        });
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}
