using PolDentEx.DAL;
using PolDentEx.Models;

namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PolDentEx.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PolDentEx.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            IDoctorRepository doctorRepository = new DoctorRepository();
            IPatientRepository patientRepository = new PatientRepository();

            context.HumanTooths.AddOrUpdate(
               // sta³e
               new HumanTooth() { HumanToothId = 1, IsMilkTooth = false, ToothName = "UpLeftOne" },
               new HumanTooth() { HumanToothId = 2, IsMilkTooth = false, ToothName = "UpRightOne" },

               new HumanTooth() { HumanToothId = 3, IsMilkTooth = false, ToothName = "UpLeftTwo" },
               new HumanTooth() { HumanToothId = 4, IsMilkTooth = false, ToothName = "UpRightTwo" },

               new HumanTooth() { HumanToothId = 5, IsMilkTooth = false, ToothName = "UpLeftThree" },
               new HumanTooth() { HumanToothId = 6, IsMilkTooth = false, ToothName = "UpRightThree" },

               new HumanTooth() { HumanToothId = 7, IsMilkTooth = false, ToothName = "UpLeftFour" },
               new HumanTooth() { HumanToothId = 8, IsMilkTooth = false, ToothName = "UpRightFour" },

               new HumanTooth() { HumanToothId = 9, IsMilkTooth = false, ToothName = "UpLeftFive" },
               new HumanTooth() { HumanToothId = 10, IsMilkTooth = false, ToothName = "UpRightFive" },

               new HumanTooth() { HumanToothId = 11, IsMilkTooth = false, ToothName = "UpLeftSix" },
               new HumanTooth() { HumanToothId = 12, IsMilkTooth = false, ToothName = "UpRightSix" },

               new HumanTooth() { HumanToothId = 13, IsMilkTooth = false, ToothName = "UpLeftSeven" },
               new HumanTooth() { HumanToothId = 14, IsMilkTooth = false, ToothName = "UpRightSeven" },

               new HumanTooth() { HumanToothId = 15, IsMilkTooth = false, ToothName = "UpLeftEight" },
               new HumanTooth() { HumanToothId = 16, IsMilkTooth = false, ToothName = "UpRightEight" },

               new HumanTooth() { HumanToothId = 17, IsMilkTooth = false, ToothName = "DownLeftOne" },
               new HumanTooth() { HumanToothId = 18, IsMilkTooth = false, ToothName = "DownRightOne" },

               new HumanTooth() { HumanToothId = 19, IsMilkTooth = false, ToothName = "DownLeftTwo" },
               new HumanTooth() { HumanToothId = 20, IsMilkTooth = false, ToothName = "DownRightTwo" },

               new HumanTooth() { HumanToothId = 21, IsMilkTooth = false, ToothName = "DownLeftThree" },
               new HumanTooth() { HumanToothId = 22, IsMilkTooth = false, ToothName = "DownRightThree" },

               new HumanTooth() { HumanToothId = 23, IsMilkTooth = false, ToothName = "DownLeftFour" },
               new HumanTooth() { HumanToothId = 24, IsMilkTooth = false, ToothName = "DownRightFour" },

               new HumanTooth() { HumanToothId = 25, IsMilkTooth = false, ToothName = "DownLeftFive" },
               new HumanTooth() { HumanToothId = 26, IsMilkTooth = false, ToothName = "DownRightFive" },

               new HumanTooth() { HumanToothId = 27, IsMilkTooth = false, ToothName = "DownLeftSix" },
               new HumanTooth() { HumanToothId = 28, IsMilkTooth = false, ToothName = "DownRightSix" },

               new HumanTooth() { HumanToothId = 29, IsMilkTooth = false, ToothName = "DownLeftSeven" },
               new HumanTooth() { HumanToothId = 30, IsMilkTooth = false, ToothName = "DownRightSeven" },

               new HumanTooth() { HumanToothId = 31, IsMilkTooth = false, ToothName = "DownLeftEight" },
               new HumanTooth() { HumanToothId = 32, IsMilkTooth = false, ToothName = "DownRightEight" },

               // mleczne
               new HumanTooth() { HumanToothId = 33, IsMilkTooth = true, ToothName = "UpLeftOne" },
               new HumanTooth() { HumanToothId = 34, IsMilkTooth = true, ToothName = "UpRightOne" },

               new HumanTooth() { HumanToothId = 35, IsMilkTooth = true, ToothName = "UpLeftTwo" },
               new HumanTooth() { HumanToothId = 36, IsMilkTooth = true, ToothName = "UpRightTwo" },

               new HumanTooth() { HumanToothId = 37, IsMilkTooth = true, ToothName = "UpLeftThree" },
               new HumanTooth() { HumanToothId = 38, IsMilkTooth = true, ToothName = "UpRightThree" },

               new HumanTooth() { HumanToothId = 39, IsMilkTooth = true, ToothName = "UpLeftFour" },
               new HumanTooth() { HumanToothId = 40, IsMilkTooth = true, ToothName = "UpRightFour" },

               new HumanTooth() { HumanToothId = 41, IsMilkTooth = true, ToothName = "UpLeftFive" },
               new HumanTooth() { HumanToothId = 42, IsMilkTooth = true, ToothName = "UpRightFive" },

               new HumanTooth() { HumanToothId = 43, IsMilkTooth = true, ToothName = "DownLeftOne" },
               new HumanTooth() { HumanToothId = 44, IsMilkTooth = true, ToothName = "DownRightOne" },

               new HumanTooth() { HumanToothId = 45, IsMilkTooth = true, ToothName = "DownLeftTwo" },
               new HumanTooth() { HumanToothId = 46, IsMilkTooth = true, ToothName = "DownRightTwo" },

               new HumanTooth() { HumanToothId = 47, IsMilkTooth = true, ToothName = "DownLeftThree" },
               new HumanTooth() { HumanToothId = 48, IsMilkTooth = true, ToothName = "DownRightThree" },

               new HumanTooth() { HumanToothId = 49, IsMilkTooth = true, ToothName = "DownLeftFour" },
               new HumanTooth() { HumanToothId = 50, IsMilkTooth = true, ToothName = "DownRightFour" },

               new HumanTooth() { HumanToothId = 51, IsMilkTooth = true, ToothName = "DownLeftFive" },
               new HumanTooth() { HumanToothId = 52, IsMilkTooth = true, ToothName = "DownRightFive" }

           );

            context.Treatments.AddOrUpdate(
                new Treatment() { Name = "Borowanie", Nfzid = 1, TreatmentId = 1 },
                new Treatment() { Name = "Leczenie kana³owe", Nfzid = 2, TreatmentId = 2 },
                new Treatment() { Name = "Lakowanie", Nfzid = 3, TreatmentId = 3 },
                new Treatment() { Name = "Usuwanie zêba", Nfzid = 4, TreatmentId = 4 }
                );

            context.PatientCards.AddOrUpdate(
                new PatientCard() { PatientCardId = 1, Jaw = context.Teeth.Where(t => t.PatientCardId == 1).ToList(), AllergiesFile = "Ibuprofen", DiseaseFile = "Têtnica", HistoryFile = "", RtgFile = "", TakenMedicinesFile = "Claririne" },
                new PatientCard() { PatientCardId = 2, Jaw = context.Teeth.Where(t => t.PatientCardId == 2).ToList(), AllergiesFile = "Orzechy", DiseaseFile = "Narkolepsja", HistoryFile = "", RtgFile = "", TakenMedicinesFile = "Testosterone" },
                new PatientCard() { PatientCardId = 3, Jaw = context.Teeth.Where(t => t.PatientCardId == 3).ToList(), AllergiesFile = "Trawa", DiseaseFile = "Rak", HistoryFile = "", RtgFile = "", TakenMedicinesFile = "Trenbolone" },
                new PatientCard() { PatientCardId = 4, Jaw = context.Teeth.Where(t => t.PatientCardId == 4).ToList(), AllergiesFile = "Winogrona", DiseaseFile = "HIV, Homoseksualizm", HistoryFile = "", RtgFile = "", TakenMedicinesFile = "Allertec" },
                new PatientCard() { PatientCardId = 5, Jaw = context.Teeth.Where(t => t.PatientCardId == 5).ToList(), AllergiesFile = "Cytrusy", DiseaseFile = "Osteoporoza", HistoryFile = "", RtgFile = "", TakenMedicinesFile = "Ketonal" }
                );


            context.Teeth.AddOrUpdate(
                tt => tt.ToothId,
                //Set zêbów tworzony dla ka¿dego cz³owieka przy zak³adaniu karty
                //Patient 1
                //sta³e   
                new Tooth()
                {
                    ToothId = 1,
                    HumanToothId = 1,
                    PatientCardId = 1,
                    Note1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In eu ipsum est. Quisque ac sem id nibh finibus dictum. Fusce vehicula metus mauris. Aliquam in lectus lorem. Nulla facilisi. Vivamus.",
                    Note2 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In eu ipsum est. Quisque ac sem id nibh finibus dictum. Fusce vehicula metus mauris. Aliquam in lectus lorem. Nulla facilisi. Vivamus.",
                    Note3 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In eu ipsum est. Quisque ac sem id nibh finibus dictum. Fusce vehicula metus mauris. Aliquam in lectus lorem. Nulla facilisi. Vivamus.",
                    Note4 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In eu ipsum est. Quisque ac sem id nibh finibus dictum. Fusce vehicula metus mauris. Aliquam in lectus lorem. Nulla facilisi. Vivamus.",
                    Extracted = false
                },
                new Tooth() { ToothId = 2, HumanToothId = 2, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "Borowanie(do zrobienia)", Extracted = false },
                new Tooth() { ToothId = 3, HumanToothId = 3, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "Leczenie kana³owe (zrobione)", Extracted = false },
                new Tooth() { ToothId = 4, HumanToothId = 4, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "Implant(do zrobienia)", Extracted = false },
                new Tooth() { ToothId = 5, HumanToothId = 5, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "wyrwany(do zrobienia)", Extracted = false },
                new Tooth() { ToothId = 6, HumanToothId = 6, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 7, HumanToothId = 7, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 8, HumanToothId = 8, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 9, HumanToothId = 9, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 10, HumanToothId = 10, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 11, HumanToothId = 11, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 12, HumanToothId = 12, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 13, HumanToothId = 13, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 14, HumanToothId = 14, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 15, HumanToothId = 15, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 16, HumanToothId = 16, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 17, HumanToothId = 17, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 18, HumanToothId = 18, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 19, HumanToothId = 19, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 20, HumanToothId = 20, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 21, HumanToothId = 21, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 22, HumanToothId = 22, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 23, HumanToothId = 23, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 24, HumanToothId = 24, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 25, HumanToothId = 25, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 26, HumanToothId = 26, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 27, HumanToothId = 27, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 28, HumanToothId = 28, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 29, HumanToothId = 29, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 30, HumanToothId = 30, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 31, HumanToothId = 31, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                new Tooth() { ToothId = 32, HumanToothId = 32, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = false },
                //mleczne
                new Tooth() { ToothId = 33, HumanToothId = 33, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 34, HumanToothId = 34, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 35, HumanToothId = 35, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 36, HumanToothId = 36, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 37, HumanToothId = 37, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 38, HumanToothId = 38, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 39, HumanToothId = 39, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 40, HumanToothId = 40, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 41, HumanToothId = 41, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 42, HumanToothId = 42, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 43, HumanToothId = 43, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 44, HumanToothId = 44, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 45, HumanToothId = 45, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 46, HumanToothId = 46, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 47, HumanToothId = 47, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 48, HumanToothId = 48, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 49, HumanToothId = 49, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 50, HumanToothId = 50, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 51, HumanToothId = 51, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true },
                new Tooth() { ToothId = 52, HumanToothId = 52, PatientCardId = 1, Note1 = "Notka1", Note2 = "", Note3 = "", Note4 = "", Extracted = true });


            context.Doctors.AddOrUpdate(
                d => d.DoctorId,
                new Doctor() { DoctorId = 1, FirstName = "Anatol", LastName = "Zukerberg" },
                new Doctor() { DoctorId = 2, FirstName = "Karol", LastName = "Kowal" },
                new Doctor() { DoctorId = 3, FirstName = "Marek", LastName = "Sosna" },
                new Doctor() { DoctorId = 4, FirstName = "Micha³", LastName = "Grom" },
                new Doctor() { DoctorId = 5, FirstName = "Pawe³", LastName = "Kaczmarski"}
                );
            context.SaveChanges();
            
            context.Patients.AddOrUpdate(
                new Patient() { Date = new DateTime(1996,05,05),
                    PatientId = 1,
                    DoctorId = 1,
                    PatientCardId = 1,
                    PatientDetailsId = 1,
                    PatientDetails = new PatientDetails() {PatientDetailsId = 1, FirstName = "Janina", LastName = "Kowalska", PhoneNumber = "123123123"},
                    Doctor = doctorRepository.GetDoctorById(1),
                    PESEL = "83010425607"
                },
                new Patient()
                {
                    Date = new DateTime(1996, 05, 05),
                    PatientId = 2,
                    DoctorId = 2,
                    PatientCardId = 2,
                    PatientDetailsId = 2,
                    PatientDetails = new PatientDetails() { PatientDetailsId = 2, FirstName = "Marlena", LastName = "Œwierpiel", PhoneNumber = "333222111" },
                    Doctor = doctorRepository.GetDoctorById(2),
                    PESEL = "66010444902"
                },
                new Patient()
                {
                    Date = new DateTime(1996, 05, 05),
                    PatientId = 3,
                    DoctorId = 3,
                    PatientDetailsId = 3,
                    PatientDetails = new PatientDetails() { PatientDetailsId = 3, FirstName = "Halina", LastName = "D¹browska", PhoneNumber = "111444332" },
                    Doctor = doctorRepository.GetDoctorById(3),
                    PatientCardId = 3,
                    PESEL = "66010486609"
                },
                new Patient()
                {
                    Date = new DateTime(1996, 05, 05),
                    PatientId = 4,
                    DoctorId = 4,
                    PatientDetailsId = 4,
                    PatientDetails = new PatientDetails() { PatientDetailsId = 4, FirstName = "£ukasz", LastName = "Kot", PhoneNumber = "111111222" },
                    Doctor = doctorRepository.GetDoctorById(4),
                    PatientCardId = 4,
                    PESEL = "96010493514"
                },
                new Patient()
                {
                    Date = new DateTime(1996,05,05),
                    PatientId = 5,
                    DoctorId = 5,
                    PatientDetailsId = 5,
                    PatientDetails = new PatientDetails() { PatientDetailsId = 5, FirstName = "Jan", LastName = "Nowak", PhoneNumber = "323332333" },
                    Doctor = doctorRepository.GetDoctorById(5),
                    PatientCardId = 5,
                    PESEL = "83092267818"
                }
                );

            context.Appointments.AddOrUpdate(
                a => a.AppointmentId,
                new Appointment()
                {
                    AppointmentId = 2, Date = new DateTime(2018, 01, 01), Doctor = doctorRepository.GetDoctorById(1), DoctorId = 1, PatientId = 1, Patient = patientRepository.GetPatientById(1), Type = AppointmentType.Konserwacja
                });

            context.SaveChanges();

        }
    }
    
}
