using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFinalProject
{
    public class Worker
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public CV Cv { get; set; }
        public List<Notification> Notifications { get; set; } = new List<Notification>();
        public string Ixtisas;
        public string OxuduguMekteb;
        public int UniQebulBali;
        public List<string>? Bacariqlar = new List<string>();
        public List<string> Companies = new List<string>();
        public Dictionary<string, string> BildiyiXariciDiller = new Dictionary<string, string>();
        public bool Diplom;
        public Worker(string name, string surname, int age, string username, string email, string password, string city, string phone)
        {

        Id = "1";
            Name = name;
            Surname = surname;
            Age = age;
            Username = username;
            Email = email;
            Password = password;
            City = city;
            Phone = phone;
            Notifications = new List<Notification>();
            Cv = new CV(Ixtisas, OxuduguMekteb, UniQebulBali, Bacariqlar, Companies, BildiyiXariciDiller, Diplom);

        }
    }

    public class CV
    {
        public string Ixtisas { get; set; }
        public string OxuduguMekteb { get; set; }
        public double UniQebulBali { get; set; }
        public List<string>? Bacariqlar { get; set; } = new List<string>();
        public List<string> Companies { get; set; } = new List<string>();
        public Dictionary<string, string> BildiyiXariciDiller { get; set; } = new Dictionary<string, string>();
        public bool Diplom { get; set; }

        public CV(string ixtisas,string oxudugumekteb,int uniqebulbali,List<string> bacariqlar,List<string> companies,
            Dictionary<string,string> xaricidil,bool diplom)
        {
            Ixtisas = ixtisas;
            OxuduguMekteb = oxudugumekteb;
            UniQebulBali = uniqebulbali;
            Bacariqlar = bacariqlar;
            Companies = companies;
            BildiyiXariciDiller = xaricidil;
            Diplom = diplom;
        }
        
        public string Print()
        {
            Console.WriteLine("Ixtisas: " + Ixtisas);
            Console.WriteLine("Oxudugu Mekteb: " + OxuduguMekteb);
            Console.WriteLine("Universitet qebul bali: " + UniQebulBali);
            Console.WriteLine("Bacariqlar:");
            foreach (var bacariq in Bacariqlar!)
            {
                Console.WriteLine("- " + bacariq);
            }
            Console.WriteLine("Companies:");
            foreach (var company in Companies)
            {
                Console.WriteLine("- " + company);
            }
            Console.WriteLine("Bildiyi Xarici Diller:");
            foreach (var dil in BildiyiXariciDiller)
            {
                Console.WriteLine("- " + dil.Key + ": " + dil.Value);
            }
            Console.WriteLine("Ferqlenme Diplomu: " + Diplom);
            return " ";
        }
    }

    public class Employer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public List<Vacancie> Vacancies { get; set; } = new List<Vacancie>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public Employer(string name, string surname, int age, string username, string email, string password, string city, string phone) 
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Age = age;
            Username = username;
            Email = email;
            Password = password;
            City = city;
            Phone = phone;
            Vacancies = new List<Vacancie>();
            Notifications = new List<Notification>();
        }
    }

    public class Vacancie
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public DateTime CreationDateTime { get; set; }

        public Vacancie(string content, int price)
        {
            Id = Guid.NewGuid();
            CreationDateTime = DateTime.Now;
            Content = content;
            Price = price;

        }

        public string Print()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Content: " + Content);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Creation DateTime: " + CreationDateTime);
            Console.WriteLine();
            Console.WriteLine();
            return " ";
        }
    }


    public class Notification
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime date_time { get; set; }
        public Worker FromWorker { get; set; }

        public Notification(string text, Worker from)
        {
            Id = Guid.NewGuid();
            Text = text;
            date_time = DateTime.Now;
            FromWorker = from;
        }

        public void Print()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Text:" + Text);
            Console.WriteLine("Data: " + date_time);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
