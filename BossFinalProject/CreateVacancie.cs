using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BossFinalProject
{
    internal static class CreateVacancie
    {
        public static void CheckVacancie(List<Employer> employers, int current_employer)
        {
            string? content;
            int price;
            Regex regex;
            Console.Write("Enter Content: ");
            do
            {
                content = Console.ReadLine();
                string patterin = @"^[A-Za-z]{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(content!))
                    break;
                else
                {
                    Console.WriteLine("Invalid content.Press any button to enter again...");
                    Console.ReadKey();
                }

            } while (true);

            Console.Write("Enter Price: ");
            do
            {
                try
                {
                    price = Convert.ToInt32(Console.ReadLine());
                    if (price > 0)
                        break;
                    else
                    {
                        Console.WriteLine("Invalid price.Press any button to enter again...");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Price must be a number !");
                }


            } while (true);

            Vacancie vacancie = new Vacancie(content, price);
            employers[current_employer].Vacancies.Add(vacancie);
            Console.WriteLine("Vacancie succesfully created.Press any button to continue...");
            Console.ReadKey();
        }
    }
}
