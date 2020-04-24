using System;
using System.Linq;
using LO.MyAirport.EF;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace LO.MyAirport.ConsoleApp
{
    class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<MyAirportContext>();
            optionsBuilder
                    .UseSqlServer(connectionString)
                    .UseLoggerFactory(MyLoggerFactory);

            ILogger logger = MyLoggerFactory.CreateLogger<Program>();

            System.Console.WriteLine("MyAirport project bonjour!!");
            using (var db = new MyAirportContext(optionsBuilder.Options))
            {
                // Create
                Console.WriteLine("Création du vol LH1232");
                Vol v1 = new Vol
                {
                    Cie = "LH",
                    Des = "BKK",
                    Dhc = Convert.ToDateTime("14 January 2020 4:45:00 PM"),
                    Imm = "RZ62",
                    Lig = "1232",
                    Pkg = "R52",
                    Pax = 238
                };
                db.Add(v1);

                Console.WriteLine("Creation vol SQ333");
                Vol v2 = new Vol
                {
                    Cie = "SK",
                    Des = "CDG",
                    Dhc = Convert.ToDateTime("14 January 2020 6:45:00 PM"),
                    Imm = "TG43",
                    Lig = "333",
                    Pkg = "R51",
                    Pax = 423
                };
                db.Add(v2);

                Console.WriteLine("creation du bagage 012387364501");
                Bagage b1 = new Bagage
                {
                    Classe = "Y",
                    CodeIata = "012387364501",
                    DateCreation = Convert.ToDateTime("14 January 2020 5:45:00 PM"),
                    Destination = "BEG"
                };
                db.Add(b1);

                db.SaveChanges();
                Console.ReadLine();

                // Read
                Console.WriteLine("Voici la liste des vols disponibles");
                var vol = db.Vols.OrderBy(v => v.Cie);
                foreach (var v in vol)
                {
                    Console.WriteLine($"Le vol {v.Cie}{v.Lig} N° {v.VolId} a destination de {v.Des} part à {v.Dhc} heure");
                }
                Console.ReadLine();

                // Update
                Console.WriteLine($"Le bagage {b1.BagageId} est modifié pour être rattaché au vol {v1.VolId} => {v1.Cie}{v1.Lig}");
                b1.VolId = v1.VolId;
                db.SaveChanges();
                Console.ReadLine();

                // Delete vol et bagages du vol
                Console.WriteLine($"Suppression du vol {v1.VolId} => {v1.Cie}{v1.Lig}");
                db.Remove(v1);
                db.SaveChanges();
                Console.ReadLine();

            }
        }
    }
}