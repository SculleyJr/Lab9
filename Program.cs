using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var information = new List<List<string>>()
            {
            new List<string>() { "Adrian", "Carly", "Debra", "Lauren" },
            new List<string>() { "Celery", "Oreos", "Rice", "Lollipops" },
            new List<string>() { "Miami", "Salt Lake", "Denver", "Tampa" },
            new List<string>() { "Red", "Blue", "Green", "Orange" }
            };
            var names = information[0];
            var favoriteFood = information[1];
            var hometown = information[2];
            var favoriteColor = information[3];
            int indexStudent;
            string run = "y";
            
            while (run == "y")
            {
                try
                {
                    indexStudent = GetIndexStudent();
                    indexStudent = indexStudent - 1;
                    Console.WriteLine($"You selected {names[indexStudent]} ");
                    string learnMore = GetMoreInfo(names, indexStudent);
                    GiveMoreInfo(names, favoriteFood, hometown,favoriteColor, indexStudent, learnMore);
                    AddStudent(names,favoriteFood,hometown,favoriteColor);
                    Console.WriteLine("Type 'Y' to learn about another student?");
                    run = Console.ReadLine();
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine("not valid information please try again");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Your format is wack");
                }
            }
        }
        private static void GiveMoreInfo(List<string> names, List<string> favoriteFood, List<string> hometown, List<string> favoriteColor, int indexStudent, string learnMore)
        {
            
                switch (learnMore)
                {
                    case "favorite food":
                        {
                            Console.WriteLine($"{names[indexStudent]}'s favorite food is {favoriteFood[indexStudent]}");
                            break;
                        }
                    case "home town":
                        {
                            Console.WriteLine($"{names[indexStudent]}'s hometown is {hometown[indexStudent]}");
                            break;
                        }
                    case "favorite color":
                        {
                            Console.WriteLine($"{names[indexStudent]}'s favorite color is {favoriteColor[indexStudent]}");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You did not select on of the following \"favorite food\", \"home town\", or \"favorite color\" ");

                        break;

                        }
                } 
            
        }
        private static string GetMoreInfo(List<string> names, int indexStudent)
        {
            Console.WriteLine($"Would you like to know {names[indexStudent]}'s \"favorite food\", \"hometown\", or \"favorite color\"");
            string learnMore = Console.ReadLine();
            return learnMore;
        }
        private static int GetIndexStudent()
        {
            Console.WriteLine("Select an index to learn more about a student");
            int indexStudent = int.Parse(Console.ReadLine());
            return indexStudent;
        }
        private static void AddStudent(List<string> names, List<string> favoriteFood, List<string> hometown, List<string> favoriteColor)
        {
            Regex pattern = new Regex(@"\w");

            Console.WriteLine("Would you like to add a student?");
            string ans = Console.ReadLine();
            if (ans == "yes")
            {
                Console.WriteLine("What is students name?");
                string newStudentName = Console.ReadLine();
                if (pattern.Match(newStudentName).Success)
                {
                    names.Add(newStudentName);
                    names.Sort();
                    
                    
                }
                else
                {
                    Console.WriteLine("Data entry not valid please try again");
                    AddStudent(names, favoriteFood, hometown, favoriteColor);
                }

                int i = names.IndexOf(newStudentName);
                Console.WriteLine("what is students favorite food");
                string newFavoriteFood = Console.ReadLine();
                if (pattern.Match(newFavoriteFood).Success)
                {
                    favoriteFood.Insert(i, newFavoriteFood);

                }
                else
                {
                    Console.WriteLine("Data entry not valid");
                    AddStudent(names, favoriteFood, hometown, favoriteColor);

                }
                Console.WriteLine("What is students home town?"); 
                string newStudentHometown = Console.ReadLine();
                if (pattern.Match(newStudentHometown).Success)
                {
                    hometown.Insert(i, newStudentHometown);
                }
                else
                {
                    Console.WriteLine("Data entry not valid");
                    AddStudent(names, favoriteFood, hometown, favoriteColor);
                }
                Console.WriteLine("What is students favorite color?");
                string newStudentFavoriteColor = Console.ReadLine();
                if (pattern.Match(newStudentFavoriteColor).Success)
                {
                    favoriteColor.Insert(i, newStudentFavoriteColor);
                }
                else
                {
                    Console.WriteLine("Data entry not valid");
                    AddStudent(names, favoriteFood, hometown, favoriteColor);
                }



            }
            else
            {
                Environment.Exit(-1);

            }
        }
    }
}
