using Management7.Application.Service;
using System.Reflection.Metadata;
namespace Management7.Client
{
    internal class Program
    {
        public static StudentService newStudent = new StudentService();
        public const string password = "1111";
        static void Main(string[] args)
        {
            Console.WriteLine("\n Assalomu alaykum xurmatli o'qituvchi!");

            int passwordCounter = 1;
            while (passwordCounter <= 3)
            {
                Console.Write("\n Tizimga kirish uchun parolni kiriting:");
                if (password == Console.ReadLine())
                {
                    SalomBer();
                    return;
                }
                else
                {
                    Console.WriteLine(" Parol xato, qayta urinib ko'ring! \n");
                    Console.WriteLine($" Sizda {3 - passwordCounter} ta urinish qoldi.");
                    passwordCounter++;
                }
            }
        }

        static void SalomBer()
        {
            Console.WriteLine("\n Xush kelibsiz, Elbek!");

            bool savol = false;
            while (!savol)
            {
                savol = true;
                Console.WriteLine("\n Quyidagi menyudan birini tanlang: \n");
                Console.WriteLine(" 1) Yangi talaba qoshish");
                Console.WriteLine(" 2) Talabalar ro'yxati");
                Console.WriteLine(" 3) Qabullar soni\n");
                Console.Write(" Kerakli bo'limni raqamini kiriting: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            TalabaQoshish();
                            if (QaytaIshgaTushir()) { savol = false; }
                            break;
                        }
                    case "2":
                        {
                            newStudent.GetAllStudents();
                            if (QaytaIshgaTushir()) { savol = false; }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine($" Jami qabul qilingan talabalar soni: {newStudent.GetStudentCount()}");
                            Console.WriteLine($" Vakant o'rinlar soni: {12 - newStudent.GetStudentCount()}");
                            if (QaytaIshgaTushir()) { savol = false; }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(" Noto'g'ri raqam kiritildi!");
                            if (QaytaIshgaTushir()) { savol = false; }
                            break;
                        }
                }
            }
            
        }
        static void TalabaQoshish()
        {
            Console.Write(" Talaba ismi: ");
            string ism = Console.ReadLine();
            Console.Write(" Talaba familiyasi: ");
            string familiya = Console.ReadLine();

            newStudent.AddStudent(ism, familiya);
            Console.WriteLine("\n Talaba muvofaqiyatli qo'shildi! ");
        }

        static bool QaytaIshgaTushir()
        {
            Console.Write("\n Davom etishni xohlaysizmi? (yes/no):");
            return Console.ReadLine().ToLower() == "yes";
        }
    }
}
