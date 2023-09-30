using System.Text.Json;
using System.Text.RegularExpressions;


namespace BossFinalProject
{
    internal static class CheckData
    {
        public static void sign_up(List<Worker> workers)
        {
            string? name, surname, username, email, password, city, phone;
            int age;
            bool isCheck = true;
            bool Check = true;
            Regex regex;
            Console.Write("Enter name: ");
            do
            {
                name = Console.ReadLine();
                string patterin = @"^[A-Za-z]{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(name!))
                    break;
                else
                {
                    Console.WriteLine("Invalid name.Enter again...");
                }

            } while (true);
            Console.Write("Enter surname: ");
            do
            {
                surname = Console.ReadLine();
                string patterin = @"^[A-Za-z]{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(surname!))
                    break;
                else
                {
                    Console.WriteLine("Invalid surname.Enter again...");
                }

            } while (true);

            Console.Write("Enter age: ");
            do
            {
                try 
                {
                    age = Convert.ToInt32(Console.ReadLine());
                    if (age >= 18)
                        break;
                    else
                    {
                        Console.WriteLine("Invalid age.Enter again...");
                    }
                } 
                catch 
                {
                    Console.WriteLine("Age must be a number !");
                }


            } while (true);

            Console.Write("Enter username: ");
            do
            {
                username = Console.ReadLine();
                string patterin = @"^\w{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(username!))
                    break;
                else
                {
                    Console.WriteLine("Invalid username.Enter again...");
                }

            } while (true);

            Console.Write("Enter email: ");
            do
            {
                email = Console.ReadLine();
                string patterin = @"^\w+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(email!))
                    break;
                else
                {
                    Console.WriteLine("Invalid email.Enter again...");
                }

            } while (true);

            Console.Write("Enter password: ");
            do
            {
                password = Console.ReadLine();
                string patterin = @"^\w{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(password!))
                    break;
                else
                {
                    Console.WriteLine("Invalid password.Enter again...");
                }

            } while (true);

            Console.Write("Enter city: ");
            do
            {
                city = Console.ReadLine();
                string patterin = @"^[A-Za-z]{3,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(city!))
                    break;
                else
                {
                    Console.WriteLine("Invalid city.Enter again...");
                }

            } while (true);

            Console.Write("Enter Phone: ");
            do
            {
                phone = Console.ReadLine();
                string patterin = @"(^055|099|070|050|051|060|010)\d{7}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(phone!))
                    break;
                else
                {
                    Console.WriteLine("Invalid phone.Enter again...");
                }

            } while (true);
  
            foreach(var item in workers)
            {
                if(item.Username == username || item.Email == email)
                {
                    Console.WriteLine("This username or email already exists.Press any button to continue...");
                    Console.ReadKey();
                    isCheck = false;
                    break;
                }
            }
            if (isCheck)
            {
                Console.WriteLine("Worker successfully created.Press any button to continue...");
                Console.ReadKey();
                Worker worker = new Worker(name!, surname!, age, username!, email!, password!, city!, phone!);
                workers.Add(worker);
            }
        }

        public static bool Sign_in(List<Worker> workers,ref int current_worker)
        {
            string? username, password;
            Regex regex;

            Console.Write("Enter username: ");
            do
            {
                username = Console.ReadLine();
                string patterin = @"^\w{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(username!))
                    break;
                else
                {
                    Console.WriteLine("Invalid username.Enter again...");
                }

            } while (true);

            Console.Write("Enter password: ");
            do
            {
                password = Console.ReadLine();
                string patterin = @"^\w{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(password!))
                    break;
                else
                {
                    Console.WriteLine("Invalid password.Enter again...");
                    
                }

            } while (true);

            for(int i = 0; i < workers.Count;i++)
            {
                if (workers[i].Username == username && workers[i].Password == password)
                {
                    current_worker = i;
                    return true;
                }
            }
            Console.WriteLine("InValid Username or Password.Press any button to continue...");
            Console.ReadKey();
            return false;
        }

        public static void sign_up_employer(List<Employer> employers)
        {
            string? name, surname, employername, email, password, city, phone;
            int age;
            bool isCheck = true;
            bool Check = true;
            Regex regex;
            Console.Write("Enter name: ");
            do
            {
                name = Console.ReadLine();
                string patterin = @"^[A-Za-z]{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(name!))
                    break;
                else
                {
                    Console.WriteLine("Invalid name.Enter again...");
                }

            } while (true);
            Console.Write("Enter surname: ");
            do
            {
                surname = Console.ReadLine();
                string patterin = @"^[A-Za-z]{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(surname!))
                    break;
                else
                {
                    Console.WriteLine("Invalid surname.Enter again...");
                }

            } while (true);

            Console.Write("Enter age: ");
            do
            {
                try
                {
                    age = Convert.ToInt32(Console.ReadLine());
                    if (age >= 18)
                        break;
                    else
                    {
                        Console.WriteLine("Invalid age.Age must be more than 18.Enter again...");
                    }
                }
                catch
                {
                    Console.WriteLine("Age must be a number !");
                }


            } while (true);

            Console.Write("Enter employername: ");
            do
            {
                employername = Console.ReadLine();
                string patterin = @"^\w{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(employername!))
                    break;
                else
                {
                    Console.WriteLine("Invalid employername.Enter again...");
                }

            } while (true);

            Console.Write("Enter email: ");
            do
            {
                email = Console.ReadLine();
                string patterin = @"^\w+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(email!))
                    break;
                else
                {
                    Console.WriteLine("Invalid email.Enter again...");
                }

            } while (true);

            Console.Write("Enter password: ");
            do
            {
                password = Console.ReadLine();
                string patterin = @"^\w{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(password!))
                    break;
                else
                {
                    Console.WriteLine("Invalid password.Enter again...");
                }

            } while (true);

            Console.Write("Enter city: ");
            do
            {
                city = Console.ReadLine();
                string patterin = @"^[A-Za-z]{3,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(city!))
                    break;
                else
                {
                    Console.WriteLine("Invalid city.Enter again...");
                }

            } while (true);

            Console.Write("Enter Phone: ");
            do
            {
                phone = Console.ReadLine();
                string patterin = @"(^055|099|070|050|051|060|010)\d{7}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(phone!))
                    break;
                else
                {
                    Console.WriteLine("Invalid phone.Enter again...");
                }

            } while (true);

            foreach (var item in employers)
            {
                if (item.Username == employername || item.Email == email)
                {
                    Console.WriteLine("This username or email already exists.Press any button to continue...");
                    Console.ReadKey();
                    isCheck = false;
                    break;
                }
            }
            if (isCheck)
            {
                Console.WriteLine("Employer successfully.Press any button to continue...");
                Console.ReadKey();
                Employer employer = new Employer(name!, surname!, age, employername!, email!, password!, city!, phone!);
                employers.Add(employer);
            }
        }
        public static bool Sign_in_employer(List<Employer> employers, ref int current_employer)
        {
            string? employername, password;
            Regex regex;

            Console.Write("Enter employername: ");
            do
            {
                employername = Console.ReadLine();
                string patterin = @"^\w{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(employername!))
                    break;
                else
                {
                    Console.WriteLine("Invalid employername.Enter again...");
                }

            } while (true);

            Console.Write("Enter password: ");
            do
            {
                password = Console.ReadLine();
                string patterin = @"^\w{4,}$";
                regex = new Regex(patterin);

                if (regex.IsMatch(password!))
                    break;
                else
                {
                    Console.WriteLine("Invalid password.Enter again...");
                }

            } while (true);

            for (int i = 0; i < employers.Count; i++)
            {
                if (employers[i].Username == employername && employers[i].Password == password)
                {
                    current_employer = i;
                    return true;
                }
            }
            Console.WriteLine("InValid Employername or Password.Press any button to continue...");
            Console.ReadKey();
            return false;
        }
    }
}
