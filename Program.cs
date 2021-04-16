using System;
using System.Linq;
using System.Data.Entity;

namespace Dziekanacik
{
    public class Student
    {
        public int Id { set; get; }
        public string name { set; get; }
        public string surname { set; get; }

        public void ShowStudent()
        {
            Console.WriteLine($"Numer: {Id}");
            Console.WriteLine($"Imie i nazwisko: {name} {surname}");
        }
    }


    public class Dziekanat : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }

        public Student AddToBase()
        {
            var student = new Student();
            Console.WriteLine("Imie: ");
            student.name = Console.ReadLine();
            Console.WriteLine("Nazwisko: ");
            student.surname = Console.ReadLine();
            return student;
        }

        public void ClearBase()
        {
            Students.RemoveRange(Students);
            this.SaveChanges();
        }

        public void ShowBase()
        {
            var students = (from a in this.Students select a).ToList<Student>();
            foreach (var stud in students)
            {
                stud.ShowStudent();
                Console.WriteLine("");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var dziekanatDB = new Dziekanat();
            while (true)
            {
                Console.WriteLine("Wybierz opcje");
                Console.WriteLine("'1' Dodac studenta");
                Console.WriteLine("'2' Drop bazy");
                Console.WriteLine("'3' Wyswietlenie bazy");
                Console.WriteLine("'4' Wzywanie serwisy od naprawy maszyny do kawy");
                Console.WriteLine("'5' Wyjscie");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Podaj dane studenta");
                        dziekanatDB.Students.Add(dziekanatDB.AddToBase());
                        dziekanatDB.SaveChanges();
                        Console.WriteLine("Zapisane\n");
                        break;

                    case "2":
                        dziekanatDB.ClearBase();
                        Console.WriteLine("Baza dropnieta\n");
                        break;
                    
                    case "3":
                        dziekanatDB.ShowBase();
                        Console.WriteLine("\n");
                        break;

                    case "4":
                        Console.WriteLine("Proszę podaj jaki jest problem z maszyna");
                        Console.ReadLine();
                        Console.WriteLine("Serwis zostal poinformowany, prosze czekac na przyjazd mechanika\n");
                        break;

                    case "5":
                        break;                       

                    default:
                        Console.WriteLine("BLAD");
                        Console.WriteLine("\nENTER do powrotu\n");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}