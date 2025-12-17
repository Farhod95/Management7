using Manaegment7.Domain.Models;
namespace Managament7.Infrastructure.Data
{
    public class DbContext
    {
        public Student[] students { get; set; }
        public DbContext()
        {
            this.students = new Student[12];
        }
        public int studentCount { get; set; } = 0;
    }
}
