using System;
using System.Collections.Generic;
using System.Linq;
using Pri.Generics.Core.Entities;
using Pri.Generics.Core.Interfaces;
using Pri.Generics.Core.Repositories;

namespace Pri.Generics.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderExample();
            NumberRepositoryExample();
            StringRepositoryExample();
            PersonRepositoryExample();

            //Constraints
            WhereTBaseClassExample();

            System.Console.ReadLine();
        }

        private static void WhereTBaseClassExample()
        {
            var teacher = new Teacher { FirstName = "Siegfried", LastName = "Derdeyn", Salary = 1234M };
            var student = new Student { FirstName = "Jane", LastName = "Doe", RegisteredOn = DateTime.Now };
            var person = new Person { FirstName = "John", LastName = "Doe" };

            var teacherRepository = new PersonRepository<Teacher>();
            teacherRepository.Add(teacher);

            var studentRepository = new PersonRepository<Student>();
            studentRepository.Add(student);

            var personRepository = new PersonRepository<Person>();
            personRepository.Add(person);

            var television = new Television { Brand = "Sony", ScreenSize = 32 };
            // this won't work:
            //var orderRepository = new PersonRepository<Television>();


        }

        private static void OrderExample()
        {
            var order1 = new Order<int>(1, 10);
            var order2 = new Order<string>("My item", 5);
            var television = new Television
            {
                Brand = "Sony",
                ScreenSize = 50
            };
            var order3 = new Order<Television>(television, 20);

            var televisionList = new List<Television>
            {
                new Television {
                    Brand = "Philips", ScreenSize = 40
                },
                new Television
                {
                    Brand = "LG", ScreenSize = 60
                }
            };
            var order4 = new Order<List<Television>>(televisionList, 4);
        }

        private static void PrintRepositoryData<T>(IRepository<T> repository)
        {
            var data = repository.GetAll();
            foreach (var dataItem in data)
            {
                System.Console.WriteLine(dataItem);
            }
            System.Console.WriteLine(Environment.NewLine);
        }

        private static void PersonRepositoryExample()
        {
            System.Console.WriteLine("Repository with persons:");
            IRepository<Person> personRepository = new Repository<Person>();

            var lectorPri = new Person { FirstName = "Dries", LastName = "Deboosere" };
            var lectorMde = new Person { FirstName = "Maxim", LastName = "Lesy" };
            var lectorWsi = new Person { FirstName = "Joachim", LastName = "François" };
            var lectorProg = new Person { FirstName = "William", LastName = "Schokkelé" };

            personRepository.Add(lectorPri);
            personRepository.Add(lectorMde);
            personRepository.Add(lectorProg);
            personRepository.Add(lectorWsi);
            personRepository.Delete(lectorProg);
            var allLectors = personRepository.GetAll();
            var lastLector = personRepository.GetAll().Last(); //Last() is Linq

            System.Console.WriteLine("Print data in personRepository:");
            PrintRepositoryData<Person>(personRepository);
        }

        private static void StringRepositoryExample()
        {
            System.Console.WriteLine("Repository with strings:");
            IRepository<string> stringRepository = new Repository<string>();

            stringRepository.Add("First");
            stringRepository.Add("Second");
            stringRepository.Add("Third");
            stringRepository.Add("Fourth");
            stringRepository.Delete("Fourth");
            var allStrings = stringRepository.GetAll();
            var secondString = stringRepository.Get(1);

            System.Console.WriteLine("Print data in stringRepository:");
            PrintRepositoryData<string>(stringRepository);
        }

        private static void NumberRepositoryExample()
        {
            System.Console.WriteLine("Repository with numbers:");
            IRepository<int> numberRepository = new Repository<int>();

            numberRepository.Add(1);
            numberRepository.Add(12);
            numberRepository.Add(23);
            numberRepository.Delete(12);
            var firstNumber = numberRepository.Get(0);
            var allNumbers = numberRepository.GetAll();


            System.Console.WriteLine("Print data in numberRepository:");
            PrintRepositoryData<int>(numberRepository);
        }
    }
}
