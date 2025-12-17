using Manaegment7.Domain.Models;
using Managament7.Infrastructure.Data;
namespace Management7.Application.Service
{
    public class StudentService
    {
        public DbContext DbContext { get; set; }

        public StudentService()
        {
            this.DbContext = new DbContext();
        }

        public void AddStudent(string firstName, string lastName)
        {
            var newStudent = new Student
            {
                Id = new Random().Next(1000, 9999).ToString(),
                FirstName = firstName,
                LastName = lastName
            };

            if(this.DbContext.studentCount >= this.DbContext.students.Length)
            {
                Console.WriteLine(" Talabalar soni maksimal darajaga yetdi, yangi talaba qoshib bolmaydi.");
                return;
            }
            this.DbContext.students[this.DbContext.studentCount] = newStudent;
            this.DbContext.studentCount++;
        }

        public void GetAllStudents()
        {
            for (int i=0; i<this.DbContext.studentCount; i++)
            {
                var s = this.DbContext.students[i];
                Console.WriteLine($"  {s.Id}:  {s.FirstName} {s.LastName}");
            }
        }
        public int GetStudentCount()
        {
            return this.DbContext.studentCount;
        }
    }
}