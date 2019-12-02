using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace MultiThreadingApplication
{
    class Program
    {
        public static void readDatabase()
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Student
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void updateDatabase()
        {
            
        }

        public static void addToDatabase()
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog
                Console.Write("Enter the name for a new student: ");
                var name = Console.ReadLine();

                Console.WriteLine("Enter the standard:");
                int std = Convert.ToInt32(Console.ReadLine());

                var student = new Student { Name = name, Standard = std };
                db.Student.Add(student);
                db.SaveChanges();

            }

        }
        static void Main(string[] args)
        {

            addToDatabase();
            readDatabase();
        }
    }

    public class Student 
    {
        public int StudentId { get; set; }
        public string Name { get; set; } 
        public int Standard { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
      
    }
}
