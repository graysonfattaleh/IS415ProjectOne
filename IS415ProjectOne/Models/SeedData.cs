using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS415ProjectOne.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            TempleAppointmentDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<TempleAppointmentDbContext>();

            

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Groups.Any())
            {
                context.Groups.AddRange(
                    new Group
                    {
                        GroupName = "Marlins",
                        Size = 10,
                        Email = "fake1@gmail.com",
                        PhoneNumber = "123-123-1234",
                        //assigns year, month, day, hour, min, seconds
                        //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
                        StartTime = new DateTime(2021, 3, 18, 16, 0, 0)
                    },
                    new Group 
                    {
                        GroupName = "Marlins2",
                        Size = 20,
                        Email = "fake2@gmail.com",
                        PhoneNumber = "123-123-1235",
                        //assigns year, month, day, hour, min, seconds
                        //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
                        StartTime = new DateTime(2021, 3, 19, 16, 0, 0)
                    },
                    new Group
                    {
                        GroupName = "Marlins3",
                        Size = 30,
                        Email = "fake4@gmail.com",
                        PhoneNumber = "123-123-1235",
                        //assigns year, month, day, hour, min, seconds
                        //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
                        StartTime = new DateTime(2021, 3, 20, 17, 0, 0)
                    },
                    new Group
                    {
                        GroupName = "Marlins4",
                        Size = 30,
                        Email = "fake4@gmail.com",
                        PhoneNumber = "123-123-1235",
                        //assigns year, month, day, hour, min, seconds
                        //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
                        StartTime = new DateTime(2021, 3, 21, 17, 0, 0)
                    },
                    new Group
                    {
                        GroupName = "Marlins5",
                        Size = 30,
                        Email = "fake4@gmail.com",
                        PhoneNumber = "123-123-1235",
                        //assigns year, month, day, hour, min, seconds
                        //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
                        StartTime = new DateTime(2021, 3, 22, 11, 0, 0)
                    },
                    new Group
                    {
                        GroupName = "Marlins5.1",
                        Size = 30,
                        Email = "fake4@gmail.com",
                        PhoneNumber = "123-123-1235",
                        //assigns year, month, day, hour, min, seconds
                        //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
                        StartTime = new DateTime(2021, 3, 22, 10, 0, 0)
                    },
                    new Group
                    {
                        GroupName = "Marlins7",
                        Size = 30,
                        Email = "fake4@gmail.com",
                        PhoneNumber = "123-123-1235",
                        //assigns year, month, day, hour, min, seconds
                        //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
                        StartTime = new DateTime(2021, 3, 24, 17, 0, 0)
                    }
                    );


                context.SaveChanges();
            }
        }

        public static List<Appointment> GetDefaultListAppointmentTimes()
        {
            List<Appointment> defaultAppts = new List<Appointment>();
            int daysAppointmentsAvailable = 7;
            int hourStart = 8;
            int hourEnd = 20;
            int dayStart = 18;
            int dayEnd = 24;
            int year = 2021;
            int month = 3;
            for (int i = 0; i < daysAppointmentsAvailable; i++)
            {
                for (int z = 0; z < 12 ; z++)
                {
                    DateTime StartTime = new DateTime(
                        year, 
                        month, 
                        dayStart + i, 
                        hourStart + z, 
                        0, 
                        0
                        );

                    
                    defaultAppts.Add(new Appointment
                    {
                        StartTime = StartTime,
                        EndTime = StartTime.AddHours(1),
                        TotalSlots = 30,

                    });
                }
            }
            Console.Out.WriteLine("here bro again");
            return defaultAppts;
        }
    }
}
