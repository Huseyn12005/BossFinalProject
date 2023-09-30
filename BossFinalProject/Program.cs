using System.Text.Json;
using BossFinalProject;

List<Worker>? workers = new List<Worker>();
string filePath = "../../../workers.json";
if (File.Exists(filePath))
{
    string jsonData = File.ReadAllText(filePath);
    workers = JsonSerializer.Deserialize<List<Worker>>(jsonData);
}

List<Employer>? employers = new List<Employer>();
string filePath_ = "../../../employers.json";
if (File.Exists(filePath_))
{
    string jsonData = File.ReadAllText(filePath_);
    employers = JsonSerializer.Deserialize<List<Employer>>(jsonData);
}

string[] start_menu = { "Worker", "Employer", "Exit" };
int choice_start_menu = 0;
string[] worker_menu = { "Log in", "Sign up", "Exit" };
int choice_worker_menu = 0;

string[] employer_menu = { "Log in", "Sign up", "Exit" };
int choice_employer_menu = 0;

string[] employer_menu_menu = { "Your Vacancies", "Create Vacancie","Delete Vacation", "Notification", "Exit" };
int choice_employer_menu_menu = 0;

string[] worker_menu_menu = { "Vacancies", "CV", "Create or change CV","Notification", "Exit" };
int choice_worker_menu_menu = 0;

bool Exit = false;
int current_worker = 0;
int current_employer = 0;
do
{
    bool Exit_1 = true;
    bool Exit_2 = true;
    Console.Clear();
    Intro.boss_theme();

    Console.WriteLine();
    for (int i = 0; i < start_menu.Length; i++)
    {
        if (choice_start_menu == i)
        {
            Console.Write("                                                        ");
            Console.Write("-> ");
        }
        else
        {
            Console.Write("                                                        ");
            Console.Write("   ");
        }

        Console.WriteLine(start_menu[i]); ;
    }

    ConsoleKeyInfo choice = Console.ReadKey();

    switch (choice.Key)
    {
        case ConsoleKey.UpArrow:
            if (choice_start_menu == 0)
                choice_start_menu = 2;
            else
                --choice_start_menu;
            break;

        case ConsoleKey.DownArrow:
            if (choice_start_menu == 2)
                choice_start_menu = 0;
            else
                ++choice_start_menu;
            break;

        case ConsoleKey.Enter:
            if (choice_start_menu == 0)
            {
                do
                {
                    Console.Clear();
                    Intro.boss_theme();
                    bool Exit_4 = true;
                    Console.WriteLine();
                    for (int i = 0; i < worker_menu.Length; i++)
                    {
                        if (choice_worker_menu == i)
                        {
                            Console.Write("                                                        ");
                            Console.Write("-> ");
                        }
                        else
                        {
                            Console.Write("                                                        ");
                            Console.Write("   ");
                        }

                        Console.WriteLine(worker_menu[i]); ;
                    }

                    ConsoleKeyInfo choice_1 = Console.ReadKey();

                    switch (choice_1.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (choice_worker_menu == 0)
                                choice_worker_menu = 2;
                            else
                                --choice_worker_menu;
                            break;

                        case ConsoleKey.DownArrow:
                            if (choice_worker_menu == 2)
                                choice_worker_menu = 0;
                            else
                                ++choice_worker_menu;
                            break;

                        case ConsoleKey.Enter:
                            if (choice_worker_menu == 0)
                            { 
                                Console.Clear() ;
                                if (CheckData.Sign_in(workers!, ref current_worker))
                                {
                                    do
                                    {
                                        Console.Clear();
                                        Intro.boss_theme();
                                        Console.WriteLine();
                                        for (int i = 0; i < worker_menu_menu.Length; i++)
                                        {
                                            if (choice_worker_menu_menu == i)
                                            {
                                                Console.Write("                                                        ");
                                                Console.Write("-> ");
                                            }
                                            else
                                            {
                                                Console.Write("                                                        ");
                                                Console.Write("   ");
                                            }

                                            Console.WriteLine(worker_menu_menu[i]); ;
                                        }

                                        ConsoleKeyInfo choice_4 = Console.ReadKey();

                                        switch (choice_4.Key)
                                        {
                                            case ConsoleKey.UpArrow:
                                                if (choice_worker_menu_menu == 0)
                                                    choice_worker_menu_menu = 4;
                                                else
                                                    --choice_worker_menu_menu;
                                                break;

                                            case ConsoleKey.DownArrow:
                                                if (choice_worker_menu_menu == 4)
                                                    choice_worker_menu_menu = 0;
                                                else
                                                    ++choice_worker_menu_menu;
                                                break;

                                            case ConsoleKey.Enter:
                                                if(choice_worker_menu_menu == 0)
                                                {
                                                    Console.Clear() ;
                                                    for (int i = 0;i<employers.Count;i++)
                                                    {
                                                        Console.WriteLine("---------------------------------------------------");
                                                        Console.WriteLine("Employer: "+employers[i].Username);
                                                        Console.WriteLine();
                                                        Console.WriteLine();
                                                        for (int j = 0; j < employers[i].Vacancies.Count;j++)
                                                        {
                                                            Console.WriteLine(employers[i].Vacancies[j].Print());
                                                        }
                                                   
                                                    }
                                                    Console.Write("Enter ID of Vacancie: ");
                                                    string? id = Console.ReadLine();
                                                    Console.WriteLine();
                                                    bool check = true;
                                                    foreach (var item in employers)
                                                    {
                                                        foreach(var item2 in item.Vacancies)
                                                        {
                                                            if(Convert.ToString(item2.Id) == id)
                                                            {
                                                                Notification notification = new Notification($"{workers[current_worker].Username} sent you his CV for {item2.Content} Vacancie\nWorker ID: {workers[current_worker].Id}", workers[current_worker]);
                                                                item.Notifications.Add(notification);
                                                                JsonSerializerOptions options = new JsonSerializerOptions();
                                                                options.WriteIndented = true;
                                                                string JsonWorker = JsonSerializer.Serialize(employers, options);
                                                                File.WriteAllText($"../../../employers.json", JsonWorker);
                                                                Console.WriteLine("We sent your CV to employer.Press any button to continue...");
                                                                Console.ReadKey();
                                                                check = true;
                                                                break;
                                                            }
                                                            check = false;
                                                        }
                                                        if (check)
                                                            break;
                                                    }
                                                    if(check == false)
                                                    {
                                                        Console.WriteLine("There is not Vacancie for this ID.Press any button to continue...");
                                                        Console.ReadKey();
                                                    }
                                                }
                                                else if(choice_worker_menu_menu == 1)
                                                {
                                                    Console.Clear();
                                                    if(workers[current_worker].Cv != null)
                                                    {
                                                        workers[current_worker].Cv.Print();
                                                    }
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any button to continue...");
                                                    Console.ReadKey();  
                                                }
                                                else if (choice_worker_menu_menu == 2)
                                                {
                                                    Console.Clear();
                                                    CreateCV.cv(workers!, current_worker);

                                                    JsonSerializerOptions options = new JsonSerializerOptions();
                                                    options.WriteIndented = true;
                                                    string JsonWorker = JsonSerializer.Serialize(workers, options);
                                                    File.WriteAllText($"../../../workers.json", JsonWorker);
                                                }
                                                else if (choice_worker_menu_menu == 3)
                                                {
                                                    foreach(var item in workers[current_worker].Notifications)
                                                    {
                                                        item.Print();
                                                    }
                                                }
                                                else if(choice_worker_menu_menu == 4)
                                                {
                                                    Exit_4 = false;
                                                }

                                                break;



                                        }
                                    } while (Exit_4);
                                }
                                else continue;
                            }
                            else if (choice_worker_menu == 1)
                            {
                                Console.Clear();
                                CheckData.sign_up(workers!);
                                JsonSerializerOptions options = new JsonSerializerOptions();
                                options.WriteIndented = true;
                                string JsonWorker = JsonSerializer.Serialize(workers, options);
                                File.WriteAllText("../../../workers.json", JsonWorker);
                            }
                            else if (choice_worker_menu == 2)
                                Exit_1 = false;
                            break;
                    }
                } while (Exit_1);
            }
            else if (choice_start_menu == 1)
            {
                do
                {
                    Console.Clear();
                    Intro.boss_theme();
                    bool Exit_3 = true;
                    Console.WriteLine();
                    for (int i = 0; i < employer_menu.Length; i++)
                    {
                        if (choice_employer_menu == i)
                        {
                            Console.Write("                                                        ");
                            Console.Write("-> ");
                        }
                        else
                        {
                            Console.Write("                                                        ");
                            Console.Write("   ");
                        }

                        Console.WriteLine(employer_menu[i]); ;
                    }

                    ConsoleKeyInfo choice_2 = Console.ReadKey();

                    switch (choice_2.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (choice_employer_menu == 0)
                                choice_employer_menu = 2;
                            else
                                --choice_employer_menu;
                            break;

                        case ConsoleKey.DownArrow:
                            if (choice_employer_menu == 2)
                                choice_employer_menu = 0;
                            else
                                ++choice_employer_menu;
                            break;

                        case ConsoleKey.Enter:
                            if (choice_employer_menu == 0)
                            {
                                Console.Clear();
                                if (CheckData.Sign_in_employer(employers!, ref current_employer))
                                {
                                    Console.Clear();
                                    Intro.boss_theme();


                                    do
                                    {
                                        Console.Clear();
                                        Intro.boss_theme();
                                        Console.WriteLine();
                                        for (int i = 0; i < employer_menu_menu.Length; i++)
                                        {
                                            if (choice_employer_menu_menu == i)
                                            {
                                                Console.Write("                                                        ");
                                                Console.Write("-> ");
                                            }
                                            else
                                            {
                                                Console.Write("                                                        ");
                                                Console.Write("   ");
                                            }

                                            Console.WriteLine(employer_menu_menu[i]); ;
                                        }

                                        ConsoleKeyInfo choice_3 = Console.ReadKey();

                                        switch (choice_3.Key)
                                        {
                                            case ConsoleKey.UpArrow:
                                                if (choice_employer_menu_menu == 0)
                                                    choice_employer_menu_menu = 4;
                                                else
                                                    --choice_employer_menu_menu;
                                                break;

                                            case ConsoleKey.DownArrow:
                                                if (choice_employer_menu_menu == 4)
                                                    choice_employer_menu_menu = 0;
                                                else
                                                    ++choice_employer_menu_menu;
                                                break;

                                            case ConsoleKey.Enter:
                                                if(choice_employer_menu_menu == 0)
                                                {
                                                    Console.Clear();
                                                    string filePath_2 = "../../../employers.json";
                                                    if (File.Exists(filePath_2))
                                                    {
                                                        string jsonData = File.ReadAllText(filePath_);
                                                        employers = JsonSerializer.Deserialize<List<Employer>>(jsonData);
                                                    }

                                                    for (int i = 0; i < employers[current_employer].Vacancies.Count;i++)
                                                    {
                                                        employers[current_employer].Vacancies[i].Print();
                                                    }
                                                    Console.WriteLine("Press any button to continue...");
                                                    Console.ReadKey();
                                                }
                                                else if(choice_employer_menu_menu == 1)
                                                {
                                                    Console.Clear();
                                                    CreateVacancie.CheckVacancie(employers!, current_employer);

                                                    JsonSerializerOptions options = new JsonSerializerOptions();
                                                    options.WriteIndented = true;
                                                    string JsonWorker = JsonSerializer.Serialize(employers, options);
                                                    File.WriteAllText($"../../../employers.json", JsonWorker);
                                                }
                                                else if (choice_employer_menu_menu == 2)
                                                {
                                                    Console.Clear();
                                                    string filePath_2 = "../../../employers.json";
                                                    if (File.Exists(filePath_2))
                                                    {
                                                        string jsonData = File.ReadAllText(filePath_);
                                                        employers = JsonSerializer.Deserialize<List<Employer>>(jsonData);
                                                    }

                                                    for (int i = 0; i < employers[current_employer].Vacancies.Count; i++)
                                                    {
                                                        employers[current_employer].Vacancies[i].Print();
                                                    }
                                                    Console.Write("Enter ID of Vacancie that you want delete: ");
                                                    string? id = Console.ReadLine();
                                                    Console.WriteLine();
                                                    bool check = true;
                                                    foreach (var item in employers)
                                                    {
                                                        foreach (var item2 in item.Vacancies)
                                                        {
                                                            if (Convert.ToString(item2.Id) == id)
                                                            {
                                                                item.Vacancies.Remove(item2);
                                                                Console.WriteLine();
                                                                Console.WriteLine("Vacancie succesfully deleted.Press any button to continue...");
                                                                Console.ReadKey();
                                                                check = true;

                                                                JsonSerializerOptions options = new JsonSerializerOptions();
                                                                options.WriteIndented = true;
                                                                string JsonWorker = JsonSerializer.Serialize(employers, options);
                                                                File.WriteAllText($"../../../employers.json", JsonWorker);

                                                                break;
                                                            }
                                                            check = false;
                                                        }
                                                        if (check)
                                                            break;
                                                    }
                                                    if (check == false)
                                                    {
                                                        Console.WriteLine("There is not Vacancie for this ID.Press any button to continue...");
                                                        Console.ReadKey();
                                                    }
                                                }
                                                else if (choice_employer_menu_menu == 3)
                                                {
                                                    Console.Clear();
                                                    foreach(var item in employers[current_employer].Notifications)
                                                    {
                                                        Console.WriteLine(item.Id);
                                                        Console.WriteLine();
                                                        Console.WriteLine();
                                                    }

                                                    Console.Write("Enter ID of Notification  to see: ");
                                                    string? id = Console.ReadLine();
                                                    Console.WriteLine();
                                                    bool check = true;

                                                    foreach (var item in employers[current_employer].Notifications)
                                                    {
                                                        if (Convert.ToString(item.Id) == id)
                                                        {
                                                            Console.Clear();
                                                            item.Print();
                                                            item.FromWorker.Cv.Print();
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            Console.WriteLine("Do you want accept worker's request(yes/no): ");
                                                            string? answer = Console.ReadLine();
                                                            if (answer.ToLower() == "yes")
                                                            {
                                                                Console.WriteLine();
                                                                Notification notification = new Notification($"{employers[current_employer].Username} accept your request for Vacancie\nEmployer ID: {employers[current_employer].Id}", workers![0]);
                                                                item.FromWorker.Notifications.Add(notification);
                                                                JsonSerializerOptions options = new JsonSerializerOptions();
                                                                options.WriteIndented = true;
                                                                string JsonWorker = JsonSerializer.Serialize(workers, options);
                                                                File.WriteAllText($"../../../workers.json", JsonWorker);
                                                                Console.WriteLine("We sent your accept message to worker.Press any button to continue...");
                                                                Console.ReadKey();
                                                                employers[current_employer].Notifications.Remove(item);
                                                            }
                                                            else if (answer.ToLower() == "no")
                                                            {
                                                                employers[current_employer].Notifications.Remove(item);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Wrong choice.Press any button to continue...");
                                                                Console.ReadKey();
                                                            }
                                                            check = true;
                                                            break;
                                                        }
                                                        check = false;
                                                    }
                                                    if (check == false)
                                                    {
                                                        Console.WriteLine("There is not Worker for this ID.Press any button to continue...");
                                                        Console.ReadKey();
                                                    }

                                                }
                                                else if (choice_employer_menu_menu == 4)
                                                {
                                                    Exit_3 = false;
                                                }

                                                break;
                                        }
                                    } while (Exit_3);
                                }
                                else continue;
                            }
                            else if (choice_employer_menu == 1)
                            {
                                Console.Clear();
                                CheckData.sign_up_employer(employers!);
                                JsonSerializerOptions options = new JsonSerializerOptions();
                                options.WriteIndented = true;
                                string JsonEmployer = JsonSerializer.Serialize(employers, options);
                                File.WriteAllText("../../../employers.json", JsonEmployer);
                            }
                            else if (choice_employer_menu == 2)
                                Exit_2 = false;
                            break;
                    }
                } while (Exit_2);
            }

            else if (choice_start_menu == 2)
                Exit = true;
                break;

        }
    if (Exit == true)
        break;


} while (true);
