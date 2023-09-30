using System.Diagnostics;
using System.Text.RegularExpressions;

namespace BossFinalProject
{
    internal static class CreateCV
    {
        public static void cv(List<Worker> workers,int current_worker)
        {
            List<string>? bacariglar = new List<string>();
            List<string>? Companies = new List<string>();
            Dictionary<string, string>? xaricidiller = new Dictionary<string, string>();
            string? ixtisas, oxudugumekteb;
            int score;
            bool diplom;

            Regex regex;
            Console.Write("Enter Ixtisas: ");
            do
            {
                ixtisas = Console.ReadLine();
                string patterin = @"^[A-Za-z ]{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(ixtisas!))
                    break;
                else
                {
                    Console.WriteLine("Invalid ixtisas.Press any button to enter again...");
                    Console.ReadKey();
                }

            } while (true);

            Console.Write("Enter Oxudugu Mekteb: ");
            do
            {
                oxudugumekteb = Console.ReadLine();
                string patterin = @"^[A-Za-z0-9 ]{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(oxudugumekteb!))
                    break;
                else
                {
                    Console.WriteLine("Invalid mekteb.Press any button to enter again...");
                    Console.ReadKey();
                }

            } while (true);

            Console.Write("Enter Score: ");
            do
            {
                try
                {
                    score = Convert.ToInt32(Console.ReadLine());
                    if (score > 0)
                        break;
                    else
                    {
                        Console.WriteLine("Invalid score.Press any button to enter again...");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Score must be a number !");
                }


            } while (true);

            Console.WriteLine();
            Console.Write("How many skills do you have: ");
            int count = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < count; i++)
            {
                Console.Write($"Skill {i+1}: ");
                string? skill = Console.ReadLine();
                Console.WriteLine();
                bacariglar!.Add(skill!);
            }

            Console.WriteLine();
            Console.Write("How many companies do you worked: ");
            int count_1 = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < count_1; i++)
            {
                Console.Write($"Company {i + 1}: ");
                string? company = Console.ReadLine();
                Console.WriteLine();
                Companies!.Add(company!);
            }

            Console.WriteLine();
            Console.Write("How many language do you know: ");
            int count_ = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < count_; i++)
            {
                Console.Write($"Language {i + 1}: ");
                string? language = Console.ReadLine();
                Console.WriteLine();
                Console.Write($"Level {i + 1}: ");
                string? level = Console.ReadLine();
                Console.WriteLine();
                xaricidiller!.Add(language!,level!);
            }

            do
            {
                Console.Write("Do you have diplom(yes/no): ");
                string? answer = Console.ReadLine();

                if (answer!.ToLower() == "yes")
                {
                    diplom = true;
                    break;
                }
                else if (answer.ToLower() == "no")
                {
                    diplom = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong choice.Press any button to continue...");
                    Console.ReadKey();
                }
            } while (true);

            CV cv = new CV(ixtisas!, oxudugumekteb!, score, bacariglar!, Companies!, xaricidiller!, diplom);
            workers[current_worker].Cv = cv;
        }
       
    }
}